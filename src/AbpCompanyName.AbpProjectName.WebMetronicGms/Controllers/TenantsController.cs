using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using Abp.Domain.Uow;
using Abp.Web.Mvc.Authorization;
using Abp.Web.Mvc.Models;
using AbpCompanyName.AbpProjectName.Authorization;
using AbpCompanyName.AbpProjectName.MultiTenancy;
using AbpCompanyName.AbpProjectName.MultiTenancy.Dto;
using AbpCompanyName.AbpProjectName.WebMetronicGms.Models.Account;
using AbpCompanyName.AbpProjectName.WebMetronicGms.Models.UI;
using AbpCompanyName.AbpProjectName.WebMetronicGms.Models.UI.JqueryDatatables;
using Abp.Linq.Extensions;
using Abp.AutoMapper;
using AbpCompanyName.AbpProjectName.WebMetronicGms.Models.Tenants;

namespace AbpCompanyName.AbpProjectName.WebMetronicGms.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Tenants)]
    public class TenantsController : AbpProjectNameControllerBase
    {
        private readonly ITenantAppService _tenantAppService;
        private readonly TenantManager _tenantManager;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public TenantsController(ITenantAppService tenantAppService,
                TenantManager tenantManager,
                IUnitOfWorkManager unitOfWorkManager
                
            )
        {
            _tenantAppService = tenantAppService;
            _tenantManager = tenantManager;
            _unitOfWorkManager = unitOfWorkManager;
        }

        public ActionResult Index()
        {
            //var output = _tenantAppService.GetTenants();
            return View();
        }

        [HttpPost]
        [UnitOfWork]
        public virtual ActionResult GetList(PageRequest pageRequst)
        {
            //var tenants = _tenantManager.GetTenantList().PageBy(pageRequst).ToList();

            var tenants = _tenantManager.Tenants
                .OrderBy(l=>l.Id)
                .PageBy(pageRequst)
                .ToList()
                .MapTo<List<TenantViewModel>>();

            return PageJson<TenantViewModel>(tenants, pageRequst);

        }

        public ActionResult Create()
        {
            return View();
        }
    }

}