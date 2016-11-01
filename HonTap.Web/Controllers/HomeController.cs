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
    public class HomeController : Controller
    {
        private PostDao _postDao = new PostDao();
        private TagDao _tagDao = new TagDao();
        private PostCategoryDao _postCategoryDao = new PostCategoryDao();

        public ActionResult Index(int page = 1)
        {
            int pageSize = int.Parse(ConfigHelper.GetByKey("PageSize"));
            int totalRow = 0;
            var postModel = _postDao.GetAllPaging(page, pageSize, out totalRow);
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
            ViewBag.Title = ConfigHelper.GetByKey("HomeTitle");
            ViewBag.Keywords = ConfigHelper.GetByKey("HomeKeyword");
            ViewBag.Descriptions = ConfigHelper.GetByKey("HomeDescription");
            return View(paginationSet);
        }

        [ChildActionOnly]
        public ActionResult Header()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult Menu()
        {
            var model = Mapper.Map<IEnumerable<PostCategory>, IEnumerable<PostCategoryViewModel>>(_postCategoryDao.GetAllByStatus());
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult SideBar()
        {
            var model = Mapper.Map<IEnumerable<Post>, IEnumerable<PostViewModel>>(_postDao.GetViewCount(10));
            ViewBag.Tags = _tagDao.GetAll();
            return PartialView(model);
        }
    }
}