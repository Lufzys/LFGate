using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameOverlay.Drawing;
using GameOverlay.Windows;
using LFGate.Classes.Classes;

namespace LFGate.Classes
{
    class Overlay
    {
        private readonly GraphicsWindow _window;

        public Overlay()
        {
			var gfx = new Graphics()
			{
				MeasureFPS = true,
				PerPrimitiveAntiAliasing = true,
				TextAntiAliasing = true
			};

			_window = new GraphicsWindow(0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, gfx)
			{
				FPS = 15,
				IsTopmost = true,
				IsVisible = true
			};

			_window.DestroyGraphics += window_DestroyGraphics;
			_window.DrawGraphics += window_DrawGraphics;
			_window.SetupGraphics += window_SetupGraphics;
		}

		public void Run()
        {
			_window.Create();
			_window.Join();
		}

        private void window_SetupGraphics(object sender, SetupGraphicsEventArgs e)
        {

        }

        private void window_DrawGraphics(object sender, DrawGraphicsEventArgs e)
        {
			var gfx = e.Graphics;
			gfx.ClearScene();
			if (Utils.GetForegroundProcess().ProcessName.Contains("PortalWars"))
            {
				if(Settings.ShowMenu)
                {
					gfx.DrawTextWithBackground(gfx.CreateFont("Consolas", 14), gfx.CreateSolidBrush(255, 255, 255), gfx.CreateSolidBrush(0, 0, 0), new Point(10, 10), "LFGate - Splitgate Trigger Bot (Color Based)");
					gfx.DrawTextWithBackground(gfx.CreateFont("Consolas", 14), gfx.CreateSolidBrush(255, 255, 255), gfx.CreateSolidBrush(0, 0, 0), new Point(10, 30), "Coded by Lufzys 1337");
					gfx.DrawTextWithBackground(gfx.CreateFont("Consolas", 14), gfx.CreateSolidBrush(255, 255, 0), gfx.CreateSolidBrush(0, 0, 0), new Point(10, 55), "Menu Key    - Insert");
					gfx.DrawTextWithBackground(gfx.CreateFont("Consolas", 14), (Settings.StreamProof) ? gfx.CreateSolidBrush(0, 255, 0) : gfx.CreateSolidBrush(255, 0, 0), gfx.CreateSolidBrush(0, 0, 0), new Point(10, 75), "Stream Proof   - End");
					gfx.DrawTextWithBackground(gfx.CreateFont("Consolas", 14), (Settings.PerformanceMode) ? gfx.CreateSolidBrush(0, 255, 0) : gfx.CreateSolidBrush(255, 0, 0), gfx.CreateSolidBrush(0, 0, 0), new Point(10, 95), "Performance   - Home");
					gfx.DrawTextWithBackground(gfx.CreateFont("Consolas", 14), (Settings.TriggerBot) ? gfx.CreateSolidBrush(0, 255, 0) : gfx.CreateSolidBrush(255, 0, 0), gfx.CreateSolidBrush(0, 0, 0), new Point(10, 120), "Toggle          - F1");
					gfx.DrawTextWithBackground(gfx.CreateFont("Consolas", 14), (Settings.Humanize) ? gfx.CreateSolidBrush(0, 255, 0) : gfx.CreateSolidBrush(255, 0, 0), gfx.CreateSolidBrush(0, 0, 0), new Point(10, 140), "Humanize        - F2");
					gfx.DrawTextWithBackground(gfx.CreateFont("Consolas", 14), (Settings.DrawFOV) ? gfx.CreateSolidBrush(0, 255, 0) : gfx.CreateSolidBrush(255, 0, 0), gfx.CreateSolidBrush(0, 0, 0), new Point(10, 160), "Draw Fov        - F3");
				}
				if(Settings.DrawFOV)
                {
					Point SSize = new Point(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
					gfx.DrawRectangle(gfx.CreateSolidBrush(255, 0, 0), new Rectangle((SSize.X - Settings.TriggerBotFov) / 2, (SSize.Y - Settings.TriggerBotFov) / 2, ((SSize.X - Settings.TriggerBotFov) / 2) + Settings.TriggerBotFov, ((SSize.Y - Settings.TriggerBotFov) / 2) + Settings.TriggerBotFov), 1f);
				}
				WinAPI.SetWindowDisplayAffinity(_window.Handle ,Settings.StreamProof ? WinAPI.DisplayAffinity.Monitor : WinAPI.DisplayAffinity.None);
			}
		}

		private void window_DestroyGraphics(object sender, DestroyGraphicsEventArgs e)
        {

        }
    }
}
