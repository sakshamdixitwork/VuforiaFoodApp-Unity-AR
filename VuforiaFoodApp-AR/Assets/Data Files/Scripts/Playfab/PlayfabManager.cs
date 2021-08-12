using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;

public class PlayfabManager : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text outputMessage;
    public TMP_Text successfulMessage;

    [Header("Register")]
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public TMP_InputField confirmPasswordInput;

    [Header("Login")]
    public TMP_InputField emailLoginInput;
    public TMP_InputField passwordLoginInput;

    public void RegisterButton()
    {
        ClearMessage();

        if (passwordInput.text.Length < 6)
        {
            outputMessage.text = "Password too short!";
            return;
        }
        else if (passwordInput.text != confirmPasswordInput.text)
        {
            outputMessage.text = "Password does not match!";
            return;
        }
        else if(passwordInput.text == "" || emailInput.text == "" || confirmPasswordInput.text == "")
        {
            outputMessage.text = "Empty Field!";
            return;
        } 
        
        var request = new RegisterPlayFabUserRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
        
    }

    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        ClearMessage();
        successfulMessage.text = "Registered";
        //SceneManager.LoadScene("AR");
        
    }

    public void LoginButton()
    {
        if(emailLoginInput.text == "" || passwordLoginInput.text == "")
        {
            ClearMessage();
            outputMessage.text = "Empty Field!";
        } 
        else
        {
            var request = new LoginWithEmailAddressRequest
            {
                Email = emailLoginInput.text,
                Password = passwordLoginInput.text,
            };
            PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
        }
        
    }

    void OnLoginSuccess(LoginResult result)
    {
        ClearMessage();
        successfulMessage.text = "Logged In!";
        SceneManager.LoadScene("AR");
        Debug.Log("Successfull login/account create!");
    }

    public void ResetPasswordButton()
    {
        if(emailLoginInput.text == "")
        {
            ClearMessage();
            outputMessage.text = "Enter E-Mail to reset password!";
            return;
        }
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = emailLoginInput.text,
            TitleId = "C7733"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnError);
    }

    void OnPasswordReset(SendAccountRecoveryEmailResult result)
    {
        ClearMessage();
        successfulMessage.text = "Password reset mail sent!";
    }

    void OnError(PlayFabError error)
    {
        ClearMessage();
        outputMessage.text = error.ErrorMessage;
        Debug.Log(error.GenerateErrorReport());
    }

    void ClearMessage()
    {
        outputMessage.text = "";
        successfulMessage.text = "";
    }

    /*
    private void Start()
    {
        Login();
    }

    

    void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }

    
    */
    
}
