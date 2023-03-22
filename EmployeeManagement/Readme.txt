1).Create New Project 
2).Select Asp.NetCore Empty Template.
3).Uncheck Http Configure check box
4).Create Project.

Asp.net core web app entry point
public static void Main(string[] args)
{
    CreateHostBuilder(args).Build().Run();
}

1).From Main() CreateHostBuilder(args) gets called

public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });

2).CreateHostBuilder returns an Object that Implements IHostBuilder.
3).On that object returned by CreateHostBuilder we are ccalling Build() Method.
    Which build the web host that hosts Our web application.
4).On that web host we are calling Run() method which runs our application 
    and start listening incoming http requests.
