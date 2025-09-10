using Dapper;
using System.Data;
using Test2.Data.Interface;
namespace Test2.Data.Repository
{
	public class IRepository
	{
		private readonly IDbConnection _dbConnection;
		public IRepository(IDbConnection dbConnection)
		{
			_dbConnection = dbConnection;
		}
		public List<T> GetList<T>(string query) where T : class
		{
			return _dbConnection.Query<T>(query).ToList();
		}
		public T GetModelData<T>(string query) where T : class
		{
			return _dbConnection.QueryFirstOrDefault<T>(query);
		}

	}
}
