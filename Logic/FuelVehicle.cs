using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public abstract class FuelVehicle:Vehicle
    {
        private eFuelTypes m_FuelType;
        private float      m_currAmountOfFuel;
        private float      m_MaxAmountOfFuel;

        public eFuelTypes FuelType
        {
            get { return m_FuelType; }
            set { m_FuelType = value; }
        }

        public float MaxAmountOfFuel
        {
            get { return m_MaxAmountOfFuel; }
            set { m_MaxAmountOfFuel = value; }
        }

        public float currAmountOfFuel
        {
            get { return m_currAmountOfFuel; }
            set { m_currAmountOfFuel = value; }
        }

        // $G$ DSN-001 (-5) You should have declared the original method virtual, overriding it and calling the base implementation in inherited classes as needed.
        // $G$ DSN-001 (-5) Missing base energy provider(ENGINE) class with concrete Electric/Gas derived classes.
        // $G$ DSN-001 (-10) Code duplication. except in energy type, gas and electric car are identical.
        public override void ChargingVehicle(float i_amountToAdd, int? i_fuelType = null)
        {
            if(i_fuelType != m_FuelType.GetHashCode())
            {
                throw new ArgumentException();
            }
            if ((this.m_currAmountOfFuel + i_amountToAdd) > this.m_MaxAmountOfFuel)
            {
                throw new ValueOutOfRangeException(0, this.m_MaxAmountOfFuel - this.m_currAmountOfFuel);
            }
            m_currAmountOfFuel += i_amountToAdd;
            this.EnergyPercent = ((this.currAmountOfFuel * 100) / this.MaxAmountOfFuel);
        }

        // $G$ DSN-001 (-5) You should have used polymorphism to implement this.
        public override bool IsElectricCar()
        {
            return false;
        }
    }
}
