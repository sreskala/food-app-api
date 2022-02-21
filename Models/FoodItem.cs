using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace food_tracker_api.Models
{
    public class FoodItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public bool IsPerishable { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal IndividualPrice { get; set; }
        public StoragePlace StoragePlace { get; set; }
    }
}