using Infrastructure.EntityFramework.Contexts;
using MediatR;
using Shared.Core;

namespace Infrastructure.EntityFramework;

internal class UnitOfWork : IUnitOfWork
{
    private readonly WriteDbContext _dbContext;
    private readonly IMediator _mediator;

    private readonly List<DomainEvent> _domainEvents;
    private int _tansactionCounter;

    public UnitOfWork(WriteDbContext context, IMediator mediator)
    {
        _dbContext = context;
        _mediator = mediator;
        _tansactionCounter = 0;

        _domainEvents = new List<DomainEvent>();
    }

    public void AddDomainEvent(DomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }


    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        _tansactionCounter++;

        var receivedEvents = _dbContext.ChangeTracker.Entries<Entity<Guid>>()
            .Select(x => x.Entity)
            .SelectMany(entity =>
            {
                var events = entity.DomainEvents.ToList();
                entity.ClearDomainEvents();

                return events;
            });

        _domainEvents.AddRange(receivedEvents);

        var domainEvents = _domainEvents
            .Where(x => !x.Consumed)
            .OrderBy(x => x.OccuredOn)
            .ToArray();

        foreach (var evento in domainEvents)
        {
            if (evento.Consumed)
            {
                continue;
            }
            evento.MarkAsConsumed();
            await _mediator.Publish(evento, cancellationToken);
        }

        if (_tansactionCounter == 1)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        else
        {
            _tansactionCounter--;
        }

    }

}