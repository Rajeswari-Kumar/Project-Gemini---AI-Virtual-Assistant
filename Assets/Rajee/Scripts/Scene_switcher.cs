using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scene_switcher : MonoBehaviour
{
    public void Assesment(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    public void Practice(string scenename)
    {
        //SceneManager.LoadScene(scenename);
    }
    public void Simulated_scenario(string scenename)
    {
        //SceneManager.LoadScene(scenename);
    }
    public void Ask_gemini(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
     
    public void Go_home(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
