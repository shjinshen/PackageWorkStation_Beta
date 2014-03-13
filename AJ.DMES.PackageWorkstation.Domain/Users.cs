using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AJ.DMES.PackageWorkstation.Domain
{
    public class Users : Entity
    {
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        public virtual string RealName { get; set; }
        public virtual string Gender { get; set; }
        public virtual string Age { get; set; }
        public virtual string Phone { get; set; }
		public virtual string Remark { get; set; }
    }
}
