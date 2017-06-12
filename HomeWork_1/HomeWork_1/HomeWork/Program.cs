using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bil;
using Model;

namespace HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            //Company company = new Company()
            //{
            //    ID=4,
            //    Name = "xx国际",
            //    CreateTime = DateTime.Now.AddDays(1),
            //    CreatorId = 1,
            //    LastModifierId = 0,
            //    LastModifyTime = DateTime.Now.AddDays(-1)
            //};
            //UpdateCompany(company);
            var data = QueryCompany(4);
            var list = QueryCompany();


        }
        static List<Company> QueryCompany()
        {
            Bil.BaseModelOperator<Company> companyOpeator = new BaseModelOperator<Company>();
            var company = companyOpeator.QueryAll();
            return company;
        }
        static Company QueryCompany(int id)
        {
            Bil.BaseModelOperator<Company> companyOpeator = new BaseModelOperator<Company>();
            var company= companyOpeator.QueryById(id);
            return company;
        }
        static int AddCompany(Company company)
        {
            Bil.BaseModelOperator<Company> companyOpeator = new BaseModelOperator<Company>();
            return companyOpeator.SaveData(company);
        }
        static int UpdateCompany(Company company)
        {
            Bil.BaseModelOperator<Company> companyOpeator = new BaseModelOperator<Company>();
            return companyOpeator.UpdateData(company);
        }
    }
}
