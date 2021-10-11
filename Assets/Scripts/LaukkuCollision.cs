using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class LaukkuCollision : MonoBehaviour
{
    public bool isColliding = false;
    public GameManager gameManager;
    public GameObject pusher;
    public List<string> baggages;
    public GameObject audioPlace;
    private void Start() {
        baggages = new List<string>();
       // Animation push = pusher.GetComponent<Animation>();    
    }
    void OnTriggerEnter(Collider este) {
        if(este.CompareTag("Este") ){
            gameObject.GetComponent<SpawnRed>().setForce();
            pusher.GetComponent<Animator>().Play("Base Layer.Työntö",0,0.4f);
        }
        if(este.CompareTag("HitBox")){
            if(este.name == "PunainenHitBox" && gameObject.name.Contains("Punainen") && isColliding == false && !baggages.Contains(gameObject.name)) {
            gameManager.GetComponent<GameManager>().punainenMin();
            baggages.Add(gameObject.name);
            audioPlace.GetComponent<AudioSource>().Play();
            }

            if(este.name == "SininenHitBox" && gameObject.name.Contains("Sininen") && isColliding == false && !baggages.Contains(gameObject.name)){
            
            gameManager.GetComponent<GameManager>().sininenMin();
            baggages.Add(gameObject.name);
            audioPlace.GetComponent<AudioSource>().Play();
            }
        }
    
        }   
        
}
