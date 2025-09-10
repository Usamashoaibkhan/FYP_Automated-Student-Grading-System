namespace Test2.Data.Interface
{
	public interface IGenericRepository<T> where T : class
	{
		List<T> GetList(string query);

	}
}
