using Dapper;
using MISA.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MySqlConnector;
using System.Threading.Tasks;


namespace MISA.Infrastructure.Repository
{
    public class BaseRepository<MISAEntity> : IBaseRepository<MISAEntity>
    {
        protected string _tableName = string.Empty;
        protected string _connectionString = "" +
               "Host=47.241.69.179; " +
               "Port=3306;" +
               "User Id= dev; " +
               "Password=12345678;" +
               "Database= MF0_NVManh_CukCuk02;" +
                "convert zero datetime=True";
        protected IDbConnection _dbConnection;
        public BaseRepository()
        {
            _tableName = typeof(MISAEntity).Name;
            _dbConnection = new MySqlConnection(_connectionString);
        }

        public int Delete(Guid entityId)
        {
            string storeName = $"Proc_Delete{_tableName}";
            DynamicParameters dynamicParameters = new DynamicParameters();
            string paramName = $"@{_tableName}Id";
            dynamicParameters.Add(paramName, entityId);
            var entity = _dbConnection.Query<MISAEntity>(storeName, param: dynamicParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            if (entity != null) return 1;
            else return 0;
        }

        public MISAEntity GetById(Guid entityId)
        {
            string storeName = $"Proc_Get{_tableName}ById";
            DynamicParameters dynamicParameters = new DynamicParameters();
            string paramName = $"@{_tableName}Id";
            dynamicParameters.Add(paramName, entityId);
            var entity = _dbConnection.Query<MISAEntity>(storeName, param: dynamicParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return entity;
        }

        public IEnumerable<MISAEntity> GetEntities()
        {
            string storeName = $"Proc_Get{_tableName}s";
            var entities = _dbConnection.Query<MISAEntity>(storeName, commandType: CommandType.StoredProcedure);
            return entities;
        }

        public int Insert(MISAEntity entity)
        {
            var storeName = $"Proc_Insert{_tableName}";
            var storeParam = entity;
            var rowAffects = _dbConnection.Execute(storeName, param: storeParam, commandType: CommandType.StoredProcedure);
            return rowAffects;
        }

        public int UpDate(MISAEntity entity, Guid entityId)
        {
            var storeName = $"Proc_Update{_tableName}";
            var rowAffects = _dbConnection.Execute(storeName, param: entity, commandType: CommandType.StoredProcedure);
            return rowAffects;
        }
    }
}
