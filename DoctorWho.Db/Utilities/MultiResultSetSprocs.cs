using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Dynamic;
using System.Linq;
using DoctorWho.Db.Domain;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Utilities
{
    public static class MultiResultSetSprocs
    {
        public static List<ArrayList> GetMultipleResultSets(this DbContext context, List<Type> setTypes)
        {
            var connection = context.Database.GetDbConnection();
            connection.Open();

            List<ArrayList> resultSets = GetResultSets(connection, setTypes);

            connection.Close();

            return resultSets;
        }

        private static List<ArrayList> GetResultSets(DbConnection connection, List<Type> types)
        {
            List<ArrayList> resultSets = new List<ArrayList>();

            using (var command =
                CreateCommand(connection,
                    "dbo.sprocCompanionsAndEnemiesRanking",
                    CommandType.StoredProcedure))
            {
                using (var reader = command.ExecuteReader())
                {
                    var columnNames = GetColumnNames(reader);
                    for (int i = 0; i < types.Count; i++)
                    {
                        Type itemType = types[i];

                        ArrayList itemsOfTheType = new ArrayList();

                        while (reader.Read())
                        {
                            var currentItem = PopulateItem(reader, columnNames, itemType);

                            itemsOfTheType.Add(currentItem);
                        }
                        
                        resultSets.Add(itemsOfTheType);
                        
                        reader.NextResult();
                    }
                }
            }

            return resultSets;
        }
        private static DbCommand CreateCommand(DbConnection connection, string commandText, CommandType commandType)
        {
            var command = connection.CreateCommand();
            command.CommandType = commandType;
            command.CommandText = commandText;
            return command;
        }
        private static IEnumerable<string> GetColumnNames(DbDataReader reader)
        {
            return Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i));
        }
        private static object PopulateItem(DbDataReader reader, IEnumerable<string> columnNames, Type itemType)
        {
            var currentRow = Activator.CreateInstance(itemType);

            foreach (var columnName in columnNames)
            {
                SetValueInRow(reader, itemType, columnName, ref currentRow);
            }

            return currentRow;
        }
        private static void SetValueInRow(DbDataReader reader, Type itemType, string column, ref object currentRow)
        {
            itemType.GetProperty(column).SetValue(currentRow, reader[column]);
        }
        
    }
}