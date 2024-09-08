using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace DataView_UMS.Components.Shared
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class MainLayout
    {
        private bool UseTabSet { get; set; } = true;

        private string Theme { get; set; } = "";

        private bool IsOpen { get; set; }

        private bool IsFixedHeader { get; set; } = true;

        private bool IsFixedFooter { get; set; } = true;

        private bool IsFullSide { get; set; } = true;

        private bool ShowFooter { get; set; } = true;

        private List<MenuItem>? Menus { get; set; }

        /// <summary>
        /// OnInitialized 方法
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();

            Menus = GetIconSideMenuItems();
        }

        private static List<MenuItem> GetIconSideMenuItems()
        {
            var menus = new List<MenuItem>
            {
                //new() { Text = "返回组件库", Icon = "fa-solid fa-fw fa-home", Url = "https://www.blazor.zone/components" },
                new() { Text = "Home", Icon = "fa-solid fa-fw fa-flag", Url = "/" , Match = NavLinkMatch.All},
                new() { Text = "User", Icon = "fa-solid fa-fw fa-users", Url = "/users" },
                new() { Text = "ROS", Icon = "fa-solid fa-fw fa-users", Url = "/ros" },
                new() { Text = "History", Icon = "fa-solid fa-fw fas fa-database", Url = "/History" },
                new() { Text = "Setting", Icon = "fa-solid fa-fw fa-wrench", Url = "/setting" },
                //new() { Text = "Weather", Icon = "fa-solid fa-fw fa-database", Url = "/weather" },
                
            };

            return menus;
        }
    }
}
