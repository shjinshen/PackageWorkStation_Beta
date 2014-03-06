using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/***************************************************************************
*Class Name: Model
*Description:
*Author: Jinshen
*Creation Time: 2014/3/6 15:15:47
*Modified by:
*Modification Time:
*@Version 1.0
****************************************************************************/

namespace AJ.DMES.PackageWorkstation.Domain
{
    public class Model : Entity
    {
        public string ModelName { get; set; }
        public string Description { get; set; }
        public string Reservation_1 { get; set; }
        public string Reservation_2 { get; set; }
        public string Reservation_3 { get; set; }
        public string Reservation_4 { get; set; }
        public string Reservation_5 { get; set; }
    }
}
