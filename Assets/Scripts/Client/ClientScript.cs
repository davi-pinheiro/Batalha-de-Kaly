using WebSocketSharp;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClientScript : MonoBehaviour
{
    WebSocket ws;
    string email, username, password;
    // Start is called before the first frame update

    public void GetCredentials(string email, string username, string password)
    {
        this.email = email;
        this.username = username;
        this.password = password;
    } 

    void Start()
    {
        ws = new WebSocket("ws://localhost:3000");

        ws.OnOpen += (sender, e) =>
        {
            Debug.Log("Hello" + ((WebSocket)sender).Url);
        };

        ws.OnMessage += (sender, e) =>
        {
            Debug.Log("Message received from" + ((WebSocket)sender).Url + e.Data);
        };
        ws.Connect();
    }

    // Update is called once per frame
    void Update()
    {
        if (ws == null)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
            {
                ws.Send(email + "\n" + username + "\n" + password);
            }
    }
}
