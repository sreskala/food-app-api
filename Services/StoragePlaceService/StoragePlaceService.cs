using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using food_tracker_api.Models;
using food_tracker_api.Dtos.StoragePlace;


namespace food_tracker_api.Services.StoragePlaceService
{
    public class StoragePlaceService : IStoragePlaceService
    {
        private readonly IMapper _mapper;
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
        public StoragePlaceService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetStoragePlaceDTO>>> GetAllStoragePlaces()
        {
            var serviceResponse = new ServiceResponse<List<GetStoragePlaceDTO>>();
            serviceResponse.Data = storagePlaces.Select(s => _mapper.Map<GetStoragePlaceDTO>(s)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetStoragePlaceDTO>> GetStoragePlaceById(int id)
        {
            var serviceResponse = new ServiceResponse<GetStoragePlaceDTO>();
            serviceResponse.Data = _mapper.Map<GetStoragePlaceDTO>(storagePlaces.FirstOrDefault(s => s.Id == id));

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetStoragePlaceDTO>>> AddStoragePlace(AddStoragePlaceDTO newStoragePlace)
        {
            var serviceResponse = new ServiceResponse<List<GetStoragePlaceDTO>>();
            storagePlaces.Add(_mapper.Map<StoragePlace>(newStoragePlace));
            serviceResponse.Data = storagePlaces.Select(s => _mapper.Map<GetStoragePlaceDTO>(s)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetStoragePlaceDTO>> UpdateStoragePlace(UpdateStoragePlaceDTO updatedStoragePlace)
        {
            var serviceResponse = new ServiceResponse<GetStoragePlaceDTO>();

            try
            {
                StoragePlace storagePlace = storagePlaces.FirstOrDefault(s => s.Id == updatedStoragePlace.Id);

                storagePlace.Name = updatedStoragePlace.Name;
                storagePlace.StorageLocation = updatedStoragePlace.StorageLocation;
                storagePlace.CurrentCapacity = updatedStoragePlace.CurrentCapacity;

                serviceResponse.Data = _mapper.Map<GetStoragePlaceDTO>(storagePlace);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }


            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetStoragePlaceDTO>>> DeleteStoragePlace(int id) {
            var serviceResponse = new ServiceResponse<List<GetStoragePlaceDTO>>();

            try
            {
                StoragePlace storagePlace = storagePlaces.First(s => s.Id == id);

                storagePlaces.Remove(storagePlace);

                serviceResponse.Data = storagePlaces.Select(s => _mapper.Map<GetStoragePlaceDTO>(s)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}