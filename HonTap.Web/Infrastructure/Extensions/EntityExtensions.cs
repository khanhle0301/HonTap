using HonTap.Model.Models;
using HonTap.Web.Models;

namespace HonTap.Web.Infrastructure.Extensions
{
    public static class EntityExtensions
    {
        public static void UpdatePostCategory(this PostCategory postCategory, PostCategoryViewModel postCategoryVm)
        {
            postCategory.ID = postCategoryVm.ID;
            postCategory.Name = postCategoryVm.Name;         
            postCategory.Alias = postCategoryVm.Alias;
            postCategory.ParentID = postCategoryVm.ParentID;            
            postCategory.DisplayOrder = postCategoryVm.DisplayOrder;           
            postCategory.MetaKeyword = postCategoryVm.MetaKeyword;
            postCategory.MetaDescription = postCategoryVm.MetaDescription;
            postCategory.Status = postCategoryVm.Status;
            postCategory.CreatedBy = postCategoryVm.CreatedBy;
            postCategory.CreatedDate = postCategoryVm.CreatedDate;
            postCategory.UpdatedDate = postCategoryVm.UpdatedDate;
            postCategory.UpdatedBy = postCategoryVm.UpdatedBy;
        }

        public static void UpdatePost(this Post post, PostViewModel postVm)
        {
            post.ID = postVm.ID;
            post.Name = postVm.Name;
            post.Description = postVm.Description;
            post.Alias = postVm.Alias;
            post.CategoryID = postVm.CategoryID;
            post.Content = postVm.Content;
            post.Image = postVm.Image;          
            post.ViewCount = postVm.ViewCount;
            post.CreatedDate = postVm.CreatedDate;
            post.CreatedBy = postVm.CreatedBy;
            post.UpdatedDate = postVm.UpdatedDate;
            post.UpdatedBy = postVm.UpdatedBy;
            post.MetaKeyword = postVm.MetaKeyword;
            post.MetaDescription = postVm.MetaDescription;           
            post.Status = postVm.Status;       
            post.Tags = postVm.Tags;           
        }

        public static void UpdateUserGroup(this UserGroup userGroup, UserGroupViewModel userGroupVm)
        {
            userGroup.ID = userGroupVm.ID;
            userGroup.Name = userGroupVm.Name;            
        }

        public static void UpdateUser(this User user, UserViewModel userVm)
        {
            user.ID = userVm.ID;
            user.Name = userVm.Name;
            user.UserName = userVm.UserName;
            user.Password = userVm.Password;
            user.GroupID = userVm.GroupID;
            user.Address = userVm.Address;
            user.Email = userVm.Email;
            user.Phone = userVm.Phone;
        }      
    }
}