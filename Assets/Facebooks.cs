using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Facebook.Unity;
using SimpleJSON;

public class Facebooks : MonoBehaviour
{

    void Awake()
    {
        if (!FB.IsInitialized)
        {
            // Initialize the Facebook SDK
            FB.Init();
        }
        else
        {
            // Already initialized, signal an app activation App Event
            FB.ActivateApp();
        }
    }

    private void InitCallback()
    {
        if (FB.IsInitialized)
        {
            // Signal an app activation App Event
            FB.ActivateApp();
            // Continue with Facebook SDK
            // ...
        }
        else
        {
            Debug.Log("Failed to Initialize the Facebook SDK");
        }
    }

    public void LoginFacebook()
    {
        List<string> perms = new List<string>() { "public_profile", "email", "user_friends" };
        FB.LogInWithReadPermissions(perms, AuthCallback);
    }

    private void AuthCallback(ILoginResult result)
    {
        if (FB.IsLoggedIn)
        {
            // AccessToken class will have session details
            var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
            // Print current access token's User ID
            Debug.Log(aToken.UserId);
            // Print current access token's granted permissions
            foreach (string perm in aToken.Permissions)
            {
                Debug.Log(perm);
            }
            WWWForm form = new WWWForm(); //here you create a new form connection
            form.AddField("username", aToken.UserId); //add your hash code to the field myform_hash, check that this variable name is the same as in PHP file
            StartCoroutine(FinishDownload(form));
        }
        else
        {
            Debug.Log("User cancelled login");
        }
    }

    IEnumerator FinishDownload(WWWForm form)
    {
        WWW w = new WWW("http://angsila.cs.buu.ac.th/~58660001/pet/facebook.php", form);


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
                print("Login Sucessful");
                PauseGame p = new PauseGame(w.data);
                p.setItem(w.data);
                w.Dispose(); //clear our form in game
                Application.LoadLevel("mainGame");
            }
        }
        //Work with the retrieved info.

    }
}