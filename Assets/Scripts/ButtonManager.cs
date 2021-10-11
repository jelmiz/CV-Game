using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonManager : MonoBehaviour
{
    public Button buttoni;
    public GameObject diaManager;
    // Start is called before the first frame update
    void Start()
    {
        buttoni.onClick.AddListener(Tee);
    }

    // Update is called once per frame
    void Tee(){
        diaManager.GetComponent<DialogueManager>().ShowNextSentence();
    }
}
