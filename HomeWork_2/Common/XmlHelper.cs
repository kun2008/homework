/**
* 命名空间: Common
*
* 功 能： N/A
* 类 名： XmlHelper
* 作 者:  罗唐坤
* 创建时间：2017/6/18 22:42:05
* 修改人：
* 修改日期:
* 修改描述:
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Common
{
    public class XmlHelper
    {
        public void ObjectToXml<T>(T obj,string fileName)
        {
            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite))
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(T));
                xmlFormat.Serialize(fStream, obj);
            }
        }

        public T XmlToObj<T>(string fileName)
        {
            using (Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(T));
                return (T)xmlFormat.Deserialize(fStream);
            }
        }
    }
}
