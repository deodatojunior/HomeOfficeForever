using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class ImovelViewModel
    {
        [HiddenInput]
        public int id { get; set; }

        [Required(ErrorMessage = "O campo Cidade é obrigatório")]
        public string cidade { get; set; }

        [Required(ErrorMessage = "O campo Bairro é obrigatório")]
        public string bairro { get; set; }

        [Required(ErrorMessage = "O campo Quantidade de Quartos é obrigatório")]
        public string quantidade { get; set; }

        [Required(ErrorMessage = "O campo Valor é obrigatório")]
        public double valor { get; set; }
    }
}