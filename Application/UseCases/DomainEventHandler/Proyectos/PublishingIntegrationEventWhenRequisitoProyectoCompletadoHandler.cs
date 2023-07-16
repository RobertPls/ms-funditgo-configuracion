using Domain.Events.Proyecto;
using MassTransit;
using MediatR;
using Shared.Core;

namespace Application.UseCases.DomainEventHandler
{
    public class PublishingIntegrationEventWhenRequisitoProyectoCompletadoHandler : INotificationHandler<ConfirmedDomainEvent<RequisitoProyectoCompletado>>
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public PublishingIntegrationEventWhenRequisitoProyectoCompletadoHandler(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task Handle(ConfirmedDomainEvent<RequisitoProyectoCompletado> notification, CancellationToken cancellationToken)
        {
            Shared.IntegrationEvents.RequisitoProyectoCompletado evento = new Shared.IntegrationEvents.RequisitoProyectoCompletado()
            {
                ProyectoId = notification.DomainEvent.ProyectoId,
            };
            await _publishEndpoint.Publish<Shared.IntegrationEvents.DonacionCreada>(evento);

        }
    }
}
