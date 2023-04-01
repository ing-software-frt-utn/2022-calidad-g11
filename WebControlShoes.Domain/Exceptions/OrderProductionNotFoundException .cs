using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Zapaitllas.Domain.Entities;

namespace WebControlShoes.Domain.Exceptions
{
    public sealed class OrderProductionNotFoundException : NotFoundException
    {
        public OrderProductionNotFoundException(string id) 
            : base ($"The account with the identifier {id}  was not found")
        {

        }
    }
}
