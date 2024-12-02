using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] //ObjectID bunun bir id olduğunu uygulamaya bildirmiş oldu.
        public string CategoryId { get; set; } //Mongodb de ilişkisel veritabanı olmadığı için bide burda
                                               //identity olaylarında id'le int türünde tutulmuyor string
                                               //türünde tutuluyor. 

        public string CategoryName { get; set; }
    }
}
