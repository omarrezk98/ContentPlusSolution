using AutoMapper;
using Entity;
using Mongo.ErrorLog;
using MongoDB.Driver;
using MongoDiagnosis;
using Newtonsoft.Json;

namespace MangerService
{
    public interface IBaseService {}
    public class BaseService(EntityContext context, IMapper mapper,
                       IMongoDatabaseSettings mongoDBSettings, IMongoClient mongoClient) : IBaseService
    {
        public readonly EntityContext db = context;
        public readonly IMapper Mapper = mapper;
        private readonly IMongoCollection<ServiceErrorLog> serviceErrorLog =
        mongoClient.GetDatabase(mongoDBSettings.DatabaseName).GetCollection<ServiceErrorLog>("ServiceErrorLog");

        #region Log
        public async Task LogError(Exception ex, string url, string? mangerUserId = null, object? model = null)
        {
            try
            {
                ServiceErrorLog log = new()
                {
                    Message = ex?.Message,
                    StackTrace = ex?.StackTrace,
                    URL = url,
                    Source = ex?.Source,
                    InnerException = JsonConvert.SerializeObject(ex?.InnerException),
                    UserId = mangerUserId,
                    Model = JsonConvert.SerializeObject(model),
                    ServiceErrorLogType = ServiceErrorLogTypeEnum.MangerService
                };
                await serviceErrorLog.InsertOneAsync(log);
            }
            catch
            {
                throw ex;
            }
        }
        #endregion
    }
}
