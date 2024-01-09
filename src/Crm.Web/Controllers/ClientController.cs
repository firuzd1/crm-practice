using Crm.BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace Crm.DataAccess;

[ApiController]
[Route("clients")]
public sealed class ClientController : ControllerBase
{
    private readonly IClientService _clientService;
    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }
    [HttpGet("count")]
    public ValueTask<int> GetClientCountAsync(CancellationToken cancellationToken = default) 
        => _clientService.GetClientCountAsync(cancellationToken);

    [HttpPost]
    public ValueTask<bool> CreateClientAsync([FromBody] ClientInfo clientInfo, CancellationToken cancellationToken = default) 
        => _clientService.CreateClientAsync(clientInfo, cancellationToken);

    [HttpGet("only")]
    public ValueTask<ClientInfo?> GetClientAsync([FromQuery] string firstName, [FromQuery] string lastName, CancellationToken cancellationToken = default) 
        => _clientService.GetClientAsync(firstName, lastName, cancellationToken);

    [HttpPatch]
    public ValueTask<bool> ChangeClientNameAsync([FromQuery] string name, [FromQuery] string lastName, [FromQuery] string newFirstName, [FromQuery] string newLastname, CancellationToken cancellationToken) 
        => _clientService.ChangeClientNameAsync(name, lastName, newFirstName, newLastname, cancellationToken);

}