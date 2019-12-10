using System;
using System.Collections.Generic;

namespace CoreApiGITVersion.Models
{
    public partial class TArticle
    {
        public TArticle()
        {
            TComments = new HashSet<TComments>();
        }

        public int TArticleId { get; set; }
        public string Header { get; set; }
        public string ArticleText { get; set; }
        public int? CreatedBy { get; set; }
        public int? AcceptedBy { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<TComments> TComments { get; set; }
    }
}
