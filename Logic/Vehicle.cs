using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public abstract class Vehicle
    {
        private string      m_LicenseNumber;
        private string      m_Model;
        private float       m_EnergyPercent;
        private List<Wheel> m_Wheels = new List<Wheel>();

        public string LicenseNumber
        {
            get{ return m_LicenseNumber; }
            set{ m_LicenseNumber = value; }
        }
        public string Model
        {
            get { return m_Model; }
            set { m_Model = value; }
        }
        public float EnergyPercent
        {
            get { return m_EnergyPercent; }
            set { m_EnergyPercent = value; }
        }
        public List<Wheel> WheelsList
        {
            get { return m_Wheels; }
        }

        public abstract List<string> GetOutputToUser();

        public abstract List<Type> GetTypeList();

        public abstract void AddDataToVehicleAndAddToList(List<Object> i_ListObjectsFromUser);

        public void CreateWheelsList(int i_countWheels, float i_maxAirPressure, float i_airPressure, string i_producter)
        {
            if(i_maxAirPressure< i_airPressure)
            {
                throw new ValueOutOfRangeException(0, i_maxAirPressure);
            }
            for (int i = 0; i < i_countWheels; i++)
            {
                Wheel i_NewWheel = new Wheel();
                i_NewWheel.MaxAirPressure = i_maxAirPressure;
                i_NewWheel.CurrentAirPressure = i_airPressure;
                i_NewWheel.Producer = i_producter;
                this.m_Wheels.Add(i_NewWheel);
            }
        }

        public void InflatingAllWheelsToMax()
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.InflatingWheelToMax();
            }
        }

        public abstract List<string> GetVehicleDataToPrint();

        public abstract void ChargingVehicle(float i_amountToAdd, int? i_fuelType = null);

        public abstract bool IsElectricCar();
    }
}

