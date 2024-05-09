using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace Logic
{
    public class ManageGarage
    {
        private FactoryVehicle                    m_Factory = new FactoryVehicle();
        private Dictionary<String, VehicleGarage> m_ListOfVehicles = new Dictionary<String, VehicleGarage>();

        public Dictionary<string, VehicleGarage> ListOfVehicles
        {
            get { return m_ListOfVehicles; }
        }

        public bool IsVehicleExist(string i_LicenseNumber)
        {
            bool i_IsExist = false;
            foreach(KeyValuePair<string, VehicleGarage> vehicle in m_ListOfVehicles)
            {
                if (vehicle.Key == i_LicenseNumber)
                {
                    i_IsExist = true;
                }
            }
            return i_IsExist;
        }

        public void UpdateStatusByLicense(string i_LicenseNumber, int i_StatusFromUser)
        {
            eStatus i_NewStatus = eStatus.PROCESS;
            switch (i_StatusFromUser)
            {
                case 1:
                    i_NewStatus = eStatus.PROCESS;
                    break;
                case 2:
                    i_NewStatus = eStatus.FIXED;
                    break;
                case 3:
                    i_NewStatus = eStatus.PAID;
                    break;
                default:
                    throw new ValueOutOfRangeException(1, 3);
                    break;
            }
            if (m_ListOfVehicles.ContainsKey(i_LicenseNumber))
            {
                m_ListOfVehicles[i_LicenseNumber].Status = i_NewStatus;
            }
        }

        public Vehicle CreateNewVehicleInGarage(int i_VehicleType)
        {
             Vehicle i_newVehicle;
             if (i_VehicleType == 1)
             {
                i_newVehicle = m_Factory.MakeVehicle("FuelCar");
             }
             else if (i_VehicleType == 2)
             {
                i_newVehicle = m_Factory.MakeVehicle("ElectricCar");
            }
             else if (i_VehicleType == 3)
             {
                i_newVehicle = m_Factory.MakeVehicle("FuelMotorcycle");
            }
             else if (i_VehicleType == 4)
             {
                i_newVehicle = m_Factory.MakeVehicle("ElectricMotorcycle");
            }
             else if (i_VehicleType == 5)
             {
                i_newVehicle = m_Factory.MakeVehicle("Truck");
            }
            else
            {
                i_newVehicle = null;
            }
            return i_newVehicle;
        }

        public void AddDataToVehicleAndAddToList(ref Vehicle i_Vehicle, List<Object> i_ListObjectsFromUser)
        {
            i_Vehicle.AddDataToVehicleAndAddToList(i_ListObjectsFromUser);
        }
  
        public void InsertVehicleToList(VehicleGarage i_vehicleGarage)
        {
            m_ListOfVehicles.Add(i_vehicleGarage.Vehicle.LicenseNumber, i_vehicleGarage);
        }

        public void InflatingAllWheelsToMax(string i_LicenseNumber)
        {
            m_ListOfVehicles[i_LicenseNumber].Vehicle.InflatingAllWheelsToMax();
        }

        public void RefuelingVehicle(string i_LicenseNumber, int i_FuelType, float i_FuelAmountToAdd)
        {
            m_ListOfVehicles[i_LicenseNumber].Vehicle.ChargingVehicle(i_FuelAmountToAdd, i_FuelType);
        }

        public void ChargingElectricVehicle(string i_LicenseNumber, float hoursToAdd)
        {
            m_ListOfVehicles[i_LicenseNumber].Vehicle.ChargingVehicle(hoursToAdd);
        }
    }
}
