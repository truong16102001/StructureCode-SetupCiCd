using DemoCICD.Contract.Abstractions.Message;
using DemoCICD.Contract.Services.V2.Product;

namespace DemoCICD.Application.Usercases.V2.Events;
public class SendSMSWhenWriteProductEventHandler : IDomainEventHandler<DomainEvent.ProductCreated>, IDomainEventHandler<DomainEvent.ProductDeleted>, IDomainEventHandler<DomainEvent.ProductUpdated>
{
    public async Task Handle(DomainEvent.ProductCreated notification, CancellationToken cancellationToken)
    {
        await SendSMS();
    }

    public async Task Handle(DomainEvent.ProductDeleted notification, CancellationToken cancellationToken)
    {
        await SendSMS();
    }

    public async Task Handle(DomainEvent.ProductUpdated notification, CancellationToken cancellationToken)
    {
        await SendSMS();
    }

    private async Task SendSMS()
    {
        await Task.Delay(10000);
    }
}
