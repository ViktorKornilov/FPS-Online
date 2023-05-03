using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject hitPrefab;
    public float maxDistance = 100;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            var ray = new Ray(transform.position, transform.forward);
            
            if (Physics.Raycast(ray,out var hit,maxDistance))
            {
                // hit
                print(hit.point);
                var hitObj = Instantiate(hitPrefab, hit.point, Quaternion.Euler(0, 0, 0));
                hitObj.transform.forward = hit.normal;
                hitObj.transform.position += hit.normal * 0.02f;
            }
        }
    }
}
