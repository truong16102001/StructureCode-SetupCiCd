using DemoCICD.Contract.Abstractions.Message;
using DemoCICD.Contract.Services.V2.Product;

namespace DemoCICD.Application.Usercases.V2.Events;
public class SendEmailWhenWriteProductEventHandler : IDomainEventHandler<DomainEvent.ProductCreated>, IDomainEventHandler<DomainEvent.ProductDeleted>, IDomainEventHandler<DomainEvent.ProductUpdated>
{
    public async Task Handle(DomainEvent.ProductCreated notification, CancellationToken cancellationToken)
    {
        await SendEmail();
    }

    public async Task Handle(DomainEvent.ProductDeleted notification, CancellationToken cancellationToken)
    {
        await SendEmail();
    }

    public async Task Handle(DomainEvent.ProductUpdated notification, CancellationToken cancellationToken)
    {
        await SendEmail();
    }

    private async Task SendEmail()
    {
        await Task.Delay(5000);
    }
}
