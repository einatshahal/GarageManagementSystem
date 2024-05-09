using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class ElectricMotorcycle:ElectricVehicle
    {
        private eLicenseMotorcycle m_License;
        private int                m_EngineCapacity;

        public eLicenseMotorcycle License
        {
            get { return m_License; }
            set { m_License = value; }
        }
        public int EngineCapacity
        {
            get { return m_EngineCapacity; }
            set { m_EngineCapacity = value; }
        }

        public override List<string> GetOutputToUser()
        {
            List<string> i_ListParametrs = new List<string>();

            i_ListParametrs.Add("Enter the model of the vehcile: ");
            i_ListParametrs.Add("Enter the current Battery: ");
            i_ListParametrs.Add("Enter the Current Air Pressure: ");
            i_ListParametrs.Add("Enter the Producer of the wheels: ");
            i_ListParametrs.Add("Enter the Engine Capacity: ");
            i_ListParametrs.Add("Choose the type of the license:\n1. A1\n2. A2\n3. AA\n4. B1");
            return i_ListParametrs;
        }

        public override List<Type> GetTypeList()
        {
            List<Type> i_ListOfTypes = new List<Type>();

            i_ListOfTypes.Add(typeof(string));
            i_ListOfTypes.Add(typeof(float));
            i_ListOfTypes.Add(typeof(float));
            i_ListOfTypes.Add(typeof(string));
            i_ListOfTypes.Add(typeof(int));
            i_ListOfTypes.Add(typeof(int));
            return i_ListOfTypes;
        }

        public override void AddDataToVehicleAndAddToList(List<Object> ListObjectsFromUser)
        {
            this.MaxBatteryTime = (float)2.6;
            this.Model = ListObjectsFromUser[0].ToString();
            this.CurrBatteryTime = (float)ListObjectsFromUser[1];
            if (this.CurrBatteryTime > this.MaxBatteryTime)
            {
                throw new ValueOutOfRangeException(0, this.MaxBatteryTime);
            }
            CreateWheelsList(2, 31, (float)ListObjectsFromUser[2], ListObjectsFromUser[3].ToString());
            this.m_EngineCapacity = (int)ListObjectsFromUser[4];
            this.m_License = (eLicenseMotorcycle)ListObjectsFromUser[5];
            this.EnergyPercent = ((this.CurrBatteryTime * 100) / this.MaxBatteryTime);
        }

        public override List<string> GetVehicleDataToPrint()
        {
            List<string> i_ListOfData = new List<string>();

            i_ListOfData.Add("\nThe model is: ");
            i_ListOfData.Add(this.Model.ToString());
            i_ListOfData.Add("\nNumber of Wheels: 2");
            i_ListOfData.Add("\nCurrent pressure: ");
            i_ListOfData.Add(this.WheelsList[0].CurrentAirPressure.ToString());
            i_ListOfData.Add("\nMaximum pressure: ");
            i_ListOfData.Add(this.WheelsList[0].MaxAirPressure.ToString());
            i_ListOfData.Add("\nThe Producer of the wheels: ");
            i_ListOfData.Add(this.WheelsList[0].Producer.ToString());
            i_ListOfData.Add("\nThe amount of current battery time: ");
            i_ListOfData.Add(this.CurrBatteryTime.ToString());
            i_ListOfData.Add("\nThe amount of full battery time: ");
            i_ListOfData.Add(this.MaxBatteryTime.ToString());
            i_ListOfData.Add("\nEnergy Precent: ");
            i_ListOfData.Add(this.EnergyPercent.ToString());
            i_ListOfData.Add("\nThe license of the motorcycle is: ");
            i_ListOfData.Add(m_License.ToString());
            i_ListOfData.Add("\nThe engine capacity is: ");
            i_ListOfData.Add(m_EngineCapacity.ToString());
            return i_ListOfData;
        }
    }
}
