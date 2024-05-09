using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public abstract class ElectricVehicle:Vehicle
    {
        private float m_MaxBatteryTime;
        private float m_CurrBatteryTime;

        public float MaxBatteryTime
        {
            get { return m_MaxBatteryTime; }
            set { m_MaxBatteryTime = value; }
        }

        public float CurrBatteryTime
        {
            get { return m_CurrBatteryTime; }
            set { m_CurrBatteryTime = value; }
        }

        public override void ChargingVehicle(float i_amountToAdd, int? i_fuelType = null)
        {
            if ((this.m_CurrBatteryTime+ i_amountToAdd) > this.m_MaxBatteryTime)
            {
                throw new ArgumentException();
            }
            this.m_CurrBatteryTime += i_amountToAdd;
            this.EnergyPercent = ((this.CurrBatteryTime * 100) / this.MaxBatteryTime);
        }

        public override bool IsElectricCar()
        {
            return true; 
        }
    }
}
