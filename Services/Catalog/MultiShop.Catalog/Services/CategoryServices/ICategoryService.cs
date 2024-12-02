using MultiShop.Catalog.Dtos.CategoryDtos;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public interface ICategoryService
    {
        // Bu Interface bizim kategoriyle ilgili gerçekleştiğimiz
        // ekleme silme idye göre veya başka işlemlerin metodların imzalarını tutacak

        Task<List<ResultCategoryDto>> GetAllCategoryAsync(); // 1.Metod // GetAllCategoriesAsync(), Bütün verilerimizi getirecek metod
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto); // 2.Metod // CreateCategoryAsync ekleme işlemi
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto); // 3.metod // UpdateCategoryAsync güncelleme
        Task DeleteCategoryAsync(string id); // 4.metod // DeleteCategoryAsync silme işlemi yapıcak.
        Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id); // 5.metod // GetByIdCategoryAsync(), id'ye göre veri getirme işlemi

        // Hepsini asenkron olarak yazmış olduk.
    }
}
