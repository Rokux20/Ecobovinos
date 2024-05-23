using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class LogicaNPC : MonoBehaviour
{

    public GameObject simboloMision;
    public PlayerMove jugador;
    public GameObject panelNPC;
    public GameObject panelNPC2;
    public GameObject panelNPCMision;
    public TextMeshProUGUI textoMision;
    public bool jugadorCerca;
    public bool aceptarMision;
    public GameObject[] objetivos;
    public int numDeObjetivos;
    public GameObject botonDeMision;



    void Start() 
    { 
       numDeObjetivos= objetivos.Length;
        textoMision.text = "Obten las Partes de los paneles y los molinos" +
                    "\n Restantes: " + numDeObjetivos;
       jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
       simboloMision.SetActive(true);
       panelNPC.SetActive(false);
    }


     void Update()
    {
        if(Input.GetKeyDown(KeyCode.X) && aceptarMision== false )
        {
            Vector3 posicionJugador = new Vector3(transform.position.x, jugador.gameObject.transform.position.y,transform.position.z);
            jugador.gameObject.transform.LookAt(posicionJugador);


            jugador.animator.SetFloat("VelX", 0);
            jugador.animator.SetFloat("VelY", 0);
            jugador.enabled = false;
            panelNPC.SetActive(false);
            panelNPC2.SetActive(true);
        }
    }

      void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            jugadorCerca = true;
            if (aceptarMision == false)
            {
                panelNPC.SetActive(true);
            }
        }

    }


    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            jugadorCerca = false;

            panelNPC.SetActive(false);
            panelNPC2.SetActive(false);
        }
    }
    public void No()
    {
        jugador.enabled = true;
        panelNPC2.SetActive(false);
        panelNPC.SetActive(true);
    }


    public void Si()
    {
        jugador.enabled = true;
        aceptarMision = true;
        for(int i = 0; i < objetivos.Length; i++)
        {
            objetivos[i].SetActive(true);
        }
        jugadorCerca = false;
        simboloMision.SetActive(false);
        panelNPC.SetActive(false);
        panelNPC2.SetActive(false);
        panelNPCMision.SetActive(true);
    }
}


