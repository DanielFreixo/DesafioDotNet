using Entidades.Extensoes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Entidades
{
    public class BaseEntity : Extensao
    {
        [Display(Name = "Id")]
        public int ID { get; set; }
    }
}
