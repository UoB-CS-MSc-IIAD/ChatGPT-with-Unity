using UnityEngine;

[CreateAssetMenu(fileName = "ChatGPTSettings", menuName = "ChatGPT/ChatGPTSettings")]
public class ChatGTPSettings : ScriptableObject
{
    // Store API-related information, such as the API URL, API key, organization, and model


    public string apiURL;

    public string apiKey;

    public bool debug;

    public string[] reminders;
}
