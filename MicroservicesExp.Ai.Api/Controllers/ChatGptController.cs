using MicroservicesExp.Ai.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace MicroservicesExp.Ai.Api.Controllers;

[Route("api/[controller]")]
public class ChatGptController : Controller
{
    private readonly IChatGptService _chatGptService;

    public ChatGptController(IChatGptService chatGptService)
    {
        _chatGptService = chatGptService;
    }
    
    [HttpGet("{question}")]
    public async Task<IActionResult> Get(string question)
    {
        var result = await _chatGptService.GetCompletion(question);
        return Ok(result);
    }
    
    [HttpGet("recipe/{meal}")]
    public async Task<IActionResult> GetRecipe(string meal)
    {
        var result = await _chatGptService.GetCompletionForRecipe(meal);
        
        return Ok(result);
    }
}