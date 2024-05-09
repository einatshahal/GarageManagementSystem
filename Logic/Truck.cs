using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class Truck:FuelVehicle
    {
        private bool  m_DangerousMaterial;
        private float m_AmountOfCargo;

        public bool DangerousMaterial
        {
            get { return m_DangerousMaterial; }
            set { m_DangerousMaterial = value; }
        }
        public float AmountOfCargo
        {
            get { return m_AmountOfCargo; }
            set { m_AmountOfCargo = value; }
        }

        public override List<string> GetOutputToUser()
        {
            List<string> i_ListParametrs = new List<string>();

            i_ListParametrs.Add("Enter the model of the vehcile: ");
            i_ListParametrs.Add("Enter the current fuel amount:  ");
            i_ListParametrs.Add("Enter the Current Air Pressure: ");
            i_ListParametrs.Add("Enter the Producer of the wheels: ");
            i_ListParametrs.Add("Enter 1 if you have dangerous material, else enter 0: ");
            i_ListParametrs.Add("Enter the amount of cargo: ");
            return i_ListParametrs;
        }

        public override List<Type> GetTypeList()
        {
            List<Type> i_ListOfTypes = new List<Type>();

            i_ListOfTypes.Add(typeof(string));
            i_ListOfTypes.Add(typeof(float));
            i_ListOfTypes.Add(typeof(float));
            i_ListOfTypes.Add(typeof(string));
            i_ListOfTypes.Add(typeof(bool));
            i_ListOfTypes.Add(typeof(float));
            return i_ListOfTypes;
        }

        // $G$ SFN-003 (-5) The program does not cope as expected with incorrect input (can insert negative current air pressure/cargo/fuel level/number of weels).
        public override void AddDataToVehicleAndAddToList(List<Object> ListObjectsFromUser)
        {
            this.MaxAmountOfFuel = 135;
            this.FuelType = eFuelTypes.DIESEL;
            this.Model = ListObjectsFromUser[0].ToString();
            this.currAmountOfFuel = (float)ListObjectsFromUser[1];
            if (this.currAmountOfFuel > this.MaxAmountOfFuel)
            {
                throw new ValueOutOfRangeException(0, this.MaxAmountOfFuel);
            }
            CreateWheelsList(14, 26, (float)ListObjectsFromUser[2], ListObjectsFromUser[3].ToString());
            this.m_DangerousMaterial = (bool)ListObjectsFromUser[4];
            this.m_AmountOfCargo = (float)ListObjectsFromUser[5];
            this.EnergyPercent = ((this.currAmountOfFuel * 100) / this.MaxAmountOfFuel);
        }

        public override List<string> GetVehicleDataToPrint()
        {
            List<string> i_ListOfData = new List<string>();
           
            i_ListOfData.Add("\nThe model is: ");
            i_ListOfData.Add(this.Model.ToString());
            i_ListOfData.Add("\nNumber of Wheels: 14");
            i_ListOfData.Add("\nCurrent pressure: ");
            i_ListOfData.Add(this.WheelsList[0].CurrentAirPressure.ToString());
            i_ListOfData.Add("\nMaximum pressure: ");
            i_ListOfData.Add(this.WheelsList[0].MaxAirPressure.ToString());
            i_ListOfData.Add("\nThe Producer of the wheels: ");
            i_ListOfData.Add(this.WheelsList[0].Producer.ToString());
            i_ListOfData.Add("\nFuel Type is: DIESEL");
            i_ListOfData.Add("\nCurrent amount of fuel: ");
            i_ListOfData.Add(this.currAmountOfFuel.ToString());
            i_ListOfData.Add("\nMax amount of fuel: ");
            i_ListOfData.Add(this.MaxAmountOfFuel.ToString());
            i_ListOfData.Add("\nEnergy Precent: ");
            i_ListOfData.Add(this.EnergyPercent.ToString());
            i_ListOfData.Add("\nThe amount of cargo is: ");
            i_ListOfData.Add(m_AmountOfCargo.ToString());
            if (m_DangerousMaterial == true)
            {
                i_ListOfData.Add("\nThis truck is carry dangerous material!\n");
            }
            else
            {
                i_ListOfData.Add("\nThis truck doesn't carry dangerous material\n");
            }
            return i_ListOfData;
        }
    }
}
