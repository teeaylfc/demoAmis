using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Reflection;

namespace DLL
{
    public class DataAccess
    {
        //Chuỗi kết nối:
        string _connectionString = @"Data Source=TUANANH-PC;Initial Catalog=Misa.DemoAMIS;Integrated Security=True";
        // Sql Connection:
        SqlConnection _sqlConnection;
        // Sql Command:
        SqlCommand _sqlCommand;

        // Khởi tạo DataAccess:
        public DataAccess() //Mở kết nối
        {
            _sqlConnection = new SqlConnection(_connectionString);
            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }
        }

        public bool CheckUserInfo(string useName, string password) //Kiểm tra tài khoản : trả về true or false
        {
            _sqlCommand = _sqlConnection.CreateCommand();
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.CommandText = "[dbo].[Proc_CheckLoginInfo]";
            _sqlCommand.Parameters.AddWithValue("@UserName", useName);
            _sqlCommand.Parameters.AddWithValue("@Password", password);
            bool result = (bool)_sqlCommand.ExecuteScalar();
            return result;
            //    SqlDataReader sqlDataReader = _sqlCommand.ExecuteReader();
            //    if (sqlDataReader.Read())
            //    {
            //        var user = new User();
            //        // Thực hiện đọc dữ liệu từng dòng->cột-> cell:
            //        for (int i = 0; i < sqlDataReader.FieldCount; i++)
            //        {
            //            // Tên cột
            //            string fieldName = sqlDataReader.GetName(i);

            //            PropertyInfo property = user.GetType().GetProperty(fieldName);
            //            // Nếu tên cột trùng với tên propery thì gán giá trị tương ứng:
            //            if (property != null && sqlDataReader[fieldName] != DBNull.Value)
            //            {
            //                property.SetValue(user, sqlDataReader[fieldName], null);
            //            }
            //        }
            //        // Thêm đối tượng vào List:
            //        return user;
            //    }
            //    return null;
            //}
        }

        public void RegisterAccount(User user) //Đăng kí tài khoản truyền vào 1 User
        {
         
            String query = "INSERT INTO dbo.[User](UserID,UserName,Password) VALUES (NEWID(),'"+user.UserName+"','"+user.Password+"')";
            _sqlCommand = new SqlCommand(query, _sqlConnection);
            _sqlCommand.ExecuteNonQuery();
        }

        public List<Post> GetListPost()
        {
            List<Post> posts = new List<Post>();
            // Khởi tạo Sql Command để thao tác với dữ liệu:
            _sqlCommand = _sqlConnection.CreateCommand();

            // Chọn loại truy vấn để thao tác với dữ liệu:
            _sqlCommand.CommandType = CommandType.StoredProcedure;

            _sqlCommand.CommandText = "[dbo].[Proc_GetPostList]";

            // Khởi tạo đối tượng SqlDataReader để hứng dữ liệu trả về từ Store:
            SqlDataReader sqlDataReader = _sqlCommand.ExecuteReader();

            // Duyệt từng dòng dữ liệu trong sqlDataReader:
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
        public bool UpPost(Post post)  //Up status thao tác vs csdl
        {
            string sql = "INSERT dbo.Post(PostID,UserID,PostContent,CreatedDate)VALUES(NEWID(),'@UserID',N'@PostContent',GETDATE())";
            try
            {
                _sqlCommand = new SqlCommand(sql, _sqlConnection);
                _sqlCommand.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = post.UserID;
                _sqlCommand.Parameters.Add("@PostContent", SqlDbType.NVarChar).Value = post.PostContent;
                _sqlCommand.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                return false;
            }

            return true;
        }
        public List<Entity.Comment> GetListComment() // Lấy danh sách comment
        {
            List<Entity.Comment> Comments = new List<Comment>();
            _sqlCommand = _sqlConnection.CreateCommand();
            _sqlCommand.CommandType = CommandType.StoredProcedure;
            _sqlCommand.CommandText = "";
            SqlDataReader sqldata = _sqlCommand.ExecuteReader();
            while (sqldata.Read())
            {
                var Comment = new Comment();
                // Thực hiện đọc dữ liệu từng dòng->cột-> cell:
                for (int i = 0; i < sqldata.FieldCount; i++)
                {
                    // Tên cột
                    string fieldName = sqldata.GetName(i);

                    PropertyInfo property = Comment.GetType().GetProperty(fieldName);
                    // Nếu tên cột trùng với tên propery thì gán giá trị tương ứng:
                    if (property != null && sqldata[fieldName] != DBNull.Value)
                    {
                        property.SetValue(Comment, sqldata[fieldName], null);
                    }
                }
                // Thêm đối tượng vào List:
                Comments.Add(Comment);
            }
            return Comments;
        }
    }
}
    
