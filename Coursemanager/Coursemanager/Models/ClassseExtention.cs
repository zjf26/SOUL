using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coursemanager.Models
{
    public partial class Classse
    {
        public string TeacherName
        {
            get
            { 
            if(!TeacherId.HasValue)
            {
                return "";
            }
            CoursemanagerEntities db = new CoursemanagerEntities();
            var teacher = db.Teachers.Where(t => t.Id == TeacherId.Value).FirstOrDefault();
            if (teacher == null)
            {
                return "";
            }
            return teacher.Name;
            }
            
        } 
       

    }
}