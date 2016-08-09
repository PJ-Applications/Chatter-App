using System.Web;
using System.Web.Mvc;

namespace Chatter
{
    public class FilterConfig
    {
        //all changes from tutorial worked to block/manage user access but the code below for some reason
        //still blocks user access with code on home and chat controllers even with this commented out...

        //tried updating database and re-building still got error: "localhost refused to connect." 
            //when using below tutorial code...

        //public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        //{
        //    filters.Add(new HandleErrorAttribute());
        //    filters.Add(new System.Web.Mvc.AuthorizeAttribute());
        //    filters.Add(new RequireHttpsAttribute());
        //}

        //old code... just in case
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
