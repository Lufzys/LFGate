using LFGate.Classes.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LFGate.Classes
{
    class Cheat
    {
        public static Thread thCheat = new Thread(new ThreadStart(CheatThread));
        public static Thread thOptimization = new Thread(new ThreadStart(OptimizationThread));

        static Color CrosshairEnemy = Color.FromArgb(241, 0, 0);
        public static void CheatThread()
        {
            while(true)
            {
                if(Settings.TriggerBot)
                {
                    if (Utils.GetForegroundProcess().ProcessName.Contains("PortalWars"))
                    {
                        Rectangle sourceRectangle = new Rectangle(Screen.PrimaryScreen.Bounds.Width / 2 - Settings.TriggerBotFov, Screen.PrimaryScreen.Bounds.Height / 2 - Settings.TriggerBotFov, Settings.TriggerBotFov * 2, Settings.TriggerBotFov * 2);
                        //var l = Utils.PixelSearch(sourceRectangle, CrosshairEnemy, 5);
                        if (Utils.DetectionPixelSearch(sourceRectangle, CrosshairEnemy, 5))
                        {
                            LFInput.LFInput.Click(LFInput.LFInput.Enums.Buttons.LEFT, (Settings.Humanize) ? 10 : Settings.PerformanceMode ? 5 : 0, Settings.Humanize);
                        }
                    }
                }

                if (LFInput.LFInput.IsKeyPushedDown(Keys.Insert))
                {
                    Settings.ShowMenu = !Settings.ShowMenu;
                    Thread.Sleep(150);
                }
                if (LFInput.LFInput.IsKeyPushedDown(Keys.End))
                {
                    Settings.StreamProof = !Settings.StreamProof;
                    Thread.Sleep(150);
                }
                if (LFInput.LFInput.IsKeyPushedDown(Keys.Home))
                {
                    Settings.PerformanceMode = !Settings.PerformanceMode;
                    Thread.Sleep(150);
                }
                if (LFInput.LFInput.IsKeyPushedDown(Keys.F1))
                {
                    Settings.TriggerBot = !Settings.TriggerBot;
                    Thread.Sleep(150);
                }
                if (LFInput.LFInput.IsKeyPushedDown(Keys.F2))
                {
                    Settings.Humanize = !Settings.Humanize;
                    Thread.Sleep(150);
                }
                if (LFInput.LFInput.IsKeyPushedDown(Keys.F3))
                {
                    Settings.DrawFOV = !Settings.DrawFOV;
                    Thread.Sleep(150);
                }
                Task.Delay(1);
                Thread.Sleep(Settings.PerformanceMode ? 25 : 5);
            }
        }

        public static void OptimizationThread()
        {
            while(true)
            {
                Thread.Sleep(10000);
                FlushMemory();
            }
        }

        public static void FlushMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                WinAPI.SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }
        }
    }
}
