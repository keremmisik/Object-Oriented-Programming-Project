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
    public class NewsManager
    {
        private readonly GenericRepository<news> _newsRepository;
        private readonly NtpProjeContext _context;

        // --- LOGLAMA DEĞİŞKENİ ---
        private readonly ILogger _logger;

        public NewsManager()
        {
            _context = new NtpProjeContext();
            _newsRepository = new GenericRepository<news>(_context);

            // Loglama servisini başlatıyoruz
            _logger = new FileLogger();
        }

        // --- ANA SİTE İÇİN GEREKLİ METOTLAR ---

        public List<news> GetActiveNewsOrderedByDate()
        {
            try
            {
                var newsList = _newsRepository.GetList(n => n.IsActive == true);
                return newsList.OrderByDescending(n => n.PublishDate).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "NewsManager.GetActiveNewsOrderedByDate");
                throw;
            }
        }

        public List<news> GetActiveNewsOrderedByDate(int take)
        {
            try
            {
                var newsList = _newsRepository.GetList(n => n.IsActive == true);
                return newsList.OrderByDescending(n => n.PublishDate).Take(take).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "NewsManager.GetActiveNewsOrderedByDate(int take)");
                throw;
            }
        }

        // --- ADMİN PANELİ İÇİN GEREKLİ METOTLAR ---

        public List<news> GetAllNews()
        {
            return _newsRepository.GetAll();
        }

        public news GetNewsById(int id)
        {
            return _newsRepository.GetById(id);
        }

        public void AddNews(news news)
        {
            try
            {
                // Yeni haber eklendiğinde yayın tarihini o an olarak ayarla
                news.PublishDate = DateTime.Now;
                _newsRepository.Add(news);

                _logger.LogInfo($"Yeni haber eklendi: {news.Title}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "NewsManager.AddNews");
                throw;
            }
        }

        public void UpdateNews(news news)
        {
            try
            {
                _newsRepository.Update(news);
                _logger.LogInfo($"Haber güncellendi. ID: {news.NewsID}, Başlık: {news.Title}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "NewsManager.UpdateNews");
                throw;
            }
        }

        public void DeleteNews(int id)
        {
            try
            {
                var newsToDelete = _newsRepository.GetById(id);
                if (newsToDelete != null)
                {
                    _newsRepository.Delete(newsToDelete);
                    _logger.LogInfo($"Haber silindi. ID: {id}, Başlık: {newsToDelete.Title}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "NewsManager.DeleteNews");
                throw;
            }
        }
    }
}
