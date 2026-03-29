using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

var builder = WebApplication.CreateBuilder(args);

var kvUri = "https://labudemy.vault.azure.net/";
var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());
var secret = await client.GetSecretAsync("App--DbConnection");

builder.Configuration["DbConnection"] = secret.Value.Value;

var app = builder.Build();
app.MapGet("/segredo", () => builder.Configuration["DbConnection"]);
app.Run();