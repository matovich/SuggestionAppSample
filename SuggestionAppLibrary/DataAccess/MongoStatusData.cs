using Microsoft.Extensions.Caching.Memory;
using MongoDB.Driver;

namespace SuggestionAppLibrary.DataAccess
{
    public class MongoStatusData : IStatusData
    {
        private readonly IMongoCollection<StatusModel> _statuses;
        private readonly IMemoryCache _cache;
        private const string CacheName = "StatusData";

        public MongoStatusData(IDbConnection db, IMemoryCache cache)
        {
            _statuses = db.StatusCollection;
            _cache = cache;
        }

        public async Task<List<StatusModel>> GetAllStatusesAsync()
        {
            var output = _cache.Get<List<StatusModel>>(CacheName);
            if (output == null)
            {
                var result = await _statuses.FindAsync(_ => true);
                output = result.ToList();

                _cache.Set(CacheName, output, TimeSpan.FromDays(1));
            }
            return output;
        }

        public Task CreatStatusAsync(StatusModel status)
        {
            return _statuses.InsertOneAsync(status);
        }
    }
}
