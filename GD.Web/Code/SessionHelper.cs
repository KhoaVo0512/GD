using GD.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GD.Web
{
    public class SessionHelper
    {
        public static List<MenuViewModel> MenuGlobal
        {
            get
            {
                if (HttpContext.Current.Session["Menu"] == null)
                    return null;
                return HttpContext.Current.Session["Menu"] as List<MenuViewModel>;
            }
            set { HttpContext.Current.Session["Menu"] = value; }
        }
        public static List<MenuGroupViewModel> MenuGroupGlobal
        {
            get
            {
                if (HttpContext.Current.Session["MenuGroup"] == null)
                    return null;
                return HttpContext.Current.Session["MenuGroup"] as List<MenuGroupViewModel>;
            }
            set { HttpContext.Current.Session["MenuGroup"] = value; }
        }
        public static EmployeeGlobal Information
        {
            get
            {
                if (HttpContext.Current.Session["EmployeeGlobal"] == null)
                    return null;
                return HttpContext.Current.Session["EmployeeGlobal"] as EmployeeGlobal;
            }
            set { HttpContext.Current.Session["EmployeeGlobal"] = value; }
        }

        public static List<ScoreViewModel> ScoreGlobal
        {
            get
            {
                if (HttpContext.Current.Session["ScoreGlobal"] == null)
                    return null;
                return HttpContext.Current.Session["ScoreGlobal"] as List<ScoreViewModel>;
            }
            set { HttpContext.Current.Session["ScoreGlobal"] = value; }
        }

        public static TitleScore TitleScore
        {
            get
            {
                if (HttpContext.Current.Session["TitleScore"] == null)
                    return null;
                return HttpContext.Current.Session["TitleScore"] as TitleScore;
            }
            set { HttpContext.Current.Session["TitleScore"] = value; }
        }
    }
}