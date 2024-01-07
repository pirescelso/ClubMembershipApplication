using ClubMembershipApplication;
using ClubMembershipApplication.Views;

IView mainView = Factory.GetMainViewObject();
mainView.RunView();

Console.ReadKey();


// var builder = WebApplication.CreateBuilder(args);
// var app = builder.Build();

// app.MapGet("/", () => "Hello World!");

// app.Run();
