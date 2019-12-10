using CoreApiGITVersion.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApiGITVersion.Contexts;
using CoreApiGITVersion.Models;

namespace CoreApiGITVersion.Repositories
{
    public class ArticleRepository:BaseRepository,IArticleRepository
    {
        private readonly CoreAPIGITVersionContext Context;
        public ArticleRepository(CoreAPIGITVersionContext _context ) : base(_context)
        {
            Context = _context;
        } 

        public void AddArticle(TArticle article)
        {
            Context.TArticle.Add(article);
            Context.SaveChanges();
        }

        public TArticle GetArticleById(int articleId)
        {
            return Context.TArticle.Where(x=>x.TArticleId==articleId && x.Deleted!=true && x.AcceptedBy>0).FirstOrDefault();
        }
         
        public void RemoveArticle(TArticle article)
        {
            article.Deleted = true;
            Context.TArticle.Update(article);
            Context.SaveChanges();
        }

        public TArticle UpdateArticle(TArticle article)
        {
            Context.TArticle.Update(article);
            Context.SaveChanges();
            return article;

        }
    }
}
