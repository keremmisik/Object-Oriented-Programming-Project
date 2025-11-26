using NtpProje_Data.Abstract;
using NtpProje_Data.Concrete;
using NtpProje_DataAccess;
using NtpProje_DataAccess.Concrete;
using NtpProje_Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtpProje_Business
{
    public class TeamMemberManager
    {
        private readonly GenericRepository<teammembers> _teamRepository;
        private readonly NtpProjeContext _context;

        // --- LOGLAMA DEĞİŞKENİ ---
        private readonly ILogger _logger;

        public TeamMemberManager()
        {
            _context = new NtpProjeContext();
            _teamRepository = new GenericRepository<teammembers>(_context);

            // Loglama servisini başlatıyoruz
            _logger = new FileLogger();
        }

        // --- ANA SİTE ---
        public List<teammembers> GetActiveTeamMembersOrdered()
        {
            try
            {
                var list = _teamRepository.GetList(t => t.IsActive == true)
                                          .OrderBy(t => t.Order).ToList();
                return list;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "TeamMemberManager.GetActiveTeamMembersOrdered");
                throw;
            }
        }

        // --- ADMIN PANELİ ---
        public List<teammembers> GetAllTeamMembers()
        {
            return _teamRepository.GetAll();
        }

        public teammembers GetTeamMemberById(int id)
        {
            return _teamRepository.GetById(id);
        }

        public void AddTeamMember(teammembers teamMember)
        {
            try
            {
                _teamRepository.Add(teamMember);
                _logger.LogInfo($"Yeni ekip üyesi eklendi: {teamMember.FullName}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "TeamMemberManager.AddTeamMember");
                throw;
            }
        }

        public void UpdateTeamMember(teammembers teamMember)
        {
            try
            {
                _teamRepository.Update(teamMember);
                _logger.LogInfo($"Ekip üyesi güncellendi. ID: {teamMember.TeamMemberID}, İsim: {teamMember.FullName}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "TeamMemberManager.UpdateTeamMember");
                throw;
            }
        }

        public void DeleteTeamMember(int id)
        {
            try
            {
                var member = _teamRepository.GetById(id);
                if (member != null)
                {
                    _teamRepository.Delete(member);
                    _logger.LogInfo($"Ekip üyesi silindi. ID: {id}, İsim: {member.FullName}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "TeamMemberManager.DeleteTeamMember");
                throw;
            }
        }
    }
}
