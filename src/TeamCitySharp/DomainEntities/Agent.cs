﻿using Newtonsoft.Json;

namespace TeamCitySharp.DomainEntities
{
  public class Agent
  {

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("href")]
    public string Href { get; set; }

    [JsonProperty("typeId")]
    public string TypeId { get; set; }

    [JsonProperty("webUrl")]
    public string WebUrl { get; set; }
    
    [JsonProperty("connected")]
    public string Connected { get; set; }
    
    [JsonProperty("enabled")]
    public string Enabled { get; set; }
    
    [JsonProperty("authorized")]
    public string Authorized { get; set; }



    public override string ToString()
    {
      return "agent";
    }
  }
}