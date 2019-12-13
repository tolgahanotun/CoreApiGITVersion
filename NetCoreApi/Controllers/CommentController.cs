using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApiGITVersion.Interfaces.Service;
using CoreApiGITVersion.Models;
using CoreApiGITVersion.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreApiGITVersion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService CommentService;
        public CommentController(ICommentService commentService)
        {
            CommentService = commentService;
        }
        
        [AllowAnonymous]
        [HttpGet("{id:int}")] 
        public IActionResult GetArticleComments(int id)
        {
            try
            {
                var result =CommentService.GetCommentsByArticleId(id);
                if (result.Success)
                    return Ok(result);
                else
                    return BadRequest(result.Message);
               
            }
            catch (Exception ex)
            {
                return  BadRequest(new GenericResponse<TComments>(ex.Message));
            }
           
        }


        [Authorize]
        [HttpPut]
        public IActionResult AddComments(TComments comment)
        {
            try
            {
               var response= CommentService.AddComment(comment);
                if (response.Success)
                    return Ok(response);
                else
                    return BadRequest(response.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpPost]
        public IActionResult UpdateComment(TComments comment)
        {
            try
            {
              var result=  CommentService.UpdateComment(comment);
                if (result.Success)
                    return Ok(result);
                else
                    return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete]
        public IActionResult RemoveComment(TComments comment)
        {
            try
            {
                var result = CommentService.RemoveComment(comment);
                if (result.Success)
                    return Ok(result);
                else
                    return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}