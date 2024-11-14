#region Usings
using knowledge.common.entities.Types;
using knowledge.common.entities.Types.Enums;
using knowledge.common.interfaces;
using knowledge.common.interfaces.IServices;
#endregion

namespace knowledge.common.services
{
    public class TracerService : ITracerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TracerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task ExceptionAsync(ApplicationModule logModule, string component, Exception exception, Dictionary<string, string> context = null)
        {
            await _unitOfWork.TracerRepository.ExceptionAsync(logModule, component, exception, context);
            int saved = _unitOfWork.SaveChanges();
        }

        public async Task TraceAsync(Trace log, LogType traceType)
        {
            await _unitOfWork.TracerRepository.TraceAsync(log, traceType);
            int saved = _unitOfWork.SaveChanges();
        }
    }
}
