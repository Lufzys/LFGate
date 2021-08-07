using LFGate.Classes;
using LFGate.Classes.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFGate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = Utils.RandomString(new Random().Next(8, 16));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("LFGate - Splitgate Triggerbot (Color based)");
            Overlay overlay = new Overlay();
            Cheat.thCheat.Start();
            Cheat.thOptimization.Start();
            overlay.Run();
        }
    }
}
