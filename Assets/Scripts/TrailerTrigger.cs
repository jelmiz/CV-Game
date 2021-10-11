using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailerTrigger : MonoBehaviour
{
   public GameManager gameManager;
   public GameObject audioW;
   public GameObject audioR;
   private void OnTriggerEnter(Collider box) {
        if(box.name.Contains("Turku")){
            gameManager.PakettiOikein();
            audioR.GetComponent<AudioSource>().Play();
        }  
        if(box.name.Contains("Helsinki") || box.name.Contains("Espoo")) {
            gameManager.PakettiVaara();
            audioW.GetComponent<AudioSource>().Play();
        }  
   }
}
