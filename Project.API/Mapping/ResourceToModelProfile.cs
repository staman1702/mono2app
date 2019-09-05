using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.API.Resources;
using Project.Model;
using AutoMapper;
using Project.Model.Common;

namespace Project.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveVehicleMakeResource, VehicleMake>();
            CreateMap<SaveVehicleModelResource, VehicleModel>();
            CreateMap<SaveVehicleMakeResource, IVehicleMake>();
            CreateMap<SaveVehicleModelResource, IVehicleModel>();
        }
    }
}
