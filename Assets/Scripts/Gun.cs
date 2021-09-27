using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float ImpactForce = 30f;
    public float firerate = 40f;

    public int maxAmmo = 10;
    private int currAmmo;
    public float reloadTime = 2;
    private bool isReloading = false;

    public Camera fpsCamera;
    public ParticleSystem muzzleFlash;
    public GameObject targetHit;
    public GameObject otherHit;

    private float nextTimeToFire = 0f;

    public Animator animator;

    private void Start()
    {
        if(currAmmo == -1)
        currAmmo = maxAmmo;
        isReloading = false;
    }

    private void OnEnable()
    {
        isReloading = false;
        animator.SetBool("isReloading", false);
    }

    private void Update()
    {
        if (isReloading)
            return;

        if(currAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
        if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / firerate;
            Shoot();
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        animator.SetBool("isReloading" , true);

        yield return new WaitForSeconds(reloadTime - .25f);
        animator.SetBool("isReloading", false);
        yield return new WaitForSeconds(.25f);

        currAmmo = maxAmmo;
        isReloading = false;
       
    }

    void Shoot()
    {
        muzzleFlash.Play();

        currAmmo--;

        RaycastHit hit;
        if(Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(damage);
                GameObject impactGO = Instantiate(targetHit, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 2);
            }
            else
            {
              GameObject impactGO =  Instantiate(otherHit, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 2);
            }

            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * ImpactForce);
            }         
        }
    }
}