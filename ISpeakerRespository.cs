using System.Collections.Generic;
using MongoDB.Bson;
using MongoMvc.Models;

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
}