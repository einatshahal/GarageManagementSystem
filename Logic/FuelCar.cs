using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class FuelCar:FuelVehicle
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
            i_ListParametrs.Add("Enter the current fuel amount: ");
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

        public override void AddDataToVehicleAndAddToList(List<Object> ListObjectsFromUser)
        {
            this.MaxAmountOfFuel = 46;
            this.FuelType = eFuelTypes.OCTAN95;
            this.Model = ListObjectsFromUser[0].ToString();
            this.currAmountOfFuel = (float)ListObjectsFromUser[1];
            if (this.currAmountOfFuel > this.MaxAmountOfFuel)
            {
                throw new ValueOutOfRangeException(0, this.MaxAmountOfFuel);
            }
            CreateWheelsList(5, 33, (float)ListObjectsFromUser[2], ListObjectsFromUser[3].ToString());
            if ((int)ListObjectsFromUser[4] < 2 || (int)ListObjectsFromUser[4] > 5)
            {
                throw new ArgumentException();
            }
            this.m_CarDoors = (eNumberOfDoors)ListObjectsFromUser[4];
            if ((int)ListObjectsFromUser[5] < 1 || (int)ListObjectsFromUser[5] > 4)
            {
                throw new ArgumentException();
            }
            this.m_CarColor = (eColorTypes)ListObjectsFromUser[5];
            this.EnergyPercent = ((this.currAmountOfFuel * 100) / this.MaxAmountOfFuel);
        }

        public override List<string> GetVehicleDataToPrint()
        {
            List<string> i_ListOfData = new List<string>();

            i_ListOfData.Add("\nCar model: ");
            i_ListOfData.Add(this.Model.ToString());
            i_ListOfData.Add("\nNumber of Wheels: 5");
            i_ListOfData.Add("\nCurrent pressure: ");
            i_ListOfData.Add(this.WheelsList[0].CurrentAirPressure.ToString());
            i_ListOfData.Add("\nMaximum pressure: ");
            i_ListOfData.Add(this.WheelsList[0].MaxAirPressure.ToString());
            i_ListOfData.Add("\nThe Producer of the wheels: ");
            i_ListOfData.Add(this.WheelsList[0].Producer.ToString());
            i_ListOfData.Add("\nFuel Type is: Octan95");
            i_ListOfData.Add("\nCurrent amount of fuel: ");
            i_ListOfData.Add(this.currAmountOfFuel.ToString());
            i_ListOfData.Add("\nMax amount of fuel: ");
            i_ListOfData.Add(this.MaxAmountOfFuel.ToString());
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
