namespace DevStore.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        void Begin();
        void Commit();
    }
}
