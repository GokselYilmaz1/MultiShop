using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.Order.Application.Features.CQRS.Queries.AddressQueries
{
    public class GetAddressByIdQuery
    {
        public int Id { get; set; }

        // Controllerda çağırırken constructer üzerinden çağırıcaz yani nesne örneği oluşturarak çağırıcaz.
        // O yüzden burada Constructer(yapıcı metod)'a ihityacımız var. Aşağıdaki gibi.
        public GetAddressByIdQuery(int id)
        {
            Id = id;
        }
    }
}
