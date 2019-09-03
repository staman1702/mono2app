using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DAL.Entities
{
    public class MakeEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public IList<ModelEntity> VehicleModels { get; set; } = new List<ModelEntity>();

    }
}
