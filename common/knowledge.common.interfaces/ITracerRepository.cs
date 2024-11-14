#region Usings
using knowledge.common.entities.Types;
using knowledge.common.entities.Types.Enums; 
#endregion

namespace knowledge.common.interfaces
{
    public interface ITracerRepository : IGenericRepository<Trace, int>
    {
        Task ExceptionAsync(ApplicationModule logModule, string component, Exception exception, Dictionary<string, string> context = null);
        Task TraceAsync(Trace log, LogType traceType);
        Trace CreateTrace(ApplicationModule logModule, string component, string message, Dictionary<string, string> context = null);
    }
}
