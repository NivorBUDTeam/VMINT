using UnityEngine;

public class DamagingObject : Interactable
{
    [SerializeField] PlayerHealth health;

    protected override void Interact()
    {
        health.TakeDamage(20);
    }
}
