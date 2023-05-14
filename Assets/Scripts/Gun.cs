using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Gun : MonoBehaviour
{
    public GameObject hitPrefab;
    public float maxDistance = 100;
    public GameObject flashEffect;

    private AudioSource source;
    public AudioClip shootSound;

    public UnityEvent onShoot;

    private void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        onShoot.Invoke();
        
        var cam = Camera.main;
        var ray = new Ray(cam.transform.position, cam.transform.forward);
            
        flashEffect.SetActive(true);
        Invoke("DisableFlashEffect",0.05f);
        
        // play shoot sound
        source.pitch = Random.Range(0.8f, 1.2f);
        source.PlayOneShot(shootSound);
            
        if (Physics.Raycast(ray,out var hit,maxDistance))
        {
            var health = hit.transform.GetComponent<Health>();
            if (health)
            {
                health.Damage();
            }
            
            if(!hit.transform.CompareTag("Enemy")){
                var hitObj = Instantiate(hitPrefab, hit.point, Quaternion.Euler(0, 0, 0),hit.transform);
                hitObj.transform.forward = hit.normal;
                hitObj.transform.position += hit.normal * 0.02f;
            }
        }
    }

    void DisableFlashEffect()
    {
        flashEffect.SetActive(false);
    }
}
