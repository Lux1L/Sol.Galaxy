using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sol.Galaxy.Data.Entities.Base;

namespace Sol.Galaxy.Data.Entities
{
    public class Customer: AuditaBase 
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }

        public virtual List<Invoice> Invoices { get; set; }

    }
}
