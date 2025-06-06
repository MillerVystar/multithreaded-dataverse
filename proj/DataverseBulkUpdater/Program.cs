using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.Xrm.Sdk;
using System.ServiceModel;
using Microsoft.Xrm.Tooling.Connector;


namespace DataverseBulkUpdater
{
    public class RecordModel
    {
        public string Id { get; set; }
        public string EntityName { get; set; }
        public Dictionary<string, object> Properties { get; set; }
    }

    //public class DataverseService
    //{
    //    private readonly ServiceClient _serviceClient;

    //    public DataverseService(string connectionString)
    //    {
    //        _serviceClient = new ServiceClient(connectionString);
    //    }
    //}

    class Program
    {
        
        static async Task Main(string[] args)
        {
            //// TODO: Replace with your actual Dataverse connection string
            //var connectionString = "AuthType=ClientSecret;Url=https://yourorg.crm.dynamics.com;ClientId=YOUR_CLIENT_ID;ClientSecret=YOUR_CLIENT_SECRET;TenantId=YOUR_TENANT_ID;";
            //var dataverseService = new DataverseService(connectionString);

            // Set up connection parameters
            //string url = "https://vystardev.crm.dynamics.com"; // Replace with your Dynamics 365 URL
            string url = "https://orgb17a0e15.crm.dynamics.com/"; // Replace with your Dynamics 365 URL
            //string username = "millert2@vystarcu.org"; // Username
            string username = "jbatra@m.azhasys.com"; // Username
            string password = "GolmalVystar@123"; // Password
            //string password = "GolmalVystar@12345"; // Password
            
            // Build connection string
            string connectionString = $"AuthType=Office365;Url={url};Username={username};Password={password};";
            CrmServiceClient crmServiceClient;
            try
            {
                // Create a connection to the Dynamics 365 instance
                crmServiceClient = new CrmServiceClient(connectionString);

                if (crmServiceClient.IsReady)
                {
                    Console.WriteLine("Successfully connected to Dynamics 365!");

                    // Example list of records to update (replace Ids with real GUIDs from your Dataverse)
                    var recordsToUpdate = new List<RecordModel>
                    {
                        new RecordModel {
                            Id = "6af3572a-9642-f011-8779-7c1e527d3127",
                            EntityName = "account",
                            Properties = new Dictionary<string, object> {
                                { "name", "Test 1" }
                                //{ "new_value", "Updated Value 1" } // Replace with your actual field name
                            }
                        },
                        new RecordModel {
                            Id = "cafb7e3f-9642-f011-8779-7c1e527d3127",
                            EntityName = "account",
                            Properties = new Dictionary<string, object> {
                                { "name", "Test 2" }
                                //{ "new_value", "Updated Value 2" }
                            }
                        }
                    };

                    foreach (var record in recordsToUpdate)
                    {
                        var entity = new Entity(record.EntityName, new Guid(record.Id));
                        foreach (var property in record.Properties)
                        {
                            entity[property.Key] = property.Value;
                        }

                        crmServiceClient.Update(entity);
                    }
                    await Task.CompletedTask;

                    Console.WriteLine("Records updated successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to connect to Dynamics 365.");
                    Console.WriteLine(crmServiceClient.LastCrmError);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.ReadLine();



        }

        //public async Task UpdateRecordsAsync(List<RecordModel> records)
        //{
        //    foreach (var record in records)
        //    {
        //        var entity = new Entity(record.EntityName, new Guid(record.Id));
        //        foreach (var property in record.Properties)
        //        {
        //            entity[property.Key] = property.Value;
        //        }

        //        crmServiceClient.Update(entity);
        //    }
        //    await Task.CompletedTask;
        //}
    }
}