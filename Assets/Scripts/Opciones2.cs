using UnityEngine;
using System.Collections;

public class Opciones2 : MonoBehaviour {
	public static int piedras = 0;
	public GUISkin miSkin;
    public GameObject panelNPC;
    void OnGUI(){
		GUI.skin = miSkin;


		if (Mision2.misionSegunda) { 
			GUI.Label(new Rect(Screen.width / 2 - 20, 20, 150, 30), piedras + "/9");
		}
		if(piedras == 9)
		{
            panelNPC.SetActive(true);
        }
			
	}
    void Start()
    {
        panelNPC.SetActive(false);
    }
}
