using NtpProje_Data.Concrete;
using NtpProje_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtpProje_Business
{
    public class LogManager
    {
        private readonly LogRepository _logRepository;

        public LogManager()
        {
            _logRepository = new LogRepository();
        }

        public List<LogEntry> GetAllLogs()
        {
            return _logRepository.GetLogs();
        }

        public void ClearAllLogs()
        {
            _logRepository.ClearLogs();
        }
    }
}
