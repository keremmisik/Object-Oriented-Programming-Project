using NtpProje_Data.Abstract;
using NtpProje_DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtpProje_Data.Concrete
{
    public class FileLogger : ILogger
    {
        // --- ALANLAR SINIFIN İÇİNDE ---
        private const string LogFileName = "NtpProjeLog.txt";

        // Loglama işlemini yürüten ana metot
        private void WriteLog(string level, string message, string source = "")
        {
            string logEntry = $"[{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")}] | {level} | Source: {source} | Message: {message}{Environment.NewLine}";

            try
            {
                // Uygulamanın çalıştığı dizine yazar
                File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, LogFileName), logEntry);
            }
            catch (Exception)
            {
                // Loglama hatası olursa sistemi durdurmaz
            }
        }

        // --- ARABİRİM (Interface) METOTLARI SINIFIN İÇİNDE ---
        public void LogInfo(string message)
        {
            WriteLog("INFO", message);
        }

        public void LogError(string message, string source)
        {
            WriteLog("ERROR", message, source);
        }
    }
}

