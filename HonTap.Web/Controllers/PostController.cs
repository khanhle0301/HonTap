using AutoMapper;
using HonTap.Common;
using HonTap.Model.Dao;
using HonTap.Model.Models;
using HonTap.Web.Infrastructure.Core;
using HonTap.Web.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace HonTap.Web.Controllers
{
    public class PostController : Controller
    {      
        private PostDao _postDao = new PostDao();
        private TagDao _tagDao = new TagDao();
        private PostCategoryDao _postCategoryDao = new PostCategoryDao();

        public ActionResult Category(string alias, int page = 1)
        {
            var category = _postCategoryDao.GetByAlias(alias);
            int pageSize = int.Parse(ConfigHelper.GetByKey("PageSize"));
            int totalRow = 0;
            var postModel = _postDao.GetAllByCategoryPaging(category.ID, page, pageSize, out totalRow);
            var postViewModel = Mapper.Map<IEnumerable<Post>, IEnumerable<PostViewModel>>(postModel);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);
            var paginationSet = new PaginationSet<PostViewModel>()
            {
                Items = postViewModel,
                MaxPage = int.Parse(ConfigHelper.GetByKey("MaxPage")),
                Page = page,
                TotalCount = totalRow,
                TotalPages = totalPage
            };
            ViewBag.Category = category;
            return View(paginationSet);
        }

        public ActionResult Tag(string tagId, int page = 1)
        {
            var tag = new TagDao().GetById(tagId);
            int pageSize = int.Parse(ConfigHelper.GetByKey("PageSize"));
            int totalRow = 0;
            var postModel = _postDao.GetAllByTagPaging(tagId, page, pageSize, out totalRow);
            var postViewModel = Mapper.Map<IEnumerable<Post>, IEnumerable<PostViewModel>>(postModel);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);
            var paginationSet = new PaginationSet<PostViewModel>()
            {
                Items = postViewModel,
                MaxPage = int.Parse(ConfigHelper.GetByKey("MaxPage")),
                Page = page,
                TotalCount = totalRow,
                TotalPages = totalPage
            };
            ViewBag.Tag = tag;
            return View(paginationSet);
        }

        public ActionResult Search(string keyword, int page = 1)
        {           
            int pageSize = int.Parse(ConfigHelper.GetByKey("PageSize"));
            int totalRow = 0;
            var postModel = _postDao.GetAllBySearch(keyword, page, pageSize, out totalRow);
            var postViewModel = Mapper.Map<IEnumerable<Post>, IEnumerable<PostViewModel>>(postModel);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);
            var paginationSet = new PaginationSet<PostViewModel>()
            {
                Items = postViewModel,
                MaxPage = int.Parse(ConfigHelper.GetByKey("MaxPage")),
                Page = page,
                TotalCount = totalRow,
                TotalPages = totalPage
            };
            ViewBag.Keyword = keyword;
            return View(paginationSet);
        }

        public ActionResult Detail(int id)
        {
            var model = _postDao.GetAllById(id);
            ViewBag.Related = Mapper.Map<IEnumerable<Post>, IEnumerable<PostViewModel>>(_postDao.GetReatedPosts(id, 4));
            _postDao.IncreaseView(id);
            return View(model);
        }
    }
}