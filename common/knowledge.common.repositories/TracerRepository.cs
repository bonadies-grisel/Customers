#region Usings
using knowledge.common.entities.Types;
using knowledge.common.entities.Types.Enums;
using knowledge.common.interfaces;
using knowledge.common.mysql;
#endregion

namespace knowledge.common.repositories
{
    public class TracerRepository : GenericRepository<Trace, int>, ITracerRepository
    {
        public TracerRepository(DataContext context) : base(context)
        {

        }

        #region Public Methods
        public async Task ExceptionAsync(ApplicationModule logModule, string component, Exception exception, Dictionary<string, string> context = null)
        {
            if (context == null) context = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(exception.StackTrace))
                context.Add("exception.stacktrace", exception.StackTrace);

            if (exception.InnerException != null)
            {
                if (!string.IsNullOrEmpty(exception.InnerException.Message))
                    context.Add("innerexception.message", exception.InnerException.Message);

                if (!string.IsNullOrEmpty(exception.InnerException.StackTrace))
                    context.Add("innerexception.stacktrace", exception.InnerException.StackTrace);
            }

            var log = CreateTrace(logModule, component, exception.Message, context);

            await TraceAsync(log, LogType.Exception);
        }

        public async Task TraceAsync(Trace log, LogType traceType)
        {
            log.Exception = traceType.Equals(LogType.Exception);

            await Insert(log);
        }
        #endregion

        #region Private Methods
        public Trace CreateTrace(ApplicationModule logModule, string component, string message, Dictionary<string, string> context = null)
        {
            var trace = new Trace
            {
                Fecha = DateTime.UtcNow,
                Aplicacion = "knowledge",
                Modulo = logModule.GetDescription(),
                Componente = component,
                Mensaje = message
            };

            if (context == null) return trace;

            foreach (
                var logContext in
                context.Select(entry => new TraceDetail { Trace = trace, Clave = entry.Key, Valor = entry.Value }))
                trace.AddContext(logContext);

            return trace;
        }
        #endregion
    }
}
