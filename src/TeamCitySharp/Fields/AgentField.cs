﻿using System;

namespace TeamCitySharp.Fields
{
  public class AgentField : IField
  {
    #region Properties

    public bool Id { get; private set; }
    public bool Name { get; private set; }
    public bool Href { get; private set; }
    public bool TypeId { get; private set; }
    public bool WebUrl { get; private set; }
    public bool Connected { get; private set; }
    public bool Enabled { get; private set; }
    public bool Authorized { get; private set; }

    #endregion

    #region Public Methods

    public static AgentField WithFields(bool id = false,
                                        bool name = false,
                                        bool href = false, 
                                        bool typeId = false,
                                        bool webUrl = false,
                                        bool connected = false,
                                        bool enabled = false,
                                        bool authorized = false)
    {
      return new AgentField
        {
          Id = id,
          Name = name,
          Href = href,
          TypeId = typeId,
          WebUrl = webUrl,
          Connected = connected,
          Enabled = enabled,
          Authorized = authorized
      };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "agent"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Id, ref currentFields, "id");

      FieldHelper.AddField(Name, ref currentFields, "name");

      FieldHelper.AddField(Href, ref currentFields, "href");

      FieldHelper.AddField(TypeId, ref currentFields, "typeId");

      FieldHelper.AddField(WebUrl, ref currentFields, "webUrl");
      
      FieldHelper.AddField(Connected, ref currentFields, "connected");
      
      FieldHelper.AddField(Enabled, ref currentFields, "enabled");
      
      FieldHelper.AddField(Authorized, ref currentFields, "authorized");

      return currentFields;
    }

    #endregion
  }
}