using System;
using System.Collections.Generic;

namespace CoreApiGITVersion.Models
{
    public partial class TUserRole
    {
        public int TUserId { get; set; }
        public int TRoleId { get; set; }

        public virtual TRole TRole { get; set; }
    }
}
