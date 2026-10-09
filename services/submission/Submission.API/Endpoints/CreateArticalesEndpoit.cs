using Submission.Application.Features.Articles.Commands;
using MediatR;

namespace Submission.API.Endpoints
{
    public static class CreateArticlesEndpoit
    {
        public static void Map(this IEndpointRouteBuilder app)
        {
            app.MapPost("/api/articles", async (CreateArticle.Command command, ISender sender, CancellationToken ct) =>
            {
                var result = await sender.Send(command, ct);
                return Results.Created($"/api/articles/{result.Id}", result);

            }).RequireAuthorization(policy => policy.RequireRole("AUTH"))
            .WithName("CreateArticle")
            .WithTags("Articles")
            .Produces(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status401Unauthorized)
            .ProducesValidationProblem(StatusCodes.Status400BadRequest);
        }
    }
}
