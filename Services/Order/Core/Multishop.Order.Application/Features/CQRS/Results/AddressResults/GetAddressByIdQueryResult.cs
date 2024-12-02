using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.Order.Application.Features.CQRS.Results.AddressResults
{
    public class GetAddressByIdQueryResult
    {
        //Adres ıd'ye göre getiricek. Ben id göndericem o id'deki adres bilgisini bana getiricek.
        //Burası select * from yaptıktan sonra sonunu where şartı yazcak ve sadece bana geriye 1 veri döndericek.
        //Burada listelemeye ihtiyaç duyarız
        public int AddressId { get; set; }
        public string UserId { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Detail { get; set; }
    }
}
