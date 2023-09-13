using Azure.Identity;
using Azure.Storage.Blobs;
using DocxStorageApi.BLL;
using DocxStorageApi.DAL;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;

namespace DocxStorageApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const string origins = "origins";

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: origins,
                    policy =>
                    {
                        policy.WithOrigins(builder.Configuration["FrontServerUrl"]).AllowAnyHeader().AllowAnyMethod();
                    });
            });

            builder.Services.AddAzureClients(clientBuilder =>
                clientBuilder.AddBlobServiceClient(builder.Configuration["BlobStorageConnectionString"]));

            builder.Services.AddTransient<IDocxRepository, DocxRepository>(s =>
                new DocxRepository(s.GetRequiredService<BlobServiceClient>(), s.GetRequiredService<IConfiguration>()));
  
            builder.Services.AddTransient(s =>
                new DocxService(s.GetRequiredService<IDocxRepository>()));

            builder.Services.AddControllers();

            var app = builder.Build();


            app.UseHttpsRedirection();

            app.UseCors(origins);

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}