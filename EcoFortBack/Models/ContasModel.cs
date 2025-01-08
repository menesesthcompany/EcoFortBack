using System.ComponentModel.DataAnnotations;

namespace CRM.Models
{
    public class ContasModel
    {
        [Key]
        public int Id { get; set; }
        public string Sexo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Empresa { get; set; }
        public DateTime DataDeCadastro { get; set; }
    }
}
