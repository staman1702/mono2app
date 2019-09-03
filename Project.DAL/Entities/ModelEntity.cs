using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DAL.Entities
{
    public class ModelEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public Guid VehicleMakeId { get; set; }
        public MakeEntity VehicleMake { get; set; }
    }
}
