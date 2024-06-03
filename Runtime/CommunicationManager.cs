using System;
using UnityEngine;
using UnityEngine.Events;


    [Serializable] public class OnConnectStatus : UnityEvent<bool>
    {
    }
    
    [Serializable] public class OnReadValue : UnityEvent<string>
    {
    }

    public abstract class CommunicationManager : MonoBehaviour
    {
        protected bool isConnected;
        
        [Header("Connection Settings")]
        [Space(10)]
        [SerializeField] protected string deviceToConnect;

        [Header("Events")]
        [Space(10)]
        [SerializeField] public OnConnectStatus OnConnectStatus;
        [Space(10)]
        [SerializeField] public OnReadValue OnReadValue;
        public virtual void Init()
        {
            Debug.Log("Serial communication initialized");
        }
        
        public virtual void StartConnection()
        {
            Debug.Log("Serial connection started");
        }
        
        public virtual void StopConnection()
        {
            Debug.Log("Serial connection stopped");
        }
        
        protected void ConnectStatus(string status)
        {
            Debug.Log("Connection Status: " + status);
            isConnected = status == "connected";
            OnConnectStatus.Invoke(isConnected);
        }
        
        protected void ReadValue(string data)
        {
            Debug.Log("Data received: " + data);
            OnReadValue.Invoke(data);
        }
        
        public virtual void WriteValue(byte[] dataToSend)
        {
            Debug.Log("Data sent: " + dataToSend);
        }
    }