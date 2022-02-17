using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace databasepractice

{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string connetionString;
            MySqlConnection cnn;
            connetionString = @"Data Source=localhost;Initial Catalog=mydb;User ID=root;Password=WorkBench7";
            cnn = new MySqlConnection(connetionString);
            cnn.Open();
            MySqlCommand command;
            MySqlDataReader datareader;
            String mysql, Output = "";
            mysql = "Select * from actor";
            command = new MySqlCommand(mysql, cnn);
            datareader = command.ExecuteReader();

            while (datareader.Read())
            {
                Output = Output + datareader.GetValue(0) + "-" + datareader.GetValue(1) + "\n";
            }
            MessageBox.Show(Output);
            cnn.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString;
            string firstName = textBox1.Text;
            string lastName = textBox2.Text;
            MySqlConnection cnn;
            connectionString = @"Data Source=localhost;Initial Catalog=sakila;User ID=root;Password=WorkBench7";
            cnn = new MySqlConnection(connectionString);
            cnn.Open();
            MySqlCommand command;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            String mysql="";
            mysql = "Insert into actor(first_name, last_name) values (\""+firstName+"\",\""+lastName+"\")";
            command = new MySqlCommand(mysql, cnn);
            adapter.InsertCommand = new MySqlCommand(mysql, cnn);
            adapter.InsertCommand.ExecuteNonQuery();
            command.Dispose();
            cnn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connectionString;
            MySqlConnection cnn;
            connectionString = @"Data Source=localhost;Initial Catalog=sakila;User ID=root;Password=WorkBench7";
            cnn = new MySqlConnection(connectionString);
            cnn.Open();
            MySqlCommand command;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            String mysql = "";

            mysql = "DELETE FROM actor WHERE actor_id=201";

            command = new MySqlCommand(mysql, cnn);

            adapter.DeleteCommand = new MySqlCommand(mysql, cnn);
            adapter.DeleteCommand.ExecuteNonQuery ();

            command.Dispose();
            cnn.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString;
            string firstName = textBox3.Text;
            MySqlConnection cnn;
            connectionString = @"Data Source=localhost;Initial Catalog=sakila;User ID=root;Password=WorkBench7";
            cnn = new MySqlConnection(connectionString);
            cnn.Open();
            MySqlCommand command;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            String mysql = "";

            mysql = " UPDATE actor set first_name = \"" + firstName + "\" WHERE last_name = 'Ledger'";


                command = new MySqlCommand(mysql, cnn);
            adapter.UpdateCommand = new MySqlCommand(mysql, cnn);
            adapter.UpdateCommand.ExecuteNonQuery();

            command.Dispose();
            cnn.Close();
        }

        
    }
}