using Coursemanager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coursemanager.Migrations.Seeds
{
    public class UserCreator
    {
        private readonly Coursemanager.Models.CoursemanagerEntities _context;
        public UserCreator(Coursemanager.Models.CoursemanagerEntities context)
        {
            _context = context;
        }
        public void seed()
        {
            var intialUsers = new List<Users>
            {
              new Users
            {
           Account = "admin",
            UserName="admin",
            Passwoed="123456"
         
            }
            };
            foreach (var action in intialUsers)
            {
                if (_context.Users.Any(r => r.UserName == action.UserName))
                {
                    continue;
                }
                _context.Users.Add(action);
            }
            _context.SaveChanges();
        }
    }
}