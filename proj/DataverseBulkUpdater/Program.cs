using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk;
using DataverseBulkUpdater.Models;
using DataverseBulkUpdater.Services;

namespace DataverseBulkUpdater
{
    public class RecordModel
    {
        public string Id { get; set; }
        public string EntityName { get; set; }
        public Dictionary<string, object> Properties { get; set; }
    }

    public class DataverseService
    {
        private readonly ServiceClient _serviceClient;

        public DataverseService(string connectionString)
        {
            _serviceClient = new ServiceClient(connectionString);
        }

        public async Task UpdateRecordsAsync(List<RecordModel> records)
        {
            foreach (var record in records)
            {
                var entity = new Entity(record.EntityName, new Guid(record.Id));
                foreach (var property in record.Properties)
                {
                    entity[property.Key] = property.Value;
                }

                _serviceClient.Update(entity);
            }
            await Task.CompletedTask;
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            // TODO: Replace with your actual Dataverse connection string
            var connectionString = "AuthType=ClientSecret;Url=https://yourorg.crm.dynamics.com;ClientId=YOUR_CLIENT_ID;ClientSecret=YOUR_CLIENT_SECRET;TenantId=YOUR_TENANT_ID;";
            var dataverseService = new DataverseService(connectionString);

            // Example list of records to update (replace Ids with real GUIDs from your Dataverse)
            var recordsToUpdate = new List<RecordModel>
            {
                new RecordModel {
                    Id = "11111111-1111-1111-1111-111111111111",
                    EntityName = "account",
                    Properties = new Dictionary<string, object> {
                        { "name", "Record 1" },
                        { "new_value", "Updated Value 1" } // Replace with your actual field name
                    }
                },
                new RecordModel {
                    Id = "22222222-2222-2222-2222-222222222222",
                    EntityName = "account",
                    Properties = new Dictionary<string, object> {
                        { "name", "Record 2" },
                        { "new_value", "Updated Value 2" }
                    }
                }
            };

            await dataverseService.UpdateRecordsAsync(recordsToUpdate);

            Console.WriteLine("Records updated successfully.");
        }
    }
}