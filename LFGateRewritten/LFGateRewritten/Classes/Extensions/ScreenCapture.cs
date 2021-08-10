using LFGateRewritten.Classes.Variable;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFGateRewritten.Classes.Extensions
{
    class ScreenCapture
    {
        public static Bitmap CaptureRegion(Rectangle region)
        {
            IntPtr desktophWnd;
            IntPtr desktopDc;
            IntPtr memoryDc;
            IntPtr bitmap;
            IntPtr oldBitmap;
            bool success;
            Bitmap result;

            desktophWnd = WinAPI.GetDesktopWindow();
            desktopDc = WinAPI.GetWindowDC(desktophWnd);
            memoryDc = WinAPI.CreateCompatibleDC(desktopDc);
            bitmap = WinAPI.CreateCompatibleBitmap(desktopDc, region.Width, region.Height);
            oldBitmap = WinAPI.SelectObject(memoryDc, bitmap);

            success = WinAPI.BitBlt(memoryDc, 0, 0, region.Width, region.Height, desktopDc, region.Left, region.Top, Constants.SRCCOPY | Constants.CAPTUREBLT);

            try
            {
                if (!success)
                {
                    //throw new Win32Exception();
                    return null;
                }

                result = Image.FromHbitmap(bitmap);
            }
            finally
            {
                WinAPI.SelectObject(memoryDc, oldBitmap);
                WinAPI.DeleteObject(bitmap);
                WinAPI.DeleteDC(memoryDc);
                WinAPI.ReleaseDC(desktophWnd, desktopDc);
            }

            return result;
        }
    }
}
