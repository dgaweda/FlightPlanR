﻿using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FlightPlanApi.Models;

public abstract class BaseEntity
{
    [BsonId]
    public ObjectId ObjectId { get; set; }

    [BsonElement("id")] 
    public string? Id { get; set; }

    public void NewDocumentId()
    {
        Id = Guid.NewGuid().ToString("N");
    }
}