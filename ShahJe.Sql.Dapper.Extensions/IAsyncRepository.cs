using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ShahJe.Sql.Dapper.Extensions
{
	public interface IAsyncRepository
	{
		Task<SqlConnection> ConnectionAsync(bool mars = false);

		Task<TEntity> GetOneAsync<TEntity>(string sql, CommandType commandType = CommandType.StoredProcedure)
			where TEntity : class;

		Task<TEntity> GetOneAsync<TEntity>(string sql, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure)
			where TEntity : class;

		Task<TEntity> GetOneAsync<TEntity, TEntity2>(string sql, Func<TEntity, TEntity2, TEntity> map, string splitOn, CommandType commandType = CommandType.StoredProcedure)
			where TEntity : class
			where TEntity2 : class;

		Task<TEntity> GetOneAsync<TEntity, TEntity2>(string sql, DynamicParameters param, Func<TEntity, TEntity2, TEntity> map, string splitOn, CommandType commandType = CommandType.StoredProcedure)
			where TEntity : class
			where TEntity2 : class;

		Task<TEntity> GetOneAsync<TEntity, TEntity2, TEntity3>(string sql, Func<TEntity, TEntity2, TEntity3, TEntity> map, string splitOn, CommandType commandType = CommandType.StoredProcedure)
			where TEntity : class
			where TEntity2 : class
			where TEntity3 : class;

		Task<TEntity> GetOneAsync<TEntity, TEntity2, TEntity3>(string sql, DynamicParameters param, Func<TEntity, TEntity2, TEntity3, TEntity> map, string splitOn, CommandType commandType = CommandType.StoredProcedure)
			where TEntity : class
			where TEntity2 : class
			where TEntity3 : class;

		Task<TEntity> GetOneAsync<TEntity, TEntity2, TEntity3, TEntity4>(string sql, DynamicParameters param, Func<TEntity, TEntity2, TEntity3, TEntity4, TEntity> map, string splitOn, CommandType commandType = CommandType.StoredProcedure)
			where TEntity : class
			where TEntity2 : class
			where TEntity3 : class
			where TEntity4 : class;

		Task<IEnumerable<TEntity>> GetManyAsync<TEntity>(string sql, CommandType commandType = CommandType.StoredProcedure)
			where TEntity : class;

		Task<IEnumerable<TEntity>> GetManyAsync<TEntity>(string sql, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure)
			where TEntity : class;

		Task<IEnumerable<TEntity>> GetManyAsync<TEntity, TEntity2>(string sql, Func<TEntity, TEntity2, TEntity> map, string splitOn, CommandType commandType = CommandType.StoredProcedure)
			where TEntity : class
			where TEntity2 : class;

		Task<IEnumerable<TEntity>> GetManyAsync<TEntity, TEntity2>(string sql, DynamicParameters param, Func<TEntity, TEntity2, TEntity> map, string splitOn, CommandType commandType = CommandType.StoredProcedure)
			where TEntity : class
			where TEntity2 : class;

		Task<IEnumerable<TEntity>> GetManyAsync<TEntity, TEntity2, TEntity3>(string sql, Func<TEntity, TEntity2, TEntity3, TEntity> map, string splitOn, CommandType commandType = CommandType.StoredProcedure)
			where TEntity : class
			where TEntity2 : class
			where TEntity3 : class;

		Task<IEnumerable<TEntity>> GetManyAsync<TEntity, TEntity2, TEntity3>(string sql, DynamicParameters param, Func<TEntity, TEntity2, TEntity3, TEntity> map, string splitOn, CommandType commandType = CommandType.StoredProcedure)
			where TEntity : class
			where TEntity2 : class
			where TEntity3 : class;

		Task<int> GetScalarAsync(string sql, CommandType commandType = CommandType.StoredProcedure);

		Task<int> GetScalarAsync(string sql, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure);

		Task<DateTime?> GetScalarDateAsync(string sql, CommandType commandType = CommandType.StoredProcedure);

		Task<DateTime?> GetScalarDateAsync(string sql, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure);

		Task<bool> GetScalarBoolAsync(string sql, CommandType commandType = CommandType.StoredProcedure);

		Task<bool> GetScalarBoolAsync(string sql, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure);

		Task NonQueryAsync(string sql, CommandType commandType = CommandType.StoredProcedure);

		Task NonQueryAsync(string sql, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure);

		Task NonQueryAsync(string sql, List<DynamicParameters> param, CommandType commandType = CommandType.StoredProcedure);
	}
}