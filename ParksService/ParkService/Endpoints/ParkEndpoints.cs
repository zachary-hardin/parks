using ParksService.Repository;

namespace ParksService.Endpoints;

public static class ParkEndpoints
{
    public static void UseParkEndpoints(this WebApplication app)
    {
        app.MapGet("/parks", async (IParkRepository parkRepository) =>
        {
            var parks = await parkRepository.GetAllAsync();
            return Results.Ok(parks);
        });
    }
}