using System;
using System.Collections.Generic;
using MongoDB.Driver;
using NoSql.Domain;
using NoSql.Impl;

namespace NoSql
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "mongodb://localhost:27017";
            MongoClient client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase("test");
            /*GetCollectionsNames(client).GetAwaiter();

            BsonClassMap.RegisterClassMap<Employee>(cm =>
            {
                cm.AutoMap();
            });
            //Console.ReadLine();

            var collection = database.GetCollection<BsonDocument>("Employee");
            BsonDocument person1 = new BsonDocument
            {
                { "LastName","1" },
                { "FirstName","2"},
                {"MiddleName","3"}
            };
            collection.InsertOneAsync(person1).GetAwaiter().GetResult();*/


            //Пример создания подразделения
            SubdivisionManager.Create(new Subdivision() { Name = "Отдел программистов", ChiefId = "1", Employees = new List<string> { "2", "3", "4" } }, database);
            var a = SubdivisionManager.ReadAll(database);

            //Пример удаления подразделения
            SubdivisionManager.Destroy(a[0].Id, database);
            var b = SubdivisionManager.Read(a[0].Id, database);

            //Пример изменения подразделения
            var newSubdivision = new Subdivision() { Id = b.Id, Name = "Отдел разработки", Employees = b.Employees, ChiefId = b.ChiefId };
            SubdivisionManager.Update(b, newSubdivision, database);
            var c = SubdivisionManager.Read(a[0].Id, database);

            Console.ReadLine();
        }
    }
}
