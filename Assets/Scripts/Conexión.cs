using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Net;
using System.IO;
using UnityEngine.SceneManagement;

[System.Serializable]
public class User
{
   // public int userId; // 
    public string usuario;
    public string password;
}

public class UserList
{
    public List<User> users;
}

public class Conexión : MonoBehaviour
{
    public InputField usuarioInputField;
    public InputField passwordInputField;
    public Button loginButton;
    public Text messageText;
    public Canvas MenuInicial;

    private List<User> users = new List<User>();

    
    void Start()
    {
        loginButton.onClick.AddListener(Login);

        GetHttpsData();
    }

    public void GetHttpsData()
    {
        try
        {
            string url = "http://www.ecobovinos.somee.com/api/User";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                string jsonResponse = reader.ReadToEnd();
                Debug.Log(jsonResponse);

                UserList userList = JsonUtility.FromJson<UserList>("{\"users\":" + jsonResponse + "}");

                users = userList.users;
            }
            else
            {
                Debug.LogError("Failed to get data. Status Code: " + response.StatusCode);
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error:" + e.Message);
        }
    }
    IEnumerator ShowMessageAndSwitchCanvas(float delay)
    {
        messageText.text = "¡Inicio de sesión exitoso!";
        yield return new WaitForSeconds(delay);

        
        gameObject.SetActive(false); 
                                     
        MenuInicial.gameObject.SetActive(true); 
    }
    public void Login()
    {
        string usuario = usuarioInputField.text;
        string password = passwordInputField.text;

        bool usuarioAutenticado = false;

        foreach (User user in users)
        {
            if (user.usuario == usuario && user.password == password)
            {
                usuarioAutenticado = true;
                StartCoroutine(ShowMessageAndSwitchCanvas(1.5f)); 
                Debug.Log("Usuario autenticado: " + usuario);
                
               
            }
        }

        if (!usuarioAutenticado)
        {
            
            messageText.text = "Usuario o contraseña incorrectos.";
            Debug.LogWarning("Usuario o contraseña incorrectos.");
        }
    }
}