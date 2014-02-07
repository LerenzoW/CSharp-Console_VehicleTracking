using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleTracking
{
    class Program
    {
        //vehicle declaration.
        Vehicle[] vehicleArray = new Vehicle[50];
        int numVehicles = 0;

        //list all vehicles.
        public void DisplayAllVehicles()
        {
            Console.WriteLine("Display All Vehicles");
            Console.WriteLine("----------------------------------------------");
            for (int loop = 0; loop < numVehicles; loop++)
            {
                Console.WriteLine(vehicleArray[loop]);
                
            }
        }

        //list all cars.
        public void DisplayAllCars()
        {
            Console.WriteLine("Display All Cars");
            Console.WriteLine("----------------------------------------------");
            for (int loop = 0; loop < numVehicles; loop++)
            {
                //the 'is' operator returns true if the object 'is' of the specified type.
                if (vehicleArray[loop] is Car)
                {
                    Console.WriteLine(vehicleArray[loop]);
                }
            }
        }

        //list all trucks.
        public void DisplayAllTrucks()
        {
            Console.WriteLine("Display All Trucks");
            Console.WriteLine("----------------------------------------------");
            for (int loop = 0; loop < numVehicles; loop++)
            {
                //the 'is; operator returns true if the object 'is' of the specified type.
                if (vehicleArray[loop] is Truck)
                {
                    Console.WriteLine(vehicleArray[loop]);
                }
            }
        }

        //list all motorbikes.
        public void DisplayAllMotorbikes()
        {
            Console.WriteLine("Display All Motorbikes");
            Console.WriteLine("----------------------------------------------");
            for (int loop = 0; loop < numVehicles; loop++)
            {
                if (vehicleArray[loop] is Motorbike)
                {
                    Console.WriteLine(vehicleArray[loop]);
                }
            }
        }

        //prompts user for info and adds a vehicle to the array.
        public void AddVehicle()
        {
            //variable declarations.
            Vehicle v;
            char vehicleType;
            int vehicleCapacity;
            string vehicleMake;
            string vehicleModel;
            Vehicle.eVehicleCondition vehicleCondition;
            double vehiclePrice;

            //this program cannot store more than 50 vehicles.
            if (numVehicles >= 50)
            {
                Console.WriteLine("The array is full.");
                // stop excuting the method.
                return;
            }

            //propmt user for info and read it in.
            Console.WriteLine("Add Vehicle");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Please fill in the following information: ");

            Console.WriteLine("Vehicle Make: ");
            vehicleMake = Console.ReadLine();
            Console.WriteLine("Vehicle Model: ");
            vehicleModel = Console.ReadLine();

            Console.WriteLine("Vehicle Price: ");
            vehiclePrice = Double.Parse(Console.ReadLine());

            Console.WriteLine("Vehicle Condition (0 == Good, 1 == Bad, 2 == Ugly) : ");
            //cast the user's input to the eVehicleCondition type.
            vehicleCondition = (Vehicle.eVehicleCondition)
                                Int32.Parse(Console.ReadLine());

            Console.WriteLine("Vehicle Type: ");
            //we only need to check the first letter.
            vehicleType = Console.ReadLine()[0];

            switch(char.ToLower(vehicleType))
            {
                case 'c': //Car
                    //prompt for correct capacity type.
                    Console.WriteLine("Passenger Capacity: ");
                    //parse the input.
                    vehicleCapacity = Int32.Parse(Console.ReadLine());
                    //create a new instance of the Car class.
                    v = new Car(vehicleMake, vehicleModel, vehicleCondition, vehiclePrice, vehicleCapacity);
                    break;

                case 't': //Truck
                    //prompt for the correct capacity type.
                    Console.WriteLine("Cargo Capacity: ");
                    //parse the input.
                    vehicleCapacity = Int32.Parse(Console.ReadLine());
                    //create a new instance of the Truck class.
                    v = new Truck(vehicleMake, vehicleModel, vehicleCondition, vehiclePrice, vehicleCapacity);
                    break;

                case 'm': //Motorbike
                    //prompt for the correct capacity type.
                    Console.WriteLine("Engine capacity: ");
                    //parse the input.
                    vehicleCapacity = Int32.Parse(Console.ReadLine());
                    //create a new instance of the Motorbike class.
                    v = new Motorbike(vehicleMake, vehicleModel, vehicleCondition, vehiclePrice, vehicleCapacity);
                    break;

                default : //invalid input.
                    Console.WriteLine("Invalid vehicle type. Returning to main menu...");
                    // stop executing this method, return to the menu.
                    return;

                    break;
            }

            //add the new vehicle to the array.
            vehicleArray[numVehicles] = v;
            // increment the count.
            numVehicles = numVehicles + 1;

            //clear the console.
            Console.Clear();

            Console.WriteLine("Vehicle Added!");
        }

        //displays a menu and prompts the user to amke a selection.
        public void DisplayMenu()
        {
            //this method clears the screen.
            Console.Clear();

            Console.WriteLine("Vehicle Tracking");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("1.   Add a vehicle");
            Console.WriteLine("2.   Display all vehicles");
            Console.WriteLine("3.   Display all cars");
            Console.WriteLine("4.   Display all trucks");
            Console.WriteLine("5.   Display all motorbikes");
            Console.WriteLine("6.   Exit");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Please make your choice: ");
        }

        //execute the user's choice.
        public void ExecuteChoice(char c)
        {
            //this method clears the screen.
            Console.Clear();

            switch (c)
            {
                case '1' : //Add a vehicle.
                    AddVehicle();
                    break;

                case '2' : //Display all vehicles.
                    DisplayAllVehicles();
                    break;

                case '3' : //Display all cars.
                    DisplayAllCars();
                    break;

                case '4' : //Display all trucks.
                    DisplayAllTrucks();
                    break;

                case '5' : //Display all motorbikes.
                    DisplayAllMotorbikes();
                    break;

                case '6' : //Exit.
                    Console.WriteLine("Goodbye!");
                    break;

                default : //invalid input.
                    Console.WriteLine("Please enter a number between 1 and 6");
                    break;
            }

            //Pause.
            Console.WriteLine("Please press any key to continue...");
            Console.ReadLine();
        }

        //constructor.
        public Program()
        {
            char choice = ' ';

            while (choice != '6')
            {
                //display the menu.
                DisplayMenu();
                //read in the user's choice.
                choice = Console.ReadLine()[0];
                //perform the requested operation.
                ExecuteChoice(choice);
            }
        }


        static void Main(string[] args)
        {
            new Program();
        }
    }
}
