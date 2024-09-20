using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EggTrackingApp
{
    public partial class EggTrackingForm : Form
    {
        private Dictionary<DateTime, int> eggRecords = new Dictionary<DateTime, int>();
        public EggTrackingForm()
        {
            InitializeComponent();
        }

        private void UpdateMonthlyTotal(DateTime date)
        {
            // Calculate the total for the selected month
            int monthlyTotal = eggRecords
                .Where(record => record.Key.Month == date.Month && record.Key.Year == date.Year)
                .Sum(record => record.Value);

            // Display the total eggs for the month
            lblMonthlyTotal.Text = $"Total Eggs for {date.ToString("MMMM yyyy")}: {monthlyTotal}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dtpDate.Value;
            int eggCount;

            if (int.TryParse(txtEggCount.Text, out eggCount))
            {
                // Add or update daily egg record
                eggRecords[selectedDate] = eggCount;
                MessageBox.Show("Egg count saved!");

                // Update the total eggs produced in the month
                UpdateMonthlyTotal(selectedDate);
            }
            else
            {
                MessageBox.Show("Please enter a valid number of eggs.");
            }
        }

        private void lblMonthlyTotal_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();  
            LoginForm loginForm = new LoginForm();
            loginForm.Show();  
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
