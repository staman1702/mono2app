using System;

namespace Project.Model.Common
{
    public abstract class Vehicle
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}
