﻿using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AbpCompanyName.AbpProjectName.MultiTenancy.Dto;

namespace AbpCompanyName.AbpProjectName.MultiTenancy
{
    public interface ITenantAppService : IApplicationService
    {
        ListResultOutput<TenantListDto> GetTenants();

        Task CreateTenant(CreateTenantInput input);

        Task DeleteTenant(int id);

        Task DisableTenant(int id);
    }
}
