using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evolution
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Initialize();
            InitializeComponent();
        }

        public void Show(string _input)
        {
            MessageBox.Show(_input);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Display.Initialize(25);
            DirectBitmap db = new DirectBitmap(64, 64);
            db.Bitmap = new Bitmap("a.png");

            Display.DrawObject(0, 0, db);
        }
    }
}
