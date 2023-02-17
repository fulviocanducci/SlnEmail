using RazorLight.Extensions;
using FluentEmail.Core.Defaults;

namespace Web
{
   public class Program
   {
      public static void Main(string[] args)
      {
         var builder = WebApplication.CreateBuilder(args);
         builder.Services
            .AddFluentEmail("recoverymiles@s2milhas.com.br")
            .AddRazorRenderer()
            .AddSmtpSender("mail.s2milhas.com.br", 587, "recoverymiles@s2milhas.com.br", "P$YHB3p1fUbbwk#@@");
         builder.Services.AddControllersWithViews();
         var app = builder.Build();

         if (!app.Environment.IsDevelopment())
         {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
         }
         app.UseHttpsRedirection();
         app.UseStaticFiles();
         app.UseRouting();
         app.UseAuthorization();
         app.MapControllerRoute(
             name: "default",
             pattern: "{controller=Home}/{action=Index}/{id?}");
         app.Run();
      }
   }
}