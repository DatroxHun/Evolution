using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;
using Z0mziMath;

namespace Evolution
{
    public static class Display
    {
        private static DirectBitmap background = new DirectBitmap(Form1.instance.display.Width, Form1.instance.display.Height);
        private static DirectBitmap canvas = new DirectBitmap(Form1.instance.display.Width, Form1.instance.display.Height);

        private static int step;
        private static int tileWidth;

        public static void Initialize(int _tileWidth)
        {
            step = (int)((double)Form1.instance.display.Width / (double)_tileWidth);
            tileWidth = _tileWidth;

            for (int x = 0; x < background.Width; x++)
            {
                for (int y = 0; y < background.Height; y++)
                {
                    if (x % step == 0 || y % step == 0)
                    {
                        background.SetPixel(x, y, Color.White);
                    }
                    else
                    {
                        background.SetPixel(x, y, Color.Black);
                    }
                }
            }

            canvas.Bitmap = background.Bitmap.Clone(new Rectangle(0, 0, background.Width, background.Height), PixelFormat.Format32bppArgb);
            Refresh();
        }

        public static void DrawObject(int _x, int _y, DirectBitmap _img)
        {
            canvas.Bitmap = background.Bitmap.Clone(new Rectangle(0, 0, background.Width, background.Height), PixelFormat.Format32bppArgb);

            for (int x = 0; x < step - 1; x++)
            {
                for (int y = 0; y < step - 1; y++)
                {
                    Vector2 v = new Vector2(_x * step + 1 + x, _y * step + 1 + y);
                    Color currColor = _img.Bitmap.GetPixel((int)Math.Floor(_img.Width * (float)x / (float)step), (int)Math.Floor(_img.Height * (float)y / (float)step));
                    if (currColor.A != 0)
                    {
                        canvas.Bitmap.SetPixel(v.x, v.y, currColor);
                    }

                    //Form1.instance.Show(((int)Math.Floor(_img.Height * (float)y / (float)step)).ToString());
                }
            }

            Refresh();
        }

        public static void Refresh()
        {
            Form1.instance.display.Image = canvas.Bitmap;
            Form1.instance.display.Refresh();
        }
    }

    public class DirectBitmap : IDisposable
    {
        public Bitmap Bitmap { get; set; }
        public Int32[] Bits { get; private set; }
        public bool Disposed { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }

        protected GCHandle BitsHandle { get; private set; }

        public DirectBitmap(int width, int height)
        {
            Width = width;
            Height = height;
            Bits = new Int32[width * height];
            BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
            Bitmap = new Bitmap(width, height, width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());
        }

        public DirectBitmap(Bitmap bmp)
        {
            Width = bmp.Width;
            Height = bmp.Height;

            Bits = new Int32[Width * Height];
            BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
            Bitmap = new Bitmap(Width, Height, Width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());

            Bitmap = bmp;
        }

        public void SetPixel(int x, int y, Color colour)
        {
            int index = x + (y * Width);
            int col = colour.ToArgb();

            Bits[index] = col;
        }

        public Color GetPixel(int x, int y)
        {
            int index = x + (y * Width);
            int col = Bits[index];
            Color result = Color.FromArgb(col);

            return result;
        }

        public void Dispose()
        {
            if (Disposed) return;
            Disposed = true;
            Bitmap.Dispose();
            BitsHandle.Free();
        }
    }
}
