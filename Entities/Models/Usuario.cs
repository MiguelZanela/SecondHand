﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Usuario
    {
        [Required]
        [Display(Name = "ID do Usuario")]
        public long UsuarioId { get; set; }

        [Required]
        [Display(Name = "Nome do Usuario")]
        public string Name { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
