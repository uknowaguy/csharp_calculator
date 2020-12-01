using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace calculatorECPIwinForm
{
    public partial class Form1 : Form
    {
        string operation = "";
        string clearZero = "0";
        double firstNumber;
        double secondNumber;
        public Form1()
        {
            InitializeComponent();
            
        }


        private void textNumbersOnly(object sender, KeyPressEventArgs e)
        {      

            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 46)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                historyTextBox.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                historyTextBox.Text = "Welcome to the Validation Zone. The fuzz have been notified.";
            }
        }       

        private void NumericValue(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if(txtDisplay.Text == "0")
            {
                txtDisplay.Text = "";
            }
            if(b.Text == ".")
            {
                if(!txtDisplay.Text.Contains("."))
                {
                    txtDisplay.Text = txtDisplay.Text + b.Text;
                }
            }
            else
            {
                txtDisplay.Text = txtDisplay.Text + b.Text;
            }           

        }

        private void buttonClearAll_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = clearZero;
            label1.Text = "";
        }

        private void buttonKindaClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = clearZero;
            label1.Text = "";
            string first;
            string second;

            second = Convert.ToString(secondNumber);
            first = Convert.ToString(firstNumber);            

            second = "";
            first = "";            

        }

        private void Operational_Function(object sender, EventArgs e)
        {            
            Button b = (Button)sender;
            firstNumber = Double.Parse(txtDisplay.Text);
            operation = b.Text;
            txtDisplay.Text = "0";

            _ = b.Text == "➕" ? label1.Text = "+" :
            b.Text == "➖" ? label1.Text = "-" :
            b.Text == "✖" ? label1.Text = "✖" :
            b.Text == "➗" ? label1.Text = "➗" :
            b.Text == "xᵡ" ? label1.Text = $"{firstNumber}^" :
            null;
            
        }

        private void buttonBackSpace_Click(object sender, EventArgs e)
        {
            if(txtDisplay.Text.Length > 0)
            {
                txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1, 1);
            }
            if (txtDisplay.Text == "")
            {
                txtDisplay.Text = "0";
            }            

        }

        private void buttonPlusMinus_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text.Contains("-"))
            {
                txtDisplay.Text = txtDisplay.Text.Remove(0, 1);
            }
            else
            {
                txtDisplay.Text = "-" + txtDisplay.Text;
            }           
        }

        private void buttonSquareRoot_Click(object sender, EventArgs e)
        {      
            firstNumber = Double.Parse(txtDisplay.Text);            

            txtDisplay.Text = Convert.ToString(Math.Sqrt(firstNumber));
            label1.Text = $"√{firstNumber}";
            historyTextBox.Text = $"√{firstNumber} = {Math.Sqrt(firstNumber)}";
        }
        private void buttonSquared_Click(object sender, EventArgs e)
        {
            firstNumber = Double.Parse(txtDisplay.Text);           

            txtDisplay.Text = Convert.ToString(Math.Pow(firstNumber, 2));
            label1.Text = $"{firstNumber}²";
            historyTextBox.Text = $"{firstNumber}² = {Math.Pow(firstNumber, 2)}";
        }  

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            secondNumber = Double.Parse(txtDisplay.Text);    
           
            switch (operation)
            {
                case "➕":
                    txtDisplay.Text = Convert.ToString(firstNumber + secondNumber);
                    label1.Text = $"{firstNumber} + {secondNumber} = {firstNumber + secondNumber}";
                    historyTextBox.Text = $"{firstNumber} + {secondNumber} = {firstNumber + secondNumber}\n";
                    break;

                case "➖":
                    txtDisplay.Text = Convert.ToString(firstNumber - secondNumber);
                    label1.Text = $"{firstNumber} - {secondNumber} = {firstNumber - secondNumber}";
                    historyTextBox.Text = $"{firstNumber} - {secondNumber} = {firstNumber - secondNumber}";
                    break;

                case "✖":
                    txtDisplay.Text = Convert.ToString(firstNumber * secondNumber);
                    label1.Text = $"{firstNumber} * {secondNumber} = {firstNumber * secondNumber}";
                    historyTextBox.Text = $"{firstNumber} * {secondNumber} = {firstNumber * secondNumber}";
                    break;

                case "➗":               
                    txtDisplay.Text = Convert.ToString(firstNumber / secondNumber);
                    label1.Text = $"{firstNumber} / {secondNumber} = {firstNumber / secondNumber}";
                    historyTextBox.Text = $"{firstNumber} / {secondNumber} = {firstNumber / secondNumber}";
                    break;

                case "xᵡ":
                    txtDisplay.Text = Convert.ToString(Math.Pow(firstNumber,secondNumber));
                    label1.Text = $"{firstNumber}^{secondNumber}";
                    historyTextBox.Text = $"{firstNumber}^{secondNumber} = {Math.Pow(firstNumber, secondNumber)}";
                    break;

                default:
                    break;
            }
        }

     

        private void Form1_Load(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
        }

     

        private void radioButtonTao_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"coltonAndMe-removebg-preview (1).png");

            Control control = pictureBox1.Parent;

            Form myForm = pictureBox1.FindForm();

            myForm.Text = "The Way";

            myForm.BackColor = Color.DeepPink;

            // change radio buttons
            radioButtonDark.ForeColor = Color.Black;

            radioButtonTao.ForeColor = Color.Black;

            radioButtonLight.ForeColor = Color.Black;

            radioButtonSail.ForeColor = Color.Black;

            // changing order of buttons  

            changeLayout();           

        }

        private void radioButtonSail_CheckedChanged(object sender, EventArgs e)
        {
            originalLayout();

            pictureBox1.Image = Image.FromFile(@"Asset 5.png");

            Control control = pictureBox1.Parent;

            Form myForm = pictureBox1.FindForm();

            myForm.Text = "Sailors Delight";

            myForm.BackColor = Color.Black;

            // change radio button color
            radioButtonDark.ForeColor = Color.White;

            radioButtonTao.ForeColor = Color.White;

            radioButtonLight.ForeColor = Color.White;

            radioButtonSail.ForeColor = Color.White;

            // change button color
            button0.BackColor = Color.DarkGray;
            button0.ForeColor = Color.Black;

            button1.BackColor = Color.DarkGray;
            button1.ForeColor = Color.Black;

            button2.BackColor = Color.DarkGray;
            button2.ForeColor = Color.Black;

            button3.BackColor = Color.DarkGray;
            button3.ForeColor = Color.Black;

            button4.BackColor = Color.DarkGray;
            button4.ForeColor = Color.Black;

            button5.BackColor = Color.DarkGray;
            button5.ForeColor = Color.Black;

            button6.BackColor = Color.DarkGray;
            button6.ForeColor = Color.Black;

            button7.BackColor = Color.DarkGray;
            button7.ForeColor = Color.Black;

            button8.BackColor = Color.DarkGray;
            button8.ForeColor = Color.Black;

            button9.BackColor = Color.DarkGray;
            button9.ForeColor = Color.Black;

            buttonBackSpace.BackColor = Color.Black;
            buttonBackSpace.ForeColor = Color.White;

            buttonPlusMinus.BackColor = Color.White;
            buttonPlusMinus.ForeColor = Color.Black;

            buttonPeriod.BackColor = Color.White;
            buttonPeriod.ForeColor = Color.Black;

            buttonMinus.BackColor = Color.White;
            buttonMinus.ForeColor = Color.Black;

            buttonPlus.BackColor = Color.White;
            buttonPlus.ForeColor = Color.Black;

            buttonTimes.BackColor = Color.White;
            buttonTimes.ForeColor = Color.Black;

            buttonDivide.BackColor = Color.White;
            buttonDivide.ForeColor = Color.Black;

            buttonEqual.BackColor = Color.White;
            buttonEqual.ForeColor = Color.Black;

        }

        private void radioButtonLight_CheckedChanged(object sender, EventArgs e)
        {
            originalLayout();

            pictureBox1.Image = Image.FromFile(@"ecpiCalcLogo1.PNG");

            Control control = pictureBox1.Parent;

            Form myForm = pictureBox1.FindForm();

            myForm.Text = "Just the Norm, Norman";

            myForm.BackColor = Color.White;

            // change radio button color
            radioButtonDark.ForeColor = Color.DeepPink;

            radioButtonTao.ForeColor = Color.DeepPink;

            radioButtonLight.ForeColor = Color.DeepPink;

            radioButtonSail.ForeColor = Color.DeepPink;

            // change button color
            button0.BackColor = Color.DeepPink;
            button0.ForeColor = Color.White;

            button1.BackColor = Color.DeepPink;
            button1.ForeColor = Color.White;

            button2.BackColor = Color.DeepPink;
            button2.ForeColor = Color.White;

            button3.BackColor = Color.DeepPink;
            button3.ForeColor = Color.White;

            button4.BackColor = Color.DeepPink;
            button4.ForeColor = Color.White;

            button5.BackColor = Color.DeepPink;
            button5.ForeColor = Color.White;

            button6.BackColor = Color.DeepPink;
            button6.ForeColor = Color.White;

            button7.BackColor = Color.DeepPink;
            button7.ForeColor = Color.White;

            button8.BackColor = Color.DeepPink;
            button8.ForeColor = Color.White;

            button9.BackColor = Color.DeepPink;
            button9.ForeColor = Color.White;

            buttonBackSpace.BackColor = Color.Black;
            buttonBackSpace.ForeColor = Color.Red;

            buttonPlusMinus.BackColor = Color.Black;
            buttonPlusMinus.ForeColor = Color.DeepPink;

            buttonPeriod.BackColor = Color.Black;
            buttonPeriod.ForeColor = Color.DeepPink;

            buttonMinus.BackColor = Color.Black;
            buttonMinus.ForeColor = Color.DeepPink;

            buttonPlus.BackColor = Color.Black;
            buttonPlus.ForeColor = Color.DeepPink;

            buttonTimes.BackColor = Color.Black;
            buttonTimes.ForeColor = Color.DeepPink;

            buttonDivide.BackColor = Color.Black;
            buttonDivide.ForeColor = Color.DeepPink;

            buttonEqual.BackColor = Color.Black;
            buttonEqual.ForeColor = Color.DeepPink;
        }

        private void radioButtonDark_CheckedChanged(object sender, EventArgs e)
        {
            originalLayout();

            pictureBox1.Image = Image.FromFile(@"gradientLogo1.png");

            Control control = pictureBox1.Parent;

            Form myForm = pictureBox1.FindForm();

            myForm.Text = "Darkness Within";

            myForm.BackColor = Color.Black;

            // change radio button color
            radioButtonDark.ForeColor = Color.White;

            radioButtonTao.ForeColor = Color.White;

            radioButtonLight.ForeColor = Color.White;

            radioButtonSail.ForeColor = Color.White;

            // change button color
            button0.BackColor = Color.Black;
            button0.ForeColor = Color.White;

            button1.BackColor = Color.Black;
            button1.ForeColor = Color.White;

            button2.BackColor = Color.Black;
            button2.ForeColor = Color.White;

            button3.BackColor = Color.Black;
            button3.ForeColor = Color.White;

            button4.BackColor = Color.Black;
            button4.ForeColor = Color.White;

            button5.BackColor = Color.Black;
            button5.ForeColor = Color.White;

            button6.BackColor = Color.Black;
            button6.ForeColor = Color.White;

            button7.BackColor = Color.Black;
            button7.ForeColor = Color.White;

            button8.BackColor = Color.Black;
            button8.ForeColor = Color.White;

            button9.BackColor = Color.Black;
            button9.ForeColor = Color.White;

            buttonBackSpace.BackColor = Color.Black;
            buttonBackSpace.ForeColor = Color.Red;

            buttonPlusMinus.BackColor = Color.Black;
            buttonPlusMinus.ForeColor = Color.DarkGray;

            buttonPeriod.BackColor = Color.Black;
            buttonPeriod.ForeColor = Color.DarkGray;

            buttonMinus.BackColor = Color.Black;
            buttonMinus.ForeColor = Color.DarkGray;

            buttonPlus.BackColor = Color.Black;
            buttonPlus.ForeColor = Color.DarkGray;

            buttonTimes.BackColor = Color.Black;
            buttonTimes.ForeColor = Color.DarkGray;

            buttonDivide.BackColor = Color.Black;
            buttonDivide.ForeColor = Color.DarkGray;

            buttonEqual.BackColor = Color.Black;
            buttonEqual.ForeColor = Color.DarkGray;
        }

        private void changeLayout()
        {
            // changing order of buttons 

            txtDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;

            label1.Location = new System.Drawing.Point(150, 52);

            button0.Location = new System.Drawing.Point(188, 364);

            button1.Location = new System.Drawing.Point(263, 293);

            button2.Location = new System.Drawing.Point(188, 293);

            button3.Location = new System.Drawing.Point(113, 293);

            button4.Location = new System.Drawing.Point(263, 222);

            button5.Location = new System.Drawing.Point(188, 222);

            button6.Location = new System.Drawing.Point(113, 222);

            button7.Location = new System.Drawing.Point(263, 151);

            button8.Location = new System.Drawing.Point(188, 151);

            button9.Location = new System.Drawing.Point(113, 151);

            buttonBackSpace.Location = new System.Drawing.Point(263, 80);

            buttonPlusMinus.Location = new System.Drawing.Point(38, 80);

            buttonPeriod.Location = new System.Drawing.Point(263, 364);

            buttonMinus.Location = new System.Drawing.Point(38, 222);

            buttonPlus.Location = new System.Drawing.Point(38, 151);

            buttonTimes.Location = new System.Drawing.Point(38, 293);

            buttonDivide.Location = new System.Drawing.Point(38, 364);

            buttonEqual.Location = new System.Drawing.Point(113, 364);

            buttonKindaClear.Location = new System.Drawing.Point(188, 80);

            buttonClearAll.Location = new System.Drawing.Point(113, 80);
        }

        private void originalLayout()
        {
            // changing order of buttons back to normal

            txtDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            label1.Location = new System.Drawing.Point(45, 52);

            button0.Location = new System.Drawing.Point(113, 364);

            button1.Location = new System.Drawing.Point(38, 293);

            button2.Location = new System.Drawing.Point(113, 293);

            button3.Location = new System.Drawing.Point(188, 293);

            button4.Location = new System.Drawing.Point(38, 222);

            button5.Location = new System.Drawing.Point(113, 222);

            button6.Location = new System.Drawing.Point(188, 222);

            button7.Location = new System.Drawing.Point(38, 151);

            button8.Location = new System.Drawing.Point(113, 151);

            button9.Location = new System.Drawing.Point(188, 151);

            buttonBackSpace.Location = new System.Drawing.Point(38, 80);

            buttonPlusMinus.Location = new System.Drawing.Point(263, 80);

            buttonPeriod.Location = new System.Drawing.Point(38, 364);

            buttonMinus.Location = new System.Drawing.Point(263, 222);

            buttonPlus.Location = new System.Drawing.Point(263, 151);

            buttonTimes.Location = new System.Drawing.Point(263, 293);

            buttonDivide.Location = new System.Drawing.Point(263, 364);

            buttonEqual.Location = new System.Drawing.Point(188, 364);

            buttonKindaClear.Location = new System.Drawing.Point(113, 80);

            buttonClearAll.Location = new System.Drawing.Point(188, 80);
        }

        
    }
}


