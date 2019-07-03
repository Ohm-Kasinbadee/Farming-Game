using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using SimpleJSON;

public class Register : MonoBehaviour
{
    public GameObject username;
    public GameObject email;
    public GameObject password;
    public GameObject confpassword;
    private string Username;
    private string Email;
    private string Password;
    private string ConfPassword;
    private string form;
    private bool EmailValid = false;
    private string[] Characters = {"a","b","c","d","e","f","g","h","i","j","k","l","n","m","o","p","q","r","s","t","u","v","w","x","y","z",
                                   "A","B","C","D","E","F","G","H","I","J","K","L","N","M","O","P","Q","R","S","T","U","V","W","X","Y","Z",
                                   "1","2","3","4","5","6","7","8","9","0","_","-"};

    public void RegisterButton()
    {
        bool UN = false;
        bool EM = false;
        bool PW = false;
        bool CPW = false;

        if (Username != "")
        {
            UN = true;
        }
        else
        {
            Debug.LogWarning("Username field Empty");
        }

        if (Email != "")
        {
            EmailValidation();
            if (EmailValid)
            {
                if (Email.Contains("@"))
                {
                    if (Email.Contains("."))
                    {
                        EM = true;
                    }
                    else
                    {
                        Debug.LogWarning("Email is Incorrect");
                    }
                }
                else
                {
                    Debug.LogWarning("Email is Incorrect");
                }
            }
            else
            {
                Debug.LogWarning("Email is Incorrect");
            }
        }
        else
        {
            Debug.LogWarning("Email Fail Empty");
        }

        if (Password != "")
        {
            if (Password.Length > 5)
            {
                PW = true;
            }
            else
            {
                Debug.LogWarning("Password Must Be atleast 6 Characters long");
            }
        }
        else
        {
            Debug.LogWarning("Password Fail Empty");
        }

        if (ConfPassword != "")
        {
            if (ConfPassword == Password)
            {
                CPW = true;
            }
            else
            {
                Debug.LogWarning("Password Don't Match");
            }
        }
        else
        {
            Debug.LogWarning("Confirm Password Faild Empty");
        }
        if (UN == true && EM == true && PW == true && CPW == true)
        {
            bool Clear = true;
            int i = 1;

            WWWForm form = new WWWForm(); //here you create a new form connection
            form.AddField("username", Username); //add your hash code to the field myform_hash, check that this variable name is the same as in PHP file
            form.AddField("password", Password);
            form.AddField("email", Email);
            StartCoroutine(FinishDownload(form));
            /*
            username.GetComponent<InputField>().text = "";
            email.GetComponent<InputField>().text = "";
            password.GetComponent<InputField>().text = "";
            confpassword.GetComponent<InputField>().text = "";
            print("Registration Complete");
            */
        }
    }

    IEnumerator FinishDownload(WWWForm form)
    {
        WWW w = new WWW("http://angsila.cs.buu.ac.th/~58660001/pet/register.php", form);

        yield return w;
        if (w.error != null)
        {
            print(w.error); //if there is an error, tell us
        }
        else
        {
            print("Test ok");
            print(w.data);
            var N = JSON.Parse(w.data);
            if (N["status"].Value.Equals("1"))
            {
                w.Dispose(); //clear our form in game
                username.GetComponent<InputField>().text = "";
                email.GetComponent<InputField>().text = "";
                password.GetComponent<InputField>().text = "";
                confpassword.GetComponent<InputField>().text = "";
                print("Registration Complete");
                
                // Application.LoadLevel("mainGame");
            }
            else
            {
                username.GetComponent<InputField>().text = "";
                email.GetComponent<InputField>().text = "";
                password.GetComponent<InputField>().text = "";
                confpassword.GetComponent<InputField>().text = "";
            }
        }
        //Work with the retrieved info.

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (username.GetComponent<InputField>().isFocused)
            {
                email.GetComponent<InputField>().Select();
            }
            if (email.GetComponent<InputField>().isFocused)
            {
                password.GetComponent<InputField>().Select();
            }
            if (password.GetComponent<InputField>().isFocused)
            {
                confpassword.GetComponent<InputField>().Select();
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (Password != "" && Email != "" && Password != "" && ConfPassword != "")
            {
                RegisterButton();
            }
        }
        Username = username.GetComponent<InputField>().text;
        Email = email.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
        ConfPassword = confpassword.GetComponent<InputField>().text;

    }

    void EmailValidation()
    {
        bool SW = false;
        bool EW = false;
        for (int i = 0; i < Characters.Length; i++)
        {
            if (Email.StartsWith(Characters[i]))
            {
                SW = true;
            }
        }
        for (int i = 0; i < Characters.Length; i++)
        {
            if (Email.EndsWith(Characters[i]))
            {
                EW = true;
            }
        }
        if (SW == true && EW == true)
        {
            EmailValid = true;
        }
        else
        {
            EmailValid = false;
        }
    }
}
