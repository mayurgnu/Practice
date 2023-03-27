Rahul Nath : https://www.youtube.com/watch?v=5eifH7LEnGo&list=PL59L9XrzUa-nqfCHIKazYMFRKapPNI4sP
===============================================================================================
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
====================================================================================
private IConfiguration _config;
public Startup(IConfiguration config)
{
    _config = config;
}
see more on : https://www.youtube.com/watch?v=m_BevGi7zBw&list=PL6n9fhu94yhVkdrusLaQsfERmL_Jh4XmU&index=9
=============================================================================================================================
//AddSingleton() creates a single instance of the service when it is first requested
//and reuses that same instance in all the places where that service is needed.

//AddScoped() - This method creates a Scoped service.A new instance of a Scoped
//service is created once per request within the scope.
//it creates 1 instance per each http request but uses the same instance in the other calls within that same web request.

//AddTransient() - This method creates a Transient service.A new instance of a Transient service is created each time it is requested.
==============================================================================================
Claims Based Access Control (CBAC)
==============================================================================================
what is a Claim ?
--Claim is a name-value pair. 
--It's really a piece of information about the user, 
--It's not what the user can and cannot do.
--For example username, email, age, gender etc are all claims.

Creating Claims Policy
1).ConfigureServices() method of the Startup class.
services.AddAuthorization(options =>
{
    options.AddPolicy("DeleteRolePolicy", 
        policy => policy.RequireClaim("Delete Role"));
});

2).Using Claims Policy for Authorization Checks.
[HttpPost]
[Authorize(Policy = "DeleteRolePolicy")]
public async Task<IActionResult> DeleteRole(string id)
{
    // Delete Role
}

3).Adding Multiple Claims to Policy.
services.AddAuthorization(options =>
{
    options.AddPolicy("DeleteRolePolicy", 
        policy => policy.RequireClaim("Delete Role")
                        .RequireClaim("Create Role")
                    
        );
});
==============================================================================================
Role Based Access Control (RBAC)
==============================================================================================
EX : Employee, Manager, HR
1).Create a policy
public void ConfigureServices(IServiceCollection services)
{
    services.AddAuthorization(options =>
    {
        options.AddPolicy("AdminRolePolicy", policy => policy.RequireRole("Admin"));
    });
}
2).Add  one or more roles.
options.AddPolicy("SuperAdminPolicy", policy =>
                  policy.RequireRole("Admin", "User", "Manager"));

3).The policy can then be used on a controller or a controller action.
[HttpPost]
[Authorize(Policy = "SuperAdminPolicy")]
public async Task<IActionResult> DeleteRole(string id)
{
    // Delete Role
}
