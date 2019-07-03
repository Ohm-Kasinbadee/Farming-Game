using UnityEngine;
using System.Collections;

public class Loadstart : MonoBehaviour
{
    public void starting(string name)
    {
        Application.LoadLevel("login menu");
    }
}
