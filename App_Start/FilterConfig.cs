﻿using System.Web;
using System.Web.Mvc;

namespace Buoi_3_Bai_1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
