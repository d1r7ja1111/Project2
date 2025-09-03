using Microsoft.Data.SqlClient;
using Dapper;
using test.Models;



namespace test.Models
{
    public class UserModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string personal_code { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
    }

 }
