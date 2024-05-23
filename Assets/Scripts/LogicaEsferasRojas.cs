using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class LogicaEsferasRojas : MonoBehaviour
{
    public LogicaNPC LogicaNPC;
    public GameObject panelSolar; // Referencia al objeto del panel solar
    public GameObject barrera;
    public string apiUrl = "http://www.ecobovinos.somee.com/api/Game"; // URL de tu API
    public int gameId;
    public string partida;
    public int userId;
    public int farmId;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            LogicaNPC.numDeObjetivos--;
            LogicaNPC.textoMision.text = "Obten las partes faltantes" +
                                          "\n Restantes: " + LogicaNPC.numDeObjetivos;

            if (LogicaNPC.numDeObjetivos <= 0)
            {
                // Mostrar mensaje de misión completada
                string mensajeMisionCompletada = "Completaste la misión";
                LogicaNPC.textoMision.text = mensajeMisionCompletada;
                LogicaNPC.botonDeMision.SetActive(true);
                barrera.SetActive(false);

                ActivarMovimientoPanelSolar();

                // Enviar los datos a la API
                StartCoroutine(PostGameData(gameId, partida, userId, farmId));

                if (LogicaNPC.botonDeMision.activeSelf)
                {
                    string mensajeAprendizaje = "Los paneles solares son una forma de energía renovable que aprovecha la luz del sol para generar electricidad.";
                    ReemplazarMensaje(mensajeMisionCompletada, mensajeAprendizaje);
                }
            }

            transform.parent.gameObject.SetActive(false);
        }
    }

    void ReemplazarMensaje(string mensajeAnterior, string mensajeNuevo)
    {
        // Reemplaza el mensaje anterior por el nuevo
        LogicaNPC.textoMision.text = mensajeNuevo;
    }

    void ActivarMovimientoPanelSolar()
    {
        // Verificar si el objeto del panel solar y el componente Ventilador están asignados
        if (panelSolar != null)
        {
            // Obtener el componente Ventilador del panel solar
            Ventilador ventiladorPanelSolar = panelSolar.GetComponent<Ventilador>();
            // Verificar si el componente existe y activar el movimiento
            if (ventiladorPanelSolar != null)
            {
                ventiladorPanelSolar.ActivarMovimiento(); // Llamamos al método que activa el movimiento
            }
        }
    }

    IEnumerator PostGameData(int gameId, string partida, int userId, int farmId)
    {
        var datos = new
        {
            gameId = gameId,
            partida = partida,
            userId = userId,
            farmId = farmId
        };

        string json = JsonUtility.ToJson(datos);

        using (UnityWebRequest request = new UnityWebRequest(apiUrl, "POST"))
        {
            byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(json);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                UnityEngine.Debug.LogError("Error al enviar datos a la API: " + request.error);
            }
            else
            {
                UnityEngine.Debug.Log("Datos enviados exitosamente a la API: " + request.downloadHandler.text);
            }
        }
    }
}
