using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace VentriModel
{
    [Serializable]
    public abstract class VentriBaseModel
    {
        /// <summary>
        /// 人
        /// </summary>
        public string Person
        {
            get;
            set;
        }
        /// <summary>
        /// 桌
        /// </summary>
        public string Desk
        {
            get;
            set;
        }
        /// <summary>
        /// 椅
        /// </summary>
        public string Chair
        {
            get;
            set;
        }
        /// <summary>
        /// 扇
        /// </summary>
        public string Fan
        {
            get;
            set;
        }
        /// <summary>
        /// 尺
        /// </summary>
        public string Ruler
        {
            get;
            set;
        }
        public VentriBaseModel()
        {

        }
        public VentriBaseModel(int temperature=400)
        {
            this.burnTemperature = temperature;
        }
        /// <summary>
        /// 犬吠
        /// </summary>
        public abstract void DogBark();
        /// <summary>
        /// 哭声
        /// </summary>
        public abstract void Cry();
        /// <summary>
        /// 风声
        /// </summary>
        public abstract void WindSound();

        /// <summary>
        /// 着火呼叫
        /// </summary>
        public List<string> FireValue
        {
            get;
            set;
        }
        /// <summary>
        /// 表演开始
        /// </summary>
        public void ShowBegin()
        {
            Console.WriteLine("各位老少爷们，表演开始啦");
        }
        /// <summary>
        /// 开场白
        /// </summary>
        public virtual void Introduction()
        {
            Console.WriteLine("layds and 乡亲们,我想死你们啦");
        }
        /// <summary>
        /// 结束语
        /// </summary>
        public virtual void Concluding()
        {
            Console.WriteLine("感谢各位的捧场，欢迎下回再来");
        }

        /// <summary>
        /// 默认着火温度
        /// </summary>
        private int burnTemperature = 400;
        public delegate void BurnHandler();
        public event BurnHandler BurnEvent;
        public void SetTemperature(int temperature=400)
        {
            if(temperature>=burnTemperature&&BurnEvent!=null)
            {
                BurnEvent();
            }
        }

        protected void Play(string pai,string sound)
        {
            string value = pai + ":" + sound;
            Console.WriteLine(value);
            LogHelper.WriteLog(typeof(VentriBaseModel), value);
            string file = AppDomain.CurrentDomain.BaseDirectory + "\\sound\\" + sound + ".wav";
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = file;
            player.Load(); //同步加载声音  
            player.Play(); //启用新线程播放
            player.Dispose();
        }
    }
}
