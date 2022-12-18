using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoASP.Models
{
    public class ModelTamanho
    {
        [Display(Name = "#")]
        public string IDtamanho { get; set; }

        [Display(Name = "Tamanho")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(50, ErrorMessage = "Límite de 50 caracteres ultrapassado")]
        public string sg_tamanho { get; set; }
    }
}