﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Final_
{
    public partial class MainWindow : Window
    {
        private readonly string connectionString = @"Data Source=DESKTOP-URTUFPE\SQLEXPRESS;Initial Catalog=Quiz;Integrated Security=True;Trust Server Certificate=True";


        public MainWindow()
        {
            InitializeComponent();
            LoadCustomerData();
        }

        private void LoadCustomerData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM QuizQuestion";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                    DataTable QuizQuestion = new DataTable();
                    dataAdapter.Fill(QuizQuestion);

                    Grid.ItemsSource = QuizQuestion.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        }

        private void Isclick(object sender, RoutedEventArgs e)
        {
            string Ques = txtQ.Text;
            string OptA = txtA.Text;
            string OptB = txtB.Text;
            string Correct = txtcorrect.Text;
            string Assigned = txtA.Text;
            string Time = txttime.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string commandText = "INSERT INTO QuizQuestion (Question_Text, Option_A, Option_B, Correct_Answer, Assigned_Marks,Time_Limit) " +
                                         "VALUES (@Question_Text, @Option_A, @Option_B, @Correct_Answer, @Assigned_Marks, @Time_Limit)";
                    using (SqlCommand command = new SqlCommand(commandText, connection))
                    {
                        command.Parameters.AddWithValue("@Question_Text", Ques);
                        command.Parameters.AddWithValue("@Option_A", OptA);
                        command.Parameters.AddWithValue("@Option_B", OptB);
                        command.Parameters.AddWithValue("@Correct_Answer", Correct);
                        command.Parameters.AddWithValue("@Assigned_Marks", Assigned);
                        command.Parameters.AddWithValue("@Time_Limit", Time);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Question added successfully.");
                        LoadCustomerData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inserting data: " + ex.Message);
                }
            }

        }

        private void DeleteIsClick(object sender, RoutedEventArgs e)
        {
            string ID = txtId.Text;

            if (string.IsNullOrEmpty(ID))
            {
                MessageBox.Show("Please enter the ID of the Question to delete.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string commandText = "DELETE FROM QuizQuestion WHERE Q_id = @ID";
                    using (SqlCommand command = new SqlCommand(commandText, connection))
                    {
                        command.Parameters.AddWithValue("@ID", ID);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Question deleted successfully.");
                        LoadCustomerData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting data: " + ex.Message);
                }
            }
        }

        private void EditIsClick(object sender, RoutedEventArgs e)
        {
            string Ques = txtQ.Text;
            string OptA = txtA.Text;
            string OptB = txtB.Text;
            string Correct = txtcorrect.Text;
            string Assigned = txtAssign.Text;
            string Time = txttime.Text;
            string ID = txtId.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {


                    connection.Open();

                    string commandText = "UPDATE QuizQuestion SET Ques = @Question_Text, OptA = @Option_A, OptB= @Option_B, Correct = @Correct_Answer,Assigned = @Assigned_Marks, Time = @Time_Limit   WHERE Id = @Q_id";
                    using (SqlCommand command = new SqlCommand(commandText, connection))
                    {
                        command.Parameters.AddWithValue("@Question_Text", Ques);
                        command.Parameters.AddWithValue("@Option_A", OptA);
                        command.Parameters.AddWithValue("@Option_B", OptB);
                        command.Parameters.AddWithValue("@Correct_Answer", Correct);
                        command.Parameters.AddWithValue("@Assigned_Marks", Assigned);
                        command.Parameters.AddWithValue("@Time_Limit", Time);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Question added successfully.");
                        LoadCustomerData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inserting data: " + ex.Message);
                }
            }
        }
    }
}
