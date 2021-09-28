using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lets_Share.Models
{
    public class AddItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo nome é obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo descrição é obrigatório")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Campo disponibilidade é obrigatório")]
        public bool? Available { get; set; }
    }
}
