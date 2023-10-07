using System.Windows.Forms;
using System.Drawing;
using BrightnessYUV.RGBthing;
using BrightnessYUV.YUVthing;
using System.Security.Policy;

namespace BrightnessYUV
{
    namespace RGBthing
    {
        public class RGB
        {
            private int _r;
            private int _g;
            private int _b;

            public RGB(int r, int g, int b)
            {
                this._r = r;
                this._g = g;
                this._b = b;
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
        }
    }
    namespace YUVthing
    {
        public class YUV
        {
            private double _y;
            private double _u;
            private double _v;

            public YUV(double y, double u, double v)
            {
                this._y = y;
                this._u = u;
                this._v = v;
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
        }
    }


    public partial class Form1 : Form
    {
        Bitmap bpm;
        Bitmap first_image;
        public static YUV RGBToYUV(RGB rgb)
        {
           //Y = 0,299 х R + 0,587 х G + 0,114 х B;
           // U = -0,14713 х R – 0,28886 х G +0,436 х B +128;
           // V = 0,615 х R – 0,51499 х G – 0,10001 х B +128;
            double y = rgb.R * .299000 + rgb.G * .587000 + rgb.B * .114000;
            double u = rgb.R * -.168736 + rgb.G * -.331264 + rgb.B * .500000 + 128;
            double v = rgb.R * .500000 + rgb.G * -.418688 + rgb.B * -.081312 + 128;

            return new YUV(y, u, v);
        }

        public Form1()
        {
            InitializeComponent();
            bpm = new Bitmap(@"C:\Users\shelk\Desktop\zakat.jpg");
            
            first_image = new Bitmap(bpm, new Size(400, 400));
            pictureBox1.Image = first_image;

        }

        /*
        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    originalImage = new Bitmap(openFileDialog.FileName);
                    pictureBox1.Image = originalImage;
                    adjustedImage = new Bitmap(originalImage);
                    pictureBox1.Image = adjustedImage;
                }
            }
        }
        */
        private void UpdateAdjustedImage()
        {

        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            UpdateAdjustedImage();
        }
        string[] hex_color = new string[200000];
        string[] yuv_color = new string[200000];
        int[,] indexarr = new int[1000, 1000];
        int buff_index = 0;
        int size = 160000;

        private void button2_Click(object sender, EventArgs e)
        {
            //Заполнение массива hex_color
            for (int Xcount = 0; Xcount < 400; Xcount++)
            {
                for (int Ycount = 0; Ycount < 400; Ycount++)
                {
                    hex_color[buff_index] = first_image.GetPixel(Xcount, Ycount).Name;//hex

                    indexarr[Xcount, Ycount] = buff_index;
                    buff_index++;

                }
            }
            int[] hex_to_rgb(int rgb)
            {
                int[] array = new int[3];
                array[0] = 0;
                array[1] = 0;
                array[2] = 0;
                int r = (rgb & 0xff0000) >> 16;
                int g = (rgb & 0xff00) >> 8;
                int b = (rgb & 0xff);
                array[0] = r;
                array[1] = g;
                array[2] = b;
                return array;
            }
  
            int hex;
            int[] rgb_pixels = new int[200000];
            //поиск пиксела по id, возврат пиксела в массив rgb(255)(255)(255)
            int[] show_rgb(int id)
            {

               hex = Convert.ToInt32(hex_color[id], 16);
               rgb_pixels = hex_to_rgb(hex);
                
                return rgb_pixels;
            }

      
            RGB[] array_rgb = new RGB[size];
            YUV[] array_yuv = new YUV[size];
          
            for (int i = 0; i < size; i++)
            {
                array_rgb[i] = new RGB(show_rgb(i)[0], show_rgb(i)[1], show_rgb(i)[2]);
                //  label1.Text += "\n"+ array_rgb[i].R.ToString() + "|"+ array_rgb[i].G.ToString() +"|"+ array_rgb[i].B.ToString();

            }
            label1.Text += "Все";
            
            for (int i = 0; i < 300; i++)
            {
                array_yuv[i] = RGBToYUV(array_rgb[i]);
                //  label1.Text += "\n"+ array_rgb[i].R.ToString() + "|"+ array_rgb[i].G.ToString() +"|"+ array_rgb[i].B.ToString();
            }
            label1.Text += "Все2";
            

        //    for (int i = 0; i < 10; i++)
        //    {
               // label1.Text += "\n" + array_yuv[i].Y.ToString() + "|" + array_yuv[i].U.ToString() + "|" + array_yuv[i].V.ToString();
        //    }


            // int constx = 0;
            //  int consty = 1;
            /*
        int[] return_coord(int index)
        {
            int[] array = new int[400];
            for (int i = 0; i < 400; i++)
            {
                for (int j = 0; j < 400; j++)
                {
                    if (indexarr[i, j] == index)
                    {
                        array[0] = i;
                        array[1] = j;
                    }
                }

            }
            return array;
        }
      */
            // label1.Text += "\nКоординаты пиксела: x=" + return_coord(400)[constx].ToString() + " y=" + return_coord(400)[consty].ToString();
            // label1.Text += "\nКоординаты пиксела: x=" + return_coord(0)[constx].ToString() + " y=" + return_coord(0)[consty].ToString();


            //   label1.Text += "\n rgb=\n" + show_rgb(coord_element)[0].ToString() + "|" + show_rgb(coord_element)[1].ToString() + "|" + show_rgb(coord_element)[2].ToString();
            //    label1.Text += "\n yuv=";
            //    label1.Text += "\n" + Convert.ToInt32(array_yuv[coord_element].Y).ToString() + "|" + Convert.ToInt32(array_yuv[coord_element].U).ToString() + "|" + Convert.ToInt32(array_yuv[coord_element].V).ToString();
            /*
              for (int i = 0; i < 100000; i++)
              {
                 first_image.SetPixel(return_coord(i)[constx], return_coord(i)[consty], Color.Black);

                  //   label1.Text += "\nКоординаты пиксела: x=" + return_coord(i)[constx].ToString() + " y=" + return_coord(i)[consty].ToString();

              }
              pictureBox1.Image = first_image;
            */

            /* 
             // Set each pixel in myBitmap to black.
             for (int Xcount = 0; Xcount < first_image.Width; Xcount++)
             {
                 for (int Ycount = 0; Ycount < first_image.Height; Ycount++)
                 {
                       label1.Text+=first_image.GetPixel(Xcount,Ycount).Name;
                  //   first_image.SetPixel(Xcount, Ycount, Color.Black);
                 }
             }
          //   pictureBox1.Image = first_image;


         }

         private void label1_Click(object sender, EventArgs e)
         {

         }
            */
        }
    }
}
