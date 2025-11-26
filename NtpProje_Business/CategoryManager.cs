using NtpProje_Data.Abstract;
using NtpProje_Data.Concrete;
using NtpProje_DataAccess;
using NtpProje_DataAccess.Concrete;
using NtpProje_Entities;
using NtpProje_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtpProje_Business
{
    public class CategoryManager
    {
        private readonly GenericRepository<Category> _categoryRepository;
        private readonly NtpProjeContext _context;
        private readonly ILogger _logger; // Loglama değişkeni

        public CategoryManager()
        {
            _context = new NtpProjeContext();
            _categoryRepository = new GenericRepository<Category>(_context);
            _logger = new FileLogger(); // Loglama servisi başlatılıyor
        }

        // --- ANA SİTE İÇİN GEREKLİ METOTLAR ---

        public List<Category> GetActiveCategoriesOrdered()
        {
            try
            {
                var categoryList = _categoryRepository.GetList(c => c.IsActive == true);
                _logger.LogInfo("Aktif Kategoriler başarıyla getirildi.");
                return categoryList.OrderBy(c => c.Order).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "CategoryManager.GetActiveCategoriesOrdered");
                throw;
            }
        }

        // --- ADMİN PANELİ İÇİN GEREKLİ METOTLAR ---

        public List<Category> GetAllCategories()
        {
            return _categoryRepository.GetAll();
        }

        public Category GetCategoryById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public void AddCategory(Category category)
        {
            try
            {
                _categoryRepository.Add(category);
                _logger.LogInfo($"Yeni Kategori eklendi: {category.CategoryName}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "CategoryManager.AddCategory");
                throw;
            }
        }

        public void UpdateCategory(Category category)
        {
            try
            {
                _categoryRepository.Update(category);
                _logger.LogInfo($"Kategori güncellendi. ID: {category.CategoryID}, Ad: {category.CategoryName}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "CategoryManager.UpdateCategory");
                throw;
            }
        }

        public void DeleteCategory(int id)
        {
            try
            {
                var categoryToDelete = _categoryRepository.GetById(id);
                if (categoryToDelete != null)
                {
                    _categoryRepository.Delete(categoryToDelete);
                    _logger.LogInfo($"Kategori silme başarılı. ID: {id}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "CategoryManager.DeleteCategory");
                throw;
            }
        }

        // Raporlama için Stored Procedure çağırır
        public List<CategoryReportDto> GetCategoryProjectCounts()
        {
            try
            {
                var result = _context.Database
                                   .SqlQuery<CategoryReportDto>("EXEC GetCategoryProjectCounts")
                                   .ToList();
                _logger.LogInfo("SP (GetCategoryProjectCounts) başarıyla çalıştırıldı.");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "CategoryManager.GetCategoryProjectCounts (SP Call)");
                throw;
            }
        }
    }
}