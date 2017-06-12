/**
* 命名空间: Bil
*
* 功 能： N/A
* 类 名： UserOperator
* 作 者:  罗唐坤
* 创建时间：2017/6/11 19:11:12
* 修改人：
* 修改日期:
* 修改描述:
*/
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bil
{
    public class UserOperator
    {
        public List<User> UserOrderBy(List<User> list)
        {
            return list.OrderBy(r => r.Account).ToList();
        }
        public void GetUserType(List<User> list,ref int max,ref int min,ref double avg)
        {
            max = list.Max(r => r.UserType);
            min = list.Min(r => r.UserType);
            avg = list.Average(r => r.UserType);
        }

        public void GetUserLeftJoinCompary(List<User> users,List<Company> companies)
        {
            var joinData = from u in users
                           join c in companies
                           on u.CompanyId equals c.ID
                           into temp
                           from t in temp.DefaultIfEmpty()
                           select new
                           {
                               companyid = t == null ? -1 : t.ID,
                               name = u.Name
                           };

        }

        public List<User> GetPageData(List<User> users,int pageIndex,int pageCount)
        {
            int skipCount = pageIndex * pageCount;
            return users.Skip(skipCount).Take(pageCount).ToList();
        }
    }
}
