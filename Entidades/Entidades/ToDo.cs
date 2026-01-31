using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Entidades
{
    [Table("Todo")]
    public class ToDo : BaseEntity
    {
        [Display(Name = "Título")]
        public string Titulo { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Display(Name = "Status")]
        public Enums.Enums.StatusToDoEnum? Estado { get; set; }
        [Display(Name = "Data de Vencimento")]
        public DateTime DataVencimento { get; set; } ///Odeio SQLite public DateTime DataVencimento { get; set; }
    }
}
