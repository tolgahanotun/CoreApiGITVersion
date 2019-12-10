using System;
using System.Collections.Generic;

namespace CoreApiGITVersion.Models
{
    public partial class TUser
    {
        public TUser()
        {
            TTokenAuthentication = new HashSet<TTokenAuthentication>();
        }

        public int TUserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool? Enabled { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<TTokenAuthentication> TTokenAuthentication { get; set; }
    }
}
