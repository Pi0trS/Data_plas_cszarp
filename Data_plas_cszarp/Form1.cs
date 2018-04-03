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
    public partial class Form1 : Form
    {
        private OleDbConnection conection = new OleDbConnection();
        public Form1()
        {
            InitializeComponent();
            conection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Piotr\Documents\Visual Studio 2015\Projects\Data_plas_cszarp\Baza_5boj.accdb; Persist Security Info=False;";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                conection.Open();
                Conectionshow1.Text = "Conection sucesfuel";
                conection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex);
            }
            finally
            {
                conection.Close();
            }
        }

        private void Login_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked)
                {
                    conection.Open();
                    OleDbCommand comand = new OleDbCommand();
                    comand.Connection = conection;
                    comand.CommandText = "select * from Sedziowie where Login='" + textUsername.Text + "' and Haslo='" + tex_pasword.Text + "'"; // from nazwa tabeli 

                    OleDbDataReader reader = comand.ExecuteReader();
                    int count = 0;
                    while (reader.Read())
                    {
                        count++;
                    }
                    if (count == 1)
                    {
                        MessageBox.Show("Udało się !");
                        conection.Close();
                        conection.Dispose();
                        this.Hide();
                        Form2 f2 = new Form2();
                        f2.ShowDialog();
                        this.Close();
                    }
                    else if (count == 0)
                    {
                        MessageBox.Show("Brak takiego sedziekgo lub błędne hasło");
                    }

                    conection.Close();

                }

                else
                {

                    conection.Open();
                    OleDbCommand comand = new OleDbCommand();
                    comand.Connection = conection;
                    comand.CommandText = "select * from Zawodnik where Identyfikator_Zawodnika =" + textUsername.Text + " and Haslo='" + tex_pasword.Text + "'"; // from nazwa tabeli 

                    OleDbDataReader reader = comand.ExecuteReader();
                    int count = 0;
                    while (reader.Read())
                    {
                        count++;
                    }
                    if (count == 1)
                    {
                        MessageBox.Show("Udało się !");
                        conection.Close();
                        conection.Dispose();
                        this.Hide();
                        Form3 f3 = new Form3();
                        f3.ShowDialog();
                        this.Close();
                    }
                    else if (count == 0)
                    {
                        MessageBox.Show("Brak takiego zawodnika lub błędne hasło");
                    }

                    conection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex);
                conection.Close();
            }
        }
    }
}

// toturial 9 