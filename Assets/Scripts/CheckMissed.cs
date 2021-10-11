using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMissed : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter(Collider box) {
        if(box.name.Contains("Turku")) {
            gameManager.PakettiOhi();
        }
    }
}
