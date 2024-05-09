using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class VehicleIsFoundException : Exception
    {
        private string m_Message = "is already exist," +
            "the vehicle is being repaired at the garage";
        public VehicleIsFoundException(string i_LicenseNumber) : 
            base(string.Format("The Vehicle {0} is already exist, the vehicle is being repaired at the garage", i_LicenseNumber))
        {
            
        }
    }
}
