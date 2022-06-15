namespace TaskApp1._0UI8
{
    public static class RegisterServices
    {
        public static void ConfigureService(this WebApplicationBuilder web)
        {
            // Add services to the container.
            web.Services.AddRazorPages();
            web.Services.AddServerSideBlazor();
            web.Services.AddMemoryCache();
        }


    }

}
