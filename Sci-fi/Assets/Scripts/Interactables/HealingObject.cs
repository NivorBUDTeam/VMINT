using UnityEngine;

public class HealingObject : Interactable
{
    [SerializeField] PlayerHealth health;

    protected override void Interact()
    {
        health.RestoreHealth(20);
    }
}
