using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using Unity.VisualScripting;
using UnityEngine.UI;
using Player;

public class AIIntegration : MonoBehaviour
{     
    public static AIIntegration Instance { get; private set; }
    public Transform SoruPaneli;
    public Text GPTCevap;
    private string apiKey = "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";
    private string apiUrl = "https://api.openai.com/v1/completions";
        
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
             else
            {
                Instance = this;
             }
        }
        
        public void StartAskQuestion()
        {         
            Transform soruText = SoruPaneli.GetChild(0);
            string question = soruText.GetComponent<Text>().text;

            StartCoroutine(AskQuestion(question, response => 
            {
                GPTCevap.text = response;
            }));
        }
            public IEnumerator AskQuestion(string question, System.Action<string> onResponse)
            { 
               
                var json = new
                {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new { role = "user", content = question }
                },
                max_tokens = 100
            };

           string jsonData = "{\"model\":\"gpt-3.5-turbo\",\"messages\":[{\"role\":\"user\",\"content\":\"" + question + "\"}],\"max_tokens\":100}";
            UnityWebRequest request = new UnityWebRequest("https://api.openai.com/v1/chat/completions", "POST");
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", $"Bearer {apiKey}");

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                string response = request.downloadHandler.text;
                onResponse(response);
            }
         else
            {
             Debug.LogError(request.downloadHandler.text);
            }
        }

}

