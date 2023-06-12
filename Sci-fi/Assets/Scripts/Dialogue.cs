using UnityEngine;


[System.Serializable]
public class Dialogue
{
    public Phrase[] phrases;
}

[System.Serializable]
public class Phrase
{
    public string name;

    [TextArea]
    public string sentence;
}