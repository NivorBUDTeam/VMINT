using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private Camera cam;
    private InputManager inputManager;
    [SerializeField] private Transform gunBarrel;

    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        inputManager = GetComponent<InputManager>();
    }

    void Update()
    {
        if (inputManager.OnFoot.Shoot.triggered && Inventory.Instance.ShotsCounter > 0)
        {
            Inventory.Instance.ShotsCounter--;

            Ray ray = cam.ViewportPointToRay(new Vector3(.5f, .5f, 0));
            RaycastHit hit;

            Vector3 targetPoint;
            if (Physics.Raycast(ray, out hit))
                targetPoint = hit.point;
            else
                targetPoint = ray.GetPoint(75);

            Vector3 dir = targetPoint - gunBarrel.position;

            var bullet = GameObject.Instantiate(Resources.Load("Prefabs/Bullet") as GameObject, gunBarrel.position, Quaternion.identity);
            bullet.transform.forward = dir.normalized;
            bullet.GetComponent<Rigidbody>().velocity = dir.normalized * 40;
        }
    }
}
