using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using food_tracker_api.Models;


namespace food_tracker_api.Services.StoragePlaceService
{
    public class StoragePlaceService : IStoragePlaceService
    {
        private static List<StoragePlace> storagePlaces = new List<StoragePlace> {
            new StoragePlace{
                Id = 1,
                Name = "Pantry",
                StorageType = StorageType.Dry,
                StorageCapacity = 90,
                CurrentCapacity = 15,
                IsFull = false,
                StorageLocation = "Top Right"
            },
            new StoragePlace{
                Id = 2,
                Name = "Fridge",
                StorageType = StorageType.Refrigerated,
                StorageCapacity = 35,
                CurrentCapacity = 9,
                IsFull = false,
                StorageLocation = "Middle of the kitchen"
            }
        };
        public async Task<List<StoragePlace>> GetAllStoragePlaces() {
            return storagePlaces;
        }

        public async Task<StoragePlace> GetStoragePlaceById(int id) {
            return storagePlaces.FirstOrDefault(s => s.Id == id);
        }

        public async Task<List<StoragePlace>> AddStoragePlace(StoragePlace newStoragePlace) {
            storagePlaces.Add(newStoragePlace);
            return storagePlaces;
        }
    }
}