using NtpProje_DataAccess;
using NtpProje_DataAccess.Concrete;
using NtpProje_Data.Abstract;
using NtpProje_Data.Concrete;
using NtpProje_Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity; // Include() metodu için bu gerekli!
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtpProje_Business
{
    public class PortfolioManager
    {
        private readonly GenericRepository<portfolio> _portfolioRepository;
        private readonly NtpProjeContext _context;

        // --- LOGLAMA DEĞİŞKENİ ---
        private readonly ILogger _logger;

        public PortfolioManager()
        {
            _context = new NtpProjeContext();
            _portfolioRepository = new GenericRepository<portfolio>(_context);

            // Loglama servisini başlatıyoruz
            _logger = new FileLogger();
        }

        // --- ANA SİTE İÇİN GEREKLİ METOTLAR ---

        public List<portfolio> GetActivePortfoliosOrderedByDate()
        {
            try
            {
                var portfolioList = _portfolioRepository.GetList(p => p.IsActive == true);
                return portfolioList.OrderByDescending(p => p.WorkDate).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "PortfolioManager.GetActivePortfoliosOrderedByDate");
                throw;
            }
        }

        public List<portfolio> GetActivePortfoliosWithCategory()
        {
            try
            {
                // İlişkili verileri (Category) çektiğimiz kritik sorgu
                var list = _context.Portfolios
                                   .Include(p => p.Category)
                                   .Where(p => p.IsActive == true)
                                   .OrderByDescending(p => p.WorkDate)
                                   .ToList();

                _logger.LogInfo("Aktif çalışmalar (kategorileriyle) başarıyla listelendi.");
                return list;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "PortfolioManager.GetActivePortfoliosWithCategory");
                throw;
            }
        }

        public portfolio GetPortfolioByIdWithCategory(int id)
        {
            try
            {
                return _context.Portfolios
                               .Include(p => p.Category)
                               .FirstOrDefault(p => p.PortfolioID == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, $"PortfolioManager.GetPortfolioByIdWithCategory (ID: {id})");
                throw;
            }
        }


        // --- ADMİN PANELİ İÇİN GEREKLİ METOTLAR ---

        public List<portfolio> GetAllPortfolios()
        {
            return _portfolioRepository.GetAll();
        }

        public portfolio GetPortfolioById(int id)
        {
            return _portfolioRepository.GetById(id);
        }

        public void AddPortfolio(portfolio portfolio)
        {
            try
            {
                _portfolioRepository.Add(portfolio);
                _logger.LogInfo($"Yeni çalışma eklendi: {portfolio.Title}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "PortfolioManager.AddPortfolio");
                throw;
            }
        }

        public void UpdatePortfolio(portfolio portfolio)
        {
            try
            {
                _portfolioRepository.Update(portfolio);
                _logger.LogInfo($"Çalışma güncellendi. ID: {portfolio.PortfolioID}, Başlık: {portfolio.Title}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "PortfolioManager.UpdatePortfolio");
                throw;
            }
        }

        public void DeletePortfolio(int id)
        {
            try
            {
                var portfolioToDelete = _portfolioRepository.GetById(id);
                if (portfolioToDelete != null)
                {
                    _portfolioRepository.Delete(portfolioToDelete);
                    _logger.LogInfo($"Çalışma silindi. ID: {id}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "PortfolioManager.DeletePortfolio");
                throw;
            }
        }
    }
}