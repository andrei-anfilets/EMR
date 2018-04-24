using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace utils
{
   public static class WebApiConfig
    {
        public static String BASE_URL = ConfigurationManager.AppSettings["baseUrl"];
        public static String CRM_LOGIN = ConfigurationManager.AppSettings["CrmLogin"];
        public static String CRM_PASSWORD = ConfigurationManager.AppSettings["CrmPassword"];
        public static String BEARER_TOKEN = ConfigurationManager.AppSettings["Token"];
    }
}
