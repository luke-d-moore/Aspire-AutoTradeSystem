var builder = DistributedApplication.CreateBuilder(args);

var pricingSystem = builder.AddProject<Projects.PricingSystem>("PricingSystem")
                             .WithHttpHealthCheck("/api/price/GetAllPrices");

builder.AddProject<Projects.AutoTradeSystem>("AutoTradeSystem")
                             .WithReference(pricingSystem)
                             .WaitFor(pricingSystem);

builder.AddProject<Projects.TradeActionSystem>("TradeActionSystem")
                               .WithReference(pricingSystem)
                               .WaitFor(pricingSystem);

builder.Build().Run();
