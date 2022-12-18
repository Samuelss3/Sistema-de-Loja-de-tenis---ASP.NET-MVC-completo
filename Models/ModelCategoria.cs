using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoASP.Models
{
    public class ModelCategoria
    {
        [Display(Name = "#")]
        public string IDcategoria { get; set; }

        [Display(Name = "Nome da Categoria")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(50, ErrorMessage = "Límite de 50 caracteres ultrapassado")]
        public string nm_categoria { get; set; }
    }
}