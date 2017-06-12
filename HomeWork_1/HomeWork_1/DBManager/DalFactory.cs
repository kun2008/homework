/**
* 命名空间: Dal
*
* 功 能： 数据访问类工厂
* 类 名： DalFactory
* 作 者:  罗唐坤
* 创建时间：2017/6/11 18:04:47
* 修改人：
* 修改日期:
* 修改描述:
*/
using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DBManager
{
    public class DalFactory
    {
        private IDataHelper CreateDataHelper(DBProvider provider)
        {
            switch(provider)
            {
                case DBProvider.Access:
                    return new AccessDataHelper();
                case DBProvider.SqlServer:
                    return new SqlServerDataHelper();
                default:
                    throw new Exception("目前不支持");
            }
        }

        public IDataHelper CreateDataHelper()
        {
            try
            {
                string strValue = ConfigurationManager.AppSettings["conn"];
                string[] array = strValue.Split(',');
                if (array.Length == 2)
                {
                    string connectionStr = array[1];
                    DBProvider provider = (DBProvider)Enum.Parse(typeof(DBProvider), array[0]);
                    IDataHelper helper = CreateDataHelper(provider);
                    helper.ConnectionString = connectionStr;
                    return helper;
                }
                return null;
            }
            catch(Exception ex)
            {
                return null;
            }

        }
    }
}
