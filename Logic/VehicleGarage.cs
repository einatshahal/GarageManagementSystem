using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class VehicleGarage
    {
        private string  m_Owner;
        private float   m_OwnerPhoneNumber;
        private eStatus m_VehicleStatus;
        private Vehicle m_Vehicle;

        public VehicleGarage(string i_Owner, string i_OwnerPhoneNumber, Vehicle i_Vehicle)
        {
            m_VehicleStatus = eStatus.PROCESS;
            m_Owner = i_Owner;
            m_OwnerPhoneNumber = float.Parse(i_OwnerPhoneNumber);
            m_Vehicle = i_Vehicle;
        }
        
        public string Owner
        {
            get { return m_Owner; }
            set { m_Owner = value; }
        }

        public float OwnerPhoneNumber
        {
            get { return m_OwnerPhoneNumber; }
            set { m_OwnerPhoneNumber = value; }
        }

        public eStatus Status
        {
            get { return m_VehicleStatus; }
            set { m_VehicleStatus = value; }
        }

        public Vehicle Vehicle
        {
            get { return m_Vehicle; }
            set { m_Vehicle = value; }
        }
    }
}
