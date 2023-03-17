using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public Button startbutton;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        startbutton.onClick.AddListener(StartbuttonClicked);
    }
    void StartbuttonClicked()
    {
        SceneManager.LoadScene("Prison level utomhus");
        Debug.Log("click");
    }
}
