using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistrationForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            bool isAnyEmpty = false;
            foreach(Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    if (string.IsNullOrEmpty(control.Text))
                    {
                        isAnyEmpty = true;
                        break;
                    }

                }
                else if (control is DateTimePicker)
                {
                    if(((DateTimePicker)control).Value == null)
                    {
                        isAnyEmpty = true; 
                        break;
                    }
                }
                else if (control is ComboBox)
                {
                    if(((ComboBox)control).SelectedIndex == -1)
                    {
                        isAnyEmpty = true;
                        break;
                    }
                }

            }
            if (isAnyEmpty)
            {
                MessageBox.Show("one or more fields are empty, please fill it before submitting");
            }
            else
            {
                SqlConnection con = new SqlConnection("");
                con.Open();
                string insertQuery = "INSERT INTO register VALUES (@fname, @lname, @dob, @gender, @email, @username, @password, @phone, @country)";
                SqlCommand cmd = new SqlCommand(insertQuery, con);
                cmd.Parameters.AddWithValue("@fname", txtfname.Text);
                cmd.Parameters.AddWithValue("@lname", txtlname.Text);
                cmd.Parameters.AddWithValue("@dob", dtpDOB.Value);
                cmd.Parameters.AddWithValue("@gender", cmbGender.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@username", txtUser.Text);
                cmd.Parameters.AddWithValue("@password", txtPass.Text);
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@country", txtCtry.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("register sucessfully", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }



            
        }

       
    }
}
