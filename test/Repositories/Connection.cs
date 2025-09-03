using Microsoft.Data.SqlClient;
using Dapper;
using test.Models;

namespace test.Repositories
{
    public class Connection
    {
        private readonly string stringForConnection;

        public Connection(IConfiguration configuration)
        {
            stringForConnection = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<UserModel>> GetAllUsers()
        {
            using var testConnect = new SqlConnection(stringForConnection);
            var sql = "Select * from Users";
            return await testConnect.QueryAsync<UserModel>(sql);
        }
        public async Task<int> Create(UserModel user)
        {
            using var testConnect = new SqlConnection(stringForConnection);
            var sql = @"
                INSERT INTO Users (name, surname, personal_code, start_date, end_date)
                VALUES (@name, @surname, @personal_code, @start_date, @end_date);
                SELECT CAST(SCOPE_IDENTITY() as int)";
            return await testConnect.ExecuteScalarAsync<int>(sql, user);
        }
        public async Task<UserModel?> GetUserById(int id) //read
        {
            using var testConnect = new SqlConnection(stringForConnection);
            var sql = "Select * from Users where Id = @Id";
            return await testConnect.QueryFirstOrDefaultAsync<UserModel>(sql, new { Id = id });
        }
        
        public async Task<int> Update(UserModel user)
        {
            using var testConnect = new SqlConnection(stringForConnection);
            var sql = @"
                UPDATE Users
                SET Name=@name, Surname=@surname, PersonalCode=@personal_code, StartDate=@start_date, EndDate=@end_date
                WHERE Id=@Id";
            return await testConnect.ExecuteAsync(sql, user);
        }

        public async Task<int> Delete(int id)
        {
            using var testConnect = new SqlConnection(stringForConnection);
            var sql = @"
                Delete from Users
                Where Id=@Id";
            return await testConnect.ExecuteAsync(sql, new { Id = id });
        }

       
    }
}