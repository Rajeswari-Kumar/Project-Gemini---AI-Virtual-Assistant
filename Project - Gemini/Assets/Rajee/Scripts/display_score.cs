using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class display_score : MonoBehaviour
{
    public TMP_Text score;
    public Autism_level level;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score.text = level.Level_display.ToString();
    }
}
