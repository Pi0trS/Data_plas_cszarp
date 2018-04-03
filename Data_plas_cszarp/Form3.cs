using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace Data_plas_cszarp

{
    public partial class Form3 : Form
    {
        private OleDbConnection conection = new OleDbConnection();
        public Form3()
        {
            InitializeComponent();
            conection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Piotr\Documents\Visual Studio 2015\Projects\Data_plas_cszarp\Baza_5boj.accdb; Persist Security Info=False;";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                conection.Open();
                OleDbCommand comand = new OleDbCommand();
                comand.Connection = conection;
                string query = "select * from Wynik";
                comand.CommandText = query;

                OleDbDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    if (textBox_identyfikator.Text == reader["Identyfikator_Zawodnika"].ToString() && 1.ToString() == reader["Identyfikator_Konkurencji"].ToString()) textBox_szermierka.Text = reader["Wynik"].ToString();
                    if (textBox_identyfikator.Text == reader["Identyfikator_Zawodnika"].ToString() && 2.ToString() == reader["Identyfikator_Konkurencji"].ToString()) textBox_plywanie.Text = reader["Wynik"].ToString();
                    if (textBox_identyfikator.Text == reader["Identyfikator_Zawodnika"].ToString() && 3.ToString() == reader["Identyfikator_Konkurencji"].ToString()) textBox_jazdakonna.Text = reader["Wynik"].ToString();
                    if (textBox_identyfikator.Text == reader["Identyfikator_Zawodnika"].ToString() && 4.ToString() == reader["Identyfikator_Konkurencji"].ToString()) textBox_bieg.Text = reader["Wynik"].ToString();
                    if (textBox_identyfikator.Text == reader["Identyfikator_Zawodnika"].ToString() && 5.ToString() == reader["Identyfikator_Konkurencji"].ToString()) textBox_strzelanie.Text = reader["Wynik"].ToString();
                }
                int wynik = Int32.Parse(textBox_szermierka.Text) + Int32.Parse(textBox_plywanie.Text) + Int32.Parse(textBox_jazdakonna.Text) + Int32.Parse(textBox_bieg.Text) + Int32.Parse(textBox_strzelanie.Text);
                textBox_wynik.Text = wynik.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error + " + ex);
            }
            conection.Close();
        }
    }
}
