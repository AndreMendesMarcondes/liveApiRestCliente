using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LARC.Domain.Domain
{
    public class Cliente
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; private set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string CPF { get; set; }
    }
}
