﻿namespace API_RadiadoresDiaz
{
    public class LambdaFunction: Amazon.Lambda.AspNetCoreServer.APIGatewayProxyFunction
    {
        protected override void Init(IWebHostBuilder builder)
        {
            builder
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<IStartup>()
                .UseLambdaServer();
        }
    }
}
