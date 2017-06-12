/**
* 命名空间: Dal
*
* 功 能： Access数据操作类
* 类 名： AccessDataHelper
* 作 者:  罗唐坤
* 创建时间：2017/6/11 18:01:01
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
using System.Data.OleDb;

namespace Dal
{
    public class AccessDataHelper : IDataHelper
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
                using (OleDbConnection connection = new OleDbConnection(ConnectionString))
                {
                    connection.Open();
                    OleDbCommand cmd = new OleDbCommand(commandText, connection);
                    OleDbDataReader reader = cmd.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(reader);
                    return table;
                }
            }
            catch(OleDbException ex)
            {
                return null;
            }
            catch(Exception ex)
            {
                return null;
            }

        }

        public int ExecuteNonQuery(string commandText)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(ConnectionString))
                {
                    connection.Open();
                    OleDbCommand cmd = new OleDbCommand(commandText, connection);
                    int value = cmd.ExecuteNonQuery();
                    return value;
                }
            }
            catch(OleDbException ex)
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
