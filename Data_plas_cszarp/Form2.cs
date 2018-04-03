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
    public partial class Form2 : Form
    {
        private OleDbConnection conection = new OleDbConnection();

        public Form2()
        {
            InitializeComponent();
            conection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Piotr\Documents\Visual Studio 2015\Projects\Data_plas_cszarp\Baza_5boj.accdb; Persist Security Info=False;";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conection.Open();
                OleDbCommand comand = new OleDbCommand();
                comand.Connection = conection;
                comand.CommandText = "insert into Zawodnik ([Imie], [Nazwisko],[Identyfikator_Reprezentacji],[Haslo]) values('" + textBox_imie.Text + "','" + textBox2_nazwisko.Text + "','" + textBox3_idreprezentacji.Text + "','" + textBox_haslo.Text + "')";

                comand.ExecuteNonQuery();
                MessageBox.Show("Dodano prawidlowo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error + " + ex);
            }
            conection.Close();
            button4.PerformClick();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conection.Open();
                OleDbCommand comand = new OleDbCommand();
                comand.Connection = conection;
                string query = "update Zawodnik set Imie = '" + textBox_imie.Text + "' ,Nazwisko='" + textBox2_nazwisko.Text + "' ,Identyfikator_Reprezentacji = '" + textBox3_idreprezentacji.Text + "' ,Haslo ='" + textBox_haslo.Text + "'  where Identyfikator_Zawodnika =" + textBox_identyfikator.Text + "   ";
                // MessageBox.Show(query);
                comand.CommandText = query;


                comand.ExecuteNonQuery();
                MessageBox.Show("Edytowano prawidlowo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error + " + ex);
            }
            conection.Close();
            button4.PerformClick();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                conection.Open();
                OleDbCommand comand = new OleDbCommand();
                comand.Connection = conection;
                string query = "delete from Zawodnik where Identyfikator_Zawodnika =" + textBox_identyfikator.Text + "";
                // MessageBox.Show(query);
                comand.CommandText = query;


                comand.ExecuteNonQuery();
                MessageBox.Show("usunieto prawidlowo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error + " + ex);
            }
            conection.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                conection.Open();
                OleDbCommand comand = new OleDbCommand();
                comand.Connection = conection;
                string query = "select * from Zawodnik";
                comand.CommandText = query;

                OleDbDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {

                    listBox1.Items.Add(reader["Nazwisko"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error + " + ex);
            }
            conection.Close();
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                conection.Open();
                OleDbCommand comand = new OleDbCommand();
                comand.Connection = conection;
                string query = "select * from Zawodnik where Nazwisko = '" + listBox1.Text + "' ";
                comand.CommandText = query;

                OleDbDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    textBox_identyfikator.Text = reader["Identyfikator_Zawodnika"].ToString();
                    textBox_imie.Text = reader["Imie"].ToString();
                    textBox2_nazwisko.Text = reader["Nazwisko"].ToString();
                    textBox3_idreprezentacji.Text = reader["Identyfikator_Reprezentacji"].ToString();
                    textBox_haslo.Text = reader["Haslo"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error + " + ex);
            }
            conection.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                conection.Open();
                OleDbCommand comand = new OleDbCommand();
                comand.Connection = conection;
                string query = "select * from Zawodnik";
                comand.CommandText = query;

                OleDbDataAdapter data_adapter = new OleDbDataAdapter(comand);
                DataTable data_table = new DataTable();
                data_adapter.Fill(data_table);
                dataGridView1.DataSource = data_table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error + " + ex);
            }
            conection.Close();
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

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                conection.Open();
                OleDbCommand comand = new OleDbCommand();
                comand.Connection = conection;
                string query = "update Wynik set Wynik = '" + textBox_szermierka.Text + "'  where Identyfikator_Zawodnika =" + textBox_identyfikator.Text + "and Identyfikator_Konkurencji= " + 1.ToString() + "   ";
                comand.CommandText = query;
                comand.ExecuteNonQuery();
                conection.Close();

                conection.Open();
                OleDbCommand comand1 = new OleDbCommand();
                comand.Connection = conection;
                string query1 = "update Wynik set Wynik = '" + textBox_plywanie.Text + "'  where Identyfikator_Zawodnika =" + textBox_identyfikator.Text + "and Identyfikator_Konkurencji= " + 2.ToString() + "   ";
                comand.CommandText = query1;
                comand.ExecuteNonQuery();
                conection.Close();

                conection.Open();
                OleDbCommand comand2 = new OleDbCommand();
                comand.Connection = conection;
                string query2 = "update Wynik set Wynik = '" + textBox_jazdakonna.Text + "'  where Identyfikator_Zawodnika =" + textBox_identyfikator.Text + "and Identyfikator_Konkurencji= " + 3.ToString() + "   ";
                comand.CommandText = query2;
                comand.ExecuteNonQuery();
                conection.Close();

                conection.Open();
                OleDbCommand comand3 = new OleDbCommand();
                comand.Connection = conection;
                string query3 = "update Wynik set Wynik = '" + textBox_bieg.Text + "'  where Identyfikator_Zawodnika =" + textBox_identyfikator.Text + "and Identyfikator_Konkurencji= " + 4.ToString() + "   ";
                comand.CommandText = query3;
                comand.ExecuteNonQuery();
                conection.Close();

                conection.Open();
                OleDbCommand comand4 = new OleDbCommand();
                comand.Connection = conection;
                string query4 = "update Wynik set Wynik = '" + textBox_strzelanie.Text + "'  where Identyfikator_Zawodnika =" + textBox_identyfikator.Text + "and Identyfikator_Konkurencji= " + 5.ToString() + "   ";
                comand.CommandText = query4;
                comand.ExecuteNonQuery();
                conection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error + " + ex);
            }


        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                conection.Open();
                OleDbCommand comand = new OleDbCommand();
                comand.Connection = conection;
                string query = "select * from Zawodnik where Identyfikator_Reprezentacji = " + textBox3_idreprezentacji.Text + " ";
                comand.CommandText = query;

                OleDbDataReader reader = comand.ExecuteReader();
                List<int> lista = new List<int>();
                while (reader.Read())
                {
                    lista.Add(Int32.Parse(reader["Identyfikator_Zawodnika"].ToString()));
                }
                conection.Close();



                conection.Open();
                OleDbCommand comand1 = new OleDbCommand();
                comand.Connection = conection;
                string query1 = "select * from Wynik ";
                comand.CommandText = query1;

                OleDbDataReader reader1 = comand.ExecuteReader();
                int wynik = 0;
                for (int i = 0; i < lista.Count; i++)
                {
                    while (reader1.Read())
                    {
                        if (Int32.Parse(reader1["Identyfikator_Zawodnika"].ToString()) == lista[i])
                        {
                            wynik += Int32.Parse(reader1["Wynik"].ToString());
                        }
                    }
                    conection.Close();
                    conection.Open();
                    comand.Connection = conection;
                    reader1 = comand.ExecuteReader();

                }
                conection.Close();
                textBox_wynikdruzyny.Text = wynik.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error + " + ex);
            }

        }
    }
}

