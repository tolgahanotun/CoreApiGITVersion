using System;
using System.Collections.Generic;

namespace CoreApiGITVersion.Models
{
    public partial class TUser
    {
        public int TUserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool? Enabled { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }
    }
}
