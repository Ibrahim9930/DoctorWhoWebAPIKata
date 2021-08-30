using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using DoctorWho.Db.Domain;

namespace DoctorWho.Db.Utilities
{
    public static class FakerGenerator
    {
        private static Faker<T> CreateFaker<T>(int itemsCount) where T : class
        {
            var faker = new Faker<T>();
            int id = 1;
            if (typeof(T) == typeof(Author))
            {
                faker
                    .RuleFor("AuthorId", f => id++)
                    .RuleFor("AuthorName", f => f.Name.FullName());
            }
            else if (typeof(T) == typeof(Doctor))
            {
                faker
                    .RuleFor("DoctorId", f => id++)
                    .RuleFor("DoctorName", f => f.Name.FullName())
                    .RuleFor("DoctorNumber", f => f.PickRandom<int>(Enumerable.Range(1,20)))
                    .RuleFor("Birthdate", f => f.Date.Recent())
                    .RuleFor("FirstEpisodeDate", f => f.Date.Recent())
                    .RuleFor("LastEpisodeDate", f => f.Date.Recent());
            }
            else if (typeof(T) == typeof(Companion))
            {
                faker
                    .RuleFor("CompanionId", f => id++)
                    .RuleFor("CompanionName", f => f.Name.FullName())
                    .RuleFor("WhoPlayed", f => f.Random.Bool() == true ? 1 : 0);
            }
            else if (typeof(T) == typeof(Enemy))
            {
                faker
                    .RuleFor("EnemyId", f =>id++)
                    .RuleFor("Description", f => f.Lorem.Paragraph())
                    .RuleFor("EnemyName", f => f.Name.FullName());
            }
            else if (typeof(T) == typeof(Episode))
            {
                faker
                    .RuleFor("EpisodeId", f =>id++)
                    .RuleFor("Title", f => f.Lorem.Sentence())
                    .RuleFor("Notes", f => f.Lorem.Paragraphs())
                    .RuleFor("SeriesNumber", f => f.PickRandom<int>(Enumerable.Range(1,20)))
                    .RuleFor("EpisodeNumber", f => f.PickRandom<int>(Enumerable.Range(1,20)))
                    .RuleFor("EpisodeDate", f => f.Date.Recent())
                    .RuleFor("EpisodeType", f => f.Lorem.Sentence())
                    .RuleFor("AuthorId", f => f.PickRandom(Enumerable.Range(1, itemsCount)))
                    .RuleFor("DoctorId", f => f.PickRandom(Enumerable.Range(1, itemsCount)));
            }

            return faker;
        }

        public static List<T> GenerateFakeList<T>(int itemsCount) where T : class
        {
            Faker<T> faker = CreateFaker<T>(itemsCount);
            
            return faker.Generate(itemsCount).ToList();
        }
    }
}