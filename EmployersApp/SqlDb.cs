using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using EmployersApp.Models;

namespace EmployersApp.DB
{
    public static class SqlDb
    {
        private static string connectionString = null;
        //ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        private static string tableName = null; //"Employers";

        public static void SetConnectionString(
            string server, 
            string database, 
            string username, 
            string password)
        {
            StringBuilder temp = new StringBuilder("Server=" + server 
                + ";Database=" + database + ";");
            if (username != null)
            {
                temp.Append("User Id=" + username + ";Password" + password + ";");
            }
            else
            {
                temp.Append("Integrated Security=True;");
            }
            connectionString = temp.ToString();
        }

        public static void SetTableName(string name)
        {
            if (name != null)
            {
                tableName = name;
            }
            else
            {
                tableName = "Employers";
            }
        }

        public static bool isConnectionStringNull()
        {
            return (connectionString == null);
        }

        public static bool ConfigureConnection()
        {
            string serverConnectionString = getConnectionStringToServer();
            SqlConnection serverConnection = new SqlConnection(serverConnectionString);
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                if (!checkServer(serverConnection))
                {
                    return false;
                }
                string dbName = getDatabaseName();
                bool dbExist = IsDatabaseExists(serverConnection, dbName);
                if (!dbExist)
                {
                    CreateDatabase(serverConnection, dbName);
                }

                if (!IsTableExists(tableName))
                {
                    CreateTable(connection, tableName);
                }
                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static void CloseConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public static bool checkServer(SqlConnection connection)
        {
            try
            {
                connection.Open();
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public static bool IsDatabaseExists(SqlConnection tmpConn, string databaseName)
        {
            string sqlCreateDBQuery;
            bool result = false;

            try
            {
                sqlCreateDBQuery = string.Format("SELECT database_id FROM" 
                    + " sys.databases WHERE Name = '{0}'", databaseName);
                using (SqlCommand sqlCmd = new SqlCommand(sqlCreateDBQuery, tmpConn))
                {
                    tmpConn.Open();
                    object resultObj = sqlCmd.ExecuteScalar();
                    int databaseID = 0;
                    if (resultObj != null)
                    {
                        int.TryParse(resultObj.ToString(), out databaseID);
                    }
                    tmpConn.Close();
                    result = (databaseID > 0);
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        private static bool IsTableExists(string TableName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                DataTable dTable = conn.GetSchema("TABLES",
                               new string[] { null, null, TableName });

                return dTable.Rows.Count > 0;
            }
        }

        public static bool CreateDatabase(SqlConnection connection, string dbName)
        {
            string sqlCommand = "CREATE DATABASE " + dbName + "; ";
            SqlCommand command = new SqlCommand(sqlCommand, connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return true;
        }

        public static bool CreateTable(SqlConnection connection, string tableName)
        {
            string query =
            @"CREATE TABLE dbo." + tableName
            + @"
            (
                ID int IDENTITY(1,1) PRIMARY KEY,
                Name nvarchar(50) NOT NULL,
                Surname nvarchar(50) NOT NULL,
                Post nvarchar(50) NOT NULL,
                BirthYear int NOT NULL,
                Salary float NOT NULL
            );";

            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return true;
        }

        private static string getDatabaseName()
        {
            int i = connectionString.IndexOf("Database");
            if (i == -1)
            {
                i = connectionString.IndexOf("Initial Catalog");
            }
            if (i == -1)
            {
                return "";
            }
            string temp = connectionString.Substring(i);
            int i1 = temp.IndexOf("=") + 1;
            int i2 = temp.IndexOf(";");
            return temp.Substring(i1, i2 - i1);
        }

        private static string getConnectionStringToServer()
        {
            int i = connectionString.IndexOf("Database");
            if (i == -1)
            {
                i = connectionString.IndexOf("Initial Catalog");
            }
            if (i == -1)
            {
                return connectionString;
            }
            int i1 = connectionString.IndexOf(';', 
                connectionString.IndexOf(';') + 1);
            string part1 = connectionString.Substring(0, i);
            string part2 = connectionString.Substring(i1 + 1);
            return string.Concat(part1, part2);
        }

        public static bool addEmployer(
            string name, 
            string surname, 
            string post, 
            int birthYear, 
            float salary)
        {
            int query_result = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlExpression =
                @"INSERT INTO " + tableName
                    + @" (Name, Surname, Post, BirthYear, Salary)
                    VALUES (@name, @surname, @post, @year, @salary);";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter nameParam = new SqlParameter("@name", name);
                command.Parameters.Add(nameParam);
                SqlParameter surnameParam = new SqlParameter("@surname", surname);
                command.Parameters.Add(surnameParam);
                SqlParameter postParam = new SqlParameter("@post", post);
                command.Parameters.Add(postParam);
                SqlParameter yearParam = new SqlParameter("@year", birthYear);
                command.Parameters.Add(yearParam);
                SqlParameter salaryParam = new SqlParameter("@salary", salary);
                command.Parameters.Add(salaryParam);
                query_result = command.ExecuteNonQuery();
            }
            if (query_result > 0)
                return true;
            return false;
        }

        public static bool removeEmployer(
            string name,
            string surname,
            string post,
            int? birthYear,
            float? salary)
        {
            int query_result = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                StringBuilder sqlExpression =
                    new StringBuilder("DELETE FROM " + tableName + " WHERE ");
                List<SqlParameter> parameters = new List<SqlParameter>();
                if (name != null)
                {
                    sqlExpression.Append("name=@name ");
                    parameters.Add(new SqlParameter("name", name));
                }
                if (surname != null)
                {
                    if (parameters.Count > 0)
                    {
                        sqlExpression.Append("AND ");
                    }
                    sqlExpression.Append("surname=@surname ");
                    parameters.Add(new SqlParameter("surname", surname));
                }
                if (post != null)
                {
                    if (parameters.Count > 0)
                    {
                        sqlExpression.Append("AND ");
                    }
                    sqlExpression.Append("post=@post ");
                    parameters.Add(new SqlParameter("post", post));
                }
                if (birthYear != null)
                {
                    if (parameters.Count > 0)
                    {
                        sqlExpression.Append("AND ");
                    }
                    sqlExpression.Append("BirthYear=@year ");
                    parameters.Add(new SqlParameter("year", birthYear));
                }
                if (salary != null)
                {
                    if (parameters.Count > 0)
                    {
                        sqlExpression.Append("AND ");
                    }
                    sqlExpression.Append("Salary=@salary");
                    parameters.Add(new SqlParameter("salary", salary));
                }
                sqlExpression.Append(";");
                SqlCommand command = new SqlCommand(
                    sqlExpression.ToString(), 
                    connection);
                foreach (SqlParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
                query_result = command.ExecuteNonQuery();
            }
            if (query_result > 0)
                return true;
            return false;
        }

        public static List<Employers> getEmployers()
        {
            List<Employers> data = new List<Employers>(); 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                StringBuilder sqlExpression = 
                    new StringBuilder("SELECT * FROM " + tableName + ";");
                SqlCommand command = new SqlCommand(sqlExpression.ToString(), connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    data.Add(new Employers());
                    //data[data.Count - 1].id = Convert.ToInt32(reader[0]);
                    data[data.Count - 1].Name = reader[1].ToString();
                    data[data.Count - 1].Surname = reader[2].ToString();
                    data[data.Count - 1].Post = reader[3].ToString();
                    data[data.Count - 1].BirthYear = Convert.ToInt32(reader[4]);
                    data[data.Count - 1].Salary = (float)Convert.ToDouble(reader[5]);
                }
                reader.Close();
                connection.Close();
            }
            return data;
        }
    }
}
