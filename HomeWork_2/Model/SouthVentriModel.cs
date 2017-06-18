/**
* 命名空间: VentriModel
*
* 功 能： N/A
* 类 名： SouthVentriModel
* 作 者:  罗唐坤
* 创建时间：2017/6/18 21:56:35
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
    public class SouthVentriModel : VentriBaseModel, ICharge
    {
        public SouthVentriModel():base()
        {

        }
        public SouthVentriModel(int temperature=800) : base(temperature)
        {
        }
        public override void Introduction()
        {
            Console.WriteLine("且说那西门大官人");
        }
        public void Charge()
        {
            Console.WriteLine("南派口技:有钱的捧个钱场,没钱的捧个人场");
        }

        public override void Cry()
        {
            this.Play("南派", "cry");
        }

        public override void DogBark()
        {
            this.Play("南派", "dog");
        }

        public override void WindSound()
        {
            this.Play("南派", "wind");
        }
    }
}
