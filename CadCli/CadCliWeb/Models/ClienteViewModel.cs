using Domain.Entidades;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CadCliWeb.Models
{
    public class ClienteViewModel
    {
        [Key]
        public long ClienteId { get; set; }

        [Required(ErrorMessage = "Nome é um campo obrigatório.")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Data de nascimento é um campo obrigatório.")]
        [DisplayName("Data de nascimento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data inválida")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Sexo é um campo obrigatório.")]
        public Sexo Sexo { get; set; }

        [DisplayName("CEP")]
        [MaxLength(9, ErrorMessage = "Máximo {0} caracteres.")]
        public string Cep { get; set; }

        [DisplayName("Endereço")]
        [MaxLength(250, ErrorMessage = "Máximo {0} caracteres.")]
        public string Endereco { get; set; }

        [DisplayName("Número")]
        [Range(0, int.MaxValue, ErrorMessage = "Informe um número válido.")]
        public int? Numero { get; set; }

        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres.")]
        public string Complemento { get; set; }

        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres.")]
        public string Bairro { get; set; }

        [MaxLength(2, ErrorMessage = "Máximo {0} caracteres.")]
        public string Estado { get; set; }

        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres.")]
        public string Cidade { get; set; }
    }
}