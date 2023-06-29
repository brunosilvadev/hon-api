namespace Hon.Endpoints;

public interface IEndpoint
{
    void RegisterRoutes(IEndpointRouteBuilder app);
}