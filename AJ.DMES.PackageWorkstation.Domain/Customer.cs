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
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string ShortName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string ZipCode { get; set; }
        public string WebSite { get; set; }
    }
}
