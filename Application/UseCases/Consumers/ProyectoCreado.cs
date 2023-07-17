using Application.UseCases.Command.Proyectos.CrearProyecto;
using MassTransit;
using MediatR;
using Shared.IntegrationEvents;

namespace Application.UseCases.Consumers
{
    public class ProyectoCreadoConsumer : IConsumer<ProyectoCreado>
    {
        private readonly IMediator _mediator;
        public const string ExchangeName = "proyecto-creado-exchange";
        public const string QueueName = "proyecto-creado-proyectos";

        public ProyectoCreadoConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<ProyectoCreado> context)
        {
            ProyectoCreado @event = context.Message;
            CrearProyectoCommand command = new CrearProyectoCommand(@event.ProyectoId, @event.CreadorId, @event.TipoProyectoId, @event.Titulo, @event.Estado );
            await _mediator.Send(command);

        }
    }
}
