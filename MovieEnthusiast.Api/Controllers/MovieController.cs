using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MovieEnthusiast.Api.Controllers;

public class MovieController : ApiControllerBase
{
    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.BadGateway)]
    public async Task<OkResult> Get()
    {
        await Task.Run(() => {
            Console.WriteLine("ko ce lauki;)");
        });

        return Ok();
    }
}