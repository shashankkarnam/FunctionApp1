using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{


    public class HGV
    {
        public string HGVName { get; set; }
        public string Country { get; set; }
  
    }

  
    public class Service : IService
    {
        private static readonly string DatabaseId = "HGV";
        private static readonly string CollectionId = "HGVData";
        //private static DocumentClient client;
        private  IDocumentClient _client;
        public Service(IDocumentClient client)
        {
            _client = client;
        }
        public async  Task<HGV> method(string id)
        {

           _client = new DocumentClient(new Uri("https://hgv.documents.azure.com:443/"), "RouLXrjhON6SpUwn9ML2lm67CTULIpi0axOYcd6aP7ga3s69LGJtlQaQxVOcaY9Y6QOijF9jlQHSuPc7g56Wgw==");
            
            var volcano = new HGV
            {
                HGVName = "TestHGV",
                Country = "United States",
                
            };
            
            var ans=await  _client.CreateDatabaseIfNotExistsAsync(new Database { Id =DatabaseId });

            var collectionDefinition = new DocumentCollection { Id = CollectionId };
            _client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(DatabaseId), collectionDefinition).Wait();
         
            var document = await _client.CreateDocumentAsync(
                                 UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId)
                                 , volcano);
           
            HGV rainierVolcano =  _client.CreateDocumentQuery<HGV>(
                           UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId))
                           .Where(v => v.HGVName == "TestHGV" )
                           .AsEnumerable()
                           .FirstOrDefault();
            var document0 = _client
    .CreateDocumentQuery(
        UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId))
    ;
            HGV document1 = _client
    .ReadDocumentAsync<HGV>(
        UriFactory.CreateDocumentUri(DatabaseId, CollectionId, id))
    .Result;
            //HGV rainierVolcano1 = _client.CreateDocumentQuery<HGV>(
            //               UriFactory.CreateDocumentUri(DatabaseId, CollectionId,id))
            //               .AsEnumerable()
            //               .Where()
            //               .FirstOrDefault();

            return document1;


        }
    }
}

