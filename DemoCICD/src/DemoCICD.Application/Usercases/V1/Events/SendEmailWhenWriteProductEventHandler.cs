using DemoCICD.Contract.Abstractions.Message;
using DemoCICD.Contract.Services.Product;

namespace DemoCICD.Application.Usercases.V1.Events;
public class SendEmailWhenWriteProductEventHandler : IDomainEventHandler<DomainEvent.ProductCreated>
{
    public async Task Handle(DomainEvent.ProductCreated notification, CancellationToken cancellationToken)
    {
        // Implement send email
        await Task.Delay(5000);
    }
}
