using System;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public class BlogContext : DbContext
    {
        // Your context has been configured to use a 'BTAModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DAL.BTAModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'BTAModel' 
        // connection string in the application configuration file.
        public BlogContext()
            : base("name=BlogContext")
        {
            Database.SetInitializer<BlogContext>(new BlogInitializer());
        }

      

         public virtual DbSet<AdminInfo> AdminInfos { get; set; }
         public virtual DbSet<EmpInfo> EmpInfos { get; set; }
         public virtual DbSet<BlogInfo> BlogInfos { get; set; }
    }

    
}