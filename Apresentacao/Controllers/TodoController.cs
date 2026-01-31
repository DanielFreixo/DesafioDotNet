using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidades.Entidades;
using Dominio.Servico;
using Dominio.Interfaces.IToDo;
using Dominio.Interfaces.InterfaceServicos;
using static Entidades.Enums.Enums;

namespace Apresentacao.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly IToDo _IToDO;
        private readonly IToDoServico _IToDoServico;
        public TodoController(IToDo iToDO, IToDoServico iToDoServico)
        {
            _IToDO = iToDO;
            _IToDoServico = iToDoServico;
        }

        [HttpGet("/Listar")]
        [Produces("application/json")]
        public async Task<object> Listar()
        {
            return await _IToDoServico.Listar();
        }

        [HttpPost("/Criar")]
        [Produces("application/json")]
        public async Task<object> Criar(ToDo todo)
        {
            await _IToDoServico.Criar(todo);
            return Task.FromResult(todo);
        }

        [HttpPut("/Atualizar")]
        [Produces("application/json")]
        public async Task<object> Atualizar(ToDo todo)
        {
            await _IToDoServico.Atualizar(todo);
            return Task.FromResult(todo);
        }

        [HttpDelete("/Remover")]
        [Produces("application/json")]
        public async Task<object> Remover(ToDo todo)
        {
            await _IToDoServico.Remover(todo);
            return Task.FromResult(todo);
        }

        [HttpGet("/GetVencidos")]
        [Produces("application/json")]
        public async Task<object> GetVencidos()
        {
            return await _IToDO.ListaVencidos();
        }

        [HttpGet("/GetListaPorDataVencimento")]
        [Produces("application/json")]
        public async Task<object> GetListaPorDataVencimento(DateTime dataInicial, DateTime dataFinal)
        {
            return await _IToDO.ListaPorDataVencimento(dataInicial, dataFinal);
        }

        [HttpGet("/GetPorStatus")]
        [Produces("application/json")]
        public async Task<object> GetPorStatus(StatusToDoEnum status)
        {
            //TODO: Listar com nomes dos status
            return await _IToDO.ListaPorStatus(status);
        }

    }
}
