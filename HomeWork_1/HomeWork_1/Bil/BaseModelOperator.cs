using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using DBManager;
using System.Data;

namespace Bil
{
    public class BaseModelOperator<T> where T:BaseModel
    {
        IDataHelper m_dataHelper;

        public BaseModelOperator()
        {
            m_dataHelper = new DBManager.DalFactory().CreateDataHelper();
        }

        private List<T> DataConvert(DataTable table)
        {
            if(table==null||table.Rows.Count==0)
            {
                return null;
            }
            List<T> list = new List<T>();
            var properties = typeof(T).GetProperties();
            foreach(DataRow row in table.Rows)
            {
                T t = Activator.CreateInstance<T>();
                foreach(var pro in properties)
                {
                    string colName = pro.Name;
                    if(table.Columns.Contains(colName))
                    {
                        pro.SetValue(t, row[colName]);
                    }
                }
                list.Add(t);
            }
            return list;
        }

        public T QueryById(int id)
        {
            if(m_dataHelper==null)
            {
                return default(T);
            }
            string tableName = typeof(T).Name;
            string sql = string.Format("select * from {0} where id={1}", tableName, id);
            return DataConvert(m_dataHelper.ExecuteDataTable(sql)).FirstOrDefault();
        }

        public List<T> QueryAll()
        {
            if(m_dataHelper==null)
            {
                return null;
            }
            string tableName = typeof(T).Name;
            string sql = string.Format("select * from {0}", tableName);
            return DataConvert(m_dataHelper.ExecuteDataTable(sql));
        }

        public int DeleteById(int id)
        {
            if(m_dataHelper==null)
            {
                return -1;
            }
            string tableName = typeof(T).Name;
            string sql = string.Format("delete from {0} where id={1}", tableName, id);
            return m_dataHelper.ExecuteNonQuery(sql);
        }

        public int SaveData(T t)
        {
            if (m_dataHelper == null)
            {
                return -1;
            }
            string tableName = typeof(T).Name;

            string sql = "insert into " + tableName + "({0}) values({1})";
            List<string> cols = new List<string>();
            List<string> values = new List<string>();
            foreach(var property in typeof(T).GetProperties())
            {
                //id自增长，无需insert
                if(string.Compare(property.Name,"id",true)==0)
                {
                    continue;
                }
                cols.Add(property.Name);
                values.Add(string.Format("'{0}'", property.GetValue(t)));
            }
            sql = string.Format(sql, string.Join(",", cols), string.Join(",", values));
            return m_dataHelper.ExecuteNonQuery(sql);
        }

        public int UpdateData(T t)
        {
            if (m_dataHelper == null)
            {
                return -1;
            }
            string tableName = typeof(T).Name;
            var properties = typeof(T).GetProperties();
            string sql = "update " + tableName + " set ";
            string where = " where id=";
            List<string> conditions = new List<string>();
            
            foreach(var property in properties)
            {
                if(string.Compare(property.Name,"id",true)==0)
                {
                    where += property.GetValue(t);
                    continue;
                }
                string con = string.Format("{0}='{1}'", property.Name, property.GetValue(t));
                conditions.Add(con);
            }
            sql += string.Join(",", conditions) + where;
            return m_dataHelper.ExecuteNonQuery(sql);
        }

    }
}
