using System.Net.Mime;
using backend.payments.Domain.Model.Queries;
using backend.payments.Domain.Services;
using backend.payments.Interface.REST.Resource;
using backend.payments.Interface.REST.Transform;
using backend.tracking;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace backend.payments.Interface.REST;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class PaymentsController(
        IPaymentsCommandService paymentsCommandService,
        IPaymentsQueryService paymentsQueryService
    ) : ControllerBase
{
    [HttpGet]
    [SwaggerOperation(
        Summary = "Gets all payments",
        Description = "Gets all payments",
        OperationId = "GetAllPayments")]
    [SwaggerResponse(200, "Bus Routes were found", typeof(IEnumerable<PaymentsResource>))]
    public async Task<IActionResult> GetAllPayments()
    {
        var getAllPayments = new GetAllPaymentsQuery();
        var payments = await paymentsQueryService.Handle(getAllPayments);
        var resources = payments.Select(PaymentsResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpPost]
    [SwaggerOperation(
        Summary = "Post payment",
        Description = "Post a payment",
        OperationId = "PostPayment")]
    public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentsResource createPaymentResource)
    {
        var createPaymentCommand = CreatePaymentCommandFromResourceAssembler.ToCommandFromResource(createPaymentResource);
        var payment = await paymentsCommandService.Handle(createPaymentCommand);
        if (payment is null) return BadRequest();
        var paymentResource = PaymentsResourceFromEntityAssembler.ToResourceFromEntity(payment);
        return Ok(paymentResource);
    }
}