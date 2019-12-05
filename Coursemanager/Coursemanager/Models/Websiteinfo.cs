using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coursemanager.Models
{

    public class Websiteinfo
    {
        public const string SiteName = "课程安排系统";

        public List<ActionLink> ActionLinks { get; set; }

        public Websiteinfo()
        {
            ActionLinks = new List<ActionLink>{
        new ActionLink{Name="主页",Controller="Home",Action="index"},
        new ActionLink{Name="关于",Controller="Home",Action="About"},
        new ActionLink{Name="联系方式",Controller="Home",Action="Contact"}
        };
        }
    }
}