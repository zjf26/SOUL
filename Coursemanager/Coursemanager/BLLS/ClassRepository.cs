using Coursemanager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coursemanager.BLLS
{
    public class ClassRepository : IClassRepository
    {
        protected CoursemanagerEntities db = new CoursemanagerEntities();



        public List<CourseDetail> GetClassCourse(int id)
        {
            var query =
                from cm in db.CourseManagements
                join c in db.Classse
                    on cm.ClassId equals c.Id
                join cr in db.Courses
                    on cm.CourseId equals cr.Id
                join ct in db.Teachers
                    on cm.TeacherId equals ct.Id
                where cm.ClassId == id
                select new CourseDetail
                {
                    ClassName = c.Name,
                    CourseName = cr.Name,
                    TeacherName = ct.Name
                };
            return query.ToList();
        }
    }
}