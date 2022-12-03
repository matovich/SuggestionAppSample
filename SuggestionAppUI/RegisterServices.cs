namespace SuggestionAppUI
{
    public static class RegisterServices
    {
        /// <summary>
        /// Dependency Injection.
        /// </summary>
        /// <param name="builder"></param>
        public static void ConfigureServices(this WebApplicationBuilder builder)
        {
            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            builder.Services.AddMemoryCache();

        }
    }
}
