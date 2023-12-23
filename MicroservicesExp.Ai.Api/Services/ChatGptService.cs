using OpenAI.API;
using OpenAI.API.Completions;
using OpenAI.API.Models;

namespace MicroservicesExp.Ai.Api.Services;

public class ChatGptService : IChatGptService
{
    private readonly OpenAIAPI _openai = new("<--- api-key goes here --->");

    public async Task<string> GetCompletion(string query)
    {
        var completionRequest = new CompletionRequest
        {
            Prompt = query,
            Model = Model.DavinciText,
            MaxTokens = 1024
        };

        var completions = await _openai.Completions.CreateCompletionAsync(completionRequest);
        return completions.Completions.Aggregate("", (current, completion) => current + completion.Text);
    }
    
    public async Task<string> GetCompletionForRecipe(string meal)
    {
        var query =
            $$"""
              {{meal}} yemeği için tarif hazırla. Uyuşturu ve bağımlılık yapıcı maddeleri tarifin içinde kullanma.
              Herhangi bir açıklama ekleme, yalnızca bu formata uygun RFC8259 uyumlu bir JSON yanıtı sağlayın.
              {
                "yemek_ismi": "",
                "malzemeler": [
                  {
                    "adi": "",
                    "birim": "",
                    "miktar": ""
                  }
                ],
                "tarif": []
              }
              """;
        var completionRequest = new CompletionRequest
        {
            Prompt = query,
            Model = Model.DavinciText,
            MaxTokens = 1024
        };

        var completions = await _openai.Completions.CreateCompletionAsync(completionRequest);
        return completions.Completions.Aggregate("", (current, completion) => current + completion.Text);
    }
}
