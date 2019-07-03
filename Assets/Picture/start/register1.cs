using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class register1 : MonoBehaviour {

    public Transform Button;
    public Transform login;
    public Transform start2;
    public Transform BG;
    public Transform BG2;

    public void start1()
    {
        Button.gameObject.SetActive(false);
        login.gameObject.SetActive(true);
        start2.gameObject.SetActive(false);
        BG.gameObject.SetActive(false);
        BG2.gameObject.SetActive(true);
    }

    public void button1()
    {
        Button.gameObject.SetActive(true);
        login.gameObject.SetActive(false);
    }

    public void button2()
    {
        Button.gameObject.SetActive(false);
        login.gameObject.SetActive(true);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
