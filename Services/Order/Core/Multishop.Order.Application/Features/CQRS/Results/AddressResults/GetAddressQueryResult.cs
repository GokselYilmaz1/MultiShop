using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.Order.Application.Features.CQRS.Results.AddressResults
{
    public class GetAddressQueryResult
    {
        //Bu sınıf bizim adres sınıfımızdaki propertyleri tutucak ve bunları listelememizi sağlayacak.
        //Bu bana tablodaki büyün adresleri getiricek. yani select * from yapıcak.
        public int AddressId { get; set; }
        public string UserId { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Detail { get; set; }
    }
}
