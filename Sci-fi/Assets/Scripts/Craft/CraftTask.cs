using UnityEngine;

[CreateAssetMenu(fileName = "New CraftTask", menuName = "Craft/new CraftTask")]
public class CraftTask : ScriptableObject
{
    [SerializeField] private string _info = string.Empty;
    public string Info { get { return _info; } }

    [SerializeField] Answer[] _answers;
    public Answer[] Answers { get { return _answers; } }

    [SerializeField] Sprite _image;
    public Sprite Image { get { return _image; } }
}

[System.Serializable]
public struct Answer
{
    [SerializeField] private string _info;
    public string Info { get { return _info; } }

    [SerializeField] private bool _isCorrect;
    public bool IsCorrect { get { return _isCorrect; } }
}
