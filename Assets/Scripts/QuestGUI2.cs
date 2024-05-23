using UnityEngine;
using System.Collections;

public class QuestGUI2 : MonoBehaviour {
	public static bool activarQuest = false;
	private bool mediumQuest = false;
	private bool finishQuest = false;
	
	private bool _activar = false;
	
	public Rect firstQuest = new Rect (20, 20, 300, 350);
	
	public string nomMision = "";
	public string textMisionIncompleta = "";
	public string textMisionCompleta = "";
	public string textMision = "";
	public Texture2D rostroMis;
    
    public GUISkin miSkin;

    
    void OnGUI()
    {
        GUI.skin = miSkin;
        
        if (activarQuest || mediumQuest || finishQuest)
        {
			
            // Calcular la posición y el tamaño del panel en relación con las dimensiones de la pantalla
            float panelWidth = 500; // Ancho del panel
            float panelHeight = 400; // Altura del panel
            float posX = (Screen.width - panelWidth) / 2; // Posición X para centrar el panel horizontalmente
            float posY = (Screen.height - panelHeight) / 2; // Posición Y para centrar el panel verticalmente

            Rect centerRect = new Rect(posX, posY, panelWidth, panelHeight);

            if (activarQuest)
            {
                GUI.Window(0, centerRect, Quest, "Segunda Mision - " + nomMision);
            }
            else if (mediumQuest)
            {
                GUI.Window(0, centerRect, Quest_Incompleta, "Segunda en proceso");
            }
            else if (finishQuest)
            {
                GUI.Window(0, centerRect, Quest_Completa, "Segunda Completada - " + nomMision);
            }
        }
    }

    void Quest(int WindowID)
    {
        float panelWidth = 300; // Ancho del panel
        float panelHeight = 250; // Altura del panel
        float posX = 20; // Posición X para alinear el panel hacia la izquierda
        float posY = (Screen.height - panelHeight) / 2; // Posición Y para centrar el panel verticalmente

        GUI.BeginGroup(new Rect(posX, posY, panelWidth, panelHeight)); // Iniciar un nuevo grupo para el panel

        GUI.Label(new Rect(25, 25, 250, 150), textMision, "Box"); // Ajusta el tamaño del área del texto
        GUI.DrawTexture(new Rect(100, 5, 100, 100), rostroMis); // Ajusta la posición y el tamaño de la textura

        if (GUI.Button(new Rect(100, 180, 100, 30), "Continuar")) // Ajusta el tamaño y la posición del botón
        {
            activarQuest = true;
            mediumQuest = false;
            finishQuest = false;
            Mision2.misionSegunda = true;
        }

        GUI.EndGroup(); // Finalizar el grupo del panel
    }

    void Quest_Incompleta(int WindowID){
		GUI.Label(new Rect(50, 100, 200, 165), textMisionIncompleta, "Box");
		GUI.DrawTexture(new Rect(220, 55, 60, 60), rostroMis);
		
		if(GUI.Button(new Rect(150, 255, 100, 20), "Continuar")){
			activarQuest = false;
			mediumQuest = true;
			finishQuest = false;
			Mision2.misionSegunda = true;
		}
	}
	
	void Quest_Completa(int WindowID){
		GUI.Label(new Rect(50, 100, 200, 165), textMisionCompleta, "Box");
		GUI.DrawTexture(new Rect(220, 55, 60, 60), rostroMis);
		
		if(GUI.Button(new Rect(150, 255, 100, 20), "Continuar")){
			activarQuest = false;
			mediumQuest = false;
			finishQuest = true;
			Mision2.misionSegunda = false;
		}
	}
	
	void OnTriggerStay(){
		activarQuest = true;
		
		if(Mision2.misionSegunda && Opciones2.piedras < 9){
			finishQuest = false;
			activarQuest = false;
			mediumQuest = true;
			Mision2.misionSegunda = true;
		}
		
		if(Mision2.misionSegunda && Opciones2.piedras == 9){
			finishQuest = true;
			activarQuest = false;
			mediumQuest = false;
			Mision2.misionSegunda = false;


		}
		if(Mision2.misionSegunda && Opciones2.piedras > 9){
			finishQuest = true;
			activarQuest = false;
			mediumQuest = false;
			Mision2.misionSegunda = false;
		}
		
	}
	
	void OnTriggerExit(){
		finishQuest = false;
		activarQuest = false;
		mediumQuest = false;
	}
}
