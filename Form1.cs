using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroceryRemake
{
    public partial class Form1 : Form
    {
        Dictionary<string, float> Fruits = new Dictionary<string, float>();
        float lbs = 0;
        string fruit= string.Empty;
        float total = 0; 
        public Form1()
        {
            InitializeComponent();
            //make button transparent over image 
            btnApple.Parent = FP;
            btnBanana.Parent = FP;
            btbGrape.Parent = FP;
            btnCherry.Parent = FP;
            btnLemon.Parent = FP;
            btnPear.Parent = FP;
            btnPine.Parent = FP;
            btnStraw.Parent = FP;
            btnOrange.Parent = FP;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Fruits.Add("Pineapple", 2.99f);
            Fruits.Add("Cherry\t", 1.99f);
            Fruits.Add("Pear\t\t", 1.49f);
            Fruits.Add("Lemon\t", 0.99f);
            Fruits.Add("Grape\t", 1.68f);
            Fruits.Add("Apple\t", 1.35f);
            Fruits.Add("Banana\t", 0.49f);
            Fruits.Add("Strawberry", 2.78f);
            Fruits.Add("Orange\t", 1.25f);
        }
        public float CalcPrice(string Fruit, float lbs)
        {
            return Fruits[Fruit] * lbs;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            lbs = (float)trackBar1.Value / 2;
            lblLbs.Text = $"{lbs:0.0}";
        }
        private void UncheckBtns()
        {
            btnApple.Text = string.Empty;
            btnBanana.Text = string.Empty;
            btbGrape.Text = string.Empty;
            btnCherry.Text = string.Empty;
            btnLemon.Text = string.Empty;
            btnPear.Text = string.Empty;
            btnPine.Text = string.Empty;
            btnStraw.Text = string.Empty;
            btnOrange.Text = string.Empty;
        }

        private void btnPine_Click(object sender, EventArgs e)
        {
            fruit = "Pineapple";
            UncheckBtns();
            btnPine.Text = "\u2714";// Check Mark 
        }

        private void btnCherry_Click(object sender, EventArgs e)
        {
            fruit = "Cherry\t";
            UncheckBtns();
            btnCherry.Text = "\u2714";
        }

        private void btnPear_Click(object sender, EventArgs e)
        {
            fruit = "Pear\t\t";
            UncheckBtns();
            btnPear.Text = "\u2714";
        }

        private void btnLemon_Click(object sender, EventArgs e)
        {
            fruit = "Lemon\t";
            UncheckBtns();
            btnLemon.Text = "\u2714";
        }

        private void btbGrape_Click(object sender, EventArgs e)
        {
            fruit = "Grape\t";
            UncheckBtns();
            btbGrape.Text = "\u2714"; 
        }

        private void btnApple_Click(object sender, EventArgs e)
        {
            fruit = "Apple\t";
            UncheckBtns();
            btnApple.Text = "\u2714";
        }

        private void btnBanana_Click(object sender, EventArgs e)
        {
            fruit = "Banana\t";
            UncheckBtns();
            btnBanana.Text = "\u2714";
        }

        private void btnStraw_Click(object sender, EventArgs e)
        {
            fruit = "Strawberry";
            UncheckBtns();
            btnStraw.Text = "\u2714";
        }

        private void btnOrange_Click(object sender, EventArgs e)
        {
            fruit = "Orange\t";
            UncheckBtns();
            btnOrange.Text = "\u2714";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            reciept.AppendText($"{fruit}\t{lbs:0.0} at {Fruits[fruit]:C} per lb {CalcPrice(fruit, lbs),10:C}\n");
            total = total + CalcPrice(fruit, lbs);
            lblTotal.Text = $"{total:C}";
        }

        private void btnVoid_Click(object sender, EventArgs e)
        {
            if (reciept.TextLength == 0)
            {
                reciept.AppendText("************Nothing to VOID*************\n");
                reciept.AppendText("******************************************\n");
            }
            else if (fruit == string.Empty)
            {
                reciept.AppendText("***You've already voided the last item***\n");
                reciept.AppendText("**Please coose the fruit and lbs to Void**\n");
                reciept.AppendText("******************************************\n");
            }
            else
            {
                reciept.AppendText("*******************VOID******************\n");
                reciept.AppendText($"{fruit}\t{lbs:0.0} at {Fruits[fruit]:C} per lb: {-CalcPrice(fruit, lbs),10:C}\n");
                total = total - CalcPrice(fruit, lbs);
                lblTotal.Text = $"{total:C}";
                fruit = string.Empty;
                trackBar1.Value = 0;
                lblLbs.Text = "0.0";
                UncheckBtns();
                reciept.AppendText("******************************************\n");
            }
        }
    }
}
