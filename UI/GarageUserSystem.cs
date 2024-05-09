using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Logic;

namespace UI
{
    class GarageUserSystem
    {
        private ManageGarage m_ManageGarage = new ManageGarage();

        public void Run()
        {
            while (true) {
                PrintMainMenu();
                UserInputMenu();
            }
        }

        public void PrintMainMenu()
        {
            Console.WriteLine("\n" + "          Garage System Menu            ");
            Console.Write("Please choose the number of the action:\n" +
                "1. Insert vehicle to garage\n" +
                "2. Show list of all the license numbers with filter\n" +
                "3. To change vehicle status\n" +
                "4. Inflating wheels\n" +
                "5. Car refueling\n" +
                "6. Electric vehicle charging\n" +
                "7. Show all the data by license number\n\n");
        }

        public void UserInputMenu()
        {
            int i_InputUser = 0;
            try
            {
                i_InputUser = int.Parse(Console.ReadLine());
                if (IsNumberValidInputUser(1, 7, ref i_InputUser))
                {
                    switch (i_InputUser)
                    {
                        case 1:
                            MenuInsert();
                            break;
                        case 2:
                            ShowAllTheVehicle();
                            break;
                        case 3:
                            ChangeVehicleStatus();
                            break;
                        case 4:
                            InflateWheelToMax();
                            break;
                        case 5:
                            RefuelingVehicle();
                            break;
                        case 6:
                            ChargingElectricVehicle();
                            break;
                        case 7:
                            printVehicleDataByLicense();
                            break;
                    }
                }
            }
            catch (FormatException i_InvalidInputEx)
            {
                Console.WriteLine("\nError - Format exception!");
                Console.WriteLine("\n" + i_InvalidInputEx.Message);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine("\nError - Argument exception!");
                Console.WriteLine("\n" + ex.Message);
            }
            catch(ValueOutOfRangeException ex)
            {
                Console.WriteLine("\nError - Value out of range exception!");
                Console.WriteLine("\n" + ex.Message);
            }
            catch(VehicleIsFoundException ex)
            {
                Console.WriteLine("\n" + ex.Message);
            }
            catch(VehicleIsNotFoundException ex)
            {
                Console.WriteLine("\n" + ex.Message);
            }
        }

        public void MenuInsert() //1
        {
            VehicleGarage i_NewVehicleInGarage;
            Vehicle       i_NewVehcile;
            string        i_LicenseNumber;
            string        i_PhoneNumber;
            string        i_OwnerName;
            int           i_VehicleType;

            Console.WriteLine("Please insert license number of the vehicle: ");
            i_LicenseNumber = Console.ReadLine();
            if (!m_ManageGarage.IsVehicleExist(i_LicenseNumber))
            {
                Console.WriteLine("Please insert the name of the owner: ");
                i_OwnerName = Console.ReadLine();
                Console.WriteLine("Please insert the phone number of the owner: ");
                i_PhoneNumber = Console.ReadLine();
                try
                {
                    PrintVehicleType();
                    i_VehicleType = int.Parse(Console.ReadLine());
                    if (IsNumberValidInputUser(1, 5, ref i_VehicleType))
                    {
                        i_NewVehcile = m_ManageGarage.CreateNewVehicleInGarage(i_VehicleType);
                        GetDataFromUsertoVehicle(ref i_NewVehcile, i_LicenseNumber);
                        i_NewVehicleInGarage = new VehicleGarage(i_OwnerName, i_PhoneNumber, i_NewVehcile);
                        m_ManageGarage.InsertVehicleToList(i_NewVehicleInGarage);
                        Console.WriteLine("\n" + "Add Vehicle is done!");
                    }
                }
                catch (FormatException i_InvalidInputEx)
                {
                    Console.WriteLine("\nError - Format exception!");
                    Console.WriteLine("\n" + i_InvalidInputEx.Message);
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine("\nError - Value out of range exception!");
                    Console.WriteLine("\nError\n" + ex.Message);
                }
            }
            else
            {
                m_ManageGarage.UpdateStatusByLicense(i_LicenseNumber, 1);
                throw new VehicleIsFoundException(i_LicenseNumber);
            }
        }

        // $G$ NTT-999 (-5) Should use Environment.NewLine rather than \n.
        public void PrintVehicleType()
        {
            Console.WriteLine("Please choose the type of the vehicle:\n" +
                "1.Fuel car\n" +
                "2. Electric car\n" +
                "3. Fuel Motorcycle\n" +
                "4. electric Motorcycle\n" +
                "5. Fuel truck\n");
        }

