// See https://aka.ms/new-console-template for more information
using Parking_Spots;

int n = 5;//int.Parse(Console.ReadLine());
int instructionsLength = 4;//int.Parse(Console.ReadLine());
List<List<string>> instructions = new List<List<string>>();
for (int i = 0; i < instructionsLength; i++)
{
    instructions.Add(SplitWords(Console.ReadLine()));
}
List<string> res = ParkingSystem(n, instructions);
foreach (string line in res)
{
    Console.WriteLine(line);
}
 static List<string> SplitWords(string s)
{
    return string.IsNullOrEmpty(s) ? new List<string>() : s.Trim().Split(' ').ToList();
}
 static List<string> ParkingSystem(int n, List<List<string>> instructions)
{
    var parking = new ParkingSlots(n);
    foreach (var inst in instructions)
    {
        parking.ParkingSystem(inst);
        //if (inst[0] == "park")
        //{
        //    parking.ParkCar(inst);
        //}
    }
    // WRITE YOUR BRILLIANT CODE HERE
    return new List<string>();
}