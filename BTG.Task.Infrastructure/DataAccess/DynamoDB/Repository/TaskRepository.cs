using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using BTG.Task.Application.Repository;
using BTG.Task.Domain.Entities;
using BTG.Task.Domain.Enums;
using BTG.Task.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BTG.Task.Infrastructure.DataAccess.DynamoDB.Repository
{
    internal class TaskRepository : ITaskRepository
    {
        private readonly IAmazonDynamoDB _client;
        private readonly DatabaseSettings _databaseSettings;

        public TaskRepository(IAmazonDynamoDB client, IOptions<DatabaseSettings> databaseSettings)
        {
            _client = client;
            _databaseSettings = databaseSettings.Value;
        }

        public async System.Threading.Tasks.Task DeleteAsync(Guid id)
        {
            DeleteItemRequest request = new()
            {
                TableName = _databaseSettings.DynamoTableName,
                Key = new()
                {
                    { "pk", new AttributeValue{ S = id.ToString() } },
                    { "sk", new AttributeValue{ S = id.ToString() } }
                }
            };

            await _client.DeleteItemAsync(request);
        }

        public async Task<IEnumerable<TaskAssignment>> GetActiveByAuthorAsync(string author)
        {
            List<TaskAssignment> tasks = await ScanAll();
            return tasks.Where(x => x.Status == ETaskStatus.Active && x.Responsible.Equals(author));
        }

        public async Task<TaskAssignment?> GetAsync(Guid id)
        {
            GetItemRequest request = new()
            {
                TableName = _databaseSettings.DynamoTableName,
                Key = new()
                {
                    { "pk", new AttributeValue{ S = id.ToString() } },
                    { "sk", new AttributeValue{ S = id.ToString() } }
                }
            };

            var response = await _client.GetItemAsync(request);
            if (response.Item.Count == 0) return null;

            return ResolveTaskFromAttributes(response.Item);
        }

        public async Task<IEnumerable<TaskAssignment>> GetByStatus(ETaskStatus status)
        {
            List<TaskAssignment> tasks = await ScanAll();
            return tasks.Where(x => x.Status == status);
        }

        public async Task<TaskAssignment> SaveAsync(TaskAssignment model)
        {
            Dictionary<string, AttributeValue> taskAsAttribute = TaskToAttributeMap(model);

            PutItemRequest createRequest = new()
            {
                TableName = _databaseSettings.DynamoTableName,
                Item = taskAsAttribute
            };

            var response = await _client.PutItemAsync(createRequest);
            return ResolveTaskFromAttributes(response.Attributes);
        }

        private async Task<List<TaskAssignment>> ScanAll()
        {
            List<TaskAssignment> result = [];
            ScanRequest request = new()
            {
                TableName = _databaseSettings.DynamoTableName
            };

            var response = await _client.ScanAsync(request);

            foreach(var item in response.Items)
                result.Add(ResolveTaskFromAttributes(item));
            
            return result;
        }

        static Dictionary<string, AttributeValue> TaskToAttributeMap(TaskAssignment task)
        {
            string taskAsJson = JsonSerializer.Serialize(task);
            Document taskAsDocument = Document.FromJson(taskAsJson);
            Dictionary<string, AttributeValue> taskAsAttribute = taskAsDocument.ToAttributeMap();
            return taskAsAttribute;
        }

        static TaskAssignment ResolveTaskFromAttributes(Dictionary<string, AttributeValue> attributes)
        {
            Document taskAsDocument = Document.FromAttributeMap(attributes);
            return JsonSerializer.Deserialize<TaskAssignment>(taskAsDocument.ToJson())!;
        }
    }
}
