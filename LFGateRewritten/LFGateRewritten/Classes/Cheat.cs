using LFGateRewritten.Classes.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LFGateRewritten.Classes.WinAPI;

namespace LFGateRewritten.Classes
{
    class Cheat
    {
        public static Thread thCheat = new Thread(new ThreadStart(CheatThread));
        public static Thread thOptimization = new Thread(new ThreadStart(OptimizationThread));

        public static Color CrosshairOnEnemy = Color.FromArgb(254, 0, 0);
        public static void CheatThread()
        {
            while(true)
            {
                if(Settings.TriggerBot)
                {
                    if (Utils.GetForegroundProcess().ProcessName.Contains("PortalWars"))
                    {
                        RECT region;
                        GetWindowRect(WinAPI.GetForegroundWindow(), out region);
                        int windowWidth = region.right - region.left;
                        int windowHeight = region.bottom - region.top;

                        Bitmap result = ScreenCapture.CaptureRegion(new System.Drawing.Rectangle(region.left + (windowWidth / 2) - 1, region.top + (windowHeight / 2) - 1, 1, 1));
                        if (result.GetPixel(0, 0) == CrosshairOnEnemy)
                        {
                            LFInput.LFInput.Click(LFInput.LFInput.Enums.Buttons.LEFT, (Settings.Humanize) ? 90 : Settings.Performance ? 15 : 0, Settings.Humanize);
                        }
                    }
                }

                if(LFInput.LFInput.IsKeyPushedDown(Keys.F1))
                {
                    Settings.TriggerBot = !Settings.TriggerBot;
                    Thread.Sleep(150);
                }
                if (LFInput.LFInput.IsKeyPushedDown(Keys.F2))
                {
                    Settings.Humanize = !Settings.Humanize;
                    Thread.Sleep(150);
                }
                if (LFInput.LFInput.IsKeyPushedDown(Keys.Home))
                {
                    Settings.Performance = !Settings.Performance;
                    Thread.Sleep(150);
                }
                Thread.Sleep(Settings.Performance ? 30 : 15);
            }
        }

        public static void OptimizationThread()
        {
            while (true)
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
