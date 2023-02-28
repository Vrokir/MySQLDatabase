using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using MySql.Data.MySqlClient;

namespace MySQLDatabase
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        string MySqlConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=mydb";
 
        public void button1_Click(object sender, EventArgs e)
        {
            runQuery();
        }
        public void runQuery()
        {
            string query = textBox1.Text;
            if(query == "")
            {
                MessageBox.Show("Please insert some sql querry!");
                    return;
            }


            MySqlConnection databaseConnection = new MySqlConnection(MySqlConnectionString);

            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();
                if (myReader.HasRows)
                {
                    MessageBox.Show("Your query generated results, please see the console");

                    while (myReader.Read())
                    {
                        Console.WriteLine(myReader.GetString(0) + " - " + myReader.GetString(1) + " - " + myReader.GetString(2) + " - " + myReader.GetString(3));
                    }
                }
                else
                {
                    MessageBox.Show("Query successfull executed");

                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Query error " + e.Message);

            }

        }

       public void label1_Click(object sender, EventArgs e)
        {
            string customQuery = "SELECT * FROM `oddzialy`";
            MySqlConnection databaseConnection = new MySqlConnection(MySqlConnectionString);
            MySqlCommand questDb = new MySqlCommand(customQuery, databaseConnection);
            databaseConnection.Open();
            MySqlDataReader reader = questDb.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader.GetString(0) + " - " + reader.GetString(1) + " - " + reader.GetString(2) + " - " + reader.GetString(3));
            }

        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.Text = string.Empty;

        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            textBox3.Text = string.Empty;

        }

        private void textBox5_MouseClick(object sender, MouseEventArgs e)
        {
            textBox5.Text = string.Empty;

        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            textBox4.Text = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = textBox2.Text;
            string odd = textBox3.Text;
            string opk = textBox5.Text;
            string idG = textBox4.Text;
            string customQuery = "INSERT INTO oddzialy(id, oddzial, opk_5, id_gn) VALUES ('" + id + "', '" + odd + "', '" + opk + "', '" + idG + "')";
            try
            {
                if (string.IsNullOrEmpty(id)) {
                    MessageBox.Show("Id nie może być puste");
                        return;
                }
                MySqlConnection databaseConnection = new MySqlConnection(MySqlConnectionString);
                MySqlCommand quest = new MySqlCommand(customQuery, databaseConnection);
                databaseConnection.Open();
                MySqlDataReader inputData = quest.ExecuteReader();

            }catch(Exception ex) { MessageBox.Show("Błąd: " + ex.Message); }





        }











        //public void textBox2_Text(object sender, EventArgs e)
        //{

        //    TextBox mytextbox = new TextBox();
        //    databaseConnection.Open();
        //        string customQuery = "SELECT * FROM `oddzialy`";
        //    MySqlCommand zapytanie = new MySqlCommand(customQuery, databaseConnection);
        //    MySqlDataReader czytacz = zapytanie.ExecuteReader();
        //    Console.WriteLine
        //}
    }
}
