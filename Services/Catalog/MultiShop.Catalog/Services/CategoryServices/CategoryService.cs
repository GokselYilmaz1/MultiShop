using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper,IDatabaseSettings _databaseSettings) // IDatabaseSettings üstünden _databaseSettings isminde bi field(alan) örnekle //uygulama categoryservice sınıfı üzerinden ayağa kalktığında yada categoryservice sınıfı cağrıldığında IDatabaseSettings _databaseSettings => bunun bir nesne örneğini oluşturucak arkada 
        {
            //ConnectionString normalde appsetting jsonda ama onun karşılığı nerde? IDatabaseSettings' de
            var client = new MongoClient(_databaseSettings.ConnectionString); // _databaseSettings aracılığı ile gidip connectionstringe erişim sağlayabilirsin.
            var database = client.GetDatabase(_databaseSettings.DatabaseName); // Client'tan(bağlantıdan - istemciden) GetDatabase'e(veritabanı)'na gittik.
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName); // Burada da Veritabanı üzerinden tabloya gidiş yolu.  //kategori kolleksiyonunun mongodbdeki tablo ismi CategoryCollectionName'dir.
            _mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var value = _mapper.Map<Category>(createCategoryDto);
            await _categoryCollection.InsertOneAsync(value); // Mongodb ekleme işlemi InsertOneAsync() metoduyla yapılır.
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _categoryCollection.DeleteOneAsync(x => x.CategoryId == id);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            var values = await _categoryCollection.Find(x=>true).ToListAsync();
            return _mapper.Map<List<ResultCategoryDto>>(values);
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
            var values = await _categoryCollection.Find<Category>(x=> x.CategoryId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdCategoryDto>(values);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var values = _mapper.Map<Category>(updateCategoryDto); // updateCategoryDto dan gelen veriyi maplemenin içine dahil et.
            await _categoryCollection.FindOneAndReplaceAsync(x=>x.CategoryId==updateCategoryDto.CategoryID, values); // Mongodb güncelleme işlemi FindOneAndReplaceAsync() metoduyla yapılır.  // (x=>x.CategoryID==updateCategoryDto.CategoryID, values) ==> Meaning: UpdateCategoryId'den gelen Id'ye eşit olan değeri bul. Bulduğumuz bu değeri values parametresindeki değerle değiştir.
        }
    }
}
