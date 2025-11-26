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
    public class ServiceManager
    {
        private readonly GenericRepository<service> _serviceRepository;
        private readonly NtpProjeContext _context;

        // --- LOGLAMA DEĞİŞKENİ ---
        private readonly ILogger _logger;

        public ServiceManager()
        {
            _context = new NtpProjeContext();
            _serviceRepository = new GenericRepository<service>(_context);

            // Loglama servisini başlatıyoruz
            _logger = new FileLogger();
        }

        // --- ANA SİTE ---
        public List<service> GetActiveServicesOrdered()
        {
            try
            {
                var list = _serviceRepository.GetList(s => s.IsActive == true)
                                             .OrderBy(s => s.Order).ToList();
                return list;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "ServiceManager.GetActiveServicesOrdered");
                throw;
            }
        }

        // --- ADMIN PANELİ ---
        public List<service> GetAllServices()
        {
            return _serviceRepository.GetAll();
        }

        public service GetServiceById(int id)
        {
            return _serviceRepository.GetById(id);
        }

        public void AddService(service service)
        {
            try
            {
                _serviceRepository.Add(service);
                _logger.LogInfo($"Yeni hizmet eklendi: {service.Title}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "ServiceManager.AddService");
                throw;
            }
        }

        public void UpdateService(service service)
        {
            try
            {
                _serviceRepository.Update(service);
                _logger.LogInfo($"Hizmet güncellendi. ID: {service.ServiceID}, Başlık: {service.Title}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "ServiceManager.UpdateService");
                throw;
            }
        }

        public void DeleteService(int id)
        {
            try
            {
                var service = _serviceRepository.GetById(id);
                if (service != null)
                {
                    _serviceRepository.Delete(service);
                    _logger.LogInfo($"Hizmet silindi. ID: {id}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "ServiceManager.DeleteService");
                throw;
            }
        }
    }
}
