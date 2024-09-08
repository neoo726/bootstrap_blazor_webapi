using System;
namespace DataView_UMS
{
    /// <summary>
    /// Token生成
    /// </summary>
    public static class TokenHelper
    {
        public static string GenerateToken()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
