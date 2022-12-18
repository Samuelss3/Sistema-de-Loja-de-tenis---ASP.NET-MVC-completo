using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoASP.Models
{
    public class ModelCadastroLogin
    {

        public string IDusuario { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(50,ErrorMessage ="Límite de 50 caracteres ultrapassado")]
        public string nome { get; set; }
        
        [Display(Name = "Sobrenome")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(50, ErrorMessage = "Límite de 50 caracteres ultrapassado")]
        public string sobrenome { get; set; }
        
        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string datanasc { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(14,ErrorMessage ="Digite o CPF corretamente")]        
        [MinLength(14,ErrorMessage ="Digite o CPF corretamente")]
        public string cpf { get; set; }

        [Display(Name = "CEP")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(9, ErrorMessage = "Digite o CEP corretamente")]
        [MinLength(9, ErrorMessage = "Digite o CEP corretamente")]
        public string cep { get; set; }

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

        [Display(Name = "E-Mail")]
        [Required(ErrorMessage = "Campo Obrigatório")]

        public string Email { get; set; }
        
        [Required(ErrorMessage = "Informe a senha")]
        [MinLength(8, ErrorMessage = "A senha deve ter no mínimo 8 caracteres")]
        [MaxLength(100, ErrorMessage = "A senha deve ter até 100 caracteres")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        
        [Display(Name = "Confirmar Senhar")]
        [DataType(DataType.Password)]
        [Compare(nameof(Senha), ErrorMessage = "A senha são diferentes")]
        public string confirmarSenha { get; set; }

        public string IDtipoUsuario { get; set; }

        [Display(Name = "Celular")]
        [Required(ErrorMessage = "Informe o telefone")]
        [MaxLength(13, ErrorMessage = "Informe o contato corretamente")]
        [MinLength(13, ErrorMessage = "Informe o contato corretamente")]
        public string telefoneCliente { get; set; }
    }
}