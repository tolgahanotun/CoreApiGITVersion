using CoreApiGITVersion.Models;
using CoreApiGITVersion.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiGITVersion.Interfaces.Service
{
    interface ICommentService
    {
        public GenericResponse<TComments> AddComment(TComments comment);
        public GenericResponse<TComments> RemoveComment(TComments comment);
        public GenericResponse<TComments> UpdateComment(TComments comment);
        public GenericResponse<TComments> GetCommentsById(int commentId);
        public GenericResponse<TComments> GetCommentsByArticleId(int articleId);
    }
}
