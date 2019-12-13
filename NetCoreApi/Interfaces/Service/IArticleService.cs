using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApiGITVersion.Models;
using CoreApiGITVersion.Response;

namespace CoreApiGITVersion.Interfaces.Service
{
  public  interface IArticleService
    {
        public GenericResponse<TArticle> AddArticle(TArticle article);

        public GenericResponse<TArticle> GetArticleById(int articleId);

        public GenericResponse<TArticle> RemoveArticle(TArticle article);

         
        public GenericResponse<TArticle> UpdateArticle(TArticle article);

        public GenericResponse<List<TArticle>> GetDailyList();
    }
}
