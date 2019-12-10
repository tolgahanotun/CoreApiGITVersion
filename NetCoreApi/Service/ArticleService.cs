using CoreApiGITVersion.Interfaces.Repository;
using CoreApiGITVersion.Interfaces.Service;
using CoreApiGITVersion.Models;
using CoreApiGITVersion.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiGITVersion.Service
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository ArticleRepository;

        public ArticleService(IArticleRepository article)
        {
            ArticleRepository = article;
        }


        public GenericResponse<TArticle> AddArticle(TArticle article)
        {
            try
            {
                if (article == null)
                    return new GenericResponse<TArticle>("Article is empty");

                ArticleRepository.AddArticle(article);
                return new GenericResponse<TArticle>(article);
            }
            catch (Exception ex)
            {
                return new GenericResponse<TArticle>(ex.Message);
            }
        }

        public GenericResponse<TArticle> GetArticleById(int articleId)
        {
            try
            {
                if (articleId < 1)
                    return new GenericResponse<TArticle>("ArticleId out of range");
                var article = ArticleRepository.GetArticleById(articleId);
                return new GenericResponse<TArticle>(article);

            }
            catch (Exception ex)
            {
                return new GenericResponse<TArticle>(ex.Message);
            }
        }

        public GenericResponse<TArticle> RemoveArticle(TArticle article)
        {
            try
            {
                if (article == null)
                    return new GenericResponse<TArticle>("Article is empty");
                ArticleRepository.RemoveArticle(article);
                return new GenericResponse<TArticle>(article);
            }
            catch (Exception ex)
            {
                return new GenericResponse<TArticle>(ex.Message); 
            }
        }

        public GenericResponse<TArticle> UpdateArticle(TArticle article)
        {
            try
            {
                if (article == null)
                    return new GenericResponse<TArticle>("Article is empty");

               var articleUpd= ArticleRepository.UpdateArticle(article);
                return new GenericResponse<TArticle>(articleUpd);

            }
            catch (Exception ex)
            {
              return new GenericResponse<TArticle>(ex.Message);
            }
        }
    }
}
