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
    public partial class Ros : ComponentBase
    {
        
        private List<RosStatus> RosLst { get; set; }
        private List<RosType> RosTypeLst { get; set; }
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
            RosLst = await RosService.GetAllRosDefinition();
            RosTypeLst = await RosService.GetAllRosTypeDefinition();
            //await SubscribeToDataUpdatesAsync();
        }
    }
}
