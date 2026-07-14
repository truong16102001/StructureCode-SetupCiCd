using Asp.Versioning;
using DemoCICD.Contract.Shared;
using DemoCICD.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoCICD.Presentation.Controllers.V2;

[ApiVersion(2)]
public class OrdersController : ApiController
{
    public OrdersController(ISender sender) : base(sender)
    {
    }

    [HttpGet(Name = "GetOrders")]
    public async Task<IActionResult> Products()
    {
        return Ok("oke");
    }
}
