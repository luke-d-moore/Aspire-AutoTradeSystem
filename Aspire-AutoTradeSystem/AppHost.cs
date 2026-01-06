var builder = DistributedApplication.CreateBuilder(args);

var pricingSystem = builder.AddProject<Projects.PricingSystem>("PricingSystem")
    .WithHttpEndpoint(name: "health-ep")
    .WithHttpHealthCheck(path: "/api/price/GetAllPrices", endpointName: "health-ep");

builder.AddProject<Projects.AutoTradeSystem>("AutoTradeSystem")
                             .WithReference(pricingSystem)
                             .WaitFor(pricingSystem);

builder.AddProject<Projects.TradeActionSystem>("TradeActionSystem")
                               .WithReference(pricingSystem)
                               .WaitFor(pricingSystem);

builder.Build().Run();
