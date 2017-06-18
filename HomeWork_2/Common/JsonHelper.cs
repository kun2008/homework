/**
* 命名空间: Common
*
* 功 能： N/A
* 类 名： JsonHelper
* 作 者:  罗唐坤
* 创建时间：2017/6/18 22:45:14
* 修改人：
* 修改日期:
* 修改描述:
*/
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class JsonHelper
    {
        public string ToJson<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        public T ToObject<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }

        public T FileToObject<T>(string fileName)
        {
            if (File.Exists(fileName))
            {
                return ToObject<T>(File.ReadAllText(fileName, Encoding.Default));
            }
            else
            {
                return default(T);
            }
        }

        public void ObjectToFile<T>(T obj,string fileName)
        {
            using (FileStream fileStream = File.Create(fileName))
            {
                string text = JsonConvert.SerializeObject(obj);
                byte[] bytes = Encoding.Default.GetBytes(text);
                fileStream.Write(bytes, 0, bytes.Length);
            }
        }
    }
}
