
using Linux.MvcCore.Learn.Model.Admin;
using Linux.MvcCore.Learn.Model.Blog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Linux.MvcCore.Learn.Model 
{
    public partial class LearnContext : DbContext
    {
        public LearnContext(DbContextOptions<LearnContext> options) : base(options)
        { }





        public DbSet<Role> Roles { get; set; }
        public DbSet<SysMenu> SysMenus { get; set; }
        public DbSet<SysUser> SysUsers { get; set; }
        public DbSet<UserDetial> UserDetials { get; set; }

        public DbSet<BlogPost> BlogPosts { get; set; }

        public DbSet<BlogTag> BlogTags { get; set; }

        public DbSet<BlogComment> BlogComments { get; set; }

        public DbSet<SpamShield> SpamShields { get; set; }

        public DbSet<SpamHash> SpamHashs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ///role
            modelBuilder.Entity<Role>().HasKey(p => p.RoleId).ForSqliteHasName("RoleId");
            //modelBuilder.Entity<Role>().ForSqliteToTable("role").HasMany(p => p.SysMenus);
            //modelBuilder.Entity<Role>().HasMany(p => p.SysUsers);
            modelBuilder.Entity<Role>().Property(p => p.RoleName).ForSqliteHasColumnName("RoleName");
            modelBuilder.Entity<Role>().Property(p => p.RoleRemark).ForSqliteHasColumnName("RoleRemark");

            //menu
            modelBuilder.Entity<SysMenu>().ForSqliteToTable("sysmenu").HasKey(p => p.SysMenuId).ForSqliteHasName("SysMenuId");
            modelBuilder.Entity<SysMenu>().Property(p => p.MenuName).ForSqliteHasColumnName("MenuName");
            modelBuilder.Entity<SysMenu>().Property(p => p.MenuRemark).ForSqliteHasColumnName("MenuRemark");
            modelBuilder.Entity<SysMenu>().Property(p => p.MenuUrl).ForSqliteHasColumnName("MenuUrl");

            ///sysuser
            modelBuilder.Entity<SysUser>().ForSqliteToTable("sysuser").HasKey(p => p.UserID).ForSqliteHasName("UserID");
            modelBuilder.Entity<SysUser>().Property(p => p.UserLoginName).ForSqliteHasColumnName("UserLoginName");
            modelBuilder.Entity<SysUser>().Property(p => p.Password).ForSqliteHasColumnName("MenuRemark");

            ///userDetile 
            modelBuilder.Entity<UserDetial>().ForSqliteToTable("userdetial").HasKey(p => p.UserDetialId).ForSqliteHasName("UserDetialId");
            modelBuilder.Entity<UserDetial>().Property(p => p.UserID).ForSqliteHasColumnName("UserID");
            modelBuilder.Entity<UserDetial>().Property(p => p.UserName).ForSqliteHasColumnName("UserName");
            modelBuilder.Entity<UserDetial>().Property(p => p.Sex).ForSqliteHasColumnName("Sex");
            modelBuilder.Entity<UserDetial>().Property(p => p.Age).ForSqliteHasColumnName("Age");
            modelBuilder.Entity<UserDetial>().Property(p => p.Phone).ForSqliteHasColumnName("Phone");
            modelBuilder.Entity<UserDetial>().Property(p => p.Email).ForSqliteHasColumnName("Email");

            //BlogComment
            modelBuilder.Entity<BlogComment>().ForSqliteToTable("BlogComment").HasKey(p => p.Id).ForSqliteHasName("Id");
            modelBuilder.Entity<BlogComment>().Property(p => p.Content).IsRequired().ForSqliteHasColumnName("Content");
            modelBuilder.Entity<BlogComment>().Property(p => p.CreatedTime).IsRequired().ForSqliteHasColumnName("CreatedTime");
            modelBuilder.Entity<BlogComment>().Property(p => p.Email).ForSqliteHasColumnName("Email");
            modelBuilder.Entity<BlogComment>().Property(p => p.IPAddress).IsRequired().ForSqliteHasColumnName("IPAddress");
            modelBuilder.Entity<BlogComment>().Property(p => p.NickName).ForSqliteHasColumnName("NickName");
            modelBuilder.Entity<BlogComment>().Property(p => p.PostId).ForSqliteHasColumnName("PostId");
            modelBuilder.Entity<BlogComment>().Property(p => p.SiteUrl).ForSqliteHasColumnName("SiteUrl");

            //BlogPost
            modelBuilder.Entity<BlogPost>().ForSqliteToTable("BlogPost").HasKey(p => p.BlogId).ForSqliteHasName("BlogId");
            modelBuilder.Entity<BlogPost>().Property(p => p.PubDate).IsRequired().ForSqliteHasColumnName("PubDate");
            modelBuilder.Entity<BlogPost>().Property(p => p.AuthorDisplayName).IsRequired().ForSqliteHasColumnName("AuthorDisplayName");
            modelBuilder.Entity<BlogPost>().Property(p => p.AuthorEmail).IsRequired().ForSqliteHasColumnName("AuthorEmail");
            modelBuilder.Entity<BlogPost>().Property(p => p.Content).IsRequired().ForSqliteHasColumnName("Content");
            modelBuilder.Entity<BlogPost>().Property(p => p.DateUTC).ForSqliteHasColumnName("DateUTC");
            modelBuilder.Entity<BlogPost>().Property(p => p.MarkDown).ForSqliteHasColumnName("MarkDown");
            modelBuilder.Entity<BlogPost>().Property(p => p.Status).ForSqliteHasColumnName("Status");
            modelBuilder.Entity<BlogPost>().Property(p => p.Title).ForSqliteHasColumnName("Title");
            modelBuilder.Entity<BlogPost>().Property(p => p.TitleSlug).ForSqliteHasColumnName("TitleSlug");
            modelBuilder.Entity<BlogPost>().Property(p => p.ViewCount).ForSqliteHasColumnName("ViewCount");
            modelBuilder.Entity<BlogPost>().HasMany(t => t.Tags).WithOne(p => p.BlogPost).HasForeignKey(p => p.BlogPostId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<BlogPost>().HasMany(t => t.Comments).WithOne(p => p.BlogPost).HasForeignKey(p => p.PostId).OnDelete(DeleteBehavior.Cascade);

            //tag
            modelBuilder.Entity<BlogTag>().ForSqliteToTable("BlogTag").HasKey(p => p.BlogTagId).ForSqliteHasName("BlogTagId");
            modelBuilder.Entity<BlogTag>().Property(p => p.Tag).IsRequired().ForSqliteHasColumnName("Tag");
            modelBuilder.Entity<BlogTag>().Property(p => p.BlogPostId).ForSqliteHasColumnName("BlogPostId");
            modelBuilder.Entity<BlogTag>().Property(p => p.Slug).ForSqliteHasColumnName("Slug");

            //SpamHash 
            modelBuilder.Entity<SpamHash>().ForSqliteToTable("spamhash").HasKey(p => p.SpamHashId).ForSqliteHasName("SpamHashId");
            modelBuilder.Entity<SpamHash>().Property(p => p.CreatedTime).ForSqliteHasColumnName("CreatedTime");
            modelBuilder.Entity<SpamHash>().Property(p => p.Hash).ForSqliteHasColumnName("Hash");
            modelBuilder.Entity<SpamHash>().Property(p => p.Pass).ForSqliteHasColumnName("Pass");
            modelBuilder.Entity<SpamHash>().Property(p => p.PostKey).ForSqliteHasColumnName("PostKey");

            //SpamShield
            modelBuilder.Entity<SpamShield>().ForSqliteToTable("SpamShield").HasKey(p => p.Tick).ForSqliteHasName("Tick");
            modelBuilder.Entity<SpamShield>().Property(p => p.Hash).ForSqliteHasColumnName("Hash");

            base.OnModelCreating(modelBuilder);
        }
    }
}
