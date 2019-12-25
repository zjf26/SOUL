using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursemanager.BLLS
{
    public interface IClassRepository
    {
        List<CourseDetail> GetClassCourse(int id);
    }
}
