#region Usings
using knowledge.common.entities.Types;
using knowledge.common.entities.Types.Enums; 
#endregion

namespace knowledge.common.interfaces.IServices
{
    public interface ITracerService 
    {
        Task ExceptionAsync(ApplicationModule logModule, string component, Exception exception, Dictionary<string, string> context = null);
        Task TraceAsync(Trace log, LogType traceType);
    }
}
