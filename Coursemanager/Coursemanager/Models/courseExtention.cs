using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coursemanager.Models
{
    public partial class CourseManagement
    {
        public string CourseName
        {
            get
            {
                if (CourseId == 0)
                {
                    return "";
                }
                CoursemanagerEntities db = new CoursemanagerEntities();
                var cour = db.Courses.Where(t => t.Id == CourseId).FirstOrDefault();
                if (cour == null)
                {
                    return "";
                }
                return cour.Name;
            }
        }
        public string TeacherName
        {
            get
            {
                if (TeacherId == 0)
                {
                    return "";
                }
                CoursemanagerEntities db = new CoursemanagerEntities();
                var teacher = db.Teachers.Where(t => t.Id == TeacherId).FirstOrDefault();
                if (teacher == null)
                {
                    return "";
                }
                return teacher.Name;
            }

        }
        public string ClassName
        {
            get
            {
                if (ClassId == 0)
                {
                    return "";
                }
                CoursemanagerEntities db = new CoursemanagerEntities();
                var classes = db.Classse.Where(t => t.Id == ClassId).FirstOrDefault();
                if (classes == null)
                {
                    return "";
                }
                return classes.Name;
            }

        }

    }
}