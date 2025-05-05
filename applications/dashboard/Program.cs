using NATS.Client.Core;
using NATS.Net;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<string> messages = new List<string>();
await using NatsClient nc = new NatsClient("nats://localhost:4222");
string subject = "mock.events";

using CancellationTokenSource cts = new CancellationTokenSource();

Task subscription = Task.Run(async () =>
{
  await foreach (NatsMsg<string> msg in nc.SubscribeAsync<string>(subject: subject, cancellationToken: cts.Token))
  {
    if (msg.Data == null)
    {
      continue;
    }

    messages.Add(msg.Data);
  }
});

app.MapGet("/messges", () => messages);

app.Run();
