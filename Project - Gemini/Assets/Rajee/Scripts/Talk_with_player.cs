using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Talk_with_player : MonoBehaviour
{
    public GameObject player;
    public int checkDistance = 5;
    [SerializeField] public List<string> friend_script = new List<string>();
    
    void Start()
    {
        
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= checkDistance)
        {
            //Debug.Log("Player is within range!");
        }
    }
}
