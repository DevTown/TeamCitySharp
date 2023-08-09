using System;
using System.Collections.Generic;
using TeamCitySharp.DomainEntities;
using TeamCitySharp.Locators;

namespace TeamCitySharp.ActionTypes
{
  public interface IAgents
  {
    List<Agent> All(bool includeDisconnected = false, bool includeUnauthorized = false);

    List<Agent> OnlyDisconnected();

    List<Agent> OnlyDisabled();

    List<Agent> ByAgentLocator(AgentLocator locator, List<String> param);
    List<Agent> ByAgentLocator(AgentLocator locator);

    void Enable(string agentId, bool enable);

    void Delete(string agentId);
    
    Agents GetFields(string fields);
  }
}