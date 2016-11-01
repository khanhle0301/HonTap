using System.Collections.Generic;

namespace HonTap.Web.Models
{
    public class HomeLastedNewsViewModel
    {
        public BannerViewModel BannerNews { set; get; }

        public IEnumerable<PostViewModel> LastedNews { set; get; }
    }
}