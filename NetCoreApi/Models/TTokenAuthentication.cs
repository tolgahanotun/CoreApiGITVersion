using System;
using System.Collections.Generic;

namespace CoreApiGITVersion.Models
{
    public partial class TTokenAuthentication
    {
        public int TTokenId { get; set; }
        public int? TUserId { get; set; }
        public string AccessToken { get; set; }
        public DateTime? AccessExpiredDate { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshExpiredDate { get; set; }
        public bool? TokenExpired { get; set; }

        public virtual TUser TUser { get; set; }
    }
}
