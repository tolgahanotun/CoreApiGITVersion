using System;
using System.Collections.Generic;

namespace CoreApiGITVersion.Models
{
    public partial class TComments
    {
        public int TCommentId { get; set; }
        public string CommentText { get; set; }
        public int? CommentBy { get; set; }
        public bool? Deleted { get; set; }
        public int? TArticleId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual TArticle TArticle { get; set; }
    }
}
