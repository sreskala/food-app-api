using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using food_tracker_api.Models;
using food_tracker_api.Services.StoragePlaceService;

namespace food_tracker_api.Controllers
{
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
        public async Task<ActionResult<List<StoragePlace>>> Get()
        {
            return Ok(await _storagePlaceService.GetAllStoragePlaces());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StoragePlace>> GetById(int id) {
            return Ok(await _storagePlaceService.GetStoragePlaceById(id));
        }

        [HttpPost]
        public async Task<ActionResult<List<StoragePlace>>> AddStoragePlace(StoragePlace newStorage) {
            return Ok(await _storagePlaceService.AddStoragePlace(newStorage));
        }
    }
}