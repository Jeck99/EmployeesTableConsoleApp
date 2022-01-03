using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            //connection string point to the database (server name, database name, security policy)
            string connectionString = "Data Source=LAPTOP-U0L5HKOT;Initial Catalog=workDB;Integrated Security=True";
            List<Employee> listOfEmploeeys = new List<Employee>();
            GetAllEmployees(connectionString, listOfEmploeeys);
            AddNewEmployee(connectionString);
            Console.ReadLine();
        }
        // retriving the data from Employees table, using SELECT
        static void GetAllEmployees(string connectionString, List<Employee> listOfEmploeeys)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"SELECT * FROM Employees";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader dataFromDB = command.ExecuteReader();
                    if (dataFromDB.HasRows)
                    {
                        //print data
                        while (dataFromDB.Read())
                        {
                            listOfEmploeeys.Add(new Employee(dataFromDB.GetString(0), dataFromDB.GetString(1), dataFromDB.GetInt32(2), dataFromDB.GetString(3)));
                            //Console.WriteLine(dataFromDB.GetString(0));
                        }
                    }
                    else
                    {
                        Console.WriteLine("no rows in table");
                    }
                    connection.Close();
                }
            }
            catch (SqlException)
            {
                Console.WriteLine();
            }
            catch (Exception)
            {
                throw;
            }
        }
        // adding new entry to the Employees table, using INSERT INTO
        static void AddNewEmployee(string connString)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    //open connection
                    conn.Open();
                    string firstName = Console.ReadLine(); ;
                    string query = $@"INSERT INTO Employee(firstName,...)
                                    VALUES('{firstName}')";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    //execute the SQLCommand
                    int rowEffected = cmd.ExecuteNonQuery();
                    //check if there are records
                }
            }
            catch (Exception ex)
            {
                //display error message
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
        // updating an existing entry in the Employees table, using UPDATE-SET
        static void UpdateEmployee(string connectionStr)
        {
            try
            {
                string firstName = Console.ReadLine();
                string lastName = Console.ReadLine();
                int age = int.Parse(Console.ReadLine());
                string birthday = Console.ReadLine();
                int id = int.Parse(Console.ReadLine());
                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();
                    string query = $@"UPDATE Employees 
                                SET first_name = '{firstName}', last_name='{lastName}', age={age}, birthday='{birthday}'
                                WHERE Id = {id}";
                    SqlCommand command = new SqlCommand(query, connection);
                    int rowEffected = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (SqlException sqlError)
            {
                Console.WriteLine(sqlError.Message);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }

        }
        // deleting an existing entry in Employees table, using DELETE
        static void DeleteEmployee(string connectionStr, int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();
                    string query = $@"DELETE FROM Employees
                                    WHERE Id = {id}";
                    SqlCommand command = new SqlCommand(query, connection);
                    int rowEffected = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (SqlException exSql)
            {
                Console.WriteLine(exSql.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
