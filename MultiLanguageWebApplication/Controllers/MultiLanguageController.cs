using MultiLanguageWebApplication.Common.Logger;
using MultiLanguageWebApplication.DTO;
using MultiLanguageWebApplication.Model;
using MultiLanguageWebApplication.Service;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MultiLanguageWebApplication.Controllers
{
    [RoutePrefix("MultiLanguage")]
    public class MultiLanguageController : Controller
    {
        [Route("InsertUpdateLanguage")]
        public async Task<JsonResult> InsertUpdateLanguage(string languageID, string language, string isoCode)
        {
            return Json(await MultiLanguageService.InsertUpdateLanguage(languageID, language, isoCode), JsonRequestBehavior.AllowGet);
        }

        [Route("SelectLanguageDetails")]
        public async Task<JsonResult> SelectLanguageDetails(long languageID)
        {
            return Json(await MultiLanguageService.SelectLanguageDetails(languageID), JsonRequestBehavior.AllowGet);
        }

        [Route("DeleteLanguage")]
        public async Task<JsonResult> DeleteLanguage(string languageID)
        {
            return Json(await MultiLanguageService.DeleteLanguage(languageID));
        }

        [Route("InsertUpdateLanguageResource")]
        public async Task<JsonResult> InsertUpdateLanguageResource(LanguageResourceModel resource)
        {
            try
            {
                LanguageResourceDTO dto = new LanguageResourceDTO()
                {
                    LanguageID = resource.LanguageID,
                    ResourceKey = resource.ResourceKey,
                    ResourceValue = resource.ResourceValue
                };

                return Json(await MultiLanguageService.InsertUpdateLanguageResource(dto), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                await Logger.Error(ex, "Error in MultiLanguageController.InsertUpdateLanguageResource");
                return Json(-1, JsonRequestBehavior.AllowGet);
            }
        }

        [Route("SelectLanguageResourceDetails")]
        public async Task<JsonResult> SelectLanguageResourceDetails(long resourceID)
        {
            return Json(await MultiLanguageService.SelectLanguageResourceDetails(resourceID));
        }
    }
}