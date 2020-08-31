using HRMS.Core.Contracts;
using HRMS.Core.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Repo
{
    public class EmployeeRepo : IEmployeeRepo
    {
        ApplicationDbContext db;
        private readonly string CONNECTION_STRING;
        private readonly string ID = "Id";
        private readonly string FIRST_NAME = "FirstName";
        private readonly string LAST_NAME = "LastName";
        private readonly string On_Time_CREATED = "OnTimeCreated";
        private readonly string ADDRESS = "Address";
        private readonly string EMAIL = "Email";
        private readonly string MOBILE = "Mobile";
        private readonly string USERNAME = "UserName";
        private readonly string PASSWORD = "Password";
        private readonly string DIRECTMANAGER = "DirectMangerId";
        private readonly string DMFIRSTNAME = "DMFirstName";
        private readonly string DMLASTNAME = "DMLastName";

        public EmployeeRepo(IConfiguration configuration)
        {
            CONNECTION_STRING = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<EmployeeEntity>> GetAllEmployee()
        {
            try
            {
                List<EmployeeEntity> empList = new List<EmployeeEntity>();
                using (SqlConnection sql = new SqlConnection(CONNECTION_STRING))

                {

                    using (SqlCommand cmd = new SqlCommand("GetAllEmployee", sql))

                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        await sql.OpenAsync();
                        IDataReader dataReader = await cmd.ExecuteReaderAsync();
                        while (dataReader.Read())
                        {
                            EmployeeEntity employee = new EmployeeEntity();
                            employee.Id = Convert.ToInt32(dataReader[ID]);
                            employee.FirstName = Convert.ToString(dataReader[FIRST_NAME]);
                            employee.LastName = Convert.ToString(dataReader[LAST_NAME]);
                            employee.OntimeCreted = Convert.ToDateTime(dataReader[On_Time_CREATED]);
                            employee.Address = Convert.ToString(dataReader[ADDRESS]);
                            employee.Email = Convert.ToString(dataReader[EMAIL]);
                            employee.Mobile = Convert.ToString(dataReader[MOBILE]);
                            employee.UserName = Convert.ToString(dataReader[USERNAME]);
                            //employee.Password = Convert.ToString(dataReader[PASSWORD]);
                            employee.DirectManager = Convert.ToString(dataReader[DIRECTMANAGER]);
                            employee.DMFirstName = Convert.ToString(dataReader[DMFIRSTNAME]);
                            employee.DMLastName = Convert.ToString(dataReader[DMLASTNAME]);

                            empList.Add(employee);
                        }

                        dataReader.Close();
                        cmd.Connection.Close();
                    }

                }
                return empList;

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void Insert(EmployeeEntity employee)

        {

            using (SqlConnection sql = new SqlConnection(CONNECTION_STRING))

            {

                using (SqlCommand cmd = new SqlCommand("[InsertEmployee]", sql))

                {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;


                    cmd.Parameters.Add(new SqlParameter("@FirstName", employee.FirstName));

                    cmd.Parameters.Add(new SqlParameter("@LastName", employee.LastName));

                    cmd.Parameters.Add(new SqlParameter("@Gender", employee.Gender));

                    cmd.Parameters.Add(new SqlParameter("@OnTimeCreated", employee.OntimeCreted));

                    cmd.Parameters.Add(new SqlParameter("@Address", employee.Address));

                    cmd.Parameters.Add(new SqlParameter("@Email", employee.Email));

                    cmd.Parameters.Add(new SqlParameter("@Mobile", employee.Mobile));

                    cmd.Parameters.Add(new SqlParameter("@UserName", employee.UserName));

                    cmd.Parameters.Add(new SqlParameter("@Password", employee.Password));

                    sql.Open();

                    cmd.ExecuteNonQuery();

                }

            }

        }

        public EmployeeEntity GetEmployeeById(int id)
        {
            EmployeeEntity employee = new EmployeeEntity();
            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                string sqlQuery = "SELECT * FROM Employee WHERE Id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    employee.Id = Convert.ToInt32(rdr["Id"]);
                    employee.FirstName = rdr["FirstName"].ToString();
                    employee.LastName = rdr["LastName"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.OntimeCreted = Convert.ToDateTime(rdr["OnTimeCreated"]);
                    employee.Address = rdr["Address"].ToString();
                    employee.Email = rdr["Email"].ToString();
                    employee.Mobile = rdr["Mobile"].ToString();
                    employee.UserName = rdr["UserName"].ToString();
                    employee.Password = rdr["Password"].ToString();
                
                }
            }
            return employee;

        }
        public void UpdateEmployee(EmployeeEntity employee)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
                {
                    SqlCommand cmd = new SqlCommand("UpdateEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", employee.Id);
                    cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                    cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                    cmd.Parameters.AddWithValue("@OnTimeCreated", employee.OntimeCreted);
                    cmd.Parameters.AddWithValue("@Address", employee.Address);
                    cmd.Parameters.AddWithValue("@Email", employee.Email);
                    cmd.Parameters.AddWithValue("@Mobile", employee.Mobile);
                    cmd.Parameters.AddWithValue("@UserName", employee.UserName);
                    cmd.Parameters.AddWithValue("@Password", employee.Password);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch(Exception e)
            {
                throw;

            }
        }

        public void DeleteEmployee(int id)
        {
            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                SqlCommand cmd = new SqlCommand("DeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }



    }
}


