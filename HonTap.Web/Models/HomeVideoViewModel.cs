using System.Collections.Generic;

namespace HonTap.Web.Models
{
    public class HomeVideoViewModel
    {
        public IEnumerable<PostCategoryViewModel> ChildCategory { set; get; }
     
        public IEnumerable<PostViewModel> Videos { set; get; }

        public IEnumerable<PostViewModel> Congdong { set; get; }
    }
}