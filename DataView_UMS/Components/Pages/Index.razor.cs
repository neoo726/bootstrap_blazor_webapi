using BootstrapBlazor.Components;
using DataView_UMS.Data;
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
    public sealed partial class Index : ComponentBase
    {
        private List<User> Users = new List<User>
        {
            //new User { UIStation="ROS01",UserName = "1admin", UserNickName = "张三", LoginTime = DateTime.Now.ToString() },
            //new User { UIStation="ROS02",UserName = "123", UserNickName = "张4", LoginTime = DateTime.Now.ToString() },
            //new User { UIStation="ROS05" },
            // new User { UIStation="ROS05" },
        };
     
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
            var rosAllStatus = await RosService.GetAllRosStatusAsync();
            if(rosAllStatus==null)
            {
                //提示
            }
            foreach (var ros in rosAllStatus)
            {
                Users.Add(new User
                {
                    UIStation = ros.RosName,
                    UserName = ros.UserName,
                    UserNickName = ros.NickName,
                    LoginTime = ros.LoginTime==null?string.Empty: ros.LoginTime.Value.ToString(),
                });
            }
            //await SubscribeToDataUpdatesAsync();
        }
        private void RefreshRosList()
        {

        }
        private void Logout(User user)
        {
            // 在这里处理登出逻辑
            // 可能需要导航到其他页面或执行某些操作
        }
        public class User
        {
            public string UIStation { get; set; }
            public string UserNickName { get; set; }
            public string UserName { get; set; }
            public string LoginTime { get; set; }
        }
    }
}
