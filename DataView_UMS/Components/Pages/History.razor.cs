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
    public partial class History : ComponentBase
    {
        private List<UserLog> UserLogLst { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();

        }

        protected override async Task OnInitializedAsync()
        {
            base.OnInitializedAsync();
            UserLogLst = await UserService.GetUserLogs();
            //await SubscribeToDataUpdatesAsync();
        }
    }
}
