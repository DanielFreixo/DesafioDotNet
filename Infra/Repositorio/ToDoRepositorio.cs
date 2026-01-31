using Dominio.Interfaces.IToDo;
using Entidades.Entidades;
using Entidades.Enums;
using Infra.Conifguracao;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositorio
{
    public class ToDoRepositorio : GenericoRepositorio<ToDo>, IToDo
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuiler;
        public ToDoRepositorio()
        {
            _OptionsBuiler = new DbContextOptions<ContextBase>();
        }

        private const string FORMATO_DATA_HORA = "yyyy-MM-dd HHmmss";
        private DateTime GetDataHojeSemHora()
        {
            //TODO: Criar no Projeto Helper.DateTime
            DateTime agora = DateTime.Now;
            DateTime dataFimDoDia = new DateTime(agora.Year, agora.Month, agora.Day, 23, 59, 59, DateTimeKind.Local);
            //string dataFormatada = dataFimDoDia.ToString(FORMATO_DATA_HORA);
            return dataFimDoDia;
        }
        private string GetDataHojeSemHoraStr()
        {
            //TODO: Criar no Projeto Helper.DateTime
            string dataFormatada = GetDataHojeSemHora().ToString(FORMATO_DATA_HORA);
            return dataFormatada;
        }
        private bool IsNull(DateTime data)
        {
            return (data.Year == 1 && data.Month == 1 & data.Day == 1);
        }

        public async Task<IList<ToDo>> ListaPorStatus(Enums.StatusToDoEnum status)
        {
            using (var banco = new ContextBase(_OptionsBuiler))
            {
                return await (from td in banco.ToDo
                             where td.Estado == status
                             select td).AsNoTracking().ToListAsync();
            }
        }

        public async Task<IList<ToDo>> ListaVencidos()
        {
            using (var banco = new ContextBase(_OptionsBuiler))
            {
                ///Era pra fazer assim mas o Tio SqLite não possui data... talvez depois trans
                return await (from td in banco.ToDo
                              where td.Estado != Enums.StatusToDoEnum.Concluido &&  GetDataHojeSemHora() > td.DataVencimento
                              select td).AsNoTracking().ToListAsync();
            }
        }

        public async Task<IList<ToDo>> ListaPorDataVencimento(DateTime dataInicial, DateTime dataFinal)
        {
            using (var banco = new ContextBase(_OptionsBuiler))
            {
                if (IsNull(dataInicial) && IsNull(dataFinal))
                {
                    return await base.List();
                }
                else
                {
                    if (IsNull(dataInicial))
                    {
                        dataInicial = dataFinal;
                    }
                    if (IsNull(dataFinal))
                    {
                        dataFinal = dataInicial;
                    }
                }
                if (dataInicial > dataFinal)
                {
                    (dataInicial, dataFinal) = (dataFinal, dataInicial);
                }
                dataInicial = dataInicial.Date + new TimeSpan(0, 0, 0);
                dataFinal = dataFinal.Date + new TimeSpan(23, 59, 59);
                return await (from td in banco.ToDo
                             where (td.DataVencimento >= dataInicial && td.DataVencimento <= dataFinal)
                             select td).AsNoTracking().ToListAsync();
            }
        }
    }
}
