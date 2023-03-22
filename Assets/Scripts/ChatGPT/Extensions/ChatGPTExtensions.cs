using System.Linq;

public static class ChatGPTExtensions
{
    public const string KEYWORD_USING = "using UnityEngine";
    public const string KEYWORD_PUBLIC_CLASS = "public class";
    public static readonly string[] filters = { "C#", "c#","csharp","CSHARP" };

    public static ChatGPTResponse CodeCleanUp(this ChatGPTResponse chatGPTResponse)
    {

        return chatGPTResponse;
    }
}