using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public float damage = 10.0f;
    public float range = 100.0f;
    public Camera playerCamera;
    public ParticleSystem muzzleFlash;
    public ParticleSystem hitSpark;
    public float fireRate = 15f;//开火速率
    private float nextTimeToFire = 0f;
    public bool isAuto = true;
    public bool isFired=false;
    //换弹
    public int maxAmmo = 30;
    public int currentAmmo;
    public float reloadTime = 1f;
    private bool isRealoading = false;

    //动画
    public Animator animator;

    private void OnEnable()
    {
        isRealoading = false;
        animator.SetBool("Reloading", false);
        currentAmmo = maxAmmo;

    }
    private void Start()
    {
        
        if(currentAmmo==-1)
            currentAmmo = 0;
        UIManager.Instance.currentAmmoNum.text = currentAmmo.ToString();
        UIManager.Instance.totalAmmoNum.text = maxAmmo.ToString();
        if (isAuto)
        {
            UIManager.Instance.fireState.text = "automatic";
        }
        else
        {
            UIManager.Instance.fireState.text = "semi-automatic";
        }
        UIManager.Instance.totalAmmoNum.text=maxAmmo.ToString();
        UIManager.Instance.score.text = 0.ToString();
        
    }
    // Update is called once per frame
    void Update()
    {
        if (isRealoading)
        {
            return;
        }
        if(currentAmmo<=0||Input.GetKeyDown(KeyCode.R))
        {
            currentAmmo = 0;
            UIManager.Instance.currentAmmoNum.text = currentAmmo.ToString();
            StartCoroutine(Reload());
            UIManager.Instance.weaponState.text = "Empty";
            return;
        }
        if(Input.GetButton("Fire1")&&Time.time>=nextTimeToFire)
        {
            if (isAuto)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                //开枪的方法

                Fire();
            }
            else
            {
                if(!isFired)
                {
                    Fire();
                    isFired = true;
                }
            }
            
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (isAuto)
            {
                isAuto = false;
                UIManager.Instance.fireState.text = "semi-automatic";
            }
            else
            {
                isAuto = true;
                UIManager.Instance.fireState.text = "automatic";
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            muzzleFlash.Stop();
            isFired = false;
        }
    }

    private IEnumerator Reload()
    {
        
        isRealoading = true;
        Debug.Log("Reloading");
        animator.SetBool("Reloading", true);
        yield return new WaitForSeconds(reloadTime-0.25f);

        currentAmmo = maxAmmo;
        isRealoading=false;
        animator.SetBool("Reloading", false);
        UIManager.Instance.weaponState.text = "Not empty";
        UIManager.Instance.currentAmmoNum.text = currentAmmo.ToString();
        yield return new WaitForSeconds(0.25f);
    }

    private void Fire()
    {
        if(!muzzleFlash.isPlaying)
            muzzleFlash.Play();
        
        currentAmmo--;
        UIManager.Instance.currentAmmoNum.text = currentAmmo.ToString();
        RaycastHit hitInfo;
        if(Physics.Raycast(playerCamera.transform.position,playerCamera.transform.forward,out hitInfo,range))
        {
            //如果射线击中了物体
            
            Target target = hitInfo.transform.GetComponent<Target>();
            if (target != null)
            {
                target.GetHit();
            }
            var spark = Instantiate(hitSpark, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            spark.Play();
            
            Destroy(spark, 2.0f);


        }
    }
}
