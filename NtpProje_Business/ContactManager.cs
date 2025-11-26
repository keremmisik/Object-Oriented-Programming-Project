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
    public class ContactManager
    {
        // İki farklı tabloyu yöneteceği için iki repository tanımlıyoruz
        private readonly GenericRepository<contactinfo> _infoRepository;
        private readonly GenericRepository<contactmessage> _messageRepository;
        private readonly NtpProjeContext _context;

        // --- LOGLAMA DEĞİŞKENİ ---
        private readonly ILogger _logger;

        public ContactManager()
        {
            _context = new NtpProjeContext();
            _infoRepository = new GenericRepository<contactinfo>(_context);
            _messageRepository = new GenericRepository<contactmessage>(_context);

            // Loglama servisini başlatıyoruz
            _logger = new FileLogger();
        }

        // --- İLETİŞİM BİLGİLERİ (ContactInfo) CRUD ---

        public contactinfo GetContactInfoById(int id)
        {
            return _infoRepository.GetById(id);
        }

        public contactinfo GetFirstContactInfo()
        {
            return _infoRepository.GetAll().FirstOrDefault();
        }

        public void AddContactInfo(contactinfo info)
        {
            try
            {
                _infoRepository.Add(info);
                _logger.LogInfo("İletişim bilgileri ilk kez oluşturuldu.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "ContactManager.AddContactInfo");
                throw;
            }
        }

        public void UpdateContactInfo(contactinfo info)
        {
            try
            {
                _infoRepository.Update(info);
                _logger.LogInfo($"İletişim bilgileri güncellendi. ID: {info.ContactInfoID}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "ContactManager.UpdateContactInfo");
                throw;
            }
        }


        // --- GELEN MESAJLAR ---

        // Ziyaretçi mesaj gönderdiğinde çalışacak
        public void AddMessage(contactmessage message)
        {
            try
            {
                message.SubmissionDate = DateTime.Now; // Tarihi otomatik ata
                message.IsRead = false; // Başlangıçta okunmadı olarak işaretle
                _messageRepository.Add(message);

                _logger.LogInfo($"Yeni iletişim mesajı alındı. Gönderen: {message.FirstName}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "ContactManager.AddMessage");
                throw;
            }
        }

        // Admin panelinde gelen mesajları listelemek için
        public List<contactmessage> GetAllMessages()
        {
            return _messageRepository.GetAll().OrderByDescending(x => x.SubmissionDate).ToList();
        }

        // Admin bir mesajı okuduğunda veya sildiğinde
        public contactmessage GetMessageById(int id)
        {
            return _messageRepository.GetById(id);
        }

        public void DeleteMessage(int id)
        {
            try
            {
                var msg = _messageRepository.GetById(id);
                if (msg != null)
                {
                    _messageRepository.Delete(msg);
                    _logger.LogInfo($"Mesaj silindi. ID: {id}, Gönderen: {msg.FirstName}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "ContactManager.DeleteMessage");
                throw;
            }
        }

        // Mesajı "Okundu" olarak işaretlemek için
        public void MarkAsRead(int id)
        {
            try
            {
                var msg = _messageRepository.GetById(id);
                if (msg != null)
                {
                    msg.IsRead = true;
                    _messageRepository.Update(msg);
                    _logger.LogInfo($"Mesaj okundu olarak işaretlendi. ID: {id}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "ContactManager.MarkAsRead");
                throw;
            }
        }
    }
}
