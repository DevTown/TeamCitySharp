using System.Collections.Generic;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.Locators
{
    public class AgentLocator
    {
        public bool? Authorized { get; private set; }
        public BuildLocator Build { get; private set; }
        public  bool? Connected { get; private set; }
        public bool? Enabled { get; private set; }
        public long? Id { get; private set; }
        
        public string Name { get; private set; }
        
        public static AgentLocator WithId(long id)
        {
            return new AgentLocator {Id = id};
        }

        public static AgentLocator OnlyDisconnected()
        {
            return new AgentLocator { Connected = false };
        }
        
        public static AgentLocator OnlyDisabled()
        {
            return new AgentLocator { Enabled = false };
        }



        public override string ToString()
        {
            if (Id != null)
                return "id:" + Id;
            
            var locatorFields = new List<string>();
            
            if(Authorized != null)
                locatorFields.Add("authorized:" + Authorized.Value.ToString());
            
            if(Build != null)
                locatorFields.Add("build:(" + Build + ")");

            if(Connected != null)
                locatorFields.Add("connected:" + Connected.Value.ToString());
            
            if(Enabled != null)
                locatorFields.Add("enabled:" + Enabled.Value.ToString());
            
            if (!string.IsNullOrEmpty(Name))
                locatorFields.Add("name:" + Name);
            
            return string.Join(",", locatorFields.ToArray());
        }
    }
}