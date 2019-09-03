using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Project.Model;
using Project.API.Resources;
using Project.Model.Common;

namespace Project.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<VehicleMake, VehicleMakeResource>();
            CreateMap<VehicleModel, VehicleModelResource>();
            CreateMap<IVehicleMake, VehicleMakeResource>();
            CreateMap<IVehicleModel, VehicleModelResource>();
        }
    }
}
