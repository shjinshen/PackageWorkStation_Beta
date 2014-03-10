using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/***************************************************************************
*Class Name: ModelInstance
*Description:
*Author: Jinshen
*Creation Time: 2014/3/10 14:41:21
*Modified by:
*Modification Time:
*@Version 1.0
****************************************************************************/

namespace AJ.DMES.PackageWorkstation.Domain
{
    public class ModelInstance : Entity
    {
        public virtual Model Model { get; set; }
        public virtual string ProductCode { get; set; }
        public virtual string Source { get; set; }
        public virtual Container Container { get; set; }
    }
}
