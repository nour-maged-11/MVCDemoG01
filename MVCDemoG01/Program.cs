using MVCDemoG02.CustomMiddlwares;
using static System.Net.Mime.MediaTypeNames;

namespace MVCDemoG01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();  //mvc

            var app = builder.Build();

            #region Custom Middlwares
            //app.Use(async (context, next) =>
            //    {
            //        // 1) Step 01
            //        Console.WriteLine("Hello");
            //        await next(context);
            //        Console.WriteLine("Bye");
            //    });
            app.UseMiddleware<RequestTimingMiddlware >();
            #endregion




            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=}/{action=}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
