﻿using System.Web;
using System.Web.Mvc;

namespace ERP_Mensajeria
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
