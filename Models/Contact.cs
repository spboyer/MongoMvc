using MongoDB.Bson;
using System;

namespace MongoMvc.Models
{
    public class Contact
    {
        public string First { get; set; }

        public string Last { get; set; }

        public string Gender { get; set; }

        public string Occupation { get; set; }

        public string HairColor { get; set; }

        public string DOB { get; set; }

        public ObjectId Id { get; set; }

    }
}