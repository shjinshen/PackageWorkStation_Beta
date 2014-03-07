using NHibernate.Mapping.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/***************************************************************************
*Class Name: Entity
*Description:
*Author: Jinshen
*Creation Time: 2014/3/6 15:09:57
*Modified by:
*Modification Time:
*@Version 1.0
****************************************************************************/

namespace AJ.DMES.PackageWorkstation.Domain
{
    #region 基类
    public abstract class Entity<TId>
    {
        public virtual TId IId { get; protected set; }

        public virtual int RowVersion { get; set; }

        //public virtual DateTime CreatedDateTime { get; set; }

        //public virtual DateTime ModifiedDateTime { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Entity<TId>);
        }

        public virtual bool Equals(Entity<TId> other)
        {
            if (other == null)
                return false;
            if (ReferenceEquals(this, other))
                return true;
            if (!IsTransient(this)
               && !IsTransient(other)
               && Equals(IId, other.IId))
            {
                var otherType = other.GetUnProxiedType();
                var thisType = GetUnProxiedType();
                return thisType.IsAssignableFrom(otherType) ||
                    otherType.IsAssignableFrom(thisType);
            }
            return false;
            
        }

        public override int GetHashCode()
        {
            if (Equals(IId, default(TId)))
                return base.GetHashCode();
            return IId.GetHashCode();
        }

        private static bool IsTransient(Entity<TId> obj)
        {
            return obj != null && Equals(obj.IId, default(TId));
        }

        private Type GetUnProxiedType()
        {
            return GetType();
        }
    }
    #endregion

    /// <summary>
    /// 实体类继承的基类
    /// </summary>
    public abstract class Entity : Entity<int>
    {
    }
}
