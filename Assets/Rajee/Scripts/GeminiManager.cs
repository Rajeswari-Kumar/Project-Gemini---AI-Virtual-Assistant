using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.UI;

public class GeminiManager : MonoBehaviour
{
    public TMP_Text question;
    public InputField answer;

    [SerializeField] public string prompt;
    private string gasURL = "https://script.google.com/macros/s/AKfycby5i42R-Vwy0dsDVyn0cFOYHDya0aZTYPzoVz3s2DeSUy6UCtSNoCS98TSQpvZIO1ev/exec";


    private void Update()
    {
        prompt = question.text;
    }

    public void Calling()
    {
        StartCoroutine(SendDataToGAS());
    }

    private IEnumerator SendDataToGAS()
    {
        WWWForm form = new WWWForm();
        form.AddField("parameter", prompt);
        UnityWebRequest www = UnityWebRequest.Post(gasURL, form);

        yield return www.SendWebRequest();
        string response = "";

        if (www.result == UnityWebRequest.Result.Success)
        {
            response = www.downloadHandler.text;
        }
        else
        {
            response = "There is a error in connecting";
        }

        answer.text = response;
        //Debug.Log(response);
    }

}
