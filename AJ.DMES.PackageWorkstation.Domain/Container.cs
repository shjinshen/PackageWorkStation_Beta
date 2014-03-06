using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/***************************************************************************
*Class Name: Container
*Description:
*Author: Jinshen
*Creation Time: 2014/3/6 15:48:54
*Modified by:
*Modification Time:
*@Version 1.0
****************************************************************************/

namespace AJ.DMES.PackageWorkstation.Domain
{
    /// <summary>
    /// 包装箱实体
    /// </summary>
    public class Container : Entity
    {
        public string ContainerPN { get; set; }//外箱箱号
        public string ContainerSN { get; set; }//外箱序列号
        public string CustomerId { get; set; }//关联的客户ID号
        public string ModelId { get; set; }//箱内的产品ID号
        public int? ContainerSize { get; set; }//包装箱的容量
        public DateTime? PackedDate { get; set; }//包装日期
    }
}
