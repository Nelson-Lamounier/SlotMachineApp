// The application should let the user enter into a Textbox the amount of money he/she is inserting into the machine. When the user clicks the spin button, the application should display 2 randomly selected symbols. 
// If none of the randomly displayed images match the program should inform the user that he/she has won €0. If 2 of the images match, the program should inform the user that he/she has won 2 times the amount entered.
// If 3 images match, the system should inform the user that the user has won 3 times the amount entered. 
// When the user clicks the exit button to exit the application the program should display the total amount of money entered into the slot machine and the total won. 


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlotMachineApp
{
    public partial class SlotMachine : Form
    {
        public SlotMachine()
        {
            InitializeComponent();
        }

        // Form level variables as it will accumulative
        decimal userTotal = 0.0m;
        decimal totalWinner = 0.0m;

        private void SlotMachine_Load(object sender, EventArgs e)
        {

        }

        private void btnSpin_Click(object sender, EventArgs e)
        {
            decimal ammountWin = 0.0m;
            decimal userInserted = 0.0m;

            // Validate user's Input
            if (decimal.TryParse(txtUserInputed.Text, out userInserted) && userInserted > 0)
            {
                // If valid input
                Random startRan = new Random();
                // Create randomly img index 0 to 3 to display img from the listImage box
                int img_1 = startRan.Next(0, 3);
                int img_2 = startRan.Next(0, 3);
                int img_3 = startRan.Next(0, 3);

                // Access the img on image list by it variable name
                pictureBox1.Image = imageList1.Images[img_1];
                pictureBox2.Image = imageList1.Images[img_2];
                pictureBox3.Image = imageList1.Images[img_3];

                userTotal += userInserted;
                totalWinner += GetWinner(img_1, img_2, img_3, userInserted);


                 
            }
            else
                MessageBox.Show("Not valid");
        }

        // Method to compare the img(Index) and calculate the amount - simple be called to be private and return a decimal
        private decimal GetWinner(int img1, int img2, int img3, decimal userInserted) // Also accept the amount inserted by the user as the comparition will be based on the user inputed
        {
            if (img1 == img2 && img2 == img3)
            {
                return userInserted * 3;
            }
            else if (img1 == img2 || img1 == img3 || img2 == img3)
            {
                return userInserted * 2;
            }

            return 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Exit the application and display all information for the player
            MessageBox.Show("Total Inserted: " + userTotal.ToString("C") + "\n" + "Total Won: " + totalWinner.ToString("C"));

            Application.Exit();
        }
    }
}
