using Dominio.Interfaces.IGenericas;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Enums.Enums;

namespace Dominio.Interfaces.IToDo
{
    public interface IToDo : IGenerica<ToDo>
    {
        Task<IList<ToDo>> ListaVencidos();
        Task<IList<ToDo>> ListaPorDataVencimento(DateTime dataInicial, DateTime dataFinal);
        Task<IList<ToDo>> ListaPorStatus(StatusToDoEnum status);
    }
}
