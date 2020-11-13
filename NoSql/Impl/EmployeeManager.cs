using MongoDB.Driver;
using NoSql.Domain;

namespace NoSql.Impl
{
    public class EmployeeManager
    {
        public void Create(Employee data, IMongoDatabase database)
        {
            database.GetCollection<Employee>("Employee").InsertOne(data);
        }

        public void Delete(string id, IMongoDatabase database)
        {
            var filter = Builders<Employee>.Filter.Eq("Id", id);
            database.GetCollection<Employee>("Employee").DeleteOne(filter);
        }
    }
}
