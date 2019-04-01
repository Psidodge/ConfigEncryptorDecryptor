using System;
using System.Configuration;

namespace ConfigEncryptor
{
    public static class Encryptor
    {
        public static void EncryptConnectionString(string fileName, out string errorMsg)
        {
            Configuration configuration = null;
            errorMsg = null;
            try
            {
                configuration = ConfigurationManager.OpenExeConfiguration(fileName);
                ConnectionStringsSection configSection = configuration.GetSection("connectionStrings") as ConnectionStringsSection;

                if ((!(configSection.ElementInformation.IsLocked)) && (!(configSection.SectionInformation.IsLocked)))
                {
                    if (!configSection.SectionInformation.IsProtected)
                    {
                        configSection.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
                    }

                    configSection.SectionInformation.ForceSave = true;

                    configuration.Save();
                }
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
            }
        }
    }
}
