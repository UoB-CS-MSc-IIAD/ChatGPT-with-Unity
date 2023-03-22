using Singletons;
using Newtonsoft.Json;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class ChatGPTClient : Singleton<ChatGPTClient>
{
    [SerializeField]
    private ChatGTPSettings chatGTPSettings;

    public IEnumerator Ask(string prompt, Action<ChatGPTResponse> callBack)
    {
        var url = chatGTPSettings.debug ? $"{chatGTPSettings.apiURL}?debug=true" : chatGTPSettings.apiURL;

        using(UnityWebRequest request = new UnityWebRequest(url, "POST"))
        {
            var requestParams = JsonConvert.SerializeObject(new ChatGPTRequest // creates a JSON string from a ChatGPTRequest object
            {
                // Question = prompt
                // The ChatGPTRequest object should be constructed with Model, Messages
                // The Messages array contains a single ChatGPTMessage object with the following properties:
                // Role: set to "user" to indicate that the message is coming from the user
                // Content: a string that contains the message prompt to send to the ChatGPT API.
            });

            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(requestParams);
            
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.disposeDownloadHandlerOnDispose = true;
            request.disposeUploadHandlerOnDispose = true;
            request.disposeCertificateHandlerOnDispose = true;

            request.SetRequestHeader("Content-Type", "application/json");

            // set the necessary headers to authenticate against OpenAI API


            var requestStartDateTime = DateTime.Now;

            yield return request.SendWebRequest();

            if(request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.DataProcessingError)
            {
                Debug.Log(request.error);
            }
            else
            {
                string responseInfo = request.downloadHandler.text;
                var response = JsonConvert.DeserializeObject<ChatGPTResponse>(responseInfo)
                    .CodeCleanUp();

                response.ResponseTotalTime = (DateTime.Now - requestStartDateTime).TotalMilliseconds;

                callBack(response);
            }
        }
    }
}