        public void GetDataFromUsertoVehicle(ref Vehicle i_Vehicle, string i_LicenseNumber)
        {
            List<string> ListOfPrintToUser;
            List<string> ListParametersFromUser;
            List<Object> ListObjectsFromUser = new List<object>();
            string       i_CurrParameter;
            bool         i_IsValidParameters = false;

            ListOfPrintToUser = i_Vehicle.GetOutputToUser();
            i_Vehicle.LicenseNumber = i_LicenseNumber;
            ListParametersFromUser = new List<string>();
            foreach (string printStr in ListOfPrintToUser)
            {
                Console.WriteLine(printStr);
                i_CurrParameter = Console.ReadLine();
                ListParametersFromUser.Add(i_CurrParameter);
            }
            try
            {
                i_IsValidParameters = CheckParameters(ref ListObjectsFromUser, ListParametersFromUser, ref i_Vehicle);
                if (i_IsValidParameters)
                {
                    m_ManageGarage.AddDataToVehicleAndAddToList(ref i_Vehicle, ListObjectsFromUser);
                }
                else
                {
                    throw new FormatException();
                }
            }
            catch (FormatException i_InvalidInputEx)
            {
                Console.WriteLine("\nError - Format exception!");
                Console.WriteLine("\n" + i_InvalidInputEx.Message);
            }

        }

        public bool CheckParameters(ref List<Object> ListObjectsFromUser, List<string> ListParametersFromUser, ref Vehicle i_Vehicle)
        {
            bool       i_IsValid = true;
            List<Type> ListOfTypes = i_Vehicle.GetTypeList();

            for (int i = 0; i < ListParametersFromUser.Count(); i++)
            {
                if (ListOfTypes[i] == typeof(String))
                {
                    ListObjectsFromUser.Insert(i, ListParametersFromUser[i]);
                }
                else if (ListOfTypes[i] == typeof(int))
                {
                    try 
                    {
                        int intFromUser;
                        intFromUser = int.Parse(ListParametersFromUser[i]);
                        ListObjectsFromUser.Insert(i, intFromUser);
                    }
                    catch(FormatException i_InvalidInputEx)
                    {
                        Console.WriteLine("\nError - Format exception!");
                        Console.WriteLine(i_InvalidInputEx.Message);
                        i_IsValid = false;
                        break;
                    }
                }
                else if (ListOfTypes[i] == typeof(float))
                {
                    try
                    {
                        float FloatFromUser;
                        FloatFromUser = int.Parse(ListParametersFromUser[i]);
                        ListObjectsFromUser.Insert(i, FloatFromUser);

                    }
                    catch (FormatException i_InvalidInputEx)
                    {
                        Console.WriteLine("\nError - Format exception!");
                        Console.WriteLine(i_InvalidInputEx.Message);
                        i_IsValid = false;
                        break;
                    }
                }
            }
            return i_IsValid;
        }

        public void ShowAllTheVehicle()
        {
            bool IsReadyToPrint;
            int  i_InputUser;

            Console.WriteLine("please choose the filter:\n" +
                "1.In Process\n" +
                "2.Fixed\n" +
                "3.Paid\n" +
                "4.All");
            try
            {
                i_InputUser = int.Parse(Console.ReadLine());
                if (IsNumberValidInputUser(1, 4, ref i_InputUser))
                {
                    foreach (KeyValuePair<String, VehicleGarage> CurrVehicle in m_ManageGarage.ListOfVehicles)
                    {
                        IsReadyToPrint = false;
                        switch (i_InputUser)
                        {
                            case 1:
                                if (CurrVehicle.Value.Status == eStatus.PROCESS)
                                {
                                    Console.WriteLine(CurrVehicle.Key);
                                }
                                break;
                            case 2:
                                if (CurrVehicle.Value.Status == eStatus.FIXED)
                                {
                                    Console.WriteLine(CurrVehicle.Key);
                                }
                                break;
                            case 3:
                                if (CurrVehicle.Value.Status == eStatus.PAID)
                                {
                                    Console.WriteLine(CurrVehicle.Key);
                                }
                                break;
                            case 4:
                                Console.WriteLine(CurrVehicle.Key);
                                break;
                        }
                    }
                }
            }
            catch (FormatException i_InvalidInputEx)
            {
                Console.WriteLine("\nError - Format exception!");
                Console.WriteLine("\n" + i_InvalidInputEx.Message);
            }
            catch (ValueOutOfRangeException ex)
            {
                Console.WriteLine("\nError - Value out of range exception!");
                Console.WriteLine("\n" + ex.Message);
            }
        }//2
    
        public void ChangeVehicleStatus()//3
        {
            Console.WriteLine("Please enter license number of the vehicle:");
            String i_LicenseNumber = Console.ReadLine();

            if (m_ManageGarage.IsVehicleExist(i_LicenseNumber))
            {
                int i_NewStatus;
                Console.WriteLine("Please choose a new status:\n" +
                    "1. PROCESS\n" +
                    "2. FIXED\n" +
                    "3. PAID");
                try
                {
                    i_NewStatus = int.Parse(Console.ReadLine());
                    if (IsNumberValidInputUser(1, 3, ref i_NewStatus))
                    {
                        m_ManageGarage.UpdateStatusByLicense(i_LicenseNumber, i_NewStatus);
                    }
                }
                catch (FormatException i_InvalidInputEx)
                {
                    Console.WriteLine("\nError - Format exception!");
                    Console.WriteLine("\n" + i_InvalidInputEx.Message);
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine("\nError - Value out of range exception!");
                    Console.WriteLine("\n" + ex.Message);
                }
            }
            else
            {
                throw new VehicleIsNotFoundException(i_LicenseNumber);
            }
        }

