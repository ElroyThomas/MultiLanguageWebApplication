using MultiLanguageWebApplication.DataAccess;
using MultiLanguageWebApplication.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultiLanguageWebApplication.Service
{
    public class MultiLanguageService
    {
        public static async Task<long> InsertUpdateLanguage(string languageID, string language, string isoCode)
        {
            return await MultiLanguageDA.InsertUpdateLanguage(languageID, language, isoCode);
        }
        public static async Task<IEnumerable<LanguageDetailsDTO>> SelectLanguageDetails(long languageID)
        {
            return await MultiLanguageDA.SelectLanguageDetails(languageID);
        }
        public static async Task<long> DeleteLanguage(string languageID)
        {
            return await MultiLanguageDA.DeleteLanguage(languageID);
        }

        public static async Task<long> InsertUpdateLanguageResource(LanguageResourceDTO resource)
        {
            return await MultiLanguageDA.InsertUpdateLanguageResource(resource);
        }
        public static async Task<IEnumerable<LanguageResourceDTO>> SelectLanguageResourceDetails(long resourceID)
        {
            return await MultiLanguageDA.SelectLanguageResourceDetails(resourceID);
        }
    }
}