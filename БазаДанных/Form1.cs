using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace БазаДанных
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Visible = true;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            label1.Visible = false;
            dataGridView1.Visible = false;

            dataGridView1.AutoSize = true;
            dataGridView1.AutoGenerateColumns = true;
        }
        string connectionString = @"Data Source=HASEE-ZX6\SQLEXPRESS; Initial Catalog=Aquapark; Integrated Security=True";

        //запрос: вывести список клиентов
        string sqlExpression2 = "SELECT gender_code AS 'Пол (М-0, Ж-1)', flag_code AS 'Постоянный клиент', name AS Имя, age AS Возраст FROM client;";
        //запрос: вывести список записей дохода по убыванию суммы
        string sqlExpression3 = "SELECT date AS Дата, total AS Сумма FROM bracelet ORDER BY total DESC;";
        //запрос: вывести список записей о посещении зоны "Водные аттракционы" 
        string sqlExpression4 = "SELECT minute_amount AS 'Время (мин)', total AS Сумма FROM payment WHERE zone_code = 0 ORDER BY minute_amount;";

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                button1.Visible = false;
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
                button7.Visible = true;
                label1.Visible = true;
                //Основные сведения о подключении
                label1.Text = "Подключение установлено\n\n" +
                              "Свойства подключения:\n" +
                              "    База данных: " + connection.Database + "\n" +
                              "    Сервер: " + connection.DataSource + "\n" +
                              "    Версия сервера: " + connection.ServerVersion + "\n" +
                              "    Состояние: " + connection.State + "\n" +
                              "    Рабочая станция: " + connection.WorkstationId + "\n";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                button6.Visible = true;
                button7.Visible = true;
                label1.Visible = false;
                dataGridView1.Visible = true;
                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlExpression2, connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                adapter.Fill(ds, "client");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "client";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                button6.Visible = true;
                label1.Visible = false;
                dataGridView1.Visible = true;
                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlExpression3, connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                adapter.Fill(ds, "bracelet");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "bracelet";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                button6.Visible = true;
                label1.Visible = false;
                dataGridView1.Visible = true;
                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlExpression4, connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                adapter.Fill(ds, "payment");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "payment";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Вернуться назад в меню
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button6.Visible = false;
            label1.Visible = true;
            dataGridView1.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Выход
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Close();
                this.Close();
            }
        }
    }
}
