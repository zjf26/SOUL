using Coursemanager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coursemanager.Migrations.Seeds
{
    public class SidebarCreator
    {
        private readonly Coursemanager.Models.CoursemanagerEntities _context;
        public SidebarCreator(Coursemanager.Models.CoursemanagerEntities context)
        {
            _context = context;
        }
        public void seed()
        {
            var intialSidebars = new List<Sidebar>
            {
              new Sidebar
            {
            Name = "班级管理",
            Controller="Classse",
            Action="Index"
         
            },
              new Sidebar
            {
            Name = "教师管理",
            Controller="Teachers",
            Action="Index"
         
            },
              new Sidebar
            {
            Name = "学生管理",
            Controller="Student",
            Action="Index"
         
            },
              new Sidebar
            {
            Name = "课程科目管理",
            Controller="Course",
            Action="Index"
         
            },
              new Sidebar
            {
            Name = "课程安排",
            Controller="CourseManagement",
            Action="Index"
         
            },
              new Sidebar
            {
            Name = "顶部导航栏管理",
            Controller="Actionlink",
            Action="Index"
         
            },
              new Sidebar
            {
            Name = "侧面导航栏管理",
            Controller="Sidebars",
            Action="Index"
         
            }
            };
            foreach (var bar in intialSidebars)
            {
                if (_context.Sidebar.Any(r => r.Name == bar.Name))
                {
                    continue;
                }
                _context.Sidebar.Add(bar);
            }
            _context.SaveChanges();
        }
    }
}