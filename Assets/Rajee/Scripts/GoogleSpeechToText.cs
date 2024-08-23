using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using UnityEngine.UI;
//using Oculus.Voice.Windows;

public class GoogleSpeechToText : MonoBehaviour
{
    public Text outputText; // UI Text to display the transcription result
    private string apiKey = "AIzaSyB0daDBBWXRb73iFfrFain9UwbvMqnwDzc"; // Replace with your API key
    private string serviceAccountJson;
    [SerializeField] int responseTime = 10;
    void Start()
    {
         //Load service account JSON (optional, for complex setups)
         serviceAccountJson = File.ReadAllText("Assets/Rajee/Assets/Google_API.json");

        // Start microphone and record audio
       
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(StartRecording());
        }
    }
    IEnumerator StartRecording()
    {
        // Start recording from the microphone
        AudioClip audioClip = Microphone.Start(null, false, 10, 16000);
        yield return new WaitForSeconds(responseTime);
        Microphone.End(null);

        // Convert audio clip to byte array
        byte[] audioData = ConvertAudioClipToByteArray(audioClip);

        // Create a request to Google Cloud Speech-to-Text API
        string url = $"https://speech.googleapis.com/v1/speech:recognize?key={apiKey}";

        // JSON payload
        // string jsonPayload = $"{{'config': {{'encoding': 'LINEAR16','sampleRateHertz': 16000,'languageCode': 'en-US'}},'audio': {{'content': '{System.Convert.ToBase64String(audioData)}'}}}}";
        string jsonPayload = $"{{\"config\": {{\"encoding\": \"LINEAR16\",\"sampleRateHertz\": 16000,\"languageCode\": \"hi-IN\"}},\"audio\": {{\"content\": \"{System.Convert.ToBase64String(audioData)}\"}}}}";

        // Send the request
        using (UnityWebRequest www = UnityWebRequest.Post(url, "POST"))
        {
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(jsonPayload);
            www.uploadHandler = new UploadHandlerRaw(jsonToSend);
            www.downloadHandler = new DownloadHandlerBuffer();
            www.SetRequestHeader("Content-Type", "application/json");

            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                //Debug.Log("google " + www.downloadHandler.text);
                // Process the JSON response
                ProcessResponse(www.downloadHandler.text);
            }
        }
    }

    private byte[] ConvertAudioClipToByteArray(AudioClip clip)
    {
        float[] samples = new float[clip.samples * clip.channels];
        clip.GetData(samples, 0);
        short[] intData = new short[samples.Length];
        byte[] bytesData = new byte[samples.Length * 2];
        int rescaleFactor = 32767; // to convert float to Int16

        for (int i = 0; i < samples.Length; i++)
        {
            intData[i] = (short)(samples[i] * rescaleFactor);
            byte[] byteArr = new byte[2];
            byteArr = System.BitConverter.GetBytes(intData[i]);
            byteArr.CopyTo(bytesData, i * 2);
        }

        return bytesData;
    }

    private void ProcessResponse(string jsonResponse)
    {
        var responseObj = JsonUtility.FromJson<GoogleCloudResponse>(jsonResponse);
        if (responseObj.results.Length > 0)
        {
            outputText.text = responseObj.results[0].alternatives[0].transcript;
        }
    }

    [System.Serializable]
    public class GoogleCloudResponse
    {
        public Result[] results;
    }

    [System.Serializable]
    public class Result
    {
        public Alternative[] alternatives;
    }

    [System.Serializable]
    public class Alternative
    {
        public string transcript;
    }
}
