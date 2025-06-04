using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Unity.VisualScripting;
using System.Linq;

public class SingUp : MonoBehaviour
{
    bool valid = false;
    string special_characters = "!#$%&'*+-/=?^_{|}~`.";
    string email_username, email_domain;
    [SerializeField] TMP_InputField email;
    [SerializeField] TMP_InputField username;
    [SerializeField] TMP_InputField password;
    [SerializeField] TMP_InputField password_confirm;

    [SerializeField] TMP_Text warning;

    bool initial_or_final_dot_constraint()
    {
        email_username = email.text.Substring(0, email.text.IndexOf('@'));

        if (email_username[0] == special_characters[1] || email_username[email_username.Length - 1] == special_characters[1])
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    bool consecutive_special_characters_constraint()
    {
        for (int i = 0; i < email_username.Length; i++)
        {
            for (int j = 0; j < special_characters.Length; j++)
            {
                if (email_username[i] == special_characters[j])
                {
                    for (int k = 0; k < special_characters.Length; k++)
                    {
                        if (i == 0)
                        {
                            if (email_username[i + 1] == special_characters[k])
                            {
                                return false;
                            }
                        }
                        else if (i == email_username.Length - 1)
                        {
                            if (email_username[i - 1] == special_characters[k])
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (email_username[i + 1] == special_characters[k] ||
                                email_username[i - 1] == special_characters[k])
                            {
                                return false;
                            }
                        }
                    }
                }
            }
                
            //a-a-b-.a
        }
        return true;
    }

    bool validate_email_username()
    {
        if (initial_or_final_dot_constraint() &&
            consecutive_special_characters_constraint())
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    bool validate_email_domain()
    {
        email_domain = email.text.Substring(email.text.IndexOf('@') + 1);
        return true;
    }

    public void validate_email()
    {
        validate_email_username();
        validate_email_domain();

        if (email.text.Contains('@'))
        {
            if (validate_email_username() && validate_email_domain())
            {
                valid = true;
            }
            else
            {
                valid = false;
            }
        }
        else
        {
            valid = false;
        }

        if (valid == false)
        {
            warning.text = "Email inválido";
        }
        else
        {
            warning.text = "";
        }

        Debug.Log(valid);
    }
}