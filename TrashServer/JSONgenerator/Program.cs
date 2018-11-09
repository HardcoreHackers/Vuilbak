using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace JSONgenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            TrashCanLevel[] trashCans = new TrashCanLevel[1799];
            for (int i = 0; i < 1799; i++)
            {
                trashCans[i]= new TrashCanLevel() { Level = i%100, ID = i };
            }
            
            string json = JsonConvert.SerializeObject(trashCans);
            Console.WriteLine(json);
            File.WriteAllText(@"trash.json",json);
            Console.ReadLine();
        }
    }
}
