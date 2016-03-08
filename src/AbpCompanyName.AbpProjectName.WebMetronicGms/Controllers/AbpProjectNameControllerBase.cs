using System.Collections.Generic;
using Abp.IdentityFramework;
using Abp.UI;
using Abp.Web.Mvc.Controllers;
using AbpCompanyName.AbpProjectName.WebMetronicGms.Models.UI.JqueryDatatables;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace AbpCompanyName.AbpProjectName.WebMetronicGms.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class AbpProjectNameControllerBase : AbpController
    {
        protected AbpProjectNameControllerBase()
        {
            LocalizationSourceName = AbpProjectNameConsts.LocalizationSourceName;
        }

        protected override void OnException(ExceptionContext context) {
            base.OnException(context);
        }

        protected virtual void CheckModelState()
        {
            if (!ModelState.IsValid)
            {
                throw new UserFriendlyException(L("FormIsNotValidMessage"));
            }
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }

        protected JsonResult PageJson<T>(IReadOnlyList<T> result, PageRequest pageRequest)
        {
            var jsonResult = new DataResult<T>(result, pageRequest);
            return Json(jsonResult);
        }
    }
}