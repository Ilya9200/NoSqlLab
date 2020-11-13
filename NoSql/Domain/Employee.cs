using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NoSql.Domain
{
    /// <summary>
    /// Сотрудник
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; }
    }
}
