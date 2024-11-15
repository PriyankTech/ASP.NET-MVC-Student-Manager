using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;

namespace Priyank.Models
{
    public static class StudentRepository
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public static List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Students", connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    students.Add(new Student
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Age = (int)reader["Age"],
                        Email = (string)reader["Email"]
                    });
                }
            }

            return students;
        }

        public static Student GetStudentById(int id)
        {
            Student student = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Students WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    student = new Student
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Age = (int)reader["Age"],
                        Email = (string)reader["Email"]
                    };
                }
            }

            return student;
        }

        public static void AddStudent(Student student)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Students (Name, Age, Email) VALUES (@Name, @Age, @Email)", connection);
                command.Parameters.AddWithValue("@Name", student.Name);
                command.Parameters.AddWithValue("@Age", student.Age);
                command.Parameters.AddWithValue("@Email", student.Email);
                command.ExecuteNonQuery();
            }
        }

        public static void UpdateStudent(Student student)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE Students SET Name = @Name, Age = @Age, Email = @Email WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Name", student.Name);
                command.Parameters.AddWithValue("@Age", student.Age);
                command.Parameters.AddWithValue("@Email", student.Email);
                command.Parameters.AddWithValue("@Id", student.Id);
                command.ExecuteNonQuery();
            }
        }

        public static void DeleteStudent(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Students WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}
