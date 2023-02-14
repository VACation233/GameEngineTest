using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    bool isHit;
    Renderer renderer;
    public Animator animator;
    public Material normalMat;
    public Material hitMat;

    // Start is called before the first frame update
    void Start()
    {
        renderer = transform.GetChild(0).GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetHit()
    {
        Debug.Log("��������");

        if (!isHit)
        {
            renderer.material = hitMat;
            GameManager.Instance.updateSCore();
            isHit = true;
            animator.SetBool("IsHit", true);

        }
    }
}
