using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.Dao
{
    public class UserDao
    {
        OnlineShopDbContext db = null;
        public UserDao()
        {
            db = new OnlineShopDbContext();
        }
        public long Insert(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return 1;
        }
        public bool Update(User entity)
        {
            try
            {
                var user = GetByUserName(entity.UserName);
                user.Name = entity.Name;
                user.Email = entity.Email;
                user.Mobile = entity.Mobile;
                user.Address = entity.Address;
                db.SaveChanges();
                return true;
            }
            catch(Exception ex) {
                return false;
            }
          
        }
        public User GetByUserName(string username)
        {
            return db.Users.SingleOrDefault(x => x.UserName == username);
        }
        public bool Login(string username, string password)
        {
            var res = db.Users.Count(x => x.UserName == username && x.Password == password);
            if (res > 0)
            {
                   return true;
            }
            else
            {
                   return false;
            }
        }
        public IEnumerable<User> ListAllPaging(string searchString, int page =1, int pageSize = 10)

        {
            IQueryable<User> model = db.Users;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString) || x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public bool Delete(string username)
        {
            try
            {
                var user = db.Users.SingleOrDefault(x=>x.UserName == username);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex) {
                return false;
                   }
           
        }
       
    }
}