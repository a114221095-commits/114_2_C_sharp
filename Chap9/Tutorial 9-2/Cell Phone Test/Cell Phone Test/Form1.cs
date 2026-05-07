using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cell_Phone_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // The GetPhoneData method accepts a CellPhone object
        // as an argument. It assigns the data entered by the
        // user to the object's properties.
        private void GetPhoneData(CellPhone phone)
        {
            
        }

        private void createObjectButton_Click(object sender, EventArgs e)
        {
            
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
