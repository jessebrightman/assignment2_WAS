using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment2_WAS_2.ViewModels;

namespace Assignment2_WAS_2.Models
{
    public class ViewUserRepo
    {
        MyIdentityEntities db = new MyIdentityEntities();
        public IEnumerable<ViewUser> GetViewUsers()
        {
            var query = (from u in db.AspNetUsers
                         from r in u.AspNetRoles
                         from m in db.MyUsers
                         where u.Id.Contains(r.Id)
                         where u.UserName == m.myUser
                         select new
                         {
                             UserName = u.UserName,
                             Address = m.myAddress,
                             City = m.city,
                             State = m.province,
                             Country = m.country,
                             Role = r.Name
                         }).ToList();

            List<ViewUser> users = new List<ViewUser>();
            foreach(var user in query)
            {
                users.Add(new ViewUser(user.UserName, user.Address, user.City, user.State, user.Country, user.Role));
            }
            return users;
        }
    }
}