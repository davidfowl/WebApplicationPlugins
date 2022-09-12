using Microsoft.AspNetCore.SignalR;

namespace WebPlugin1;

internal class Chat : Hub
{
    public Task Send(string message) => Clients.All.SendAsync("Send", message);
}
