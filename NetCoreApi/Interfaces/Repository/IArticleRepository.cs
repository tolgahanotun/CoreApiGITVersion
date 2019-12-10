using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApiGITVersion.Models;

namespace CoreApiGITVersion.Interfaces.Repository
{
    interface IArticleRepository
    {
        public bool AddArticle(TArticle article);

        public List<TArticle> GetArticleById(int articleId);

        public TArticle RemoveArticle(TArticle article);

        public TArticle UpdateArticle(TArticle article);
    }
}
