using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ShahJe.Sql.Dapper.Extensions
{
	public interface IRepository
	{
		SqlConnection Connection(bool mars = false);

		TEntity GetOne<TEntity>(string sql, CommandType commandType = CommandType.StoredProcedure)
			where TEntity : class;

		TEntity GetOne<TEntity>(string sql, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure)
			where TEntity : class;

		TEntity GetOne<TEntity, TEntity2>(string sql, Func<TEntity, TEntity2, TEntity> map, string splitOn, CommandType commandType = CommandType.StoredProcedure)
			where TEntity : class
			where TEntity2 : class;

		TEntity GetOne<TEntity, TEntity2>(string sql, DynamicParameters param, Func<TEntity, TEntity2, TEntity> map, string splitOn, CommandType commandType = CommandType.StoredProcedure)
			where TEntity : class
			where TEntity2 : class;

		TEntity GetOne<TEntity, TEntity2, TEntity3>(string sql, Func<TEntity, TEntity2, TEntity3, TEntity> map, string splitOn, CommandType commandType = CommandType.StoredProcedure)
			where TEntity : class
			where TEntity2 : class
			where TEntity3 : class;

		TEntity GetOne<TEntity, TEntity2, TEntity3>(string sql, DynamicParameters param, Func<TEntity, TEntity2, TEntity3, TEntity> map, string splitOn, CommandType commandType = CommandType.StoredProcedure)
			where TEntity : class
			where TEntity2 : class
			where TEntity3 : class;

		TEntity GetOne<TEntity, TEntity2, TEntity3, TEntity4>(string sql, DynamicParameters param, Func<TEntity, TEntity2, TEntity3, TEntity4, TEntity> map, string splitOn, CommandType commandType = CommandType.StoredProcedure)
			where TEntity : class
			where TEntity2 : class
			where TEntity3 : class
			where TEntity4 : class;

		IEnumerable<TEntity> GetMany<TEntity>(string sql, CommandType commandType = CommandType.StoredProcedure)
			where TEntity : class;

		IEnumerable<TEntity> GetMany<TEntity>(string sql, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure)
			where TEntity : class;

		IEnumerable<TEntity> GetMany<TEntity, TEntity2>(string sql, Func<TEntity, TEntity2, TEntity> map, string splitOn, CommandType commandType = CommandType.StoredProcedure)
			where TEntity : class
			where TEntity2 : class;

		IEnumerable<TEntity> GetMany<TEntity, TEntity2>(string sql, DynamicParameters param, Func<TEntity, TEntity2, TEntity> map, string splitOn, CommandType commandType = CommandType.StoredProcedure)
			where TEntity : class
			where TEntity2 : class;

		IEnumerable<TEntity> GetMany<TEntity, TEntity2, TEntity3>(string sql, Func<TEntity, TEntity2, TEntity3, TEntity> map, string splitOn, CommandType commandType = CommandType.StoredProcedure)
			where TEntity : class
			where TEntity2 : class
			where TEntity3 : class;

		IEnumerable<TEntity> GetMany<TEntity, TEntity2, TEntity3>(string sql, DynamicParameters param, Func<TEntity, TEntity2, TEntity3, TEntity> map, string splitOn, CommandType commandType = CommandType.StoredProcedure)
			where TEntity : class
			where TEntity2 : class
			where TEntity3 : class;

		int GetScalar(string sql, CommandType commandType = CommandType.StoredProcedure);

		int GetScalar(string sql, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure);

		DateTime? GetScalarDate(string sql, CommandType commandType = CommandType.StoredProcedure);

		DateTime? GetScalarDate(string sql, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure);

		bool GetScalarBool(string sql, CommandType commandType = CommandType.StoredProcedure);

		bool GetScalarBool(string sql, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure);

		void NonQuery(string sql, CommandType commandType = CommandType.StoredProcedure);

		void NonQuery(string sql, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure);

		void NonQuery(string sql, List<DynamicParameters> param, CommandType commandType = CommandType.StoredProcedure);
	}
}