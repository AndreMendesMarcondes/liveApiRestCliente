using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace LARC.Domain.Domain
{
    public class Cliente
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; private set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]        
        [MaxLength(20,ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]        
        [MinLength(2,ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres")]        
        public string Nome { get; set; }

        [Range(18, 999)]
        public int Idade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(11, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        [MinLength(11, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres")]
        public string CPF { get; set; }
    }
}
