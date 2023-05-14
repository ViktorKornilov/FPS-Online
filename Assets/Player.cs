using UnityEngine;

public class Player : MonoBehaviour
{
    public void OnShoot()
    {
        transform.position += -transform.forward * 0.3f;
    }
}
