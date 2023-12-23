namespace MicroservicesExp.Ai.Api.Services;

public interface IChatGptService
{
    Task<string> GetCompletion(string query);
    Task<string> GetCompletionForRecipe(string meal);
}