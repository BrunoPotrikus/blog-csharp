using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Models
{
    [Table("[Tag]")]

    public class Tag : Entity
    {
        public string Name { get; set; }
        public string Slug { get; set; }

        public Tag(SqlConnection connection)
        {

        }
    }
}
