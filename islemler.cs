using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace görüntü
{
    class islemler
    {
        public Bitmap negative(Bitmap bitmap)
        {
            Bitmap sonuc = new Bitmap(bitmap.Width, bitmap.Height);
            Color ilk_renk, ikinci_renk;
            int r, g, b;
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    ilk_renk = bitmap.GetPixel(i, j);
                    r = 255 - ilk_renk.R;
                    g = 255 - ilk_renk.G;
                    b = 255 - ilk_renk.B;
                    ikinci_renk = Color.FromArgb(r, g, b);
                    sonuc.SetPixel(i, j, ikinci_renk);
                }
            }
            return sonuc;
        }
        public Bitmap grey(Bitmap bitmap)
        {
            Bitmap sonuc2 = new Bitmap(bitmap.Width, bitmap.Height);
            Color birinci_renk, diger_renk;
            double ton;
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    birinci_renk = bitmap.GetPixel(i, j);
                    ton = birinci_renk.R * 0.299 + birinci_renk.G * 0.587 + birinci_renk.B * 0.114;
                    diger_renk = Color.FromArgb(Convert.ToInt16(ton), Convert.ToInt16(ton), Convert.ToInt16(ton));
                    sonuc2.SetPixel(i, j, diger_renk);
                }
            }
            return sonuc2;
        }
        public Bitmap whiteblack(Bitmap bitmap)
        {
            Bitmap sonuc3 = new Bitmap(bitmap.Width, bitmap.Height);
            Color birinci_renk, diger_renk;
            double ton;
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    birinci_renk = bitmap.GetPixel(i, j);
                    ton = birinci_renk.R * 0.299 + birinci_renk.G * 0.587 + birinci_renk.B * 0.114;
                    if (ton <= 128)
                    {
                        diger_renk = Color.FromArgb(0, 0, 0);
                        sonuc3.SetPixel(i, j, diger_renk);
                    }
                    else
                    {
                        diger_renk = Color.FromArgb(255, 255, 255);
                        sonuc3.SetPixel(i, j, diger_renk);
                    }
                }
            }
            return sonuc3;
        }
        public Bitmap parlaklik(Bitmap bitmap,int x)
        {
            Bitmap sonuc4 = new Bitmap(bitmap.Width, bitmap.Height);
            int r, g, b;
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color color;
                    Color color2;
                    color = bitmap.GetPixel(i, j);
                    if (color.R+x>255)
                    {
                        r = 255;
                    }
                    else if (color.R + x < 0)
                    {
                        r = 0;
                    }
                    else
                    {
                        r = color.R + x;
                    }
                    if (color.G+x > 255)
                    {
                        g = 255;
                    }
                    else if (color.G+x<0)
                    {
                        g = 0;
                    }
                    else
                    {
                        g = color.G + x;
                    }
                    if (color.B + x >255)
                    {
                        b = 255;
                    }
                    else if (color.B + x < 0)
                    {
                        b = 0;
                    }
                    else
                    {
                        b = color.B + x;
                    }
                    color2 = Color.FromArgb(r, g, b);
                    sonuc4.SetPixel(i, j, color2);
                }
            }
            return sonuc4;
        }
    }
}
