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
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace CoreApiGITVersion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService ArticleService;
        private readonly IMemoryCache MemoryCache;
        public ILogger<ArticleController> logger;
        const string cacheKey = "artOfArticles";
        public ArticleController(IArticleService articleService,IMemoryCache memory,ILogger<ArticleController> _logger)
        {
            ArticleService = articleService;
            MemoryCache = memory;
            logger = _logger;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetDailyArticles()
        {
            try
            { 

                if (!MemoryCache.TryGetValue(cacheKey, out GenericResponse<List<TArticle>> response))
                {
                    response = ArticleService.GetDailyList();
                    var cacheExpirationOptions =
                        new MemoryCacheEntryOptions
                        {
                            //Refreshing every 1 hour
                            AbsoluteExpiration = DateTime.Now.AddMinutes(60),
                            Priority = CacheItemPriority.Normal
                        };
                    MemoryCache.Set(cacheKey, response, cacheExpirationOptions);
                }
                return Ok(response);
               
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpGet("{id:int}")] 
        public IActionResult SearchArticle(int id)
        {
            try
            {
                var result = ArticleService.GetArticleById(id);
                if (result.Success)
                    return Ok(result);
                else
                    return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpPut]
        public IActionResult AddArticle(TArticle article)
        {
            try
            {
                var result = ArticleService.AddArticle(article);
                if (result.Success)
                    return Ok(result);
                else
                    return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpPost]
        public IActionResult UpdateArticle(TArticle article)
        { 
            try
            {
                var result = ArticleService.UpdateArticle(article);
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
        public IActionResult RemoveArticle(TArticle article)
        {
            try
            {
                var result = ArticleService.RemoveArticle(article);
                if (result.Success)
                    return Ok(result);
                else
                    return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }


    }
}