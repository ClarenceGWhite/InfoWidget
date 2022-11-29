using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;



namespace InfoWidget
{
    public partial class Form1 : Form
    {

        //private void Form1_Paint(object sender, PaintEventArgs e)
        //{
        //    Graphics l = e.Graphics;
        //    Pen m_pen = new Pen(Color.White, 30);
        //    l.DrawLine(m_pen, 20, 20, 400, 400);
        //    //Graph.DrawLine(m_pen, new Point(1, 100), new Point(0, 50));
        //   //l.Dispose();
        //   Thread.Sleep(2500);
        //}


        

        //Create borderless form
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,                   // x-coord of upper-left corner  
            int nTopRect,                    // y-coord of upper-left corner 
            int nRightRect,                  // x-coord of lower-right corner
            int nBottomRect,                 // y-coord of lower-right corner
            int nWidthEllipse,               // height of ellipse
            int nHeightEllipse);             // width of ellipse


        
        
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            label3.Text = "This is a test";
            //Thread.Sleep(5000);
            //label3.Text = "Closed test";
        }


        //Allow borderless form to be moved
        private bool _dragging = false;
        private Point _offset;
        private Point _start_point = new Point(800, 100);
        

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging) 
            {
                Point p = PointToScreen(e.Location);      //Get the e.X and e.Y positions
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

       

        
        private void label1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);             //Exit Application
        }

        private void label3_Click(object sender, EventArgs e) 
        {
        
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
