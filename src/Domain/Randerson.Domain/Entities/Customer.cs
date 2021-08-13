using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Randerson.Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Randerson.Domain.Entities
{
    public class Customer : BaseEntity<string>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public new string Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("Age")]
        public int Age { get; set; }
        [BsonElement("Email")]
        public string Email { get; set; }
        [BsonElement("Password")]
        public string Password { get; set; }
    }
}