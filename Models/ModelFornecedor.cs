using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoASP.Models
{
    public class ModelFornecedor
    {
        public string IDfornecedor { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(50, ErrorMessage = "Límite de 50 caracteres ultrapassado")]
        public string nome { get; set; }

        [Display(Name = "Celular")]
        [Required(ErrorMessage = "Informe o telefone")]
        [MaxLength(13, ErrorMessage = "Informe o contato corretamente")]
        [MinLength(13, ErrorMessage = "Informe o contato corretamente")]
        public string telefone { get; set; }


        [Display(Name = "CNPJ")]
        [Required(ErrorMessage = "Campo Obrigatório")]
            //[MaxLength(14, ErrorMessage = "Digite o CPF corretamente")]
            //[MinLength(14, ErrorMessage = "Digite o CPF corretamente")]
        public string CNPJ { get; set; }

        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(50, ErrorMessage = "Límite de 50 caracteres ultrapassado")]
        public string nm_log { get; set; }

        [Display(Name = "Número")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(50, ErrorMessage = "Límite de 50 caracteres ultrapassado")]
        public string no_log { get; set; }

        [Display(Name = "Complemento")]
        [MaxLength(100, ErrorMessage = "Límite de 50 caracteres ultrapassado")]
        public string ds_complemento { get; set; }

        [Display(Name = "Bairro")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(50, ErrorMessage = "Límite de 50 caracteres ultrapassado")]
        public string bairro { get; set; }

        [Display(Name = "UF")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(2, ErrorMessage = "Selecione")]
        public string uf { get; set; }
    }
}