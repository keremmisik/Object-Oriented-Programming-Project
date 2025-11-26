using NtpProje_Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtpProje_Data.Concrete
{
    public class LogRepository
    {
        private const string LogFileName = "NtpProjeLog.txt";

        public List<LogEntry> GetLogs()
        {
            var logList = new List<LogEntry>();
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, LogFileName);

            if (File.Exists(filePath))
            {
                // Dosyadaki tüm satırları oku
                var lines = File.ReadAllLines(filePath);

                // En yeni log en üstte görünsün diye ters çeviriyoruz
                foreach (var line in lines.Reverse())
                {
                    try
                    {
                        // Log formatımız: [Tarih] | Level | Source | Message
                        // "|" işaretine göre parçalıyoruz
                        var parts = line.Split('|');

                        if (parts.Length >= 4)
                        {
                            LogEntry log = new LogEntry
                            {
                                // Köşeli parantezleri temizleyip tarihe çevir
                                Date = DateTime.Parse(parts[0].Trim().Trim('[', ']')),
                                Level = parts[1].Trim(),
                                Source = parts[2].Replace("Source:", "").Trim(),
                                Message = parts[3].Replace("Message:", "").Trim()
                            };
                            logList.Add(log);
                        }
                    }
                    catch
                    {
                        // Okuma hatası olan satırları atla
                        continue;
                    }
                }
            }

            return logList;
        }

        // Logları temizlemek için opsiyonel metot
        public void ClearLogs()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, LogFileName);
            if (File.Exists(filePath))
            {
                File.WriteAllText(filePath, string.Empty);
            }
        }
    }
}
