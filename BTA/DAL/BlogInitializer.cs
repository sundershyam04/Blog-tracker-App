using System.Collections.Generic;
using System;
using System.Data.Entity;

namespace DAL
{
    public class BlogInitializer : DropCreateDatabaseIfModelChanges<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {
            List<AdminInfo> adminInfos = new List<AdminInfo>();

            adminInfos.Add(new AdminInfo() { Email = "ganesh@gamil.com", Password = "ganesh@123" });
            adminInfos.Add(new AdminInfo() { Email = "sunder@gmail.com", Password = "sunder@123" });

            context.AdminInfos.AddRange(adminInfos);
            context.SaveChanges();

            List<EmpInfo> empInfos = new List<EmpInfo>();
            empInfos.Add(new EmpInfo() { Email = "rahman@gmail.com", PassCode = 123, DateOfJoining = new DateTime(2020, 10, 05), Name = "rahman" });
            empInfos.Add(new EmpInfo() { Email = "satvika@gmail.com", PassCode = 234, DateOfJoining = new DateTime(2019, 10, 25), Name = "satvika" });
            empInfos.Add(new EmpInfo() { Email = "john@gmail.com", PassCode = 345, DateOfJoining = new DateTime(2020, 11, 05), Name = "john" });
            context.EmpInfos.AddRange(empInfos);
            context.SaveChanges();

            List<BlogInfo> blogInfos = new List<BlogInfo>();
            blogInfos.Add(new BlogInfo() { Email = "rahman@gmail.com", BlogUrl = "https://www.pexels.com/@shyam-s-desk-164967671/?nc=", DateOfCreation = new DateTime(2020, 10, 10), Subject = "Photography", Title = "Shyam's Desk" });
            blogInfos.Add(new BlogInfo() { Email = "satvika@gmail.com", BlogUrl = "https://www.pexels.com/@shyam-s-desk-164967671/?nc=", DateOfCreation = new DateTime(2020, 10, 26), Subject = "Photography", Title = "Shyam's Desk" });
            blogInfos.Add(new BlogInfo() { Email = "john@gmail.com", BlogUrl = "https://www.pexels.com/@shyam-s-desk-164967671/?nc=", DateOfCreation = new DateTime(2020, 11, 06), Subject = "Photography", Title = "Shyam's Desk" });
            context.BlogInfos.AddRange(blogInfos);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}