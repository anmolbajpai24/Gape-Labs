using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;



public class PlayFabManager : MonoBehaviour
{
    public InputField email;
    public InputField pass;
    public Text message;
   
    public void RegisterButton()
    {
        var request = new RegisterPlayFabUserRequest
        {
            Email = email.text, Password = pass.text, RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
        
    }

    public void LoginButton()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = email.text, Password = pass.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }

    void OnLoginSuccess(LoginResult result)
    {
        message.text = "Logged In";
        SceneManager.LoadScene(1);
    }

    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        message.text = "REGISTERED";
        
    }

    void OnError(PlayFabError error)
    {
        message.text = "Error: " + error.ErrorMessage;
        Debug.Log(error.ErrorMessage);
    }




}
