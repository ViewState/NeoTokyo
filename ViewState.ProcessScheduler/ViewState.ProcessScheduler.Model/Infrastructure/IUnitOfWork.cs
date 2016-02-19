namespace ViewState.ProcessScheduler.Model.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
