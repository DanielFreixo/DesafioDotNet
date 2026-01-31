using Dominio.Interfaces.InterfaceServicos;
using Dominio.Interfaces.IToDo;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servico
{
    public class ToDoServico : IToDoServico
    {
        private readonly IToDo _IToDo;
        public ToDoServico(IToDo iToDo)
        {
            _IToDo = iToDo;
        }
        public static bool Valido(ToDo todo)
        {
            var validaTitulo = todo.ValidaPropriedadeString(todo.Titulo, "Titulo");
            var validaDescricao = todo.ValidaPropriedadeString(todo.Descricao, "Descricao");
            var validaDataVencimento = todo.ValidaPropriedadeData(todo.DataVencimento, "DataVencimento");
            var valido = validaTitulo && validaDescricao && validaDataVencimento;
            todo.Propriedade = valido ? string.Empty : todo.ErrPropriedades();
            todo.Mensagem = valido ? string.Empty : todo.ErrMensagens();
            return valido;
        }
        public async Task Criar(ToDo todo)
        {
            if (Valido(todo))
            {
                await _IToDo.Add(todo);
            }
            else
            {
                //Não preciso mais tá dentro de Propriedade/Mensagem: throw new Exception("Propriedades obrigatórias não preenchidas:" + todo.ToString());
            }
        }

        public async Task Atualizar(ToDo todo)
        {
            if (todo.ID > 0 && Valido(todo))
            {
                await _IToDo.Update(todo);
            }
        }

        public async Task Remover(ToDo todo)
        {
            if (todo.ID > 0)
            {
                await _IToDo.Delete(todo);
            }
        }

        public async Task<List<ToDo>> Listar()
        {
            return await _IToDo.List();
        }

    }
}
