using Polly;
using Polly.Extensions.Http;
using Polly.Timeout;

namespace MicroservicesExp.Gateway.ApiClients;

public static class ApiClientBuilderExtensions
{
    public static IHttpClientBuilder AddRetryPolicy(this IHttpClientBuilder httpClientBuilder, int retryCount = 2)
    {
        httpClientBuilder.AddPolicyHandler(GetRetryPolicy(retryCount));
        return httpClientBuilder;
    }

    public static IHttpClientBuilder AddCircuitBreakerPolicy(this IHttpClientBuilder httpClientBuilder, int handledEventsAllowedBeforeBreaking = 3,
        int durationOfBreakInSeconds = 5)
    {
        httpClientBuilder.AddTransientHttpErrorPolicy(policyBuilder => policyBuilder.CircuitBreakerAsync(
            handledEventsAllowedBeforeBreaking: handledEventsAllowedBeforeBreaking,
            durationOfBreak: TimeSpan.FromSeconds(durationOfBreakInSeconds)
        ));

        return httpClientBuilder;
    }

    public static IHttpClientBuilder AddTimeoutPolicy(this IHttpClientBuilder httpClientBuilder, int seconds = 5)
    {
        var timeoutPolicy = Policy.TimeoutAsync<HttpResponseMessage>(seconds, TimeoutStrategy.Pessimistic);

        httpClientBuilder.AddPolicyHandler(timeoutPolicy);
        return httpClientBuilder;
    }

    private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy(int retryCount)
    {
        // Retrying on HTTP timeouts (where the caller does not respond) differs slightly from other HTTP errors
        // (where the caller returns 404 Not Found or 500 errors). This is because the HttpClient does not receive
        // an response code, but throws a TimeoutRejectedException when the call time outs.
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .Or<TimeoutRejectedException>()
            .WaitAndRetryAsync(retryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2,
                retryAttempt)));
    }
}