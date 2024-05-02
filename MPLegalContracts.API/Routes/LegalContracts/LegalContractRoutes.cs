using Microsoft.AspNetCore.Mvc;
using MPLegalContracts.Services.LegalContracts;

namespace MPLegalContracts.API.Routes.LegalContracts
{
    public static class LegalContractRoutes
    {
        public static void MapLegalContractRoutes(this WebApplication app)
        {
            app.MapGet("/legal-contracts", async (HttpContext httpContext, ILegalContractServices legalContractsServices) =>
            {
                return await GetLegalContracts.ExecuteAsync(legalContractsServices);
            })
            .WithName("GetLegalContracts")
            .WithOpenApi();

            app.MapGet("/legal-contracts/{id}", async (HttpContext httpContext, ILegalContractServices legalContractsServices, 
                int id) =>
            {
                return await GetLegalContract.ExecuteAsync(legalContractsServices, id);
            })
            .WithName("GetLegalContract")
            .WithOpenApi();

            app.MapPost("/legal-contracts", async (HttpContext httpContext, ILegalContractServices legalContractsServices, 
                [FromBody] CreateLegalContractDto model) =>
            {
                return await CreateLegalContract.ExecuteAsync(legalContractsServices, model);
            })
            .WithName("CreateLegalContract")
            .WithOpenApi();

            app.MapPut("/legal-contracts", async (HttpContext httpContext, ILegalContractServices legalContractsServices,
                [FromBody] UpdateLegalContractDto model) =>
            {
                return await UpdateLegalContract.ExecuteAsync(legalContractsServices, model);
            })
            .WithName("UpdateLegalContract")
            .WithOpenApi();

            app.MapDelete("/legal-contracts/{id}", async (HttpContext httpContext, ILegalContractServices legalContractsServices, 
                int id) =>
            {
                var deleteSucceeded = await DeleteLegalContract.ExecuteAsync(legalContractsServices, id);

                httpContext.Response.StatusCode = deleteSucceeded
                    ? StatusCodes.Status200OK
                    : StatusCodes.Status500InternalServerError;

                return;
            })
            .WithName("DeleteLegalContract")
            .WithOpenApi();
        }
    }
}
