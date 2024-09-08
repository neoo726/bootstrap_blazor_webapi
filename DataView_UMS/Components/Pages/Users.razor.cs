using BootstrapBlazor.Components;
using DataView_UMS.Data;
using DataView_UMS.Models.HttpModels;
using DataView_UMS.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;

namespace DataView_UMS.Components.Pages
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Users : ComponentBase
    {

        private List<UserInfo> UserLst { get; set; }
        private List<RoleInfo> RoleLst { get; set; }
        private readonly ConcurrentDictionary<Ros, IEnumerable<SelectedItem>> _cache = new();
        /// <summary>
        /// 
        /// </summary>
        private static IEnumerable<int> PageItemsSource => new int[] { 20, 40 };
        /// <summary>
        /// OnInitialized 方法
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();

        }

        protected override async Task OnInitializedAsync()
        {
            base.OnInitializedAsync();
            UserLst = await UserService.GetAllUser();
            RoleLst = await UserService.GetAllRole();
            //await SubscribeToDataUpdatesAsync();
        }
    }
}
