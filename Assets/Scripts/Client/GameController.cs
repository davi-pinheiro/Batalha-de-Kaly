using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController game_controller;
    public ClientScript client;
    // Start is called before the first frame update

    string email, username, password;

    void Awake()
    {
        if (game_controller == null)
        {
            game_controller = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Change_Scene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void GetCredentials(string email, string username, string password)
    {
        client.GetCredentials(email, username, password);
    } 



}
