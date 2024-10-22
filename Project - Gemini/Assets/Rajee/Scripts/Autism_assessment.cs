using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;
using UnityEngine.TextCore.Text;
using TMPro.Examples;
public class Autism_assessment : MonoBehaviour
{
    private int i = 0;
    public int Normal_score;
    private int x;
    public TMP_Text text;
    public Autism_level level;

    [SerializeField] public List<string> stringInputs = new List<string>();
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
    
    public void test_score()
    {
        level.Autism_level_score = 10 - Normal_score;
        level.Level_display = level.Autism_level_score;
    }
}