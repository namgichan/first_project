using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1
{
	public class news_services
	{
		public string ConnectionString { get; set; }
		public news_services(string connectionString)
		{
			ConnectionString = connectionString;
		}
		private MySqlConnection GetConnection()
		{
			return new MySqlConnection(ConnectionString);
		}
		public List<NewsTBL> GetNews()
		{   // C#에서 클래스는 모두 동적 메모리 할당
			List<NewsTBL> list = new List<NewsTBL>();
			string SQL = "select * from newstbl";
			using (MySqlConnection conn = GetConnection())
			{
				conn.Open();
				MySqlCommand cmd = new MySqlCommand(SQL, conn);
				using (var reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						list.Add(new NewsTBL
						{
							NewsNum = Convert.ToInt32(reader["newsnum"]),
							NewsArea = reader["newsarea"].ToString(),
							NewsTitle = reader["newstitle"].ToString(),
							NewsCont = reader["newscont"].ToString(),
							NewsPreDate = Convert.ToDateTime(reader["newspredate"]),
							Hits = Convert.ToInt32(reader["Hits"] as int?),
							UserID = reader["userid"].ToString()
						});
					}
				}
				conn.Close();
			}
			return list;
		}
		public NewsTBL SelectNews(int id)
		{
			NewsTBL news = new NewsTBL();
			string selectSQL = "SELECT * FROM newstbl WHERE newsnum = @newsnum";
			string updateHitsSQL = "UPDATE newstbl SET Hits = Hits + 1 WHERE newsnum = @newsnum";

			using (MySqlConnection conn = GetConnection())
			{
				conn.Open();
				using (MySqlTransaction transaction = conn.BeginTransaction())
				{
					try
					{
						// 조회수 업데이트 쿼리 실행
						MySqlCommand updateCmd = new MySqlCommand(updateHitsSQL, conn);
						updateCmd.Parameters.AddWithValue("@newsnum", id);
						updateCmd.ExecuteNonQuery();

						// 뉴스 항목 조회 쿼리 실행
						MySqlCommand selectCmd = new MySqlCommand(selectSQL, conn);
						selectCmd.Parameters.AddWithValue("@newsnum", id);

						using (var reader = selectCmd.ExecuteReader())
						{
							if (reader.Read())
							{
								news.NewsNum = Convert.ToInt32(reader["newsnum"]);
								news.NewsArea = reader["newsarea"].ToString();
								news.NewsTitle = reader["newstitle"].ToString();
								news.NewsCont = reader["newscont"].ToString();
								news.NewsPreDate = Convert.ToDateTime(reader["newspredate"]);
								news.Hits = Convert.ToInt32(reader["Hits"]);
								news.UserID = reader["userid"].ToString();
							}
						}

						transaction.Commit(); // 트랜잭션 커밋
					}
					catch (Exception ex)
					{
						transaction.Rollback(); // 에러 발생 시 롤백
												// 에러 처리 로직 추가
					}
				}
				conn.Close();
			}


			return news;
		}

		public int UpdateNews(int newsnum, string newsarea, string newstitle,
			  string newscont, string userid)
		{
			string SQL = "update newstbl set newsarea = @newsarea, newstitle = @newstitle, newscont = @newscont, newspredate = now(), userid = @userid where newsnum = @newsnum";


			using (MySqlConnection conn = GetConnection())
			{
				conn.Open();
				try
				{
					MySqlCommand cmd = new MySqlCommand(SQL, conn);
					cmd.Parameters.AddWithValue("@newsnum", newsnum);
					cmd.Parameters.AddWithValue("@newsarea", newsarea);
					cmd.Parameters.AddWithValue("@newstitle", newstitle);
					cmd.Parameters.AddWithValue("@newscont", newscont);
					//cmd.Parameters.AddWithValue("@newspredate", newspredate);
					//cmd.Parameters.AddWithValue("@hits", hits);
					cmd.Parameters.AddWithValue("@userid", userid);


					if (cmd.ExecuteNonQuery() == 1)
					{
						Console.WriteLine("수정 성공!!");
						return 1;
					}
					else
					{
						Console.WriteLine("수정 실패!!");
						return 0;
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine("데이터베이스 접속 실패");
					Console.WriteLine(ex.Message);
				}
				conn.Close();
			}
			return 0;
		}
		public int InsertNews(string newsarea, string newstitle,
			string newscont, string userid)
		{
			string SQL = "INSERT INTO newstbl (newsarea, newstitle, newscont, userid) VALUES (@newsarea, @newstitle, @newscont, @userid)";

			using (MySqlConnection conn = GetConnection())
			{
				try
				{
					conn.Open();
					MySqlCommand cmd = new MySqlCommand(SQL, conn);
					//cmd.Parameters.AddWithValue("@newsnum", newsnum);
					cmd.Parameters.AddWithValue("@newsarea", newsarea);
					cmd.Parameters.AddWithValue("@newstitle", newstitle);
					cmd.Parameters.AddWithValue("@newscont", newscont);
					//cmd.Parameters.AddWithValue("@newspredate", newspredate);
					//cmd.Parameters.AddWithValue("@hits", hits);
					cmd.Parameters.AddWithValue("@userid", userid);

					if (cmd.ExecuteNonQuery() == 1)
					{
						Console.WriteLine("삽입 성공!!"); return 1;
					}
					else
					{
						Console.WriteLine("삽입 실패!!"); return 0;
					}
				}
				catch (Exception e)
				{
					Console.WriteLine("DB 연결 실패!!!");
					Console.WriteLine(e.Message);
				}
				conn.Close();
			}
			return 0;
		}
		public int DeleteNews(int newsnum)
		{
			string SQL = "DELETE FROM newstbl WHERE newsnum = @newsnum";

			using (MySqlConnection conn = GetConnection())
			{
				try
				{
					conn.Open();
					MySqlCommand cmd = new MySqlCommand(SQL, conn);
					cmd.Parameters.AddWithValue("@newsnum", newsnum);

					if (cmd.ExecuteNonQuery() == 1)
					{
						Console.WriteLine("삭제 성공!!!"); return 1;
					}
					else
					{
						Console.WriteLine("삭제 실패!!!"); return 0;
					}
				}
				catch (Exception e)
				{
					Console.WriteLine("DB 연결 실패!!!");
					Console.WriteLine(e.Message);
				}
				conn.Close();
			}
			return 0;
		}

		public List<NewsTBL> SearchNews(string titleQuery, string areaQuery)
		{
			List<NewsTBL> searchResults = new List<NewsTBL>();
			string SQL = "SELECT * FROM newstbl WHERE NewsTitle LIKE @titleQuery AND NewsArea LIKE @areaQuery";

			using (MySqlConnection conn = GetConnection())
			{
				conn.Open();
				MySqlCommand cmd = new MySqlCommand(SQL, conn);
				cmd.Parameters.AddWithValue("@titleQuery", "%" + titleQuery + "%"); // 제목 검색어에 대한 와일드카드 사용
				cmd.Parameters.AddWithValue("@areaQuery", "%" + areaQuery + "%");   // 지역 검색어에 대한 와일드카드 사용

				using (var reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						searchResults.Add(new NewsTBL
						{
							NewsNum = Convert.ToInt32(reader["newsnum"]),
							NewsArea = reader["newsarea"].ToString(),
							NewsTitle = reader["newstitle"].ToString(),
							NewsCont = reader["newscont"].ToString(),
							NewsPreDate = Convert.ToDateTime(reader["newspredate"]),
							Hits = Convert.ToInt32(reader["Hits"] as int?),
							UserID = reader["userid"].ToString()
						});
					}
				}

				conn.Close();
			}

			return searchResults;
		}


	}
}