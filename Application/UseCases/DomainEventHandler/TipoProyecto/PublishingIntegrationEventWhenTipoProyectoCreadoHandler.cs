using Domain.Events.Proyecto;
using Domain.Events.TipoProyecto;
using MassTransit;
using MediatR;
using Shared.Core;

namespace Application.UseCases.DomainEventHandler.TipoProyecto
{

    public class PublishingIntegrationEventWhenTipoProyectoCreadoHandler : INotificationHandler<ConfirmedDomainEvent<TipoProyectoCreado>>
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public PublishingIntegrationEventWhenTipoProyectoCreadoHandler(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task Handle(ConfirmedDomainEvent<TipoProyectoCreado> notification, CancellationToken cancellationToken)
        {
            Shared.IntegrationEvents.TipoProyectoCreado evento = new Shared.IntegrationEvents.TipoProyectoCreado()
            {
                TipoProyectoId = notification.DomainEvent.TipoProyectoId,
                Nombre = notification.DomainEvent.Nombre
            };
            await _publishEndpoint.Publish<Shared.IntegrationEvents.DonacionCreada>(evento);

        }
    }
}
