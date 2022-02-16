using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using food_tracker_api.Models;

namespace food_tracker_api.Services.StoragePlaceService
{
    public interface IStoragePlaceService
    {
        Task<List<StoragePlace>> GetAllStoragePlaces();
        Task<StoragePlace> GetStoragePlaceById(int id);
        Task<List<StoragePlace>> AddStoragePlace(StoragePlace newStoragePlace);
    }
}