﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterApi.Models
{
    public class UserContext: DbContext
    {
        public UserContext(DbContextOptions options) : base(options) 
        {

        }
        public DbSet<MyUser> Users{ get; set; }


    }
}
