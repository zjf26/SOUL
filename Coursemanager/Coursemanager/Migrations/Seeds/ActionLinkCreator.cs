using Coursemanager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coursemanager.Migrations.Seeds
{
    public class ActionLinkCreator
    {
        private readonly Coursemanager.Models.CoursemanagerEntities _context;
        public ActionLinkCreator(Coursemanager.Models.CoursemanagerEntities context)
        {
            _context = context;
        }
        public void seed()
        {
            var intialActionLinks = new List<ActionLink>
            {
              new ActionLink
            {
           Name = "主页",
            Controller="Home",
            Action="Index"
         
            }
            };
            foreach (var action in intialActionLinks)
            {
                if (_context.ActionLink.Any(r => r.Name == action.Name))
                {
                    continue;
                }
                _context.ActionLink.Add(action);
            }
            _context.SaveChanges();
        }
    }
}