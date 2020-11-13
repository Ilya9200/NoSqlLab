using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NoSql.Domain
{
    /// <summary>
    /// Подразделение в организации
    /// </summary>
    public class Subdivision
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Идентификатор начальника
        /// </summary>
        public string ChiefId { get; set; }

        /// <summary>
        /// Сотрудники
        /// </summary>
        public List<string> Employees { get; set; }
    }
}
