using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using food_tracker_api.Models;

namespace food_tracker_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoragePlacesController : ControllerBase
    {
        private readonly ILogger<StoragePlacesController> _logger;

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

        public StoragePlacesController(ILogger<StoragePlacesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<StoragePlace>> Get()
        {
            return Ok(storagePlaces);
        }

        [HttpGet("{id}")]
        public ActionResult<StoragePlace> GetById(int id) {
            return Ok(storagePlaces.FirstOrDefault(s => s.Id == id));
        }

        [HttpPost]
        public ActionResult<List<StoragePlace>> AddStoragePlace(StoragePlace newStorage) {
            storagePlaces.Add(newStorage);
            return Ok(storagePlaces);
        }
    }
}