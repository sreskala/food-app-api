using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using food_tracker_api.Models;
using food_tracker_api.Dtos.StoragePlace;
using food_tracker_api.Data;


namespace food_tracker_api.Services.StoragePlaceService
{
    public class StoragePlaceService : IStoragePlaceService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
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
        public StoragePlaceService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ServiceResponse<List<GetStoragePlaceDTO>>> GetAllStoragePlaces()
        {
            var serviceResponse = new ServiceResponse<List<GetStoragePlaceDTO>>();
            var dbStoragePlaces = await _context.StoragePlaces.ToListAsync();

            serviceResponse.Data = dbStoragePlaces.Select(s => _mapper.Map<GetStoragePlaceDTO>(s)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetStoragePlaceDTO>> GetStoragePlaceById(int id)
        {
            var serviceResponse = new ServiceResponse<GetStoragePlaceDTO>();
            var storagePlace = await _context.StoragePlaces.FirstOrDefaultAsync(s => s.Id == id);

            serviceResponse.Data = _mapper.Map<GetStoragePlaceDTO>(storagePlace);

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetStoragePlaceDTO>>> AddStoragePlace(AddStoragePlaceDTO newStoragePlace)
        {
            var serviceResponse = new ServiceResponse<List<GetStoragePlaceDTO>>();
            StoragePlace storagePlace = _mapper.Map<StoragePlace>(newStoragePlace);
            
            await _context.StoragePlaces.AddAsync(storagePlace);
            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.StoragePlaces.Select(s => _mapper.Map<GetStoragePlaceDTO>(s)).ToListAsync();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetStoragePlaceDTO>> UpdateStoragePlace(UpdateStoragePlaceDTO updatedStoragePlace)
        {
            var serviceResponse = new ServiceResponse<GetStoragePlaceDTO>();

            try
            {
                StoragePlace storagePlace = await _context.StoragePlaces.FirstOrDefaultAsync(s => s.Id == updatedStoragePlace.Id);

                storagePlace.Name = updatedStoragePlace.Name;
                storagePlace.StorageLocation = updatedStoragePlace.StorageLocation;
                storagePlace.CurrentCapacity = updatedStoragePlace.CurrentCapacity;

                await _context.SaveChangesAsync();

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
                StoragePlace storagePlace = await _context.StoragePlaces.FirstAsync(s => s.Id == id);
                _context.StoragePlaces.Remove(storagePlace);
                await _context.SaveChangesAsync();

                serviceResponse.Data = await _context.StoragePlaces.Select(s => _mapper.Map<GetStoragePlaceDTO>(s)).ToListAsync();
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