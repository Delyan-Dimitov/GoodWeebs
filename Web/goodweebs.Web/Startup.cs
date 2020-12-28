namespace GoodWeebs.Web
{
    using System.Reflection;
    using Azure.Storage.Blobs;
    using Ganss.XSS;
    using GoodWeebs.Data;
    using GoodWeebs.Data.Common;
    using GoodWeebs.Data.Common.Repositories;
    using GoodWeebs.Data.Models;
    using GoodWeebs.Data.Repositories;
    using GoodWeebs.Data.Seeding;
    using GoodWeebs.Services;
    using GoodWeebs.Services.Data;
    using GoodWeebs.Services.Data.GoodWeebsDataServices.GroupServices;
    using GoodWeebs.Services.Data.GoodWeebsDataServices.ReccomendationsServices;
    using GoodWeebs.Services.Data.GoodWeebsDataServices.ShelvesServices;
    using GoodWeebs.Services.Data.GoodWeebsDataServices.SubmissionsServices;
    using GoodWeebs.Services.Data.GoodWeebsDataServices.UpdatesServices;
    using GoodWeebs.Services.GoodWeebs.Services.AnimeServices;
    using GoodWeebs.Services.GoodWeebs.Services.MangaServices;
    using GoodWeebs.Services.GoodWeebs.Services.SubmissionsServices;
    using GoodWeebs.Services.GoodWeebs.Services.UserServices;
    using GoodWeebs.Services.Mapping;
    using GoodWeebs.Services.Messaging;
    using GoodWeebs.Web.ViewModels;
    using GoodwWebs.Services.Data.GoodWeebsDataServices.ShelvesServices;
    using GoodwWebs.Services.Data.GoodWeebsDataServices.UpdatesServices;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {

        private readonly IConfiguration configuration;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment env;

        public Startup(IConfiguration configuration, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            this.configuration = configuration;
            this.env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
        .SetBasePath(this.env.ContentRootPath)
        .AddJsonFile("appsetting.s.json", optional: true, reloadOnChange: true);

            services.Configure<IdentityOptions>(options =>
            {
                // User settings.
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+ ";
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)
                .AddRoles<ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<CookiePolicyOptions>(
                options =>
                    {
                        options.CheckConsentNeeded = context => true;
                        options.MinimumSameSitePolicy = SameSiteMode.None;
                    });

            services.AddControllersWithViews(
                options =>
                    {
                        options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                    }).AddRazorRuntimeCompilation();
            services.AddRazorPages();

            services.AddSingleton(this.configuration);
            services.AddSingleton(x => new BlobServiceClient(this.configuration.GetValue<string>("BlobConnectionString")));

            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            // Application services
            services.AddTransient<IEmailSender, NullMessageSender>();
            services.AddTransient<ISettingsService, SettingsService>();
            services.AddTransient<IAnimeService, AnimeService>();
            services.AddTransient<IMangaService, MangaService>();
            services.AddTransient<IAnimeShelfService, AnimeShelfService>();
            services.AddTransient<IMangaShelfService, MangaShelfService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICreateSubmissionsService, CreateSubmissionsService>();
            services.AddTransient<IAnimeReccomendationsService, AnimeReccomendationService>();
            services.AddTransient<ISubmissionsService, SubmissionsService>();
            services.AddTransient<IUpdateService, UpdateService>();
            services.AddTransient<IGroupService, GroupService>();
            services.AddTransient<IMailService, SendGridMailService>();
            services.AddTransient<IHtmlSanitizer, HtmlSanitizer>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

            // Seed data on application startup
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();
                new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                    {
                        endpoints.MapControllerRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapRazorPages();
                    });
        }
    }
}
