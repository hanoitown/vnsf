using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vnsf.Data.Entities.AssetManagement
{
    public class Asset
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Made { get; set; }
        public string Model { get; set; }
        public string Name { get; set; }
        public string Serial { get; set; }
        public string Note { get; set; }
        public decimal Value { get; set; }
        public string CurrentValue { get; set; }

        public DateTime PurchaseDate { get; set; }
        public TimeSpan WarrantyDuration { get; set; }

    }
}
