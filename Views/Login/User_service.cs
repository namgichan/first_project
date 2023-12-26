using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using static System.Console;
using Project.Models;
using System.Reflection.Metadata.Ecma335;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Net.Mail;
using System.Data;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Reflection.PortableExecutable;
using Org.BouncyCastle.Bcpg;

namespace Project
{
    public class User_service
    {
        public string ConnectionString { get; set; }

        public User_service(string connectionString)
        {
            ConnectionString = connectionString;
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<Users> GetUsers()
        {
            List<Users> list = new List<Users>();
            string SQL = "select * from users";
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(SQL, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Users()
                        {
                            userId = reader["userId"].ToString(),
                            pwd = reader["pwd"].ToString(),
                            userName = reader["userName"].ToString(),
                            userPhone = reader["userPhone"].ToString(),
                            userEmail = reader["userEmail"].ToString(),
                            userAddr = reader["userAddr"].ToString(),
                            gender = reader["gender"].ToString()
                        });
                    }
                }
                conn.Close();
            }
            return list;
        }

        public int Create(string id, string password, string name, string phone, string email, string addr, string gender)
        {
            Users users = new Users();
            string SQL = "call project.create_proc('" + id + "', '" + password + "', '" + name + "', '" + phone + "', '" + email + "', '" + addr + "', '" + gender + "');";
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                try
                {
                    MySqlCommand cmd = new MySqlCommand(SQL, conn);

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        WriteLine("가입 성공!!");
                        return 1;
                    }
                    else
                    {
                        WriteLine("가입 실패!!");
                        return 0;
                    }
                }
                catch (Exception ex)
                {
                    WriteLine("DB 연결 실패!!");
                    WriteLine(ex.Message);
                }
                conn.Close();
            }
            return 0;
        }

        public int Delete(string id)
        {
            Users users = new Users();
            string SQL = "delete_proc";
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = SQL;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue ("@Id", id);
                cmd.Parameters["@Id"].Direction = System.Data.ParameterDirection.Input;
                try
                {
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        WriteLine("삭제 완료");
                        return 1;
                    }
                    else
                    {
                        WriteLine("삭제 실패");
                        return 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                conn.Close();
            }
            return 0;
        }

        public Users Select(string id)
        {
            Users user = new Users();
            string SQL = "select_proc";
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = SQL;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters["@id"].Direction = System.Data.ParameterDirection.Input;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user = new Users()
                        {
                            userId = reader["userId"].ToString(),
                            pwd = reader["pwd"].ToString(),
                            userName = reader["userName"].ToString(),
                            userPhone = reader["userPhone"].ToString(),
                            userEmail = reader["userEmail"].ToString(),
                            userAddr = reader["userAddr"].ToString(),
                            gender = reader["gender"].ToString()
                        };
                    }
                }
                conn.Close();
            }
            return user;
        }

        public int Update(string id, string password, string name, string phone, string email, string addr, string gender)
        {
            Users users = new Users();  
            string SQL = "project.update_proc";
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();

                try
                {
                    MySqlCommand cmd = new MySqlCommand(SQL, conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@u_id", id);
                    cmd.Parameters.AddWithValue("@u_pwd", password);
                    cmd.Parameters.AddWithValue("@u_name", name);
                    cmd.Parameters.AddWithValue("@u_phone", phone);
                    cmd.Parameters.AddWithValue("@u_Email", email);
                    cmd.Parameters.AddWithValue("@u_Addr", addr);
                    cmd.Parameters.AddWithValue("@u_gender", gender);

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        WriteLine("수정 성공!!");
                        return 1;
                    }
                    else
                    {
                        WriteLine("수정 실패!!");
                        return 0;
                    }
                }
                catch (MySqlException ex)
                {
                    WriteLine("데이터 베이스 접속 실패");
                    WriteLine(ex.Message);
                }
                conn.Close();
            }
            return 0;
        }

        public int Login(string id, string password)
        {
            Users users = new Users();
            string SQL = "select_proc";
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = SQL;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        users = new Users()
                        {
                            userId = reader["userId"].ToString(),
                            pwd = reader["pwd"].ToString()
                        };

                        if(id == users.userId && users.pwd == password)
                        {
                            WriteLine("로그인성공");
                            return 1;
                        }
                        else
                        {
                            WriteLine("로그인 실패");
                            return 0;
                        }
                    }
                }
                conn.Close();
            }
            return 0;
        }


        public Users Mypage(string id)
        {
            Users user = new Users();
            string SQL = "select_proc";
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = SQL;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters["@id"].Direction = System.Data.ParameterDirection.Input;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user = new Users()
                        {
                            userId = reader["userId"].ToString(),
                            pwd = reader["pwd"].ToString(),
                            userName = reader["userName"].ToString(),
                            userPhone = reader["userPhone"].ToString(),
                            userEmail = reader["userEmail"].ToString(),
                            userAddr = reader["userAddr"].ToString(),
                            gender = reader["gender"].ToString()
                        };
                    }
                }
                conn.Close();
            }
            return user;
        }


    }
}
