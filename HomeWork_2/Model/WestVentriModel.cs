/**
* 命名空间: VentriModel
*
* 功 能： N/A
* 类 名： WestVentriModel
* 作 者:  罗唐坤
* 创建时间：2017/6/18 22:04:24
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
    class WestVentriModel : VentriBaseModel, ICharge
    {
        public WestVentriModel():base()
        {

        }
        public WestVentriModel(int temperature=400) : base(temperature)
        {
        }

        public override void Concluding()
        {
            Console.WriteLine("预知后事如何，请听下回");
        }
        public override void Introduction()
        {
            Console.WriteLine("天下大势分久必合");
        }
        public void Charge()
        {
            Console.WriteLine("西派口技:有钱的捧个钱场,没钱的捧个人场");
        }

        public override void Cry()
        {
            this.Play("西派", "cry");
        }

        public override void DogBark()
        {
            this.Play("西派", "dog");

        }

        public override void WindSound()
        {
            this.Play("西派", "wind");
        }
    }
}
