using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using food_tracker_api.Models;

namespace food_tracker_api.Dtos.StoragePlace
{
    public class GetStoragePlaceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public StorageType StorageType { get; set; }
        public int StorageCapacity { get; set; }
        public int CurrentCapacity { get; set; }
        public bool IsFull { get; set; }
        public string StorageLocation { get; set; }
    }
}