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
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository CommentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            CommentRepository = commentRepository;
        }

        public GenericResponse<TComments> AddComment(TComments comment)
        {
            try
            {
                if (comment == null)
                    return new GenericResponse<TComments>("Comment is empty");
                CommentRepository.AddComment(comment);
                return new GenericResponse<TComments>(comment);
            }
            catch (Exception ex)
            {
                return new GenericResponse<TComments>(ex.Message);
            }
        }

        public GenericResponse<TComments> GetCommentsByArticleId(int articleId)
        {
            try
            {
                if (articleId < 1) return new GenericResponse<TComments>("ArticleId out of range");
                var comment = CommentRepository.GetCommentsByArticleId(articleId);
                return new GenericResponse<TComments>(comment);
            }
            catch (Exception ex)
            {
                return new GenericResponse<TComments>(ex.Message);
            }
        }

        public GenericResponse<TComments> GetCommentsById(int commentId)
        {
            try
            {
                if (commentId < 1) return new GenericResponse<TComments>("CommentId out of range");
                var comment = CommentRepository.GetCommentsById(commentId);
                return new GenericResponse<TComments>(comment);
            }
            catch (Exception ex)
            {
                return new GenericResponse<TComments>(ex.Message);
            }
        }

        public GenericResponse<TComments> RemoveComment(TComments comment)
        {
            try
            {
                if (comment == null)
                    return new GenericResponse<TComments>("Comment is empty");
                CommentRepository.RemoveComment(comment);
                return new GenericResponse<TComments>(comment);
            }
            catch (Exception ex)
            {
                return new GenericResponse<TComments>(ex.Message);
            }
        }

        public GenericResponse<TComments> UpdateComment(TComments comment)
        {
            try
            {
                if (comment == null) return new GenericResponse<TComments>("Comment is empty");
             var  commentUpd= CommentRepository.UpdateComment(comment);
                return new GenericResponse<TComments>(commentUpd);
            }
            catch (Exception ex)
            {
                return new GenericResponse<TComments>(ex.Message);
            }
        }
    }
}
