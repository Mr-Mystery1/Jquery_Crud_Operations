using JQueryCrud.Models;
using System.Data;
using System.Data.SqlClient;

namespace JQueryCrud.Data
{
    public class DataAccessLayer
    {
        string cs = Connection.cs;

        public List<Employee> getAllEmployees()
        {
            List<Employee> empList = new List<Employee>();
            using(SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetAllEmployees", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    Employee emp = new Employee();
                    emp.Id = Convert.ToInt32(reader["Id"]);
                    emp.Name = reader["Name"].ToString()??"";
                    emp.Email = reader["Email"].ToString()??"";
                    emp.Phone = reader["Phone"].ToString()??"";
                    empList.Add(emp);
                }

            }
            return empList;
        }

        public Employee getEmployeeById(int? id)
        {

            Employee emp = new Employee();
            using(SqlConnection  conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetEmployeeId", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    emp.Id = Convert.ToInt32(reader["Id"]);
                    emp.Name = reader["Name"].ToString() ?? "";
                    emp.Email = reader["Email"].ToString() ?? "";
                    emp.Phone = reader["Phone"].ToString() ?? "";
                }
            }

            return emp;
        }

        public void AddEmployee(Employee emp)
        {
            using(SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Email", emp.Email);
                cmd.Parameters.AddWithValue("@Phone", emp.Phone);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        
        }

        public void UpdateEmployee(Employee emp)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spUpdateEmployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", emp.Id);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Email", emp.Email);
                cmd.Parameters.AddWithValue("@Phone", emp.Phone);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteEmployee(int? id)
        {

            
            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            
        }
    }
}
