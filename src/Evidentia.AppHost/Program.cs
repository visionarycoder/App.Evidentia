var builder = DistributedApplication.CreateBuilder(args);
builder.AddProject<CustomerApi>("customer-api");
builder.AddProject<Projects.Evidentia_EmployeeApi>("employee-api");
builder.AddProject<Projects.Evidentia_Api>("shared-api"); // Optional

builder.AddProject<Projects.Evidentia_CaseService>("case-service");

builder.AddOrleans("orleans")
  .WithMemoryGrainStorage();

builder.AddOpenTelemetry();
builder.Build().Run();
