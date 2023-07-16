using Infrastructure.EntityFramework.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Core;

namespace Infrastructure.EntityFramework;

internal class UnitOfWork : IUnitOfWork
{
    private readonly WriteDbContext _context;
    private readonly IMediator _mediator;

    private readonly List<DomainEvent> _domainEvents;

    public UnitOfWork(WriteDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;

        _domainEvents = new List<DomainEvent>();
    }

    public void AddDomainEvent(DomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }


    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        var domainEvents = _context.ChangeTracker.Entries<Entity<Guid>>()
                .Select(x => x.Entity.DomainEvents)
                .SelectMany(x => x)
                .Where(x => !x.Consumed)
                .ToArray();

        foreach (var domainEvent in domainEvents)
        {
            domainEvent.MarkAsConsumed();
            await _mediator.Publish(domainEvent);
        }
        await _context.SaveChangesAsync();

        foreach (var @event in domainEvents)
        {
            Type type = typeof(ConfirmedDomainEvent<>).MakeGenericType(@event.GetType());

            var confirmedEvent = (INotification)Activator.CreateInstance(type, @event);

            await _mediator.Publish(confirmedEvent);
        }

    }

}