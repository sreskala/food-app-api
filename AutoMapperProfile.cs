using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using food_tracker_api.Dtos.StoragePlace;
using food_tracker_api.Models;

namespace food_tracker_api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<StoragePlace, GetStoragePlaceDTO>();
            CreateMap<AddStoragePlaceDTO, StoragePlace>();
        }
    }
}