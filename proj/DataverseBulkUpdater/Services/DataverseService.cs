using System;
using System.Collections.Generic;
using System.Threading.Tasks;
//using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk;
using DataverseBulkUpdater.Models;

namespace DataverseBulkUpdater.Services
{
    public class DataverseService
    {
        //private readonly ServiceClient _serviceClient;

        //public DataverseService(string connectionString)
        //{
        //    _serviceClient = new ServiceClient(connectionString);
        //}

        //public async Task UpdateRecordsAsync(List<RecordModel> records)
        //{
        //    foreach (var record in records)
        //    {
        //        var entity = new Entity(record.EntityName)
        //        {
        //            Id = Guid.Parse(record.Id)
        //        };

        //        if (record.Properties != null)
        //        {
        //            foreach (var property in record.Properties)
        //            {
        //                entity[property.Key] = property.Value;
        //            }
        //        }

        //        await Task.Run(() => _serviceClient.Update(entity));
        //    }
        //}
    }
}