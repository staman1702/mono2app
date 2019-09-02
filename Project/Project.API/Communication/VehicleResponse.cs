using System;
using System.Collections.Generic;
using System.Text;

namespace Project.API.Communication
{
    public class VehicleResponse<T> : BaseResponse
    {
        public T Response { get; set; }        


        private VehicleResponse(bool success, string message, T item) : base(success, message)
        {
            Response = item;            
        }

        /// <param name="item">Saved item.</param>

        public VehicleResponse(T item) : this(true, string.Empty, item)
        { }


        /// <param name="message">Error message.</param>

        public VehicleResponse(string message) : this(false, message, default)
        { }
    }
}
