using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ConnectionManager : MonoBehaviour
{
    public CommunicationManager communicationManager;
    
    public static ConnectionManager Instance;
   
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
       communicationManager.Init();
       communicationManager.StartConnection();
    }

    private void OnDisable()
    {
        communicationManager.StopConnection();
    }
    
    public void WriteValue(byte[] dataToSend)
    {
        communicationManager.WriteValue(dataToSend);
    }
}
