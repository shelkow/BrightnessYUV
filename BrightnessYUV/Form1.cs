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
        Bitmap bpm;
        Bitmap first_image;

        RGB[] array_rgb = new RGB[3000000];
        YUV[] array_yuv = new YUV[3000000];
        int trackbar_state = 0;

        public static YUV RGBToYUV(RGB rgb)
        {
            double y = 0.299 * rgb.R + 0.587 * rgb.G + 0.114 * rgb.B;
            double u = -0.14713 * rgb.R - 0.28886 * rgb.G + 0.436 * rgb.B + 128;
            double v = 0.615 * rgb.R - 0.51499 * rgb.G + -0.10001 * rgb.B + 128;
            int x_ = rgb.pointX;
            int y_ = rgb.pointY;
            return new YUV(y, u, v, x_, y_);
        }
        public static RGB YUVToRGB(YUV yuv)
        {

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

            int[] hex_to_rgb(int hex)
            {
                int[] array = new int[3];
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
            int[] rgb_pixels = new int[first_image.Width * first_image.Height];

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
            
           bpm = new Bitmap(@"C:\Users\shelk\Desktop\dm.png");
            

           first_image = new Bitmap(bpm, new Size(495, 300));
           pictureBox1.Image = first_image;
      //      int size_img = first_image.Width * first_image.Height;

           TransformToYuv();

        }

        string[] hex_color = new string[200000];
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
            first_image = new Bitmap(bpm, new Size(495, 300));
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
                    first_image = new Bitmap(bpm, new Size(495, 300)); 
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

/*
        float GetPixelBrightness(int r, int g, int b)
        {
            float brightness = (r * 0.299f + g * 0.587f + b * 0.114f) / 256;
            return brightness;
        }
        */
//y=0.299R+0.587G+0.114B relative luminance
//y=0.2926R+0.7152G+0.0722B //ôîðìóëà ÿðêîñòè
//ßðêîñòü !!!



/* static String HexConverter(RGB rgb)
{
    return "#" + rgb.R.ToString("X2") + rgb.G.ToString("X2") + rgb.B.ToString("X2");
}
*/
/*
  for (int i = 0; i < 10; i++)
  {
      array_yuv[i].Y += 10;
  }
  int curr_pixel = 0;

  label1.Text = "yuv="+array_yuv[curr_pixel].Y+" "+array_yuv[curr_pixel].U+ " "+ array_yuv[curr_pixel].V + " \nÊîîðäèíàòû ïèêñåëà=" +
      + array_yuv[curr_pixel].pointX+" "+ array_yuv[curr_pixel].pointY;

  */
//Ïåðåâîä îáðàòíî â RGB


/*
label1.Text += "\nrgb=" + array_rgb2[curr_pixel].R + " " + array_rgb2[curr_pixel].G + " " + array_rgb2[curr_pixel].B + " \nÊîîðäèíàòû ïèêñåëà=" +
+array_rgb2[curr_pixel].pointX + " " + array_rgb2[curr_pixel].pointY;
*/
/*

*/
//Çàïîëíåíèå ìàññèâà hex êîäàìè
/*
for (int i = 0; i < size; i++)
{
    resulthex[i]= "\nhex=" + HexConverter(array_rgb[i]);

}
for (int i = 0; i < 10; i++)
{
    label1.Text += resulthex[i];

}
*/

// array_rgb2[0] = YUVToRGB(array_yuv[0]);

/*
for (int i = 400; i < 800; i++)
{
    label1.Text += "\n" + array_rgb2[i].R + " " + array_rgb2[i].G + " " + array_rgb2[i].B;
    label1.Text += "\n" + array_rgb2[i].pointX + " " + array_rgb2[i].pointY;
}

/*
    array_yuv[0].Y = 10;
for (int i = 0; i < 100; i++)
{


}
*/
//label1.Text += "\n"+ array_yuv[i].Y.ToString() + "|"+ array_yuv[i].U.ToString() +"|"+ array_yuv[i].V.ToString();




/*
for (int i = 0; i < 300; i++)
{
    array_yuv[i] = RGBToYUV(array_rgb[i]);
    //  label1.Text += "\n"+ array_rgb[i].R.ToString() + "|"+ array_rgb[i].G.ToString() +"|"+ array_rgb[i].B.ToString();
}
label1.Text += "Âñå2";
*/

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
// label1.Text += "\nÊîîðäèíàòû ïèêñåëà: x=" + return_coord(400)[constx].ToString() + " y=" + return_coord(400)[consty].ToString();
// label1.Text += "\nÊîîðäèíàòû ïèêñåëà: x=" + return_coord(0)[constx].ToString() + " y=" + return_coord(0)[consty].ToString();


//   label1.Text += "\n rgb=\n" + show_rgb(coord_element)[0].ToString() + "|" + show_rgb(coord_element)[1].ToString() + "|" + show_rgb(coord_element)[2].ToString();
//    label1.Text += "\n yuv=";
//    label1.Text += "\n" + Convert.ToInt32(array_yuv[coord_element].Y).ToString() + "|" + Convert.ToInt32(array_yuv[coord_element].U).ToString() + "|" + Convert.ToInt32(array_yuv[coord_element].V).ToString();
/*
  for (int i = 0; i < 100000; i++)
  {
     first_image.SetPixel(return_coord(i)[constx], return_coord(i)[consty], Color.Black);

      //   label1.Text += "\nÊîîðäèíàòû ïèêñåëà: x=" + return_coord(i)[constx].ToString() + " y=" + return_coord(i)[consty].ToString();

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