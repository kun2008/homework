/**
* 命名空间: Dal
*
* 功 能： SqlServer数据操作类
* 类 名： SqlServerDataHelper
* 作 者:  罗唐坤
* 创建时间：2017/6/11 17:55:16
* 修改人：
* 修改日期:
* 修改描述:
*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Dal
{
    public class SqlServerDataHelper : IDataHelper
    {
        public string ConnectionString
        {
            get;
            set;
        }
        public DataTable ExecuteDataTable(string commandText)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    DataTable table = new DataTable();
                    SqlCommand cmd = new SqlCommand(commandText, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    table.Load(reader);
                    return table;
                }
            }
            catch(SqlException ex)
            {
                return null;
            }
            catch(Exception ex)
            {
                return null;
            }

        }

        public int ExecuteNonQuery( string commandText)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(commandText, connection);
                    int value = cmd.ExecuteNonQuery();
                    return value;
                }
            }
            catch(SqlException ex)
            {
                return -1;
            }
            catch(Exception ex)
            {
                return -1;
            }

        }
    }
}
