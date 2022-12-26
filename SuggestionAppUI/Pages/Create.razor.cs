using SuggestionAppUI.Models;

namespace SuggestionAppUI.Pages
{
    public partial class Create
    {
        private CreateSuggestionModel suggestion = new();
        private UserModel loggedInUser;
        private List<CategoryModel> categories;
        protected async override Task OnInitializedAsync()
        {
            categories = await categoryData.GetAllCategoriesAsync();
            loggedInUser = await authProvider.GetUserFromAuth(userData);
        }

        private void ClosePage()
        {
            navManager.NavigateTo("/");
        }

        private async Task CreateSuggestion()
        {
            SuggestionModel s = new();
            s.Suggestion = suggestion.Suggestion;
            s.Description = suggestion.Description;
            s.Author = new BasicUserModel(loggedInUser);
            s.Category = categories.Where(c => c.Id == suggestion.CategoryId).FirstOrDefault();
            if (s.Category is null)
            {
                suggestion.CategoryId = "";
                return;
            }

            await suggestionData.CreateSuggestionAsync(s);
            suggestion = new();
            ClosePage();
        }
    }
}