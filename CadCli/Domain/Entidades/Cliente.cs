using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entidades
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        public long ClienteId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Nome { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime DataNascimento { get; set; }

        [Required]
        public Sexo Sexo { get; set; }

        [Column(TypeName = "nvarchar(9)")]
        public string Cep { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Endereco { get; set; }

        public int? Numero { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Complemento { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Bairro { get; set; }

        [Column(TypeName = "nvarchar(2)")]
        public string Estado { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Cidade { get; set; }
    }
}