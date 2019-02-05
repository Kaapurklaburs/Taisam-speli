using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public float Dumage = 10f;
    public float Range = 100f;
    public float ImpactForce;
    public float FireRate = 15f;
    private float NextTimeToFire = 0f;
    public Camera FPScam;
    public int MaxAmo = 10;
    public float relodTime = 1f;
    private int correntAmo;
    private bool IsReloding = false;
    public ParticleSystem muzzleFlash;
    public Animator animator;
    public bool IsFlameThrower;


    private void Start()
    {
        correntAmo = MaxAmo;
    }
    void OnEnable()
    {
        IsReloding = false;
        animator.SetBool("Reloding", false);
    }


    // Update is called once per frame
    void Update() {

        if (IsReloding)
            return;

        if (correntAmo <= 0)
        {
            StartCoroutine(Relod());
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= NextTimeToFire)
        {
            NextTimeToFire = Time.time + 1f / FireRate;
            Shote();
        }



    }

        #region Relode
        IEnumerator Relod()
        {
            muzzleFlash.Stop();

            IsReloding = true;
            Debug.Log("Reloding...");

            animator.SetBool("Reloding", true);

            yield return new WaitForSeconds(relodTime - 0.3f);

            animator.SetBool("Reloding", false);

            yield return new WaitForSeconds(0.3f);

            correntAmo = MaxAmo;
            IsReloding = false;
            Debug.Log("Ok");
        }
        #endregion

    void Shote()
    {

        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(FPScam.transform.position, FPScam.transform.forward, out hit, Range))
        {

            HP hp = hit.transform.GetComponent<HP>();
            if (hp != null)
            {
                HP.dumage = Dumage;
                hp.Dumage();
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * ImpactForce);
            }

            correntAmo--;
        }


    }
}

