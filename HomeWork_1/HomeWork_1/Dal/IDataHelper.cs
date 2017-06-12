/**
* 命名空间: Dal
*
* 功 能： 数据库访问接口
* 类 名： IDataHelper
* 作 者:  罗唐坤
* 创建时间：2017/6/11 17:47:39
* 修改人：
* 修改日期:
* 修改描述:
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Dal
{
    public interface IDataHelper
    {
        string ConnectionString
        {
            get;
            set;
        }
        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns></returns>
        int ExecuteNonQuery(string commandText);
        /// <summary>
        /// 执行查询sql
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns></returns>
        DataTable ExecuteDataTable(string commandText);
    }
}