        public void InflateWheelToMax()//4
        {
            Console.WriteLine("Please enter license number of the vehicle:");
            String i_LicenseNumber = Console.ReadLine();

            if (m_ManageGarage.IsVehicleExist(i_LicenseNumber))
            {
                m_ManageGarage.InflatingAllWheelsToMax(i_LicenseNumber);
                Console.WriteLine("Done to inflating all wheels to max");
            }
            else
            {
                throw new VehicleIsNotFoundException(i_LicenseNumber);
            }
        }

        public void RefuelingVehicle()//5
        {
            Console.WriteLine("Please enter license number of the vehicle:");
            String i_LicenseNumber = Console.ReadLine();

            if (m_ManageGarage.IsVehicleExist(i_LicenseNumber))
            {
                if (!m_ManageGarage.ListOfVehicles[i_LicenseNumber].Vehicle.IsElectricCar()) //if it is fuel
                {
                    int i_InputUserFuelType;
                    Console.WriteLine("Please choose the type of the fuel:\n" +
                        "1.OCTAN98\n" +
                        "2.OCTAN96\n" +
                        "3.OCTAN95\n" +
                        "4.DIESEL");
                    i_InputUserFuelType = int.Parse(Console.ReadLine());

                    if (IsNumberValidInputUser(1, 4, ref i_InputUserFuelType))
                    {
                        int i_FuelAmount;
                        Console.WriteLine("Please enter the amount of the fuel:");
                        try
                        { 
                            i_FuelAmount = int.Parse(Console.ReadLine());
                            m_ManageGarage.RefuelingVehicle(i_LicenseNumber, i_InputUserFuelType, i_FuelAmount);
                        }
                        catch (FormatException i_InvalidInputEx)
                        {
                            Console.WriteLine("\nError - Format exception!");
                            Console.WriteLine("\n" + i_InvalidInputEx.Message);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine("\nError - Argument exception!");
                            Console.WriteLine("\n" + ex.Message);
                        }
                        catch (ValueOutOfRangeException ex)
                        {
                            Console.WriteLine("\nError - Value out of range exception!");
                            Console.WriteLine("\n" + ex.Message);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Error! this vehicle is Electric!");
                }   
            }
            else
            {
                throw new VehicleIsNotFoundException(i_LicenseNumber);
            }
        }

        public void ChargingElectricVehicle()//6
        {
            float i_HoursToCharge;

            Console.WriteLine("Please enter license number of the vehicle:");
            String i_LicenseNumber = Console.ReadLine();
            if (m_ManageGarage.IsVehicleExist(i_LicenseNumber))
            {
                Console.WriteLine("Please enter the amount time to add in minutes:");
                i_HoursToCharge = int.Parse(Console.ReadLine());
                i_HoursToCharge = (i_HoursToCharge / 60);
                m_ManageGarage.ChargingElectricVehicle(i_LicenseNumber, i_HoursToCharge);
            }
            else
            {
                throw new VehicleIsNotFoundException(i_LicenseNumber);
            }
        }

        public void printVehicleDataByLicense()//7
        {
            Console.WriteLine("Please enter license number of the vehicle:");
            String i_LicenseNumber = Console.ReadLine();
            if (m_ManageGarage.IsVehicleExist(i_LicenseNumber))
            {
                printDataOfVehicle(i_LicenseNumber);
            }
            else
            {
                throw new VehicleIsNotFoundException(i_LicenseNumber);
            }
        }

        public bool IsNumberValidInputUser(int firstChoice, int lastChoice, ref int inputUser)
        {
            bool Isvalid = true;
            Isvalid = (inputUser >= firstChoice && inputUser <= lastChoice);
            if (!Isvalid)
            {
                throw new ValueOutOfRangeException(firstChoice, lastChoice);
            }
            return Isvalid;
        }

        public void printDataOfVehicle(string i_LicenseNumber)
        {
            List<string> i_ListToPrint = m_ManageGarage.ListOfVehicles[i_LicenseNumber].Vehicle.GetVehicleDataToPrint();

            Console.WriteLine("\nThe License number is: {0}", i_LicenseNumber);
            Console.WriteLine("The Owner is: {0}", m_ManageGarage.ListOfVehicles[i_LicenseNumber].Owner);
            Console.WriteLine("The phone Owner is: {0}", m_ManageGarage.ListOfVehicles[i_LicenseNumber].OwnerPhoneNumber);
            Console.Write("The status in the garage is: {0}", m_ManageGarage.ListOfVehicles[i_LicenseNumber].Status.ToString());
            foreach (string currStr in i_ListToPrint)
            {
                Console.Write(currStr);
            }
            Console.WriteLine("\n\n");
        }
    }
}

