using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [TextArea(2,5)]
    public string[] names;
    
    [TextArea(3, 10)]
    public string[] sentences;
    [TextArea(1,2)]
    public string goodBtnText;
     [TextArea(1,2)]
    public string badBtnText;
        
    
}
