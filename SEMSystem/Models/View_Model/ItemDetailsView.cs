using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEMSystem.Models.View_Model
{
    public class ItemDetailsView
    {
        public int MDDAFId { get; set; }

        public int ItemId { get; set; }
        public int QuantityOrdered { get; set; }
        public decimal QuantityTotalReceived { get; set; }
        public decimal QuantityReceived { get; set; }

        public string haveRecord { get; set; }
    }
    public class ItemViewModel
    {
       
        public int Id { get; set; }
        public string Code { get; set; }
       
        public string Name { get; set; }
    
        public string SerialNo { get; set; }
        
        public DateTime? DatePurchased { get; set; }
        public int? Warranty { get; set; }
        
        public string ItemStatus { get; set; }
        public string Status { get; set; } = "Active";
       
        public string EquipmentType { get; set; }
        public int IsIn { get; set; } = 1;

        public string Type { get; set; }

        public string Capacity { get; set; }
        public int CompanyId { get; set; }
    }
}
