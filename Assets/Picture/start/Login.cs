using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using SimpleJSON;

public class Login : MonoBehaviour
{
    public GameObject username;
    public GameObject password;
    private string Username;
    private string Password;
    private string[] Lines;
   // private string DecryptedPass;

    public void LoginButton()
    {
        bool UN = false;
        bool PW = false;
        if (Username != "")
        {
            UN = true;
        }
        else
        {
            Debug.LogWarning("Username is Empty");
        }
        if (Password != "")
        {
            PW = true;
        }
        else
        {
            Debug.LogWarning("Password is Empty");
        }
        if (UN == true && PW == true)
        {
            WWWForm form = new WWWForm(); //here you create a new form connection
            form.AddField("username", Username); //add your hash code to the field myform_hash, check that this variable name is the same as in PHP file
            form.AddField("password", Password);
            StartCoroutine(FinishDownload(form));
     
        }
    }

    IEnumerator FinishDownload(WWWForm form)
    {
        WWW w = new WWW("http://angsila.cs.buu.ac.th/~58660001/pet/login.php", form);


        yield return w;
        if (w.error != null)
        {
            print(w.error); //if there is an error, tell us
        }
        else
        {
            print("connection ok");
            print(w.data);
            var N = JSON.Parse(w.data);
            if (N["status"].Value.Equals("1"))
            {
                w.Dispose(); //clear our form in game
                username.GetComponent<InputField>().text = "";
                password.GetComponent<InputField>().text = "";
                print("Login Sucessful");
                PauseGame p = new PauseGame(w.data);
                p.setItem(w.data);
                Application.LoadLevel("mainGame");
            } else
            {
                username.GetComponent<InputField>().text = "";
                password.GetComponent<InputField>().text = "";
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
                password.GetComponent<InputField>().Select();
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (Password != "" && Password != "")
            {
                LoginButton();
            }
        }
            Username = username.GetComponent<InputField>().text;
            Password = password.GetComponent<InputField>().text;
        
    }
}