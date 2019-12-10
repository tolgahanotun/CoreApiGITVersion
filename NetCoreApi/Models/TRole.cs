using System;
using System.Collections.Generic;

namespace CoreApiGITVersion.Models
{
    public partial class TRole
    {
        public TRole()
        {
            TUserRole = new HashSet<TUserRole>();
        }

        public int TRoleId { get; set; }
        public string RoleName { get; set; }
        public bool? Enabled { get; set; }

        public virtual ICollection<TUserRole> TUserRole { get; set; }
    }
}
