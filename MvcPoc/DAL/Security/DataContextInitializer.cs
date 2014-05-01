﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcPoc.Web;
using System.Data.Entity;
namespace MvcPoc.Web.DAL.Security
{
    public class DataContextInitializer : CreateDatabaseIfNotExists<DataContext>
    {

        protected override void Seed(DataContext context)
        {
            Role role1 = new Role { RoleName = "Admin" };
            Role role2 = new Role { RoleName = "User" };

            User user1 = new User { UserName = "admin", Email = "admin@ymail.com", FirstName = "Admin", Password = "123456", IsActive = true, CreateDate = DateTime.UtcNow, Roles = new List<Role>() };

            User user2 = new User { UserName = "user", Email = "user1@ymail.com", FirstName = "User", Password = "123456", IsActive = true, CreateDate = DateTime.UtcNow, Roles = new List<Role>() };

            user1.Roles.Add(role1);
            user2.Roles.Add(role2);

            context.Users.Add(user1);
            context.Users.Add(user2);

            context.SaveChanges();
        }
    }
}