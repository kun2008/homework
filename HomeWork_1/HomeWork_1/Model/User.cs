/**
* 命名空间: Model
*
* 功 能： N/A
* 类 名： User
* 作 者:  罗唐坤
* 创建时间：2017/6/11 18:25:52
* 修改人：
* 修改日期:
* 修改描述:
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User:BaseModel
    {
        public string Account
        {
            get;
            set;
        }
        public string PassWord
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }
        public string Mobile
        {
            get;
            set;
        }
        public int CompanyId
        {
            get;
            set;
        }
        public int State
        {
            get;
            set;
        }
        public int UserType
        {
            get;
            set;
        }
        public DateTime LastLoginTime
        {
            get;
            set;
        }
    }
}
