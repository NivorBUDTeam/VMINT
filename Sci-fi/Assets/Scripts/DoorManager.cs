using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public Animator anim;
    public Transform player;


    void Update()
    {
        var distance = Vector3.Distance(transform.position, player.position);

        if (distance <= 5)
        {
            anim.SetBool("character_nearby", true);
        }
        else
        {
            anim.SetBool("character_nearby", false);
        }
    }
}
