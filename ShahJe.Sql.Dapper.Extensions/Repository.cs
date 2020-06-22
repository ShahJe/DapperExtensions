using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ShahJe.Sql.Dapper.Extensions
{
	public class Repository : IRepository
	{
		private string ConnectionString { get; }

        public Repository(string sqlConnectionString)
        {
			ConnectionString = sqlConnectionString;
        }

		public SqlConnection Connection(bool mars = false)
		{
			var connection = new SqlConnection(ConnectionString);
			connection.Open();
			return connection;
		}

		public IEnumerable<TEntity> GetMany<TEntity>(string sql, CommandType commandType = CommandType.StoredProcedure) where TEntity : class
		{
			using (var conn = Connection())
			{
				return conn.Query<TEntity>(sql, commandType: commandType).ToList();
			}
		}

		public IEnumerable<TEntity> GetMany<TEntity>(string sql, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure) where TEntity : class
		{
			using (var conn = Connection())
			{
				return conn.Query<TEntity>(sql, param: param, commandType: commandType).ToList();
			}
		}

		public IEnumerable<TEntity> GetMany<TEntity, TEntity2>(string sql, Func<TEntity, TEntity2, TEntity> map, string splitOn, CommandType commandType = CommandType.StoredProcedure)
			where TEntity : class
			where TEntity2 : class
		{
			using (var conn = Connection())
			{
				return conn.Query<TEntity, TEntity2, TEntity>(sql, map: map, splitOn: splitOn, commandType: commandType).ToList();
			}
		}

		public IEnumerable<TEntity> GetMany<TEntity, TEntity2>(string sql, DynamicParameters param, Func<TEntity, TEntity2, TEntity> map, string splitOn, CommandType commandType = CommandType.StoredProcedure)
			where TEntity : class
			where TEntity2 : class
		{
			using (var conn = Connection())
			{
				return conn.Query<TEntity, TEntity2, TEntity>(sql, param: param, map: map, splitOn: splitOn, commandType: commandType).ToList();
			}
		}

		public IEnumerable<TEntity> GetMany<TEntity, TEntity2, TEntity3>(string sql, Func<TEntity, TEntity2, TEntity3, TEntity> map, string splitOn, CommandType commandType = CommandType.StoredProcedure)
			where TEntity : class
			where TEntity2 : class
			where TEntity3 : class
		{
			using (var conn = Connection())
			{
				return conn.Query<TEntity, TEntity2, TEntity3, TEntity>(sql, map: map, splitOn: splitOn, commandType: commandType).ToList();
			}
		}

		public IEnumerable<TEntity> GetMany<TEntity, TEntity2, TEntity3>(string sql, DynamicParameters param, Func<TEntity, TEntity2, TEntity3, TEntity> map, string splitOn, CommandType commandType = CommandType.StoredProcedure)
			where TEntity : class
			where TEntity2 : class
			where TEntity3 : class
		{
			using (var conn = Connection())
			{
				return conn.Query<TEntity, TEntity2, TEntity3, TEntity>(sql, param: param, map: map, splitOn: splitOn, commandType: commandType).ToList();
			}
		}

		public TEntity GetOne<TEntity>(string sql, CommandType commandType = CommandType.StoredProcedure) where TEntity : class
		{
			using (var conn = Connection())
			{
				return conn.Query<TEntity>(sql, commandType: commandType).FirstOrDefault();
			}
		}

		public TEntity GetOne<TEntity>(string sql, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure) where TEntity : class
		{
			using (var conn = Connection())
			{
				return conn.Query<TEntity>(sql, param: param, commandType: commandType).FirstOrDefault();
			}
		}

		public TEntity GetOne<TEntity, TEntity2>(string sql, Func<TEntity, TEntity2, TEntity> map, string splitOn, CommandType commandType = CommandType.StoredProcedure)
			where TEntity : class
			where TEntity2 : class
		{
			using (var conn = Connection())
			{
				return conn.Query<TEntity, TEntity2, TEntity>(sql, map: map, splitOn: splitOn, commandType: commandType).FirstOrDefault();
			}
		}

		public TEntity GetOne<TEntity, TEntity2>(string sql, DynamicParameters param, Func<TEntity, TEntity2, TEntity> map, string splitOn, CommandType commandType = CommandType.StoredProcedure)
			where TEntity : class
			where TEntity2 : class
		{
			using (var conn = Connection())
			{
				return conn.Query<TEntity, TEntity2, TEntity>(sql, param: param, map: map, splitOn: splitOn, commandType: commandType).FirstOrDefault();
			}
		}

		public TEntity GetOne<TEntity, TEntity2, TEntity3>(string sql, Func<TEntity, TEntity2, TEntity3, TEntity> map, string splitOn, CommandType commandType = CommandType.StoredProcedure)
			where TEntity : class
			where TEntity2 : class
			where TEntity3 : class
		{
			using (var conn = Connection())
			{
				return conn.Query<TEntity, TEntity2, TEntity3, TEntity>(sql, map: map, splitOn: splitOn, commandType: commandType).FirstOrDefault();
			}
		}

		public TEntity GetOne<TEntity, TEntity2, TEntity3>(string sql, DynamicParameters param, Func<TEntity, TEntity2, TEntity3, TEntity> map, string splitOn, CommandType commandType = CommandType.StoredProcedure)
			where TEntity : class
			where TEntity2 : class
			where TEntity3 : class
		{
			using (var conn = Connection())
			{
				return conn.Query<TEntity, TEntity2, TEntity3, TEntity>(sql, param: param, map: map, splitOn: splitOn, commandType: commandType).FirstOrDefault();
			}
		}

		public TEntity GetOne<TEntity, TEntity2, TEntity3, TEntity4>(string sql, DynamicParameters param, Func<TEntity, TEntity2, TEntity3, TEntity4, TEntity> map, string splitOn, CommandType commandType = CommandType.StoredProcedure)
			where TEntity : class
			where TEntity2 : class
			where TEntity3 : class
			where TEntity4 : class
		{
			using (var conn = Connection())
			{
				return conn.Query<TEntity, TEntity2, TEntity3, TEntity4, TEntity>(sql, param: param, map: map, splitOn: splitOn, commandType: commandType).FirstOrDefault();
			}
		}

		public int GetScalar(string sql, CommandType commandType = CommandType.StoredProcedure)
		{
			using (var conn = Connection())
			{
				return conn.Query<int>(sql, commandType: commandType).SingleOrDefault();
			}
		}

		public int GetScalar(string sql, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure)
		{
			using (var conn = Connection())
			{
				return conn.Query<int>(sql, param: param, commandType: commandType).SingleOrDefault();
			}
		}

		public bool GetScalarBool(string sql, CommandType commandType = CommandType.StoredProcedure)
		{
			using (var conn = Connection())
			{
				return conn.Query<bool>(sql, commandType: commandType).SingleOrDefault();
			}
		}

		public bool GetScalarBool(string sql, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure)
		{
			using (var conn = Connection())
			{
				return conn.Query<bool>(sql, param: param, commandType: commandType).SingleOrDefault();
			}
		}

		public DateTime? GetScalarDate(string sql, CommandType commandType = CommandType.StoredProcedure)
		{
			using (var conn = Connection())
			{
				return conn.Query<DateTime?>(sql, commandType: commandType).SingleOrDefault();
			}
		}

		public DateTime? GetScalarDate(string sql, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure)
		{
			using (var conn = Connection())
			{
				return conn.Query<DateTime?>(sql, param: param, commandType: commandType).SingleOrDefault();
			}
		}

		public void NonQuery(string sql, CommandType commandType = CommandType.StoredProcedure)
		{
			using (var conn = Connection())
			{
				conn.Execute(sql, commandType: commandType);
			}
		}

		public void NonQuery(string sql, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure)
		{
			using (var conn = Connection())
			{
				conn.Execute(sql, param: param, commandType: commandType);
			}
		}

		public void NonQuery(string sql, List<DynamicParameters> param, CommandType commandType = CommandType.StoredProcedure)
		{
			using (var conn = Connection())
			{
				conn.Execute(sql, param: param.ToArray(), commandType: commandType);
			}
		}
	}
}