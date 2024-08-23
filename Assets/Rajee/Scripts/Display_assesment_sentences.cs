using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Display_assesment_sentences : MonoBehaviour
{
    public TMP_Text sentences;
    public Autism_assessment sentence_access;
    // Start is called before the first frame update
    private void Start()
    {
        string combinedString = string.Join("\n", sentence_access.stringInputs);
        sentences.text = combinedString;
    }
}
