using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Model.Common
{
    public interface IVehicleModel
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
        Guid VehicleMakeId { get; set; }
        IVehicleMake VehicleMake { get; set; }
    }
}
