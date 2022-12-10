﻿using Company.API.Options;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Company.API.Repositories.MongoRepositories;

public class MongoContext
{
    public IMongoDatabase Database { get; }

    public const string CompanyCollection = "Companies";
    public const string EmployeeCollection = "Employees";
    public const string AddressCollection = "Addresses";
    public const string DepartmentCollection = "Departments";
    public const string ContractCollection = "Contracts";


    public MongoContext(IOptions<MongoConnections> connectionOptions)
    {
        if (connectionOptions == null)
        {
            throw new ArgumentNullException(nameof(connectionOptions));
        }

        var mongoConnections = connectionOptions.Value;
        var client = new MongoClient(mongoConnections.ConnectionString);
        Database = client.GetDatabase(mongoConnections.DatabaseName);
    }

    public IMongoCollection<TDocument> GetCollection<TDocument>(string collectionName)
    {
        if (collectionName == null)
        {
            throw new ArgumentNullException(nameof(collectionName));
        }

        return Database.GetCollection<TDocument>(collectionName);
    }
}