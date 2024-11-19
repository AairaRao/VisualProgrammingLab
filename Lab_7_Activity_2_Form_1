using System;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        // Constructor
        public Form1()
        {
            InitializeComponent();
        }

        // Event handler for the "Place Order" button click event
        private void btn_order_Click(object sender, EventArgs e)
        {
            // Get the selected pizza size
            string size = cmb_size.SelectedItem?.ToString() ?? "Unknown size";

            // Get the selected crust type
            string crust = rdb_thin.Checked ? "Thin Crust" :
                           rdb_thick.Checked ? "Thick Crust" : "Unknown crust";

            // Get selected toppings
            string toppings = "";
            if (chk_cheese.Checked) toppings += "Cheese, ";
            if (chk_pepperoni.Checked) toppings += "Pepperoni, ";
            if (chk_mushrooms.Checked) toppings += "Mushrooms, ";
            toppings = string.IsNullOrWhiteSpace(toppings) ? "No toppings" : toppings.TrimEnd(',', ' ');

            // Display the order summary
            lbl_summary.Text = $"You ordered a {size} pizza with {crust} and toppings: {toppings}.";
        }
    }
}
