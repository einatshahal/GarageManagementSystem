using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class Wheel
    {
        private string m_Producer;
        private float  m_CurrentAirPressure;
        private float  m_MaxAirPressure;

        public string Producer
        {
            get { return m_Producer; }
            set { m_Producer = value; }
        }
        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set { m_CurrentAirPressure = value; }
        }
        public float MaxAirPressure
        {
            get { return m_MaxAirPressure; }
            set { m_MaxAirPressure = value; }
        }

        public void InflatingWheelToMax() 
        {
            this.m_CurrentAirPressure = this.m_MaxAirPressure;
        }
    }
}
