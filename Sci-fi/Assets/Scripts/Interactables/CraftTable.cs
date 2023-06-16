public class CraftTable : Interactable
{
    private CraftModel model;
    void Start()
    {
        model = FindObjectOfType<CraftModel>();
    }

    protected override void Interact()
    {
        model.StartSession();
    }
}
