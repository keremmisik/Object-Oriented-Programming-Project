using NtpProje_Data.Abstract;
using NtpProje_Data.Concrete;
using NtpProje_DataAccess;
using NtpProje_DataAccess.Concrete;
using NtpProje_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtpProje_Business
{
    public class AboutManager
    {
        private readonly GenericRepository<about> _aboutRepository;
        private readonly NtpProjeContext _context;

        // --- LOGLAMA DEĞİŞKENİ ---
        private readonly ILogger _logger;

        public AboutManager()
        {
            _context = new NtpProjeContext();
            _aboutRepository = new GenericRepository<about>(_context);

            // Loglama servisini başlatıyoruz
            _logger = new FileLogger();
        }

        // --- ANA SİTE ---

        // Hakkımızda yazısı genelde 1 tanedir, ilkini çekeriz.
        public about GetFirstAbout()
        {
            try
            {
                return _aboutRepository.GetAll().FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "AboutManager.GetFirstAbout");
                throw;
            }
        }

        public about GetAboutById(int id)
        {
            return _aboutRepository.GetById(id);
        }

        // --- ADMIN PANELİ ---

        // Admin panelinde güncelleme yapmak için
        public void UpdateAbout(about about)
        {
            try
            {
                _aboutRepository.Update(about);
                _logger.LogInfo($"Hakkımızda içeriği güncellendi. ID: {about.AboutID}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "AboutManager.UpdateAbout");
                throw;
            }
        }

        // Eğer hiç kayıt yoksa admin panelinden eklemek için
        public void AddAbout(about about)
        {
            try
            {
                _aboutRepository.Add(about);
                _logger.LogInfo("Yeni Hakkımızda içeriği oluşturuldu.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "AboutManager.AddAbout");
                throw;
            }
        }
    }
}
