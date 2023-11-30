namespace TransactionDemo.Host.UnitOfWork
{
	public class UnitOfWorkManager
	{

		private readonly IUnitOfWork _unitOfWork;

		public UnitOfWorkManager(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}


	}
}
