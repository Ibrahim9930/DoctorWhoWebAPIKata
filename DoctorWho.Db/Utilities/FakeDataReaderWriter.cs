using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;

namespace DoctorWho.Db.Utilities
{
    public interface IEntityReader
    {
        public T ReadFakeEntity<T>(int entityId, Func<T, int> getId) where T : class;


        public IEnumerable<T> ReadAllFakeEntities<T>() where T : class;


        public IEnumerable ReadAllFakeJoinEntities<TEntityType1, TEntityType2>();
    }

    public interface IEntityWriter
    {
        public void WriteFakeEntities<T>(object data) where T : class;

        public void WriteFakeJoinEntities<TEntityType1, TEntityType2>(object data);
    }

    public class FakeDataReaderWriter : IEntityReader, IEntityWriter
    {
        public T ReadFakeEntity<T>(int entityId, Func<T, int> getId) where T : class
        {
            string fakesFilePath = FakeDataGenerator.GetFilePathForTypeFakes<T>();
            string listJson = ReadFile(fakesFilePath);

            List<T> entities = JsonSerializer.Deserialize<List<T>>(listJson) ?? new List<T>();

            return entities.First(e => getId.Invoke(e) == entityId);
        }

        public IEnumerable<T> ReadAllFakeEntities<T>() where T : class
        {
            string fakesFilePath = FakeDataGenerator.GetFilePathForTypeFakes<T>();

            string listJson = ReadFile(fakesFilePath);
            List<T> entities = JsonSerializer.Deserialize<List<T>>(listJson);

            return entities;
        }

        public IEnumerable ReadAllFakeJoinEntities<TEntityType1, TEntityType2>()
        {
            string fakesFilePath = FakeDataGenerator.GetFilePathForJoinTypeFakes<TEntityType1, TEntityType2>();

            string listJson = ReadFile(fakesFilePath);
            List<IDictionary<string, int>> entities =
                JsonSerializer.Deserialize<List<IDictionary<string, int>>>(listJson);
            return entities;
        }

        private static string ReadFile(string fakesFilePath)
        {
            string input;
            try
            {
                input = File.ReadAllText(fakesFilePath);
            }
            catch (FileNotFoundException e)
            {
                return null;
            }

            return input;
        }

        public void WriteFakeEntities<T>(object data) where T : class
        {
            string writeFilePath = FakeDataGenerator.GetFilePathForTypeFakes<T>();

            string objectJson = JsonSerializer.Serialize(data);

            var fileStream = File.Create(writeFilePath);
            StreamWriter outputStream = new StreamWriter(fileStream);

            outputStream.Write(objectJson);

            outputStream.Close();
        }

        public void WriteFakeJoinEntities<TEntityType1, TEntityType2>(object data)
        {
            string writeFilePath = FakeDataGenerator.GetFilePathForJoinTypeFakes<TEntityType1, TEntityType2>();

            string objectJson = JsonSerializer.Serialize(data);

            var fileStream = File.Create(writeFilePath);
            StreamWriter outputStream = new StreamWriter(fileStream);

            outputStream.Write(objectJson);

            outputStream.Close();
        }
    }
}