using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace TaskManagementApp.Helpers
{
    public static class DatabaseHelper
    {
        private static string connectionString = "Server=MSI\\SQLEXPRESS02;Database=TaskManagementDB;Integrated Security=True;";

        #region Task Management

        // Insert a new task
        public static bool AddTask(string title, string description, DateTime dueDate, string priority)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Tasks (Title, Description, DueDate, Priority) VALUES (@Title, @Description, @DueDate, @Priority)";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@DueDate", dueDate);
                    cmd.Parameters.AddWithValue("@Priority", priority);

                    int result = cmd.ExecuteNonQuery();
                    return result > 0; // Return true if insert is successful
                }
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("Error while adding task: " + ex.Message);
            }
        }

        // Update an existing task
        public static bool UpdateTask(int taskId, string title, string description, DateTime dueDate, string priority)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Tasks SET Title = @Title, Description = @Description, DueDate = @DueDate, Priority = @Priority WHERE TaskId = @TaskId";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@TaskId", taskId);
                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@DueDate", dueDate);
                    cmd.Parameters.AddWithValue("@Priority", priority);

                    int result = cmd.ExecuteNonQuery();
                    return result > 0; // Return true if update is successful
                }
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("Error while updating task: " + ex.Message);
            }
        }

        // Delete a task
        public static bool DeleteTask(int taskId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Tasks WHERE TaskId = @TaskId";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@TaskId", taskId);

                    int result = cmd.ExecuteNonQuery();
                    return result > 0; // Return true if deletion is successful
                }
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("Error while deleting task: " + ex.Message);
            }
        }

        // Get all tasks
        public static DataTable GetAllTasks()
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Tasks";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.Fill(dt);
                }
                return dt;
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("Error while fetching tasks: " + ex.Message);
            }
        }

        // Get tasks by specific date
        public static DataTable GetTasksByDate(DateTime date)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Tasks WHERE DueDate = @DueDate";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@DueDate", date);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                return dt;
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("Error while fetching tasks by date: " + ex.Message);
            }
        }

        // Update task completion status
        public static bool UpdateTaskStatus(int taskId, bool isComplete)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Tasks SET IsComplete = @IsComplete WHERE TaskId = @TaskId";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@TaskId", taskId);
                    cmd.Parameters.AddWithValue("@IsComplete", isComplete);

                    int result = cmd.ExecuteNonQuery();
                    return result > 0; // Return true if status update is successful
                }
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("Error while updating task status: " + ex.Message);
            }
        }

        #endregion

        #region User Authentication

        // Authenticate user
        public static bool AuthenticateUser(string username, string password)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT count(*) FROM Users WHERE Username = @Username AND Password = @Password";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("Error while authenticating user: " + ex.Message);
            }
        }

        #endregion

        #region User Registration

        // Register a new user
        public static bool SignUp(string username, string password)
        {
            try
            {
                // Check if username already exists
                if (CheckUsernameExists(username))
                {
                    return false; // Username already exists
                }

                // Insert the new user into the Users table
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Users (Username, Password) VALUES (@Username, @Password)";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    int result = cmd.ExecuteNonQuery();
                    return result > 0; // Return true if insert is successful
                }
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("Error while signing up user: " + ex.Message);
            }
        }

        // Check if the username already exists
        private static bool CheckUsernameExists(string username)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Username", username);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0; // Return true if username exists
                }
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("Error while checking username: " + ex.Message);
            }
        }

        #endregion

        #region Task Filtering by Priority

        // Get tasks by priority
        public static DataTable GetTasksByPriority(string priority)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Tasks WHERE Priority = @Priority";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Priority", priority);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                return dt;
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("Error while fetching tasks by priority: " + ex.Message);
            }
        }

        #endregion

        #region Search Tasks

        // Search tasks by keyword
        public static DataTable SearchTasks(string searchKeyword)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Tasks WHERE Title LIKE @SearchKeyword OR Description LIKE @SearchKeyword";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@SearchKeyword", "%" + searchKeyword + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                return dt;
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("Error while searching tasks: " + ex.Message);
            }
        }

        #endregion

        #region Settings Management

        // Save settings
        public static bool SaveSetting(string settingKey, string settingValue)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Settings (SettingKey, SettingValue) VALUES (@SettingKey, @SettingValue)";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@SettingKey", settingKey);
                    cmd.Parameters.AddWithValue("@SettingValue", settingValue);

                    int result = cmd.ExecuteNonQuery();
                    return result > 0; // Return true if insert is successful
                }
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("Error while saving setting: " + ex.Message);
            }
        }

        // Get setting value by key
        public static string GetSettingValue(string settingKey)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT SettingValue FROM Settings WHERE SettingKey = @SettingKey";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@SettingKey", settingKey);
                    return cmd.ExecuteScalar()?.ToString();
                }
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("Error while retrieving setting value: " + ex.Message);
            }
        }

        #endregion
    }
}

