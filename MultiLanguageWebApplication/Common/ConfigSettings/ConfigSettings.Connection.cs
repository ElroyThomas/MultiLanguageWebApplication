using System.Web.Configuration;

namespace MultiLanguageWebApplication.Common.ConfigSettings
{
    public partial class ConfigSettings
    {
        public static string ConnectionString
        {
            get
            {
                return WebConfigurationManager.ConnectionStrings["ConString"].ToString();
            }
        }
    }
}