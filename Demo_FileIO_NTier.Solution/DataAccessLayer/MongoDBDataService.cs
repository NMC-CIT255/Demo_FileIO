using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Demo_FileIO_NTier.Models;
using Newtonsoft;
using Demo_FileIO_NTier.DataAccessLayer;
using Newtonsoft.Json;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Demo_FileIO_NTier.DataAccessLayer

{
    public class MongoDBDataService : IDataService
    {

        /// <summary>
        /// read the mongoDb collection and load a list of character objects
        /// </summary>
        /// <returns>list of characters</returns>
        public IEnumerable<Character> ReadAll()
        {
            List<Character> characters = new List<Character>();



            try
            {
                var client = new MongoClient(
                    "mongodb://johnvelis:password01@cluster0-shard-00-00-hasci.mongodb.net:27017,cluster0-shard-00-01-hasci.mongodb.net:27017,cluster0-shard-00-02-hasci.mongodb.net:27017/test?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin&retryWrites=true"
                    );
                IMongoDatabase database = client.GetDatabase("cit255");
                IMongoCollection<Character> characterList = database.GetCollection<Character>("flintstone_characters");

                characters = characterList.Find(Builders<Character>.Filter.Empty).ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return characters;
        }

        /// <summary>
        /// write the current list of characters to the mongoDb collection
        /// </summary>
        /// <param name="characters">list of characters</param>
        public void WriteAll(IEnumerable<Character> characters)
        {
            try
            {
                var client = new MongoClient(
                    "mongodb://johnvelis:password01@cluster0-shard-00-00-hasci.mongodb.net:27017,cluster0-shard-00-01-hasci.mongodb.net:27017,cluster0-shard-00-02-hasci.mongodb.net:27017/test?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin&retryWrites=true"
                    );
                IMongoDatabase database = client.GetDatabase("cit255");
                IMongoCollection<Character> characterList = database.GetCollection<Character>("flintstone_characters");

                //
                // delete all documents in the collection
                //
                characterList.DeleteMany(Builders<Character>.Filter.Empty);

                characterList.InsertMany(characters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MongoDBDataService()
        {
            
        }
    }
}
