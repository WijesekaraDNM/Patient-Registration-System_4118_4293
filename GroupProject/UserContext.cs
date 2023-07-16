using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject
{
    public class UserContext:DbContext
    {
        //private readonly string path = @"D:\Documents\Rashmitha\Academic\Semester 3\EE3206 - GUI Programming\GroupProjectFinalVersion\GroupProject\DataBase\User.db";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite($"Data Source=.\\Database\\User.db");

        public DbSet<User> Users { get; set; }
    }
}
