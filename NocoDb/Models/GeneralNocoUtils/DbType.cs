namespace NocoDb.Models.GeneralNocoUtils
{
    public enum DbType
    {
        Mssql,
        Mysql,
        Mysql2,
        Oracledb,
        Pg,
        Snowflake,
        Sqlite3,
        Databricks
    }
    public class DbTypeHelper
    {
        public static string GetDbTypeString(DbType dbType)
        {
            switch (dbType)
            {
                case DbType.Mssql:
                    return "mssql";
                case DbType.Mysql:
                    return "mysql";
                case DbType.Mysql2:
                    return "mysql2";
                case DbType.Oracledb:
                    return "oracledb";
                case DbType.Pg:
                    return "pg";
                case DbType.Snowflake:
                    return "snowflake";
                case DbType.Sqlite3:
                    return "sqlite3";
                case DbType.Databricks:
                    return "databricks";
                default:
                    return "mysql2";
            }
        }
    }
    
}