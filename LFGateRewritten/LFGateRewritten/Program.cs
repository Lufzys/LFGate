using LFGateRewritten.Classes;
using LFGateRewritten.Classes.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LFGateRewritten
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                string newFile = Utils.RandomString(new Random().Next(8, 16));
                File.Copy(System.Reflection.Assembly.GetExecutingAssembly().Location, newFile + ".exe");
                MD5Controller.MD5Controller.ChangeMD5(newFile + ".exe");
                ProcessStartInfo processStartInfo = new ProcessStartInfo();
                processStartInfo.FileName = newFile + ".exe";
                processStartInfo.Arguments = "-" + Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                Process.Start(processStartInfo);
                Environment.Exit(0);
            }
            else
            {
                if(args[0] != null)
                {
                    File.Delete(args[0].Substring(1, args[0].Length - 1));
                }
            }

            Cheat.thCheat.Start();
            Console.Title = Utils.RandomString(new Random().Next(8, 16));
        start:
            Console.Clear();
            Console.WriteLine("\n LFGate - Rewritten\n");
            Console.Write(" Status       [F1]  = ");
            Console.ForegroundColor = Settings.TriggerBot ? ConsoleColor.Green : ConsoleColor.Red;
            Console.Write(Settings.TriggerBot + Environment.NewLine);
            Console.ResetColor();

            Console.Write(" Humanize     [F2]  = ");
            Console.ForegroundColor = Settings.Humanize ? ConsoleColor.Green : ConsoleColor.Red;
            Console.Write(Settings.Humanize + Environment.NewLine);
            Console.ResetColor();

            Console.Write(" Performance [HOME] = ");
            Console.ForegroundColor = Settings.Performance ? ConsoleColor.Green : ConsoleColor.Red;
            Console.Write(Settings.Performance + Environment.NewLine);
            Console.ResetColor();
            Thread.Sleep(1000);
            //while (!LFInput.LFInput.IsKeyPushedDown(System.Windows.Forms.Keys.Enter)) { }
            goto start;
        }
    }
}
