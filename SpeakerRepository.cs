using System.Collections.Generic;
using System.Linq;
using Microsoft.Framework.OptionsModel;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoMvc.Models;

namespace MongoMvc
{
    public class SpeakerRepository : ISpeakerRespository
    {
        private readonly IMongoDatabase _database;
        private readonly Settings _settings;

        public SpeakerRepository(IOptions<Settings> settings)
        {
            _settings = settings.Value;
            _database = Connect();
        }

        public void Add(Speaker speaker)
        {
            _database.GetCollection<Speaker>("speakers").InsertOneAsync(speaker);
        }

        public IEnumerable<Speaker> AllSpeakers()
        {
            var speakers = _database.GetCollection<Speaker>("speakers").Find(new BsonDocument()).ToListAsync();
            return speakers.Result;
        }

        public Speaker GetById(ObjectId id)
        {
            var query = Builders<Speaker>.Filter.Eq(e => e.Id, id);
            var speaker = _database.GetCollection<Speaker>("speakers").Find(query).ToListAsync();

            return speaker.Result.FirstOrDefault();
        }

        public bool Remove(ObjectId id)
        {
            var query = Builders<Speaker>.Filter.Eq(e => e.Id, id);
            var result = _database.GetCollection<Speaker>("speakers").DeleteOneAsync(query);

            return GetById(id) == null;
        }

        public void Update(Speaker speaker)
        {
            var query = Builders<Speaker>.Filter.Eq(e => e.Id, speaker.Id);
            var update = _database.GetCollection<Speaker>("speakers").ReplaceOneAsync(query, speaker);
        }

        private IMongoDatabase Connect()
        {
            var client = new MongoClient(_settings.MongoConnection);
            var database = client.GetDatabase(_settings.Database);

            return database;
        }
    }
}