using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MultiShop.Discount.Entities;
using System.Data;

namespace MultiShop.Discount.Context
{
    public class DapperContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnectionString"); // "DefaultConnectionString" Mongodb'de appsettinjson için yaptığımız key atamasına karşılık geliyor DefaultConnectionString.
        }

        // Tablomuzu veri tabanınına yansıtmak için bağlantı burdan yapılır. Daha Sonra burdaki bağlantıyı kaldırıp appsetting üzerinden devam edilicek.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-MM3M4EB\\SQLEXPRESS; Initial Catalog=MultishopDiscountDb; Integrated Security=true");
        }
        public DbSet<Coupon> Coupons { get; set; } // DbSet<Coupon> , DbSet  türünde < > içerisinde Coupon sınıfını alcan. Veri tabanın yansıtırken ismi'de Coupons olcak
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString); // IDbConnection türünde ismi CreateConnection() olan metod tanımlıyorum. CreateConnection() metodu çağrıldığı zaman yeni bir SqlConnection bağlantısı oluştur onun içinide _connectionString değerini göndereceksin.
    }
}
