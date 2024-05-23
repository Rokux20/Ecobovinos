using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LogicObjectives : MonoBehaviour
{
    public int numberOfObjectives;
    public TextMeshProUGUI textMission;
    public GameObject buttonMission;

    // Start is called before the first frame update
    void Start()
    {
        numberOfObjectives = GameObject.FindGameObjectsWithTag("Objective").Length;
        textMission.text = "Recoje las esferas " +
                            "\n Restantes:" +numberOfObjectives;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTiggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Objective")
        {
            Destroy(other.transform.parent.gameObject);
            numberOfObjectives--;
            textMission.text = "Recoje las esferas " +
                            "\n Restantes: " + numberOfObjectives;
            if (numberOfObjectives <= 0)
            {
                textMission.text = "Misión cumplida";
                buttonMission.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}
