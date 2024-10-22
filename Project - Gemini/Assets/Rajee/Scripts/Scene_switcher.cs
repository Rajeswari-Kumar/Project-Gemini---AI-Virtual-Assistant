using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scene_switcher : MonoBehaviour
{
    public void scene_switch(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
