using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject mainMenuUI;
    public GameObject loginUI;
    public GameObject registerUI;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else if(instance != null)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this.gameObject);
        }
    }

    public void LoginScreen()
    {
        loginUI.SetActive(true);
        mainMenuUI.SetActive(false);
        registerUI.SetActive(false);
    }

    public void registerScreen()
    {
        registerUI.SetActive(true);
        loginUI.SetActive(false);
        mainMenuUI.SetActive(false);   
    }
}
