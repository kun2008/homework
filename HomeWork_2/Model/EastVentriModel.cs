/**
* 命名空间: Model
*
* 功 能： N/A
* 类 名： EastVentriModel
* 作 者:  罗唐坤
* 创建时间：2017/6/18 21:49:41
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
    public class EastVentriModel : VentriBaseModel, ICharge
    {
        public EastVentriModel():base()
        {

        }
        public EastVentriModel(int temperature=400) : base(temperature)
        {
        }

         
        public void Charge()
        {
            Console.WriteLine("东派口技:有钱的捧个钱场,没钱的捧个人场");
        }

        public override void Cry()
        {
            this.Play("东派", "cry");
        }

        public override void DogBark()
        {
            this.Play("东派", "dog");
        }

        public override void WindSound()
        {
            this.Play("东派", "wind");
        }
    }
}
