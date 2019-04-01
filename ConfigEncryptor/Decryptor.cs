using System;
using System.Configuration;

namespace ConfigEncryptor
{
    public static class Decryptor
    {
        public static void DecryptConnectionString(string fileName, out string errorMsg)
        {
            Configuration configuration = null;
            errorMsg = null;
            try
            {
                configuration = ConfigurationManager.OpenExeConfiguration(fileName);
                ConnectionStringsSection configSection = configuration.GetSection("connectionStrings") as ConnectionStringsSection;

                if ((!(configSection.ElementInformation.IsLocked)) && (!(configSection.SectionInformation.IsLocked)))
                {
                    if (configSection.SectionInformation.IsProtected)
                        configSection.SectionInformation.UnprotectSection();

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
