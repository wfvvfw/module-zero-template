using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Abp.AutoMapper;
using AbpCompanyName.AbpProjectName.MultiTenancy;

namespace AbpCompanyName.AbpProjectName.WebMetronicGms.Models.Tenants {

    [AutoMapFrom(typeof(Tenant))]
    public class TenantViewModel {

        public int Id { get; set; }

        public string TenancyName { get; set; }

        public string Name { get; set; }
        
        public bool IsActive { get; set; }
    }
}