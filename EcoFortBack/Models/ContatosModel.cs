using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CRM.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace CRM.Models
{
    public class ContatosModel
{
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public Cargo Cargo { get; set; } // Usa o enum Cargo
        public Sexo Sexo { get; set; }   // Usa o enum Sexo
        public DateTime DataDeCadastro { get; set; }
    }

}
