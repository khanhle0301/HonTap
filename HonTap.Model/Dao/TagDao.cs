using HonTap.Model.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HonTap.Model.Dao
{
    public class TagDao
    {
        private BlogDbContext db = null;

        public TagDao()
        {
            db = new BlogDbContext();
        }

        public Tag GetById(string id)
        {
            return db.Tags.SingleOrDefault(x => x.ID == id);
        }

        public IEnumerable<Tag> GetAll()
        {
            return db.Tags;
        }
    }
}