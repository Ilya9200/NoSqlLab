using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NoSql.Domain
{
    /// <summary>
    /// Организация
    /// </summary>
    public class Organization
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        string Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Идентификатор директора
        /// </summary>
        [BsonRepresentation(BsonType.ObjectId)]
        string DirectorId { get; set; }
    }
}
