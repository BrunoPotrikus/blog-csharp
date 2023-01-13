﻿using Blog.Interfaces;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Models
{
    [Table("[Role]")]

    public class Role : Entity<Role>
    {
        public string Name { get; set; }
        public string Slug { get; set; }

    }
}
