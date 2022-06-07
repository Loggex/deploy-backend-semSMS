using LoggexWebAPI.Contexts;
using LoggexWebAPI.Domains;
using LoggexWebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggexWebAPI.Repositories
{
    public class LogAlteracaoRepository : ILogAlteracaoRepository
    {
        LoggexContext ctx = new LoggexContext();

        public void Atualizar(int idLog, LogAlteracao LogU)
        {
            LogAlteracao LogBuscado = ctx.LogAlteracaos.Find(idLog);

            if (LogU.IdPeca != null) { LogBuscado.IdPeca = LogU.IdPeca; }
            if (LogU.EstadoAlteracao != null) { LogBuscado.EstadoAlteracao = LogU. EstadoAlteracao; }
            if (LogU.DataAlteracao != null) { LogBuscado.DataAlteracao = LogU.DataAlteracao; }

            ctx.LogAlteracaos.Update(LogBuscado);

            ctx.SaveChanges();
        }

        public LogAlteracao BuscarPorID(int idLog)
        {
            return ctx.LogAlteracaos.FirstOrDefault(c => c.IdLog == idLog);
        }

        public void Cadastrar(LogAlteracao NovoLog)
        {
            ctx.LogAlteracaos.Add(NovoLog);

            ctx.SaveChanges();
        }

        public void Deletar(int idLog)
        {
            LogAlteracao logBuscado = BuscarPorID(idLog);


            ctx.LogAlteracaos.Remove(logBuscado);

            ctx.SaveChanges();
        }

        public List<LogAlteracao> Listar()
        {
            return ctx.LogAlteracaos.ToList();
        }
    }
}
