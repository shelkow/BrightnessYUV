using System.Windows.Forms;
using System.Drawing;
using BrightnessYUV.RGBthing;
using BrightnessYUV.YUVthing;
using System.Security.Policy;
using System.Reflection.Emit;

namespace BrightnessYUV
{
    namespace RGBthing
    {
        public class RGB
        {
            private int _x_p;
            private int _y_p;

            private int _r;
            private int _g;
            private int _b;

            public RGB(int r, int g, int b, int xp, int yp)
            {
                this._r = r;
                this._g = g;
                this._b = b;
                this._x_p = xp;
                this._y_p = yp;
            }

            public int R
            {
                get { return this._r; }
                set { this._r = value; }
            }

            public int G
            {
                get { return this._g; }
                set { this._g = value; }
            }

            public int B
            {
                get { return this._b; }
                set { this._b = value; }
            }
            public int pointX
            {
                get { return this._x_p; }
                set { this._x_p = value; }
            }
            public int pointY
            {
                get { return this._y_p; }
                set { this._y_p = value; }
            }
        }
    }
    namespace YUVthing
    {
        public class YUV
        {
            private int _x_p;
            private int _y_p;

            private double _y;
            private double _u;
            private double _v;

            public YUV(double y, double u, double v, int xp, int yp)
            {
                this._y = y;
                this._u = u;
                this._v = v;
                this._x_p = xp;
                this._y_p = yp;
            }

            public double Y
            {
                get { return this._y; }
                set { this._y = value; }
            }

            public double U
            {
                get { return this._u; }
                set { this._u = value; }
            }

            public double V
            {
                get { return this._v; }
                set { this._v = value; }
            }
            public int pointX
            {
                get { return this._x_p; }
                set { this._x_p = value; }
            }
            public int pointY
            {
                get { return this._y_p; }
                set { this._y_p = value; }
            }
        }
    }
    public partial class Form1 : Form
    {
       
        RGB[] array_rgb = new RGB[300000];
        YUV[] array_yuv = new YUV[300000];
        Bitmap bpm;
        Bitmap first_image;
        
      
        int trackbar_state = 0;

        public static YUV RGBToYUV(RGB rgb)
        {
            // Y = 0,299 х R +0,587 х G +0,114 х B;
            //U = -0,14713 х R – 0,28886 х G +0,436 х B +128;
            // V = 0,615 х R – 0,51499 х G – 0,10001 х B +128;
            double y = 0.299 * rgb.R + 0.587 * rgb.G + 0.114 * rgb.B;
            double u = -0.14713 * rgb.R - 0.28886 * rgb.G + 0.436 * rgb.B + 128;
            double v = 0.615 * rgb.R - 0.51499 * rgb.G + -0.10001 * rgb.B + 128;
            int x_ = rgb.pointX;
            int y_ = rgb.pointY;
            return new YUV(y, u, v, x_, y_);
        }
        public static RGB YUVToRGB(YUV yuv)
        {
            //R = Y + 1,13983 х (V – 128);
            //G = Y – 0,39465 х(U – 128) – 0,58060 х(V – 128);
            //B = Y + 2,03211 х(U – 128);
            int r = (int)(yuv.Y + 1.13983 * (yuv.V - 128));
            int g = (int)(yuv.Y - 0.39465 * (yuv.U - 128) - 0.58060 * (yuv.V - 128));
            int b = (int)(yuv.Y + 2.03211 * (yuv.U - 128));

            int x_ = yuv.pointX;
            int y_ = yuv.pointY;

            r = Math.Max(0, Math.Min(255, r));
            g = Math.Max(0, Math.Min(255, g));
            b = Math.Max(0, Math.Min(255, b));

            return new RGB(r, g, b, x_, y_);
        }
        void TransformToYuv()
        {
            for (int Xcount = 0; Xcount < first_image.Width; Xcount++)
            {
                for (int Ycount = 0; Ycount < first_image.Height; Ycount++)
                {
                    hex_color[buff_index] = first_image.GetPixel(Xcount, Ycount).Name;//hex

                    buff_index++;

                }
            }
            buff_index = 0;
            int[] array = new int[3];

            int[] hex_to_rgb(int hex)
            {
                array[0] = 0;
                array[1] = 0;
                array[2] = 0;
                int r = (hex & 0xff0000) >> 16;
                int g = (hex & 0xff00) >> 8;
                int b = (hex & 0xff);
                array[0] = r;
                array[1] = g;
                array[2] = b;
                return array;
            }

            int hex;
            int[] rgb_pixels = new int[3];

            int[] show_rgb(int id)
            {
                hex = Convert.ToInt32(hex_color[id], 16);
                rgb_pixels = hex_to_rgb(hex);

                return rgb_pixels;
            }

            int iterator = 0;
            for (int i = 0; i < first_image.Width; i++)
            {
                for (int j = 0; j < first_image.Height; j++)
                {
                    array_rgb[iterator] = new RGB(show_rgb(iterator)[0], show_rgb(iterator)[1], show_rgb(iterator)[2], i, j);
                    array_yuv[iterator] = RGBToYUV(array_rgb[iterator]);
                    iterator++;
                }

            }
        }
 
