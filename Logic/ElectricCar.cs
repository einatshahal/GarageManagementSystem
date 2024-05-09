using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class ElectricCar:ElectricVehicle
    {
        private eColorTypes    m_CarColor;
        private eNumberOfDoors m_CarDoors;

        public eColorTypes CarColor
        {
            get { return m_CarColor; }
            set { m_CarColor = value; }
        }
        public eNumberOfDoors CarDoors
        {
            get { return m_CarDoors; }
            set { m_CarDoors = value; }
        }

        public override List<string> GetOutputToUser()
        {
            List<string> i_ListParametrs = new List<string>();

            i_ListParametrs.Add("Enter the model of the vehcile: ");
            i_ListParametrs.Add("Enter the current Battery: ");
            i_ListParametrs.Add("Enter the Current Air Pressure: ");
            i_ListParametrs.Add("Enter the Producer of the wheels: ");
            i_ListParametrs.Add("Choose how many doors the vehicle have: 2, 3, 4 or 5: ");
            i_ListParametrs.Add("Choose the color of the vehicle:\n1. Black\n2. White\n3.Yellow\n4. Red");
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

        public override void AddDataToVehicleAndAddToList(List<Object> i_ListObjectsFromUser)
        {
            CreateWheelsList(5, 33, (float)i_ListObjectsFromUser[2], i_ListObjectsFromUser[3].ToString());
            this.MaxBatteryTime = (float)5.2;
            this.Model = i_ListObjectsFromUser[0].ToString();
            this.CurrBatteryTime = (float)i_ListObjectsFromUser[1];
            if (this.CurrBatteryTime > this.MaxBatteryTime)
            {
                throw new ValueOutOfRangeException(0, MaxBatteryTime);
            }
            if ((int)i_ListObjectsFromUser[4] < 2 || (int)i_ListObjectsFromUser[4] > 5)
            {
                throw new ArgumentException();
            }
            this.m_CarDoors = (eNumberOfDoors)i_ListObjectsFromUser[4];
            if ((int)i_ListObjectsFromUser[5] < 1 || (int)i_ListObjectsFromUser[5] > 4)
            {
                throw new ArgumentException();
            }
            this.m_CarColor = (eColorTypes)i_ListObjectsFromUser[5];
            this.EnergyPercent = ((this.CurrBatteryTime * 100) / this.MaxBatteryTime);
        }

        public override List<string> GetVehicleDataToPrint()
        {
            List<string> i_ListOfData = new List<string>();

            i_ListOfData.Add("\nThe model is: ");
            i_ListOfData.Add(this.Model.ToString());
            i_ListOfData.Add("\nNumber of Wheels: 5");
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
            i_ListOfData.Add("\nThe color of the car is: ");
            i_ListOfData.Add(CarColor.ToString());
            i_ListOfData.Add("\nThe amount of doors in car is: ");
            i_ListOfData.Add(CarDoors.ToString());
            return i_ListOfData;
        }
    }
}
