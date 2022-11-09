using BTAWebAPIClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BTAWebAPIClient.Controllers
{
    public class HomeController : Controller
    {
        string BaseUrl = "https://localhost:44381/api/";
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(MAdmin m)
        {
            List<MAdmin> blogs = new List<MAdmin>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                var response = client.GetAsync("admin");
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readData = result.Content.ReadAsAsync<MAdmin[]>();
                    readData.Wait();
                    var blogdata = readData.Result;
                    foreach (var item in blogdata)
                    {
                        blogs.Add(new MAdmin { Email = item.Email, Password = item.Password });
                    }
                }
            }
            var found = blogs.Find(x => x.Email == m.Email);
            if (found != null)
            {
                if (found.Password == m.Password)
                {
                    return RedirectToAction("EmpDetails");
                }
                else
                {
                    ViewBag.msg = "Incorrect Paasword";
                }
            }
            else
            {
                ViewBag.msg = "Account Not Found";
            }
            return View();
        }
        public ActionResult Index()
        {
            List<MBlog> blogs = new List<MBlog>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                var response = client.GetAsync("blog");
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readData = result.Content.ReadAsAsync<MBlog[]>();
                    readData.Wait();
                    var blogdata = readData.Result;
                    foreach (var item in blogdata)
                    {
                        blogs.Add(new MBlog { BlogId = item.BlogId, BlogUrl = item.BlogUrl, DateOfCreation = item.DateOfCreation, Email = item.Email, Subject = item.Subject, Title = item.Title });
                    }
                }
                }
            return View(blogs);
        }
        public ActionResult Show()
        {
            List<MBlog> blogs = new List<MBlog>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                var response = client.GetAsync("blog");
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readData = result.Content.ReadAsAsync<MBlog[]>();
                    readData.Wait();
                    var blogdata = readData.Result;
                    foreach (var item in blogdata)
                    {
                        blogs.Add(new MBlog { BlogId = item.BlogId, BlogUrl = item.BlogUrl, DateOfCreation = item.DateOfCreation, Email = item.Email, Subject = item.Subject, Title = item.Title });
                    }
                }
            }
            return View(blogs);
        }

        public ActionResult EmpDetails()
        {
            List<MEmp> blogs = new List<MEmp>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                var response = client.GetAsync("employee");
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readData = result.Content.ReadAsAsync<MEmp[]>();
                    readData.Wait();
                    var blogdata = readData.Result;
                    foreach (var item in blogdata)
                    {
                        blogs.Add(new MEmp { Email = item.Email, PassCode = item.PassCode, DateOfJoining = item.DateOfJoining, Name = item.Name, Blogs = item.Blogs });
                    }
                }
 }
            return View(blogs);
        }

        public ActionResult EmpLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EmpLogin(MEmp m)
        {
            List<MEmp> blogs = new List<MEmp>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                var response = client.GetAsync("employee");
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readData = result.Content.ReadAsAsync<MEmp[]>();
                    readData.Wait();
                    var blogdata = readData.Result;
                    foreach (var item in blogdata)
                    {
                        blogs.Add(new MEmp { Email = item.Email, PassCode = item.PassCode });
                    }
                }
            }
            var found = blogs.Find(x => x.Email == m.Email);
            if (found != null)
            {
                if (found.PassCode == m.PassCode)
                {
                    TempData["empEmail"] = found.Email;
                    return RedirectToAction("EmpList");
                }
                else
                {
                    ViewBag.msg = "Incorrect Paasword";
                }
            }
            else
            {
                ViewBag.msg = "Employee Account Not Found";
            }
            return View();
        }

        public ActionResult EmpList()
        {
            List<MBlog> blogs = new List<MBlog>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                var response = client.GetAsync("blog");
                response.Wait();
                var result = response.Result;
                string ans = TempData["empEmail"].ToString();
                if (result.IsSuccessStatusCode)
                {
                    var readData = result.Content.ReadAsAsync<MBlog[]>();
                    readData.Wait();
                    var blogdata = readData.Result;
                    foreach (var item in blogdata)
                    {
                        if (item.Email == ans)
                        {
                            blogs.Add(new MBlog { BlogId = item.BlogId, BlogUrl = item.BlogUrl, DateOfCreation = item.DateOfCreation, Email = item.Email, Subject = item.Subject, Title = item.Title });
                        }
                    }
                }
            }
            if (blogs != null)
            {
                return View(blogs);
            }
            else
            {
                return RedirectToAction("Create");
            }

        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(MBlog blog)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44381/api/blog");

                var blog1 = new MBlog { BlogId = blog.BlogId, BlogUrl = blog.BlogUrl, DateOfCreation = blog.DateOfCreation, Email = blog.Email, Subject = blog.Subject, Title = blog.Title };

                var postTask = client.PostAsJsonAsync<MBlog>(client.BaseAddress, blog1);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readtaskResult = result.Content.ReadAsAsync<MBlog>();
                    readtaskResult.Wait();
                    var dataInserted = readtaskResult.Result;
                }
            }

            return RedirectToAction("Index");

        }

        public ActionResult CreateEmp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateEmp(MEmp emp)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44381/api/employee");

                var emp1 = new MEmp { Email = emp.Email, DateOfJoining = emp.DateOfJoining, Name = emp.Name, PassCode = emp.PassCode };

                var postTask = client.PostAsJsonAsync<MEmp>(client.BaseAddress, emp1);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readtaskResult = result.Content.ReadAsAsync<MEmp>();
                    readtaskResult.Wait();
                    var dataInserted = readtaskResult.Result;
                }
            }

            return RedirectToAction("EmpDetails");

        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}