using Dominio.Interfaces.IGenericas;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.InterfaceServicos
{
    public interface IToDoServico
    {
        Task Criar(ToDo todo); //Pedido CriarTarefa, mas vai confundir Tarefa com ToDo?
        Task Atualizar(ToDo todo);
        Task Remover(ToDo todo);
        Task<List<ToDo>> Listar();
    }
}
