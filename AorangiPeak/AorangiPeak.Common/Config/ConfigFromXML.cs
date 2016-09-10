using System.Configuration;

namespace AorangiPeak.Common.Config
{
    public class ConfigFromXML : IConfiguration
    {
        public string EmailFromAddress
        {
            get
            {
                return GetConfigurationSetting("EmailFromAddress");
            }
        }

        public string EmailVerifyAddress
        {
            get
            {
                return GetConfigurationSetting("EmailVerifyAddress");
            }
        }

        private string GetConfigurationSetting(string key)
        {
            string value = ConfigurationManager.AppSettings.Get(key);
            if (value == null)
            {

            }

            return value;
        }
    }
}
