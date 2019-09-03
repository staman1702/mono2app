using Project.DAL.Entities;
using Project.Model;
using Project.Model.Common;
using Project.Repository.Common;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace Project.Repository
{
    public class Mapping :  Profile
    {
        
        public Mapping()
        {
            CreateMap<MakeEntity, VehicleMake>().ReverseMap();
            CreateMap<MakeEntity, IVehicleMake>().ReverseMap();
            CreateMap<IVehicleMake, VehicleMake>().ReverseMap();
            CreateMap<ModelEntity, VehicleModel>().ReverseMap();
            CreateMap<ModelEntity, IVehicleModel>().ReverseMap();
            CreateMap<IVehicleModel, VehicleModel>().ReverseMap();                       
        }

    }
}
