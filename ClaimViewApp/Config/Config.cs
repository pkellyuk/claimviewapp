using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimViewApp
{
    public static class Config
    {
        public static string RunMode = GetSetting("RunMode");
        public static string Claimdb_host = string.Empty;
        public static string Claimdb_user = string.Empty;
        public static string Claimdb_pass = string.Empty;
        public static string Claimdb_db = string.Empty;

        public static void InitSettings()
        {
            if(RunMode == "LIVE")
            {
                Claimdb_host = GetSetting("Claimdb_host_" + RunMode);
                Claimdb_user = GetSetting("Claimdb_user_" + RunMode);
                Claimdb_pass = GetSetting("Claimdb_pass_" + RunMode);
                Claimdb_db = GetSetting("Claimdb_db_" + RunMode);
            }

            if(RunMode == "DEV")
            {
                Claimdb_host = GetSetting("Claimdb_host_" + RunMode);
                Claimdb_user = GetSetting("Claimdb_user_" + RunMode);
                Claimdb_pass = GetSetting("Claimdb_pass_" + RunMode);
                Claimdb_db = GetSetting("Claimdb_db_" + RunMode);
            }
        }

        public static string GetSetting(string settingKey)
        {
            try
            {
                IConfigurationBuilder builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                IConfigurationRoot configuration = builder.Build();
                IConfigurationSection configurationSection = configuration.GetSection("AppConfig").GetSection(settingKey);
                return configurationSection.Value;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
