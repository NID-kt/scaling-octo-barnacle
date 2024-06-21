using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteEffectObject : MonoBehaviour
{
    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var a = animator.GetCurrentAnimatorStateInfo(0);
        if (a.IsName("Empty"))
        {
            Destroy(gameObject);
        }
    }
}
