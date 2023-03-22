using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using System.Collections;
using UnityEngine;


public class ChatGPTResponse
{
    // ID, object type, creation time, list of response choices, and usage statistics
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("object")]
    public string Object { get; set; }

    [JsonProperty("created")]
    public int Created { get; set; }

    [JsonProperty("choices")]
    public List<ChatGPTChoice> Choices { get; set; }

    [JsonProperty("usage")]
    public ChatGPTUsage Usage { get; set; }

    public double ResponseTotalTime { get; set; }
}


public class ChatGPTMessage
{
    // the role (e.g. "user" or "bot") and content (the actual message)
}

public class ChatGPTChoice
{
    // the choice index, message (a ChatGPTMessage object), and a finish reason
}

public class ChatGPTUsage
{
    //the number of tokens used for the prompt, completion, and total
}