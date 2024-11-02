using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using RRS_Cloud_Service.Models;

namespace RRS_Cloud_Service.Data
{
    public class UsersData : IUsers
    {
        private readonly Container _taskContainer;
        private readonly IConfiguration configuration;
        private readonly CosmosClient _client;

        public UsersData(CosmosClient cosmosClient, IConfiguration configuration)
        {
            this.configuration = configuration;
            this._client = cosmosClient;
            var databaseName = configuration["CosmosDbSettings:DatabaseName"];
            var taskContainerName = "Users";
            _taskContainer = cosmosClient.GetContainer(databaseName, taskContainerName);
        }

        public async Task<IEnumerable<UserData>> GetAllUsers()
        {
            var query = _taskContainer.GetItemLinqQueryable<UserData>().ToFeedIterator();

            var tasks = new List<UserData>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                tasks.AddRange(response);
            }

            return tasks;
        }

        //public IEnumerable<UserData> GetUsers1() {
        //    //https://jsonmock.hackerrank.com/api/food_outlets?city=Denver&page=1
        //    return NotImplementedException)(;
        //}
    }
    }
