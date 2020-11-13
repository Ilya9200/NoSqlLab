using MongoDB.Bson;
using MongoDB.Driver;
using NoSql.Domain;
using System.Collections.Generic;
using System.Linq;

/* 
 * Есть особый класс IMongoDatabase из MongoDB.Driver. При подключении в таблице проверяется целостность структуры. 
 * Если изменить класс(добавить поле\удалить\изменить), то Monga подправит соответствующую таблицу, если сможет.
 * Поэтому не нужно как-то создавать таблицы, нужно только создать саму базу.
 * 
 * Для простоты я во все методы прокидываю вот это подключение к базе IMongoDatabase, по уму, его нужно либо тут открывать, либо как-то накапливать несколько изменений, а потом одной транзакцией их производить и т.д.
 * 
 * database.GetCollection<T>("название таблицы") - открывает таблицу и пытается смапить то что там лежит на класс T. Если не удаётся - Exception(вроде).
 * Для выбора элемента используется фильтр, если он пуст, значит ВСЕ записи
 */

namespace NoSql.Impl
{
    /// <summary>
    /// Менеджер для работы с подразделениями в БД
    /// </summary>
    /// <remark></remark>
    public static class SubdivisionManager
    {
        public static void Create(Subdivision data, IMongoDatabase database)
        {
            database.GetCollection<Subdivision>("Subdivision").InsertOne(data);
        }

        public static void Destroy(string id, IMongoDatabase database)
        {
            var filter = Builders<Subdivision>.Filter.Eq("Id", id);
            database.GetCollection<Subdivision>("Subdivision").DeleteOne(filter);
        }

        public static List<string> GetListFullNameEmployees(string id, IMongoDatabase database)
        {
            var employeesList = Read(id, database).Employees;
            var filter = Builders<Employee>.Filter.In("Id", employeesList);
            var employeeList = database.GetCollection<Employee>("Employee").Find(filter).ToList();

            var result = new List<string>();
            foreach(var i in employeeList)
            {
                result.Add(i.FirstName + " " + i.LastName + " " + i.MiddleName);
            }

            return result;
        }

        public static Subdivision Read(string id, IMongoDatabase database)
        {
            var filter = Builders<Subdivision>.Filter.Eq("Id", id);
            return database.GetCollection<Subdivision>("Subdivision").Find(filter).FirstOrDefault();
        }

        public static List<Subdivision> ReadAll(IMongoDatabase database)
        {
            var filter = new BsonDocument();
            return database.GetCollection<Subdivision>("Subdivision").Find(filter).ToList();
        }

        public static void Update(Subdivision data1, Subdivision data2, IMongoDatabase database)
        {
            database.GetCollection<Subdivision>("Subdivision").ReplaceOne(data1.ToBsonDocument(), data2);
        }
    }
}
