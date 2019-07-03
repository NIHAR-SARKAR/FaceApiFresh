using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace FaceApiFresh.Util
{
    public class AppUtil
    {
        public static string ApiUri
        {
            get{ return ConfigurationManager.AppSettings["ApiUri"].ToString();}
        }
        public static string ApiKey
        {
            get{return ConfigurationManager.AppSettings["ApiKey"].ToString();}
        }
    }
}