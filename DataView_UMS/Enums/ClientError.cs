using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataView_UMS.Enums
{
    
    /// <summary>
    /// 客户端错误码
    /// </summary>   
    public enum ClientErrorCode
    {
        /// <summary>
        /// 用户名或者密码错误
        /// </summary>
        [Description("用户名或者密码错误")]
        UsernameOrPasswordIncorrect = 1001,

        /// <summary>
        /// 用户已被锁定，请联系管理员
        /// </summary>
        [Description("用户已被锁定，请联系管理员")]
        UserLocked = 1002,

        /// <summary>
        /// 您登录系统的角色已被禁用，请联系管理员
        /// </summary>
        [Description("您登录系统的角色已被禁用，请联系管理员")]
        RoleDisabled = 1003,

        /// <summary>
        /// 用户没有登录权限
        /// </summary>
        [Description("用户没有登录权限")]
        NoLoginPermission = 1004,

        /// <summary>
        /// 用户已经在线，需要等待确认退出才能登录
        /// </summary>
        [Description("用户已经在线，需要等待确认退出才能登录")]
        UserAlreadyOnline = 1005,

        /// <summary>
        /// 登录失败，不能在同一IP登录多个用户
        /// </summary>
        [Description("登录失败，不能在同一IP登录多个用户")]
        MultipleUsersFromSameIP = 1006,

        /// <summary>
        /// 登录失败，不能重复登录，需先将已经登录的退出
        /// </summary>
        [Description("登录失败，不能重复登录，需先将已经登录的退出")]
        DuplicateLogin = 1007,

        /// <summary>
        /// 用户已经在其他客户端登录，需要等待其他客户端确认退出才能登录
        /// </summary>

        [Description("用户已经在其他客户端登录，需要等待其他客户端确认退出才能登录")] 
        UserLoggedInElsewhere = 1008,

        /// <summary>
        /// 登录用户不存在
        /// </summary>
        [Description("登录用户不存在")]
        UserNotFound = 1009,

        /// <summary>
        /// 对不起，您的账号已被注销
        /// </summary>
        [Description("对不起，您的账号已被注销")]
        AccountCancelled = 1010,

        /// <summary>
        /// 对不起，您的账号有效期已过期
        /// </summary>
        [Description("对不起，您的账号有效期已过期")] 
        AccountExpired = 1011,

        /// <summary>
        /// 对不起，您的账号已停用
        /// </summary>
        [Description("对不起，您的账号已停用")] 
        AccountDisabled = 1012,

        /// <summary>
        /// Token不能为空
        /// </summary>
        [Description("Token不能为空")] 
        TokenMissing = 1013,

        /// <summary>
        /// 用户已经退出
        /// </summary>
        [Description("用户已经退出")] 
        UserLoggedOut = 1014,

        /// <summary>
        /// 密码为空或者密码错误
        /// </summary>
        [Description("密码为空或者密码错误")] 
        PasswordEmptyOrIncorrect = 1015,

        /// <summary>
        /// ID不存在
        /// </summary>
        [Description("ID不存在")] 
        IDNotFound = 1016,

        /// <summary>
        /// 消息通知等待超时
        /// </summary>
        [Description("消息通知等待超时")] 
        NotificationTimeout = 1017,

        /// <summary>
        /// 没有权限操作
        /// </summary>
        [Description("没有权限操作")] 
        NoPermission = 1018,

        /// <summary>
        /// 无效的token
        /// </summary>
        [Description("无效的token")] 
        InvalidToken = 1019,

        /// <summary>
        /// 修改密码失败，旧密码错误
        /// </summary>
        [Description("修改密码失败，旧密码错误")] 
        OldPasswordIncorrect = 1020,

        /// <summary>
        /// 新密码不能与旧密码相同
        /// </summary>
        [Description("新密码不能与旧密码相同")] 
        NewPasswordSameAsOld = 1021,

        /// <summary>
        /// 修改密码异常，请联系管理员
        /// </summary>
        [Description("修改密码异常，请联系管理员")] 
        PasswordChangeError = 1022,

        /// <summary>
        /// 新密码和旧旧密码都不能为空
        /// </summary>
        [Description("新密码和旧旧密码都不能为空")] 
        PasswordsCannotBeEmpty = 1023,

        /// <summary>
        /// 非法客户端
        /// </summary>
        [Description("非法客户端")] 
        IllegalClient = 1024,

        /// <summary>
        /// 客户端密钥错误
        /// </summary>
        [Description("客户端密钥错误")] 
        ClientKeyIncorrect = 1025,

        /// <summary>
        /// 等待退出
        /// </summary>
        [Description("等待退出")] 
        AwaitingLogout = 1026,

        /// <summary>
        /// 登录确认失败
        /// </summary>
        [Description("登录确认失败")] 
        LoginConfirmationFailed = 1027,

        /// <summary>
        /// 操作台号不存在登录信息
        /// </summary>
        [Description("操作台号不存在登录信息")] 
        NoLoginInfoForConsole = 1028,

        /// <summary>
        /// 操作台对应的opcua地址不存在
        /// </summary>
        [Description("操作台对应的opcua地址不存在")] 
        NoOpcuaAddressForConsole = 1029,

        /// <summary>
        /// opcua连接失败
        /// </summary>
        [Description("opcua连接失败")] 
        OpcuaConnectionFailed = 1030
    }
}
