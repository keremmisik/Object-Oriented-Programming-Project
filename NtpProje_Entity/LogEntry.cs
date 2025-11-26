using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtpProje_Entity
{
    public class LogEntry
    {
        public DateTime Date { get; set; }
        public string Level { get; set; } // INFO veya ERROR
        public string Source { get; set; } // Hangi Metot?
        public string Message { get; set; } // Mesaj içeriği
    }
}
