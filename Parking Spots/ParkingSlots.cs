using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Parking_Spots
{
    public enum instruction { Small, Medium , Large }
    public class Car
    {
        public string Size { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public Car(string sz,string color,string brand)
        {
            Size = sz;
            Color = color;
            Brand = brand;
        }
        public override string ToString()
        {
            return Size+" "+Color+" "+ Brand;
        }
    }

    public class ParkingSpot
    {
        public int SpotNumber { get; set; }
        public Car Car { get; set; }
        public bool Available { get; set; }
        public ParkingSpot(Car car, int num, bool available)
        {
            Car = car;
            SpotNumber = num;
            Available = available;
        }
       

    }
    public class ParkingSlots
    {
        public ParkingSlots(int n)
        {
            ParkingLotCount = n;
        }
        public int ParkingLotCount { get; set; }
        public List<ParkingSpot> ParkingSpots { get; set; }=new List<ParkingSpot>();

        // ["park", "1", "Small", "Silver", "BMW"]
        public string  ParkCar(Car car, int spot)
        {
            //Check if spot is availbale-if park then call this method
            //addcard from game
            if(!ParkingSpots.Any(x=>x.SpotNumber== spot))
            {
                //park the car
                ParkingSpots.Add(new ParkingSpot(car, spot,false));
                return "parked";
            }
            else
            {
                //find next spot
                for(int i = spot+1; i <= ParkingLotCount; i++)
                {
                    if (!ParkingSpots.Any(x => x.SpotNumber == i))
                    {
                        ParkingSpots.Add(new ParkingSpot(car, i, false));
                        return "parked";
                    }
                   
                }
                return "leave";

            }
          
        }

        internal void ParkingSystem(List<string> inst)
        {
            if (inst[0] == "park")
            {
                Car newCar = new Car(inst[2], inst[3], inst[4]);
                ParkCar(newCar, Convert.ToInt32(inst[1]));
            }
            else if (inst[0] == "remove")
            {
                RemoveCar(Convert.ToInt32(inst[1]));
            }
            else if (inst[0] == "print")
            {
               var pSpot= PrintSpot(Convert.ToInt32(inst[1]));
                Console.WriteLine( pSpot);
            }
            else if (inst[0] == "print_free_spots")
            {
                PrintFreeSpots();
            }
        }

        private void PrintFreeSpots()
        {
            var occupiedSpots=ParkingSpots.Where(x => x!=null && x.Available==false).Select(x=>x.SpotNumber-1);
            StringBuilder stringBuilder = new StringBuilder();
            for (int i=1;i<ParkingLotCount;i++)
            {
                if (!occupiedSpots.Contains(i))
                {

                    stringBuilder.Append(i);
                    stringBuilder.Append(',');
                }
            
            }
            Console.WriteLine(stringBuilder.ToString());
        }

        private string PrintSpot(int spot)
        {
            var pSpot=ParkingSpots[spot-1];
            if (pSpot == null)
            {
                return "Empty";
            }
            else
            {
              return  pSpot.Car.ToString();
            }
        }

        private void RemoveCar(int spot)
        {
            ParkingSpot s = ParkingSpots[spot];
            if(s.Available == false) {
                s.Available = true;
                s.Car = null;
            }
        }
    }
}
