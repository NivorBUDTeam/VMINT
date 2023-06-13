using UnityEngine;


[System.Serializable]
public class Dialogue
{
    public Phrase[] phrases;
    public GameObject interfaceToShow;
}

[System.Serializable]
public class Phrase
{
    public string name;

    [TextArea]
    public string sentence;
}