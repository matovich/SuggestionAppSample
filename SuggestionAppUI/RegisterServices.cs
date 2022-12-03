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

            builder.Services.AddSingleton<IDbConnection, DbConnection>();
            builder.Services.AddSingleton<ICategoryData, MongoCategoryData>();
            builder.Services.AddSingleton<IStatusData, MongoStatusData>();
            builder.Services.AddSingleton<ISuggestioniData, MongoSuggestioniData>();
            builder.Services.AddSingleton<IUserData, MongoUserData>();


        }
    }
}
