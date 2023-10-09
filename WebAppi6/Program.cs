using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using WebAppi6;
using WebAppi6.Models;
using WebAppi6.Models.Services;

internal class Program
{
    static void ConfigureServices(WebApplicationBuilder builder)
    {
        IServiceCollection allServices = builder.Services;
        //ApplicationContext context = new ApplicationContext();
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        allServices.AddControllersWithViews();
        allServices.AddControllers();
        allServices.AddDbContext<ApplicationContext>();
        //allServices.AddScoped<ApplicationContext>();
        //allServices.AddSingleton<DataBaseService>();
        //allServices.AddControllers();
        allServices.AddScoped<UserService>();
        //allServices.AddSingleton<FurtherInformationService>();
        //allServices.AddSingleton<AuthorizationService>();
        //allServices.AddSingleton<RegistrationService>();
        //services.AddInstance<IGUIDService>(new GUIDService());
    }
    private static void Main(string[] args)
    {
        //ApplicationContext context = new ApplicationContext();
        //var att = context.Attractions.ToList();
        //var attr = att.Where(a => a.ID < 300 && a.ID > 200).ToList();
        //var sc=context.SubCategories.ToList();
        //var subcat = sc.Where(s => s.ID < 2).ToList();
        //var cuis=context.Cuisines.ToList().Where(c=>c.ID<10).ToList();
        //var fr = context.FoodRestrictions.ToList().Where(f => f.ID < 3).ToList();
        //var cafes = att.Where(a => a.ID > 44000).ToList();
        //TestFilter testf = new TestFilter(context);
        ////testf.ChooseBySubCategories(attr, subcat);
        //testf.ChooseByCuisine(cafes, cuis);
        //testf.ChooseByFoodRestrictions(cafes, fr);

        //using (ApplicationContext db = new ApplicationContext())
        //{
        //    //var fr = db.FoodRestrictions.ToList();
        //    //var cat = db.Categories.ToList();
        //    var mod = db.Users.ToList();
        //    var R = db.Requests.ToList();
        //    //var pref = db.Preferences.ToList();

        //    //var ind = db.Individuals.ToList();
        //    //var routes = db.Routes.ToList();

        //    //var users = db.Users.ToList();
        //    //var req=db.Requests.ToList();

        //    //var comp=db.Companies.ToList();
        //    //var attendance = db.Attendances.ToList();

        //    //var notes=db.Notes.ToList();
        //    //var us = db.Users.ToList();
        //    var attractions = db.Attractions.ToList();
        //    //var cafe = attractions.Where(a => a.ID > 44000).ToList();


        //    //Console.WriteLine("second end");

        //}

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        //builder.Services.AddControllers();
        //// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        //builder.Services.AddEndpointsApiExplorer();
        //builder.Services.AddSwaggerGen();
        ConfigureServices(builder);
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}