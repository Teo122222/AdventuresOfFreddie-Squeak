using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    [SerializeField] string room;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetRoom(string newRoom)
    {
        room = newRoom;
    }
    
    public string GetRoom()
    {
        return room;
    }
}
