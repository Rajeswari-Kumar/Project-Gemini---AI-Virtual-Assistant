using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(fileName = "Autism_level_indicator", menuName = "Level_data")]
public class Autism_level : ScriptableObject
{
    public static Autism_level instance;
    public int Autism_level_score = 0;
    public int Level_display = 0;
}
