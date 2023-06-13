public class NPC : Interactable
{
    private bool talked;
    public Dialogue dialogue;
    public Dialogue repeatDialogue;


    protected override void Interact()
    {
        if (!talked)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

            talked = true;
        }
        else
        {
            FindObjectOfType<DialogueManager>().StartDialogue(repeatDialogue);
        }
    }
}
