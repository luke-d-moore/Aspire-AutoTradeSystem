var builder = DistributedApplication.CreateBuilder(args);

var pricingSystem = builder.AddProject<Projects.PricingSystem>("PricingSystem");

builder.AddProject<Projects.AutoTradeSystem>("AutoTradeSystem")
                             .WithReference(pricingSystem);

builder.AddProject<Projects.TradeActionSystem>("TradeActionSystem")
                               .WithReference(pricingSystem);

builder.Build().Run();
