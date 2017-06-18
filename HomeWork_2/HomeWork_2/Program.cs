using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VentriModel;

namespace HomeWork_2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //SouthVentriModel south = new SouthVentriModel();
                //south.Chair = "南派椅子";
                //south.Desk = "南派桌子";
                //south.Person = "南派说书";
                //south.Fan = "南派扇子";
                //south.Ruler = "南派尺子";

                //south.FireValue = new List<string>()
                //{
                //    "夫起大呼",
                //    "妇亦起大呼",
                //    "两儿齐哭",
                //    "俄而百千人大呼",
                //    "百千儿哭",
                //    "百千犬吠"
                //};

                XmlHelper xmlHelper = new XmlHelper();
                SouthVentriModel south = xmlHelper.XmlToObj<SouthVentriModel>(AppDomain.CurrentDomain.BaseDirectory + "south.xml");
               // xmlHelper.ObjectToXml(south, AppDomain.CurrentDomain.BaseDirectory + "south.xml");
                foreach(var item in south.FireValue)
                {
                    south.BurnEvent += () => Console.WriteLine(item);
                }
                Show(south);
                south.SetTemperature(2000);
                Console.Read();
            }
            catch(Exception ex)
            {
                LogHelper.WriteLog(typeof(Program), ex);
            }
        }
        public static void Show<T>(T t)
   where T : VentriBaseModel, ICharge
        {
            Type type = typeof(T);
            foreach (var item in type.GetProperties())
            {

                LogHelper.WriteLog(typeof(Program),string.Format("{0} = {1}", item.Name, item.GetValue(t)));
            }

            t.ShowBegin();
            t.Introduction();
            t.DogBark();
            Thread.Sleep(2000);
            t.Cry();
            Thread.Sleep(2000);
            t.WindSound();
            Thread.Sleep(2000);
            t.Concluding();
            t.Charge();
        }
    }
}
