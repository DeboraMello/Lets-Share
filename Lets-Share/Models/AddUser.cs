using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lets_Share.Models
{
    public class AddUser
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo nome é obrigatório")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Campo email é obrigatório")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Campo telefone é obrigatório")]
        public string Phone { get; set; }
    }
}
