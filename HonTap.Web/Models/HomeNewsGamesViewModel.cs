using System.Collections.Generic;

namespace HonTap.Web.Models
{
    public class HomeNewsGamesViewModel
    {
        public IEnumerable<PostCategoryViewModel> ChildCategory { set; get; }

        public IEnumerable<PostViewModel> NewsGame { set; get; }

        public IEnumerable<PostViewModel> NewsHot { set; get; }
    }
}