

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;

public class RateLimitingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IMemoryCache _cache;

    public RateLimitingMiddleware(RequestDelegate next, IMemoryCache cache)
    {
        _next = next;
        _cache = cache;
    }

    public async Task Invoke(HttpContext context)
    {
        var ipAddress = context.Connection.RemoteIpAddress;

        var cacheKey = $"{ipAddress}:requestCount";
        var requestCount = _cache.TryGetValue(cacheKey, out int count) ? count : 0;

        if (requestCount >= 20) 
        {
            context.Response.StatusCode = 429; 
            await context.Response.WriteAsync("Rate limit exceeded.");
            return;
        }

       
        _cache.Set(cacheKey, requestCount + 1, TimeSpan.FromMinutes(1));

        
        await _next(context);
    }
}
