using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SetMovement : MonoBehaviour
{
    [Header("Transform")]
    public Transform waitingSpot;
    public Transform table1;
    public Transform table2;
    public Transform table3;
    public Transform checkPoint1;
    [Header("GameObjects")]
    
    
    public GameObject dialogueManager;
    
    public GameObject text;
    public GameObject customer1;
    public GameObject customer2;
    public GameObject customer3;
    public GameObject customer4;
    private GameObject camera;
    private GameObject player;
    public GameObject pierre;
    public GameObject reception;
    public GameObject endBad;
    public GameObject endGood;
    public GameObject endNeutral;
    public GameObject badUI;
    public GameObject goodUI;
    public GameObject neutralUI;
    public GameObject nameInputUI;
    [Header("Other")]
    public GameManager gameManager;
    private NavMeshAgent agent;
    public NavMeshAgent customer;
    public int counterPlayer;
    Vector3 destination;
    public bool tableFirst;
    public bool atWait;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        destination = waitingSpot.position;
        camera = GameObject.Find("Main Camera");
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Checks that the name input screen is closed
        if(nameInputUI.activeInHierarchy == false) {
        
        int opinion = gameManager.GetComponent<GameManager>().opinion;
        int counter = customer1.GetComponent<MoveToReception>().counter;
        int counter2 = customer2.GetComponent<MoveToReception>().counter;
        int counter3 = customer4.GetComponent<MoveToReception>().counter;
        Queue<string> dialogueManagerSentences = dialogueManager.GetComponent<DialogueManager>().sentences;
        agent.destination = destination; 
        
        //When walking towards next destination look forward
            if(dialogueManagerSentences.Count == 0 && text.activeInHierarchy == false && atWait == false){
            
                camera.transform.rotation = player.transform.rotation;
            }
            //When at reception look in certain direction
            if(atWait == true){
                var lookReception = Quaternion.LookRotation(reception.transform.position - camera.transform.position);
                camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, lookReception, 7 *Time.deltaTime);
                
            }
             //Camera look change when talking
            if(dialogueManagerSentences.Count >= 0  && text.activeInHierarchy == true && counter == 3 && counterPlayer == 1) {
                    var lookCustomer1 = Quaternion.LookRotation(customer1.transform.position - camera.transform.position);
                    camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, lookCustomer1, 7 *Time.deltaTime);
                }

            if(dialogueManagerSentences.Count >= 0  && text.activeInHierarchy == true && counter2 == 3 && counterPlayer == 3) {
                    var lookCustomer2 = Quaternion.LookRotation(customer2.transform.position - camera.transform.position);
                    camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, lookCustomer2, 7 *Time.deltaTime);
                }

            if(dialogueManagerSentences.Count >= 0 && text.activeInHierarchy == true && counter3 == 3 && counterPlayer == 5) {
                    var lookCustomer4 = Quaternion.LookRotation(customer4.transform.position - camera.transform.position);
                    camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, lookCustomer4, 7 *Time.deltaTime);
                } 

            if(dialogueManagerSentences.Count >= 0 && text.activeInHierarchy == true &&  counterPlayer == 7) {
                    var lookPierre = Quaternion.LookRotation(pierre.transform.position - camera.transform.position);
                    camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, lookPierre, 7 *Time.deltaTime);
                }

            if(dialogueManagerSentences.Count == 0 && text.activeInHierarchy == false && counter == 3 && counterPlayer == 1) {
                destination = checkPoint1.position;
                agent.isStopped = false;
                }
                //Customer1
            if(dialogueManagerSentences.Count == 0 && text.activeInHierarchy == false && counter == 1){
                destination = checkPoint1.position;
                agent.isStopped = false;
            }  
            if(dialogueManagerSentences.Count == 0 && text.activeInHierarchy == false && counter == 1 && counterPlayer == 1){
                destination = table1.position;
                agent.isStopped = false;
            
            }
           
            //Customer 1 done and spawn customer 2 and 2.1
            if(dialogueManagerSentences.Count == 0 && text.activeInHierarchy == false && counterPlayer == 2){
            destination = waitingSpot.position;
            agent.isStopped = false;
            customer2.SetActive(true);
            customer3.SetActive(true);
                } 
        //Customer2 finishes dialog
            if(dialogueManagerSentences.Count == 0 && text.activeInHierarchy == false && counter2 == 1){
                destination = checkPoint1.position;
                agent.isStopped = false;
                }
            
            if(dialogueManagerSentences.Count == 0 && text.activeInHierarchy == false && counter2 == 2 && counterPlayer ==3){
                destination = table2.position;
                agent.isStopped = false;
            }

            if(dialogueManagerSentences.Count == 0 && text.activeInHierarchy == false && counter2 == 3  && counterPlayer ==3){
                destination = checkPoint1.position;
                agent.isStopped = false;
            } 

            //Spawn customer 3
            if(dialogueManagerSentences.Count == 0 && text.activeInHierarchy == false && counterPlayer == 4){
                destination = waitingSpot.position;
                agent.isStopped = false;
                customer4.SetActive(true);
            }

            //Customer3 dialog with reception stops
            if(dialogueManagerSentences.Count == 0 && text.activeInHierarchy == false && counter3 == 1){
                
                destination = checkPoint1.position;
                agent.isStopped = false;
            }  

            if(dialogueManagerSentences.Count == 0 && text.activeInHierarchy == false && counter3 == 2 && counterPlayer ==5){
                destination = table3.position;
                agent.isStopped = false; 
            }

            if(dialogueManagerSentences.Count == 0 && text.activeInHierarchy == false && counter3 == 3){
                destination = checkPoint1.position;
                agent.isStopped = false;
            } 
            //Depending on the opinion, set the ending screen hitbox accordingly
            if(dialogueManagerSentences.Count == 0 && text.activeInHierarchy == false && counterPlayer == 6 && opinion <1){
                destination = waitingSpot.position;
                agent.isStopped = false;
                endBad.SetActive(true);
            }

            if(dialogueManagerSentences.Count == 0 && text.activeInHierarchy == false && counterPlayer == 6 && opinion >1){
                destination = waitingSpot.position;
                agent.isStopped = false;
                endGood.SetActive(true);
            }

            if(dialogueManagerSentences.Count == 0 && text.activeInHierarchy == false && counterPlayer == 6 && opinion ==1){
                destination = waitingSpot.position;
                agent.isStopped = false;
                endNeutral.SetActive(true);
            }
            //depending on the opinion, after the talk with Pierre, set ending UI
        if(dialogueManagerSentences.Count == 0 && text.activeInHierarchy == false && counterPlayer == 7) {
            if(opinion == 1) {
                neutralUI.SetActive(true);
                camera.transform.LookAt(pierre.transform);
            }
            if(opinion > 1) {
                goodUI.SetActive(true);
                camera.transform.LookAt(pierre.transform);
                
            }
            if(opinion < 1) {
                badUI.SetActive(true);
                camera.transform.LookAt(pierre.transform);
            }
        }
    }
    }
    //End colliders and different dialogs
    private void OnTriggerEnter(Collider collider) {
        if(collider.CompareTag("Wait2")){
            if(collider.name.Contains("WaitSpot2GoodEnd")){
                collider.GetComponent<DialogueTrigger>().TriggerDialogue();
                counterPlayer++;
            }
            if(collider.name.Contains("WaitSpot2NeutralEnd")){
                collider.GetComponent<DialogueTrigger>().TriggerDialogue();
                counterPlayer++;
            }
            if(collider.name.Contains("WaitSpot2BadEnd")){
                collider.GetComponent<DialogueTrigger>().TriggerDialogue();
                counterPlayer++;
            }

        }
        //Check if at waitpoint
        if(collider.CompareTag("Wait")){
            atWait = true;
        }
        //When walking through a checkpoint
        if(collider.CompareTag("Checkpoint")){
            counterPlayer++;
        }
    }
    //When leaving waiting area
    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Wait")) {
            atWait =false;
        }
    }
}
