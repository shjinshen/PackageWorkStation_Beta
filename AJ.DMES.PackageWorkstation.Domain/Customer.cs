using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/***************************************************************************
*Class Name: Customer
*Description:
*Author: Jinshen
*Creation Time: 2014/3/6 15:39:21
*Modified by:
*Modification Time:
*@Version 1.0
****************************************************************************/

namespace AJ.DMES.PackageWorkstation.Domain
{
    public class Customer : Entity
    {
        public virtual string CustomerCode { get; set; }
        public virtual string CustomerName { get; set; }
        public virtual string ShortName { get; set; }
        public virtual string Address { get; set; }
        public virtual string Phone { get; set; }
        public virtual string ZipCode { get; set; }
        public virtual string WebSite { get; set; }
    }
}
