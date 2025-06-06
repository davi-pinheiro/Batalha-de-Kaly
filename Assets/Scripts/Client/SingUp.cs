using UnityEngine;
using TMPro;
using System;
using EmailValidation;
using UnityEngine.UIElements;
using TMPro.EditorUtilities;
using UnityEngine.SceneManagement;

public class SingUp : MonoBehaviour
{
    int state = 0;

    [SerializeField] TMP_InputField email;
    [SerializeField] TMP_InputField username;
    [SerializeField] TMP_InputField password;
    [SerializeField] TMP_InputField password_confirm;
    [SerializeField] TMP_Text email_address_warning;
    [SerializeField] TMP_Text user_password_warning;
    [SerializeField] GameObject start;
    [SerializeField] GameObject email_address;
    [SerializeField] GameObject user_password;

    void Start()
    {
        start.SetActive(true);
        email_address.SetActive(false);
        user_password.SetActive(false);
    }
    bool Check_User()
    {
        if (username.text == "")
        {
            user_password_warning.text = "Missing usename";
            return false;
        }
        else
        {
            return true;
        }
    }

    bool Check_Password()
    {

        if (password.text == "")
        {
            user_password_warning.text = "Enter password";
            return false;
        }
        else if (password_confirm.text == "")
        {
            user_password_warning.text = "Invalid password confirm";
            return false;
        }
        else
        {
            if (password.text == password_confirm.text)
            {
                return true;
            }
            else
            {
                user_password_warning.text = "Invalid password";
                return false;
            }
        }

        
    }

    public void Change_State(int value)
    {
        if (value < 3)
        {
            state = value;
        }
    }

    public void Email_Validation()
    {
        bool isEmailValid = EmailValidator.Validate(email.text);

        if (isEmailValid)
        {
            email_address_warning.text = "";
            email_address.SetActive(false);
            user_password.SetActive(true);
            Change_State(2);
        }
        else
        {
            email_address_warning.text = "Invalid email address";
            Change_State(1);
        }
    }

    public void Password_Validation()
    {
        bool isUserValid, isPasswordValid;

        isUserValid = Check_User();

        isPasswordValid = Check_Password();

        if (isUserValid && isPasswordValid)
        {
            user_password.SetActive(false);
            SceneManager.LoadScene("Global Lobby");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            switch (state)
            {
                case 0:
                    Change_State(1);
                    start.SetActive(false);
                    email_address.SetActive(true);
                    break;
                case 1:
                    Change_State(2);
                    Email_Validation();
                    break;
                case 2:
                    Password_Validation();
                    break;
                default:
                    break;
                
            }
        }
    }
}