using SqlSugar;

namespace DataView_UMS
{
    public static class DbHelper
    {
        #region 初始化
        private static SqlSugarScope db;
       
        /// <summary>
        /// Initializes the database helper.
        /// </summary>
        /// <param name="dbType">Type of the database.</param>
        /// <param name="connStr">The connection string.</param>
        public static void Init(string dbType, string connStr)
        {
            try
            {
                SqlSugar.DbType curDbtype = SqlSugar.DbType.MySql;
                switch (dbType.ToLower())
                {
                    case "sqlserver":
                        curDbtype = SqlSugar.DbType.SqlServer;
                        break;
                    case "mysql":
                        curDbtype = SqlSugar.DbType.MySql;
                        break;
                    default:
                        throw new ArgumentException("Unsupported database type");
                       
                }
                db = new SqlSugarScope(new ConnectionConfig()
                {
                    ConnectionString = connStr,
                    DbType = curDbtype,
                    IsAutoCloseConnection = true,
                    InitKeyType = InitKeyType.Attribute,
                });               
                //如果不存在创建数据库
                //db.DbMaintenance.CreateDatabase(); //个别数据库不支持
                //db.CodeFirst.InitTables(
                //    typeof(DbModels.role), typeof(DbModels.user),
                //    typeof(DbModels.crane_type), typeof(DbModels.crane),
                //    typeof(DbModels.ros_type), typeof(DbModels.ros),
                //    typeof(DbModels.tag_type), typeof(DbModels.tag_crane), typeof(DbModels.tag_ros),
                //    typeof(DbModels.user_log), typeof(DbModels.bind_log),
                //     typeof(DbModels.display_msg), typeof(DbModels.return_value),
                //     typeof(DbModels.tips), typeof(DbModels.ui_language), typeof(DbModels.ums_config)
                //    );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal static string GetDllPath()
        {
            string CodeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;

            CodeBase = CodeBase.Substring(8, CodeBase.Length - 8);
            CodeBase = CodeBase.Substring(0, CodeBase.LastIndexOf("/") + 1);

            CodeBase = CodeBase.Replace("/", @"\");

            return CodeBase;
        }
        /// <summary>
        /// 获取DbHelper实例
        /// </summary>
        /// <returns></returns>
        public static SqlSugarScope GetDbInstance()
        {
            return db;
        }
        #endregion

    }
}
