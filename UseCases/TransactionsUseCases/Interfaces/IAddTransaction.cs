using CoreBusiness;

namespace UseCases.TransactionsUseCases
{
    public interface IAddTransaction
    {
        void Execute(Transaction transaction);
    }
}