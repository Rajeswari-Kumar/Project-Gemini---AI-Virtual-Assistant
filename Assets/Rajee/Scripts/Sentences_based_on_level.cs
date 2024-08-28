using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level_based_sentences", menuName = "Sentences_based")]
public class Sentences_based_on_level : ScriptableObject
{
    public static Sentences_based_on_level instance_for_level;
    [SerializeField] public List<string> stringInputs_for_begginer = new List<string>();
    [SerializeField] public List<string> stringInputs_for_intermediate = new List<string>();
    [SerializeField] public List<string> stringInputs_for_advanced = new List<string>();
}
