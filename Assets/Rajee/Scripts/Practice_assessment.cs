using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;
using UnityEngine.TextCore.Text;
using TMPro.Examples;
public class Practice_assessment : MonoBehaviour
{
    private int i = 0;
    public int Normal_score;
    private int x;
    public TMP_Text text;
    public Sentences_based_on_level level;
    public Autism_level autism;
    public TMP_Text sentences;

    [SerializeField] public List<string> stringInputs = new List<string>();


    private void Start()
    {
        if (autism.Autism_level_score >= 8)
        {
            stringInputs = level.stringInputs_for_begginer;
        }
        else if (autism.Autism_level_score >= 5 && autism.Autism_level_score < 8)
        {
            stringInputs = level.stringInputs_for_intermediate;
        }
        else if (autism.Autism_level_score >= 0 && autism.Autism_level_score < 5)
        {
            stringInputs = level.stringInputs_for_advanced;
        }
        string combinedString = string.Join("\n", stringInputs);
        sentences.text = combinedString;
    }
    public void Assessment(string[] values)
    {
        var String0 = values[0];
        var String1 = values[1];
        var String2 = values[2];
        var String3 = values[3];

        foreach (string str in stringInputs)
        {
            i = 0;
            string[] words = str.Split();

            for (int j = 0; j < words.Length; j++)
            {
                if (words[j].Equals(values[i], System.StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Log(words[j] + " " + values[i] + " " + i);
                    x += 1;
                    i++;
                    break;
                }
                else
                    i++;
            }
            if (x == 3 || x == 4)
            {
                Debug.Log("match found");
                Normal_score += 1;
                x = 0;
                break;
            }

        }
        Debug.Log("Score " + Normal_score);
        text.text = Normal_score.ToString();

    }

    
}