using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using food_tracker_api.Models;
using food_tracker_api.Dtos.StoragePlace;

namespace food_tracker_api.Services.StoragePlaceService
{
    public interface IStoragePlaceService
    {
        Task<ServiceResponse<List<GetStoragePlaceDTO>>> GetAllStoragePlaces();
        Task<ServiceResponse<GetStoragePlaceDTO>> GetStoragePlaceById(int id);
        Task<ServiceResponse<List<GetStoragePlaceDTO>>> AddStoragePlace(AddStoragePlaceDTO newStoragePlace);
         Task<ServiceResponse<GetStoragePlaceDTO>> UpdateStoragePlace(UpdateStoragePlaceDTO updateStoragePlace);
         Task<ServiceResponse<List<GetStoragePlaceDTO>>> DeleteStoragePlace(int id);
    }
}