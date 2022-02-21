using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using food_tracker_api.Models;
using food_tracker_api.Dtos.StoragePlace;
using food_tracker_api.Data;


namespace food_tracker_api.Services.StoragePlaceService
{
    public class StoragePlaceService : IStoragePlaceService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public StoragePlaceService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        public async Task<ServiceResponse<List<GetStoragePlaceDTO>>> GetAllStoragePlaces()
        {
            var serviceResponse = new ServiceResponse<List<GetStoragePlaceDTO>>();
            var dbStoragePlaces = await _context.StoragePlaces.Where(s => s.User.Id == GetUserId()).ToListAsync();

            serviceResponse.Data = dbStoragePlaces.Select(s => _mapper.Map<GetStoragePlaceDTO>(s)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetStoragePlaceDTO>> GetStoragePlaceById(int id)
        {
            var serviceResponse = new ServiceResponse<GetStoragePlaceDTO>();
            var storagePlace = await _context.StoragePlaces.FirstOrDefaultAsync(s => s.Id == id && s.User.Id == GetUserId());

            serviceResponse.Data = _mapper.Map<GetStoragePlaceDTO>(storagePlace);

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetStoragePlaceDTO>>> AddStoragePlace(AddStoragePlaceDTO newStoragePlace)
        {
            var serviceResponse = new ServiceResponse<List<GetStoragePlaceDTO>>();
            StoragePlace storagePlace = _mapper.Map<StoragePlace>(newStoragePlace);
            storagePlace.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());
            
            await _context.StoragePlaces.AddAsync(storagePlace);
            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.StoragePlaces
            .Where(s => s.User.Id == GetUserId())
            .Select(s => _mapper.Map<GetStoragePlaceDTO>(s)).ToListAsync();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetStoragePlaceDTO>> UpdateStoragePlace(UpdateStoragePlaceDTO updatedStoragePlace)
        {
            var serviceResponse = new ServiceResponse<GetStoragePlaceDTO>();

            try
            {
                StoragePlace storagePlace = await _context.StoragePlaces
                .Include(s => s.User)
                .FirstOrDefaultAsync(s => s.Id == updatedStoragePlace.Id);
                if (storagePlace.User.Id == GetUserId()) {
                    storagePlace.Name = updatedStoragePlace.Name;
                    storagePlace.StorageLocation = updatedStoragePlace.StorageLocation;
                    storagePlace.CurrentCapacity = updatedStoragePlace.CurrentCapacity;

                    await _context.SaveChangesAsync();

                    serviceResponse.Data = _mapper.Map<GetStoragePlaceDTO>(storagePlace);
                } else {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Storage Place not found.";
                }
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
                StoragePlace storagePlace = await _context.StoragePlaces.FirstAsync(s => s.Id == id && s.User.Id == GetUserId());
                if (storagePlace != null) {
                    _context.StoragePlaces.Remove(storagePlace);
                    await _context.SaveChangesAsync();

                    serviceResponse.Data = await _context.StoragePlaces
                    .Where(s => s.User.Id == GetUserId())
                    .Select(s => _mapper.Map<GetStoragePlaceDTO>(s)).ToListAsync();
                } else {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Storage Place not found.";
                }
                
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