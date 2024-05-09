using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class VehicleIsNotFoundException : Exception
    {
        public VehicleIsNotFoundException(string i_LicenseNumber):
            base(string.Format("The Vehicle {0} is not exist", i_LicenseNumber))
        {
        }
    }
}
