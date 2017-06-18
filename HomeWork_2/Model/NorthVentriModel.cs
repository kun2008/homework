/**
* 命名空间: VentriModel
*
* 功 能： N/A
* 类 名： NorthVentriModel
* 作 者:  罗唐坤
* 创建时间：2017/6/18 22:00:48
* 修改人：
* 修改日期:
* 修改描述:
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentriModel
{
    [Serializable]
    class NorthVentriModel : VentriBaseModel, ICharge
    {
        public NorthVentriModel():base()
        {

        }
        public NorthVentriModel(int temperature=1000) : base(temperature)
        {
        }

        public override void Concluding()
        {
            Console.WriteLine("预知后事如何，请听下回");
        }
        public void Charge()
        {
            Console.WriteLine("北派口技:有钱的捧个钱场,没钱的捧个人场");
        }

        public override void Cry()
        {
            this.Play("北派", "cry");
        }

        public override void DogBark()
        {
            this.Play("北派", "dog");
        }

        public override void WindSound()
        {
            this.Play("北派", "wind");
        }
    }
}
