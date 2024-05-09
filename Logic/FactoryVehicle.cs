using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class FactoryVehicle
    {
        private List<Type> m_carTypes = new List<Type>()
        {
            typeof(FuelCar), typeof(ElectricCar),
            typeof(FuelMotorcycle), typeof(ElectricMotorcycle), typeof(Truck)
        };

        public Vehicle MakeVehicle(string i_UserChoiceOfVehicle)
        {
            object i_newObject = null;
            foreach (Type type in m_carTypes)
            {
                if (type.Name.ToUpper() == i_UserChoiceOfVehicle.ToUpper())
                {
                    i_newObject = Activator.CreateInstance(type, null);
                    break;
                }
            }
            return i_newObject as Vehicle;
        }
    }
}
