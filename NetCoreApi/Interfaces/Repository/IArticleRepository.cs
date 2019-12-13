using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApiGITVersion.Models;

namespace CoreApiGITVersion.Interfaces.Repository
{
   public interface IArticleRepository
    {
        public void AddArticle(TArticle article);

        public TArticle GetArticleById(int articleId);

        public void RemoveArticle(TArticle article);
         
        public TArticle UpdateArticle(TArticle article);
        public List<TArticle> GetDailyTop10();
    }
}
