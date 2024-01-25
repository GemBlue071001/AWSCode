using Amazon;
using Amazon.Runtime;
using Amazon.S3;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDefaultAWSOptions(builder.Configuration.GetAWSOptions("AWS"));
builder.Services.AddScoped<IAmazonS3>(sp =>
{

    AmazonS3Config config = new AmazonS3Config
    {
        ServiceURL = "http://127.0.0.1:4566",
        UseHttp = true,
        ForcePathStyle = true,
        AuthenticationRegion = "us-east-1",
    };
    AWSCredentials creds = new AnonymousAWSCredentials();


    return new AmazonS3Client(creds, config);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
