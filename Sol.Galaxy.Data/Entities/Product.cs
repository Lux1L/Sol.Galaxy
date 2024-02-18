using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sol.Galaxy.Data.Entities.Base;

namespace Sol.Galaxy.Data.Entities
{
    public class Product : AuditaBase
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
