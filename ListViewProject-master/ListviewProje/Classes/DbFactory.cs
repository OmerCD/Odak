using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListviewProje.Classes.CRUD;
using ListviewProje.Models.Entity;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ListviewProje.Classes
{
    public struct DbFactory
    {
        public static async Task<bool> SetConnection(string serverIP)
        {
            var port = "27017";
            if (serverIP.Contains(":"))
            {
                var split = serverIP.Split(':');
                port = split[1];
                serverIP = split[0];
            }

            _client = new MongoClient($"mongodb://{serverIP}:{port}");
            try
            {
                await Database.RunCommandAsync((Command<BsonDocument>)"{ping:1}");
            }
            catch (TimeoutException)
            {
                return false;
            }

            return true;
        }

        //public static IMongoClient Client = new MongoClient("mongodb://mustafarumeli:2dDfShKEX9rbc6e2eHxedLaouu8glHyZE9Ghz5PauBTfBkhpIWhvZuwxsgal1bnhQ2ZIQdIgjxDSrfT6XjS9YA==@mustafarumeli.documents.azure.com:10255/?ssl=true&replicaSet=globaldb");
        private static IMongoClient _client;
        private static IMongoDatabase _database;

        public static IMongoDatabase Database => _database ?? (_database = _client.GetDatabase("test2"));

        private static IMongoCollection<BsonDocument> _user;
        private static IMongoCollection<BsonDocument> _company;
        private static IMongoCollection<BsonDocument> _generalSettings;
        private static IMongoCollection<BsonDocument> _paymentDocument;

        public static IMongoCollection<BsonDocument> GeneralSettings =>
            _generalSettings ?? (_generalSettings =
                Database.GetCollection<BsonDocument>(typeof(GeneralSettings).Name));

        public static IMongoCollection<BsonDocument> User =>
            _user ?? (_user = Database.GetCollection<BsonDocument>(typeof(User).Name));


        public static IMongoCollection<BsonDocument> Company =>
            _company ?? (_company = Database.GetCollection<BsonDocument>(typeof(Company).Name));


        public static IMongoCollection<BsonDocument> PaymentDocument =>
            _paymentDocument ?? (_paymentDocument = Database.GetCollection<BsonDocument>(typeof(PaymentDocument).Name));

        private static UserCRUD _userCRUD;
        private static CompanyCRUD _companyCRUD;
        private static PaymentDocumentCRUD _paymentDocumentCrud;

        public static UserCRUD UserCRUD => _userCRUD ?? (_userCRUD = new UserCRUD());


        public static CompanyCRUD CompanyCRUD => _companyCRUD ?? (_companyCRUD = new CompanyCRUD());
        public static PaymentDocumentCRUD PaymentDocumentCRUD => _paymentDocumentCrud ?? (_paymentDocumentCrud = new PaymentDocumentCRUD());




        public struct GenericFactory
        {
            private static CRUD<User> _userGenericCRUD;
            private static CRUD<Company> _companyGenericCRUD;

            public static CRUD<User> UserGenericCRUD =>
                _userGenericCRUD ?? (_userGenericCRUD = new CRUD<User>(DbFactory.User));
            public static CRUD<Company> CompanyGenericCRUD =>
                _companyGenericCRUD ?? (_companyGenericCRUD = new CRUD<Company>(DbFactory.Company));
        }
    }
}
