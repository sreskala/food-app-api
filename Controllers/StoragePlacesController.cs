using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using food_tracker_api.Models;
using food_tracker_api.Services.StoragePlaceService;
using food_tracker_api.Dtos.StoragePlace;

namespace food_tracker_api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class StoragePlacesController : ControllerBase
    {
        private readonly ILogger<StoragePlacesController> _logger;
        private readonly IStoragePlaceService _storagePlaceService;


        public StoragePlacesController(ILogger<StoragePlacesController> logger, IStoragePlaceService storagePlaceService)
        {
            _logger = logger;
            _storagePlaceService = storagePlaceService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetStoragePlaceDTO>>>> Get()
        {
            return Ok(await _storagePlaceService.GetAllStoragePlaces());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetStoragePlaceDTO>>> GetById(int id) {
            return Ok(await _storagePlaceService.GetStoragePlaceById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetStoragePlaceDTO>>>> AddStoragePlace(AddStoragePlaceDTO newStorage) {
            return Ok(await _storagePlaceService.AddStoragePlace(newStorage));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetStoragePlaceDTO>>> UpdateStoragePlace(UpdateStoragePlaceDTO updatedStoragePlace) {
            var response = await _storagePlaceService.UpdateStoragePlace(updatedStoragePlace);
            if (response.Data == null) {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetStoragePlaceDTO>>>> DeleteStoragePlace(int id) {
            var response = await _storagePlaceService.DeleteStoragePlace(id);
            if (response.Data == null) {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}