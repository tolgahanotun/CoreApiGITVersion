using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApiGITVersion.Interfaces.Repository;
using CoreApiGITVersion.Contexts;
using CoreApiGITVersion.Models;

namespace CoreApiGITVersion.Repositories
{
    public class CommentRepository : BaseRepository, ICommentRepository
    {
        protected readonly CoreAPIGITVersionContext Context;
        public CommentRepository(CoreAPIGITVersionContext _context) : base(_context)
        {
            Context = _context;
        }

        public void AddComment(TComments comment)
        {
            Context.TComments.Add(comment);
            Context.SaveChanges();
        }

        public TComments GetCommentsByArticleId(int articleId)
        {
            return Context.TComments.Where(x => x.TArticleId == articleId).FirstOrDefault();
        }

        public TComments GetCommentsById(int commentId)
        {
            return Context.TComments.Where(x => x.TCommentId == commentId && x.Deleted != true).FirstOrDefault();
        }

        public void RemoveComment(TComments comment)
        {
            comment.Deleted = true;
            Context.TComments.Update(comment);
            Context.SaveChanges();
        }

        public TComments UpdateComment(TComments comment)
        {
            Context.TComments.Update(comment);
            Context.SaveChanges();
            return Context.TComments.Find(comment.TCommentId);
        }
    }
}
