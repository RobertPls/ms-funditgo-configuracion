namespace Shared.Core
{
    public interface IUnitOfWork
    {
        Task CommitAsync(CancellationToken cancellationToken = default);

        void AddDomainEvent(DomainEvent domainEvent);
    }
}
