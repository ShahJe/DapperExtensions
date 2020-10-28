using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ShahJe.Sql.Dapper.Extensions
{
	public class AsyncRepository : IAsyncRepository
	{
		private string ConnectionString { get; }

        public AsyncRepository(string sqlConnectionString)
        {
			ConnectionString = sqlConnectionString;
        }

		public async Task<SqlConnection> ConnectionAsync(bool mars = false)
		{
			var connection = new SqlConnection(ConnectionString);
			await connection.OpenAsync();
			return connection;
		}

		public async Task<IEnumerable<TEntity>> GetManyAsync<TEntity>(string sql, CommandType commandType = CommandType.StoredProcedure) where TEntity : class
		{
			using (var conn = await ConnectionAsync())
			{
				return (await conn.QueryAsync<TEntity>(sql, commandType: commandType)).ToList();
			}
		}

		public async Task<IEnumerable<TEntity>> GetManyAsync<TEntity>(string sql, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure) where TEntity : class
		{
			using (var conn = await ConnectionAsync())
			{
				return (await conn.QueryAsync<TEntity>(sql, param: param, commandType: commandType)).ToList();
			}
		}

		public async Task<IEnumerable<TEntity>> GetManyAsync<TEntity, TEntity2>(string sql, Func<TEntity, TEntity2, TEntity> map, string splitOn, CommandType commandType = CommandType.StoredProcedure)
			where TEntity : class
			where TEntity2 : class
		{
			using (var conn = await ConnectionAsync())
			{
				return (await conn.QueryAsync<TEntity, TEntity2, TEntity>(sql, map: map, splitOn: splitOn, commandType: commandType)).ToList();
			}
		}

		public async Task<IEnumerable<TEntity>> GetManyAsync<TEntity, TEntity2>(string sql, DynamicParameters param, Func<TEntity, TEntity2, TEntity> map, string splitOn, CommandType commandType = CommandType.StoredProcedure)
			where TEntity : class
			where TEntity2 : class
		{
			using (var conn = await ConnectionAsync())
			{
				return (await conn.QueryAsync<TEntity, TEntity2, TEntity>(sql, param: param, map: map, splitOn: splitOn, commandType: commandType)).ToList();
			}
		}

		public async Task<IEnumerable<TEntity>> GetManyAsync<TEntity, TEntity2, TEntity3>(string sql, Func<TEntity, TEntity2, TEntity3, TEntity> map, string splitOn, CommandType commandType = CommandType.StoredProcedure)
			where TEntity : class
			where TEntity2 : class
			where TEntity3 : class
		{
			using (var conn = await ConnectionAsync())
			{
				return (await conn.QueryAsync<TEntity, TEntity2, TEntity3, TEntity>(sql, map: map, splitOn: splitOn, commandType: commandType)).ToList();
			}
		}

		public async Task<IEnumerable<TEntity>> GetManyAsync<TEntity, TEntity2, TEntity3>(string sql, DynamicParameters param, Func<TEntity, TEntity2, TEntity3, TEntity> map, string splitOn, CommandType commandType = CommandType.StoredProcedure)
			where TEntity : class
			where TEntity2 : class
			where TEntity3 : class
		{
			using (var conn = await ConnectionAsync())
			{
				return (await conn.QueryAsync<TEntity, TEntity2, TEntity3, TEntity>(sql, param: param, map: map, splitOn: splitOn, commandType: commandType)).ToList();
			}
		}

		public async Task<TEntity> GetOneAsync<TEntity>(string sql, CommandType commandType = CommandType.StoredProcedure) where TEntity : class
		{
			using (var conn = await ConnectionAsync())
			{
				return (await conn.QueryAsync<TEntity>(sql, commandType: commandType)).FirstOrDefault();
			}
		}

		public async Task<TEntity> GetOneAsync<TEntity>(string sql, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure) where TEntity : class
		{
			using (var conn = await ConnectionAsync())
			{
				return (await conn.QueryAsync<TEntity>(sql, param: param, commandType: commandType)).FirstOrDefault();
			}
		}

		public async Task<TEntity> GetOneAsync<TEntity, TEntity2>(string sql, Func<TEntity, TEntity2, TEntity> map, string splitOn, CommandType commandType = CommandType.StoredProcedure)
			where TEntity : class
			where TEntity2 : class
		{
			using (var conn = await ConnectionAsync())
			{
				return (await conn.QueryAsync<TEntity, TEntity2, TEntity>(sql, map: map, splitOn: splitOn, commandType: commandType)).FirstOrDefault();
			}
		}

		public async Task<TEntity> GetOneAsync<TEntity, TEntity2>(string sql, DynamicParameters param, Func<TEntity, TEntity2, TEntity> map, string splitOn, CommandType commandType = CommandType.StoredProcedure)
			where TEntity : class
			where TEntity2 : class
		{
			using (var conn = await ConnectionAsync())
			{
				return (await conn.QueryAsync<TEntity, TEntity2, TEntity>(sql, param: param, map: map, splitOn: splitOn, commandType: commandType)).FirstOrDefault();
			}
		}

		public async Task<TEntity> GetOneAsync<TEntity, TEntity2, TEntity3>(string sql, Func<TEntity, TEntity2, TEntity3, TEntity> map, string splitOn, CommandType commandType = CommandType.StoredProcedure)
			where TEntity : class
			where TEntity2 : class
			where TEntity3 : class
		{
			using (var conn = await ConnectionAsync())
			{
				return (await conn.QueryAsync<TEntity, TEntity2, TEntity3, TEntity>(sql, map: map, splitOn: splitOn, commandType: commandType)).FirstOrDefault();
			}
		}

		public async Task<TEntity> GetOneAsync<TEntity, TEntity2, TEntity3>(string sql, DynamicParameters param, Func<TEntity, TEntity2, TEntity3, TEntity> map, string splitOn, CommandType commandType = CommandType.StoredProcedure)
			where TEntity : class
			where TEntity2 : class
			where TEntity3 : class
		{
			using (var conn = await ConnectionAsync())
			{
				return (await conn.QueryAsync<TEntity, TEntity2, TEntity3, TEntity>(sql, param: param, map: map, splitOn: splitOn, commandType: commandType)).FirstOrDefault();
			}
		}

		public async Task<TEntity> GetOneAsync<TEntity, TEntity2, TEntity3, TEntity4>(string sql, DynamicParameters param, Func<TEntity, TEntity2, TEntity3, TEntity4, TEntity> map, string splitOn, CommandType commandType = CommandType.StoredProcedure)
			where TEntity : class
			where TEntity2 : class
			where TEntity3 : class
			where TEntity4 : class
		{
			using (var conn = await ConnectionAsync())
			{
				return (await conn.QueryAsync<TEntity, TEntity2, TEntity3, TEntity4, TEntity>(sql, param: param, map: map, splitOn: splitOn, commandType: commandType)).FirstOrDefault();
			}
		}

		public async Task<int> GetScalarAsync(string sql, CommandType commandType = CommandType.StoredProcedure)
		{
			using (var conn = await ConnectionAsync())
			{
				return (await conn.QueryAsync<int>(sql, commandType: commandType)).SingleOrDefault();
			}
		}

		public async Task<int> GetScalarAsync(string sql, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure)
		{
			using (var conn = await ConnectionAsync())
			{
				return (await conn.QueryAsync<int>(sql, param: param, commandType: commandType)).SingleOrDefault();
			}
		}

		public async Task<bool> GetScalarBoolAsync(string sql, CommandType commandType = CommandType.StoredProcedure)
		{
			using (var conn = await ConnectionAsync())
			{
				return (await conn.QueryAsync<bool>(sql, commandType: commandType)).SingleOrDefault();
			}
		}

		public async Task<bool> GetScalarBoolAsync(string sql, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure)
		{
			using (var conn = await ConnectionAsync())
			{
				return (await conn.QueryAsync<bool>(sql, param: param, commandType: commandType)).SingleOrDefault();
			}
		}

		public async Task<DateTime?> GetScalarDateAsync(string sql, CommandType commandType = CommandType.StoredProcedure)
		{
			using (var conn = await ConnectionAsync())
			{
				return (await conn.QueryAsync<DateTime?>(sql, commandType: commandType)).SingleOrDefault();
			}
		}

		public async Task<DateTime?> GetScalarDateAsync(string sql, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure)
		{
			using (var conn = await ConnectionAsync())
			{
				return (await conn.QueryAsync<DateTime?>(sql, param: param, commandType: commandType)).SingleOrDefault();
			}
		}

		public async Task NonQueryAsync(string sql, CommandType commandType = CommandType.StoredProcedure)
		{
			using (var conn = await ConnectionAsync())
			{
				await conn.ExecuteAsync(sql, commandType: commandType);
			}
		}

		public async Task NonQueryAsync(string sql, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure)
		{
			using (var conn = await ConnectionAsync())
			{
				await conn.ExecuteAsync(sql, param: param, commandType: commandType);
			}
		}

		public async Task NonQueryAsync(string sql, List<DynamicParameters> param, CommandType commandType = CommandType.StoredProcedure)
		{
			using (var conn = await ConnectionAsync())
			{
				await conn.ExecuteAsync(sql, param: param.ToArray(), commandType: commandType);
			}
		}
	}
}