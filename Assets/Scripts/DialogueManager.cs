using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    public GameObject player;
    public Text nameText;
    public Text dialogueText;
    public Text goodBtnText;
    public Text badBtnText;
    public Queue<string> sentences;
    private Queue<string> names;
    public GameObject textBox;
    public GameObject good;
    public GameObject negative;
    public GameObject continueBtn;
   
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        names = new Queue<string>();
        
    }
//Starts the dialogue and clears old sentences from Queue
    public void StartDialogue (Dialogue dialogue) {
        names.Clear();
        sentences.Clear();
        goodBtnText.text = dialogue.goodBtnText;
        badBtnText.text = dialogue.badBtnText;
        textBox.SetActive(true);
        good.SetActive(false);
        negative.SetActive(false);
        continueBtn.SetActive(true);
        foreach( string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        foreach( string name in dialogue.names) {
            names.Enqueue(name);
            
        }
        names.ToArray();
        ShowNextSentence();
    }
    public void ShowNextSentence() 
    {
        //no more sentences remaining
        if (sentences.Count == 0)
        {
            DialogueEnd();
            return;
        }
        if(!names.Contains("Pierre")){
        if(sentences.Count == 1) {
            continueBtn.SetActive(false);
            good.SetActive(true);
            negative.SetActive(true); 
        }
        }
        //If more sentences to say
    string sentence =  sentences.Dequeue();
    Debug.Log(sentences.Count);
    if(sentences.Count % 2 != 0 && names.Count > 1){
        
        string name = names.ToArray()[1];
        dialogueText.text = sentence;
        nameText.text = name;
    }else {
        if(names.ToArray()[0] == ""){
            string name =  player.name.ToString();
        dialogueText.text = sentence;
        nameText.text = name;
        } else{
        string name = names.ToArray()[0];
        dialogueText.text = sentence;
        nameText.text = name;
    }
    }
    }
    void DialogueEnd()
    {
        Debug.Log("The End");
        textBox.SetActive(false);
    }
    
    
}
