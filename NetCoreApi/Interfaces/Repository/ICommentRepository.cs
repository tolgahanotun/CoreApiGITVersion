using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApiGITVersion.Models;

namespace CoreApiGITVersion.Interfaces.Repository
{
    public interface ICommentRepository
    {
        public void AddComment(TComments comment);
        public void RemoveComment(TComments comment);
        public TComments UpdateComment(TComments comment);
        public TComments GetCommentsById(int commentId);
        public TComments  GetCommentsByArticleId(int articleId);

    }
}
