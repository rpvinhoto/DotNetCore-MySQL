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
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Data de nascimento é um campo obrigatório.")]
        [DisplayName("Data de nascimento")]
        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Sexo é um campo obrigatório.")]
        public Sexo Sexo { get; set; }

        [DisplayName("CEP")]
        [StringLength(100, ErrorMessage = "Máximo 9 caracteres.")]
        public string Cep { get; set; }

        [DisplayName("Endereço")]
        [StringLength(100, ErrorMessage = "Máximo 250 caracteres.")]
        public string Endereco { get; set; }

        [DisplayName("Número")]
        [Range(0, int.MaxValue, ErrorMessage = "Informe um número válido.")]
        public int? Numero { get; set; }

        [StringLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        public string Complemento { get; set; }

        [StringLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        public string Bairro { get; set; }

        [StringLength(100, ErrorMessage = "Máximo 2 caracteres.")]
        public string Estado { get; set; }

        [StringLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        public string Cidade { get; set; }
    }
}