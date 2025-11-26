using NtpProje_Data.Abstract;
using NtpProje_Data.Concrete;
using NtpProje_DataAccess;          // NtpProjeContext sınıfımız için
using NtpProje_DataAccess.Concrete; // GenericRepository sınıfımız için
using NtpProje_Entities;              // Slider, News vb. sınıflarımız için
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtpProje_Business
{
    public class SliderManager
    {
        // --- Repository ve Context Değişkenleri ---
        private readonly GenericRepository<Slider> _sliderRepository;
        private readonly NtpProjeContext _context;

        // --- LOGLAMA DEĞİŞKENİ EKLEME ---
        private readonly ILogger _logger;

        public SliderManager()
        {
            _context = new NtpProjeContext();
            _sliderRepository = new GenericRepository<Slider>(_context);
            _logger = new FileLogger(); // Loglama servisi başlatılıyor
        }

        // --- ANA SAYFA (index.aspx) İÇİN GEREKLİ METOT ---
        public List<Slider> GetActiveSlidersOrdered()
        {
            // İş kuralı: Aktif olanları Sıra'ya göre getir.
            try
            {
                var sliderList = _sliderRepository.GetList(s => s.IsActive == true);
                _logger.LogInfo("Aktif Slider listesi başarıyla getirildi.");
                return sliderList.OrderBy(s => s.Order).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "SliderManager.GetActiveSlidersOrdered");
                throw; // Hatayı bir üst katmana fırlat
            }
        }

        // --- ADMİN PANELİ İÇİN GEREKLİ METOTLAR ---

        public List<Slider> GetAllSliders()
        {
            return _sliderRepository.GetAll();
        }

        public Slider GetSliderById(int id)
        {
            return _sliderRepository.GetById(id);
        }

        /// <summary>
        /// Yeni bir Slider EKLEMEK.
        /// </summary>
        public void AddSlider(Slider slider)
        {
            try
            {
                _sliderRepository.Add(slider);
                _logger.LogInfo($"Yeni Slider eklendi. Başlık: {slider.Title}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "SliderManager.AddSlider");
                throw;
            }
        }

        /// <summary>
        /// Mevcut bir Slider'ı GÜNCELLEMEK.
        /// </summary>
        public void UpdateSlider(Slider slider)
        {
            try
            {
                _sliderRepository.Update(slider);
                _logger.LogInfo($"Slider güncellendi. ID: {slider.SliderID}, Başlık: {slider.Title}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "SliderManager.UpdateSlider");
                throw;
            }
        }

        /// <summary>
        /// Bir Slider'ı SİLMEK.
        /// </summary>
        public void DeleteSlider(int id)
        {
            try
            {
                var sliderToDelete = _sliderRepository.GetById(id);
                if (sliderToDelete != null)
                {
                    _sliderRepository.Delete(sliderToDelete);
                    _logger.LogInfo($"Slider silme başarılı. ID: {id}, Başlık: {sliderToDelete.Title}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "SliderManager.DeleteSlider");
                throw;
            }
        }
    }
}
