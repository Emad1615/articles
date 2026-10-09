namespace Submission.API.Endpoints
{
    public static class EndpointsRegisteration
    {
        public static IEndpointRouteBuilder MapAllEndpoints(this IEndpointRouteBuilder app)
        {
            CreateArticlesEndpoit.Map(app);
            return app;
        }
    }
}
