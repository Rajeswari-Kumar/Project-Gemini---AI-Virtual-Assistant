using JetBrains.Annotations;
using Meta.WitAi.TTS.UX;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Flow_of_conversation : MonoBehaviour
{
    [SerializeField] public List<string> Player_script = new List<string>();
    public Talk_with_player frnd_script;
    public Animator friend;
    [SerializeField] Text text;
    [SerializeField] InputField texts;
    [SerializeField] Button speak;
    int i = 0;
    void Start()
    {
        dialogue_display(Player_script[0]);
    }

    public void talk_flow(string[] values)
    {
        var string1 = values[0];
        var string2 = values[1];

        foreach(string dialogue in Player_script)
        {
            if (dialogue.Equals(values[i],System.StringComparison.OrdinalIgnoreCase))
            {
                //Debug.Log("jhgjsjas");
                texts.text = frnd_script.friend_script[i];
                dialogue_display(Player_script[i + 1]);
                speak.onClick.Invoke();
                StartCoroutine(animator_setter());
                i++;
                break;

                Debug.Log("dialogue " + dialogue);
                Debug.Log(frnd_script.friend_script[i]);
            }
        }
    }

    IEnumerator animator_setter()
    {
        yield return new WaitForSeconds(1);
        friend.SetBool("Talking", true);
        yield return new WaitForSeconds(5);
        friend.SetBool("Talking", false);
    }

    public void dialogue_display(string Text)
    {
        text.text = Text;
        
    }
}
