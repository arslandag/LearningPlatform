using LearningPlatform.Api.Contracts.Users;
using LearningPlatform.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LearningPlatform.Api.EndPoints
{
    public static class UsersEndpoints
    {
        public static IEndpointRouteBuilder MapUsersEndpoints (this IEndpointRouteBuilder app)
        {
            app.MapPost("register", Register);

            app.MapPost("login", Login);

            return app;
        }

        private static async Task<IResult> Register(
            [FromBody] RegisterUserRequest reguest,
            UserService userService)
        {
            await userService.Register(reguest.UserName, reguest.Email, reguest.Password);

            return Results.Ok();
        }

        private static async Task<IResult> Login(
            [FromBody] LoginUserRequest request,
            UserService userService,
            HttpContext context)
        {
            var token = await userService.Login(request.Email, request.Password);

            context.Response.Cookies.Append("testy-cookies", token);

            return Results.Ok();
        }
    }
}
