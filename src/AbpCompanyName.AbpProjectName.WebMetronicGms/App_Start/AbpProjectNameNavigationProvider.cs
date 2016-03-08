﻿using Abp.Application.Navigation;
using Abp.Localization;
using AbpCompanyName.AbpProjectName.Authorization;

namespace AbpCompanyName.AbpProjectName.WebMetronicGms {
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See Views/Layout/_TopMenu.cshtml file to know how to render menu.
    /// </summary>
    public class AbpProjectNameNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        "BaseManage",
                        L("BaseManage"),
                        url: "/",
                        icon: "fa fa-home",
                        requiresAuthentication: true
                        ).AddItem(
                            new MenuItemDefinition(
                                    "TenantsManage",
                                    L("TenantsManage"),
                                    url: "/Tenants/Index",
                                    icon: "fa fa-home",
                                    requiresAuthentication: true
                                ).AddItem(
                                    new MenuItemDefinition(
                                        "CreateTenant",
                                        L("CreateTenant"),
                                        url: "/Tenants/Index",
                                        icon: "fa fa-home",
                                        requiresAuthentication: true
                                    )
                                )
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Tenants",
                        L("Tenants"),
                        url: "/Tenants",
                        icon: "fa fa-globe",
                        requiredPermissionName: PermissionNames.Pages_Tenants
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "About",
                        L("About"),
                        url: "/About",
                        icon: "fa fa-info"
                        )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AbpProjectNameConsts.LocalizationSourceName);
        }
    }
}
