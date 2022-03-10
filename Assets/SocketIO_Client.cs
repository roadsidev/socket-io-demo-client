using UnityEngine;
using BestHTTP.SocketIO3;
using System;

public class SocketIO_Client : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var manager = new SocketManager(new Uri("http://www.chrisbenz.dev:3000"));

        // Accessing the root ("/") socket
        var root = manager.Socket;

        // or calling GetSocket triggers the connection procedure.
        var customNamespace = manager.GetSocket("/my_namespace");
        manager.Socket.On("connect", () => 
            manager.Socket.Emit("message", "Hello, I'm connected!")
        );

        manager.Socket.On("message", () => Debug.Log("test"));

// At this point the manager already started to connect to the server
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
