using System;
using System.Collections.Generic;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;
using TeamCitySharp.Locators;

namespace TeamCitySharp.ActionTypes
{
  public class Agents : IAgents
  {
    private readonly ITeamCityCaller m_caller;
    private string m_fields;

    #region Constructor
    internal Agents(ITeamCityCaller caller)
    {
      m_caller = caller;
    }
    #endregion

    public Agents GetFields(string fields)
    {
      var newInstance = (Agents) MemberwiseClone();
      newInstance.m_fields = fields;
      return newInstance;
    }

    public List<Agent> All(bool includeDisconnected = true, bool includeUnauthorized = true)
    {
      var url =
        string.Format(
          ActionHelper.CreateFieldUrl("/agents?includeDisconnected={0}&includeUnauthorized={1}", m_fields),
          includeDisconnected.ToString().ToLower(), includeUnauthorized.ToString().ToLower());

      var agentWrapper = m_caller.Get<AgentWrapper>(url);

      return agentWrapper.Agent;
    }

    public List<Agent> OnlyDisconnected()
    {
      return ByAgentLocator(AgentLocator.OnlyDisconnected());
    }
    
    public List<Agent> OnlyDisabled()
    {
      return ByAgentLocator(AgentLocator.OnlyDisabled());
    }
    
    public List<Agent> ByAgentLocator(AgentLocator locator)
    {
      var agentWrapper =
        m_caller.Get<AgentWrapper>(
          ActionHelper.CreateFieldUrl($"/agents?locator={locator}", m_fields));

      return int.Parse(agentWrapper.Count) > 0 ? agentWrapper.Agent : new List<Agent>();
    }
    
    
    public List<Agent> ByAgentLocator(AgentLocator locator, List<String> param)
    {
      var strParam = GetParamLocator(param);
      var agentWrapper =
        m_caller.Get<AgentWrapper>(
          ActionHelper.CreateFieldUrl($"/agents?locator={locator}{strParam}", m_fields));

      return int.Parse(agentWrapper.Count) > 0 ? agentWrapper.Agent : new List<Agent>();
    }
    
    private static string GetParamLocator(List<string> param)
    {
      var strParam = "";
      if (param != null)
      {
        foreach (var tmpParam in param)
        {
          strParam += ",";
          strParam += tmpParam;
        }
      }
      return strParam;
    }
    
    public void Enable(string agentId, bool enable)
    {
      const string urlPart = "/agents/id:{0}/enabled";
      m_caller.PutFormat(enable, HttpContentTypes.TextPlain, urlPart, agentId );
    }
    
    public void Delete(string agentId)
    {
      const string urlPart = "/agents/id:{0}";
      m_caller.DeleteFormat( HttpContentTypes.TextPlain, urlPart, agentId);
    }
  }
}