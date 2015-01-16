using Microsoft.Framework.OptionsModel;
using MongoMvc.Models;
using System;
using System.Collections.Generic;

using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Builders;

namespace MongoMvc
{

    public interface ISpeakerRespository
    {
        IEnumerable<Speaker> AllSpeakers();

        Speaker GetById(ObjectId id);

        void Add(Speaker speaker);

        void Update(Speaker speaker);

        bool Remove(ObjectId id);
    }

    public class SpeakerRepository : ISpeakerRespository
    {
        
        private readonly Settings _settings;
        private readonly MongoDatabase _database;
        public SpeakerRepository(IOptions<Settings> settings)
        {
            _settings = settings.Options;
            _database = Connect();
        }

        public void Add(Speaker speaker)
        {
            _database.GetCollection<Speaker>("speakers").Save(speaker);
        }

        public IEnumerable<Speaker> AllSpeakers()
        {
            var speakers = _database.GetCollection<Speaker>("speakers").FindAll();
            return speakers;
        }

        public Speaker GetById(ObjectId id)
        {
            var query = Query<Speaker>.EQ(e => e.Id, id);
            var speaker = _database.GetCollection<Speaker>("speakers").FindOne(query);

            return speaker;
        }

        public bool Remove(ObjectId id)
        {
            var query = Query<Speaker>.EQ(e => e.Id, id);
            var result = _database.GetCollection<Speaker>("speakers").Remove(query);

            return GetById(id) == null;
        }

        public void Update(Speaker speaker)
        {
            var query = Query<Speaker>.EQ(e => e.Id, speaker.Id);
            var update = Update<Speaker>.Replace(speaker); // update modifiers
            _database.GetCollection<Speaker>("speakers").Update(query, update);
        }

        private MongoDatabase Connect()
        {
            var client = new MongoClient(_settings.MongoConnection);
            var server = client.GetServer();
            var database = server.GetDatabase(_settings.Database);

            return database;
        }
    }
}