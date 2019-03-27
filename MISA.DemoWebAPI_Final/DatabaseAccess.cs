using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Reflection;
using Entity;

namespace MISA.DemoWebAPI_Final
{
    /// <summary>
    /// Đối tượng thực hiện tương tác với Database
    /// </summary>
    public class DatabaseAccess
    {
        SqlConnection _sqlConnection;
        SqlCommand _sqlCommand;
        string _connectionString = @"Data Source=DATABASE\SQL2014;Initial Catalog=MISA.DemoAMIS;Integrated Security=True";
        public DatabaseAccess()
        {
            // Khởi tạo mới một SQL Connection tới DB:
            _sqlConnection = new SqlConnection(_connectionString);
            // Thực hiện mở kết nối (nếu kết nối đang đóng thì mở):
            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }
        }
        /// <summary>
        /// Hàm kiểm tra thông tin đăng nhập
        /// </summary>
        /// <param name="userName">Tên người dùng</param>
        /// <param name="password">mạt khẩu</param>
        /// <returns></returns>
        public bool CheckLoginInfo(string userName, string password)
        {
            return true;
        }

        public List<Post> GetListPost()
        {
            List<Post> posts = new List<Post>();
            // Khởi tạo Sql Command để thao tác với dữ liệu:
            _sqlCommand = _sqlConnection.CreateCommand();

            // Chọn loại SqlCommand để thao tác với dữ liệu:
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.CommandText = "[dbo].[Proc_GetPostList]";

            // Khởi tạo đối tượng SqlDataReader để hứng dữ liệu trả về từ Store:
            SqlDataReader sqlDataReader = _sqlCommand.ExecuteReader();

            // Duyệt từng dòng dữ liệu trong Dataread
            while (sqlDataReader.Read())
            {
                var post = new Post();
                // Thực hiện đọc dữ liệu từng dòng->cột-> cell:
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    // Tên cột
                    string fieldName = sqlDataReader.GetName(i);

                    PropertyInfo property = post.GetType().GetProperty(fieldName);
                    // Nếu tên cột trùng với tên propery thì gán giá trị tương ứng:
                    if (property != null && sqlDataReader[fieldName] != DBNull.Value)
                    {
                        property.SetValue(post, sqlDataReader[fieldName], null);
                    }
                }
                // Thêm đối tượng vào List:
                posts.Add(post);
            }
            return posts;
        }
    }
}