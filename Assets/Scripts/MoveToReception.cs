using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
[RequireComponent(typeof(NavMeshAgent))]
public class MoveToReception : MonoBehaviour
{
    [Header("Transforms")]
    public Transform receptionSpot;
    public Transform checkpoint;
    public Transform table;
    public Transform leave;
    Vector3 destination;
    private NavMeshAgent agent;
     [Header("GameObjects")]
    public GameObject dialogueManager;
    public GameObject nameInputUI;
    public GameObject text;
    public GameObject customer2;
    
     [Header("Others")]
     public int counter;
    private IEnumerator coroutine;
    public bool done;
   
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;
        destination = receptionSpot.position;
        done = false;
    }

    void Update() {
        if(gameObject.name.Contains("5")){
            counter = customer2.GetComponent<MoveToReception>().counter;
        }
        if(nameInputUI.activeInHierarchy == false) {
        Queue<string> dialogueManagerSentences = dialogueManager.GetComponent<DialogueManager>().sentences;
        
        agent.destination = destination;
        //checkpointille
                if(dialogueManagerSentences.Count == 0 && counter == 1 && text.activeInHierarchy == false){
                agent.isStopped = false;
                destination = checkpoint.position;
                
            }
            //pöydälle
            if(dialogueManagerSentences.Count == 0 && counter == 2 && text.activeInHierarchy == false){
                agent.isStopped = false;
                destination = table.position;
            }
            //lähtö checkpointille
             if(dialogueManagerSentences.Count == 0 && counter == 3 && text.activeInHierarchy == false){
                
               coroutine = Wait(100f);
                StartCoroutine(coroutine);
            }
            //poistu
            if(counter == 4){
                
                agent.isStopped = false;
                destination = leave.position;
            }
            if(counter >4) {
                counter = 4;
            }
    }
    }
    private void OnTriggerEnter(Collider stop) {
        
        if(stop.CompareTag("Stop") && stop.name.Contains("MoveR")){
            
            gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
            counter++;
        }
        if(stop.CompareTag("Checkpoint")){
            Debug.Log("CHECKPOINT");
            counter++;
            
            
        }
        if(stop.CompareTag("Table") && done == false){
            
            stop.GetComponent<DialogueTrigger>().TriggerDialogue();
            counter++;
            done = true;
        }
        if(stop.CompareTag("Leave")){
            gameObject.SetActive(false);
        }
        
    }
    private IEnumerator Wait(float time) {
        yield return new WaitForSeconds(time);
        agent.isStopped = false;
        destination = checkpoint.position;
    }
    
}