        public Form1()
        {
           InitializeComponent();
            
           bpm = new Bitmap(@"C:\Users\shelk\Desktop\dom.jpg");
        
           first_image = new Bitmap(bpm, new Size(550, 400));
           pictureBox1.Image = first_image;
           TransformToYuv();

        }

        string[] hex_color = new string[500000];
        int buff_index = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            switch (trackbar_state)
            {
                case 0:
                    break;
                case 1:
                    for (int i = 0; i < first_image.Width * first_image.Height; i++)
                    {
                        array_yuv[i].Y += trackBar1.Value;

                        array_yuv[i].U += trackBar1.Value;

                        array_yuv[i].V += trackBar1.Value;

                    }
                    break;
                case 2:
                    for (int i = 0; i < first_image.Width * first_image.Height; i++)
                    {
                        array_yuv[i].Y += trackBar2.Value;
                    }

                    break;
                case 3:
                    for (int i = 0; i < first_image.Width * first_image.Height; i++)
                    {
                        array_yuv[i].U += trackBar3.Value;

                    }

                    break;
                case 4:
                    for (int i = 0; i < first_image.Width * first_image.Height; i++)
                    {
                        array_yuv[i].V += trackBar4.Value;
                    }
                    break;
            }
            RGB[] array_rgb2 = new RGB[first_image.Width * first_image.Height];
            int iterator2 = 0;
            for (int i = 0; i < first_image.Width; i++)
            {
                for (int j = 0; j < first_image.Height; j++)
                {
                    array_rgb2[iterator2] = YUVToRGB(array_yuv[iterator2]);
                    iterator2++;
                }
            }

            int iterator3 = 0;
            for (int i = 0; i < first_image.Width; i++)
            {
                for (int j = 0; j < first_image.Height; j++)
                {
                    first_image.SetPixel(i, j, Color.FromArgb(255, array_rgb2[iterator3].R, array_rgb2[iterator3].G, array_rgb2[iterator3].B));
                    iterator3++;
                }

            }
            pictureBox1.Image = first_image;   
        }
   
        private void button3_Click(object sender, EventArgs e)
        {   
            trackBar1.Value = 0;
            trackBar2.Value = 0;
            trackBar3.Value = 0;
            trackBar4.Value = 0;
            label6.Text = "";
            first_image = new Bitmap(bpm, new Size(550, 400));
            TransformToYuv();
            pictureBox1.Image = first_image;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    first_image = new Bitmap(openFileDialog.FileName);
                    bpm = new Bitmap(openFileDialog.FileName);
                    first_image = new Bitmap(bpm, new Size(550, 400)); 
                    TransformToYuv();

                    pictureBox1.Image = first_image;
                  
                }
            }
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            trackbar_state = 1;

            pictureBox1.Image = first_image;
            trackBar1.Minimum = 0;
            trackBar1.Maximum = 100;
            label6.Text="Общая яркость:"+trackBar1.Value.ToString();

        }
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            trackbar_state = 2;

            pictureBox1.Image = first_image;
            trackBar2.Minimum = 0;
            trackBar2.Maximum = 100;
            label6.Text = "яркость Y:" + trackBar2.Value.ToString();

        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            trackbar_state = 3;

            pictureBox1.Image = first_image;
            trackBar3.Minimum = 0;
            trackBar3.Maximum = 100;
            label6.Text = "яркость U:" + trackBar3.Value.ToString();

        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            trackbar_state = 4;

            pictureBox1.Image = first_image;
            trackBar4.Minimum = 0;
            trackBar4.Maximum = 100;
            label6.Text = "яркость V:" + trackBar4.Value.ToString();

        }
    }
}