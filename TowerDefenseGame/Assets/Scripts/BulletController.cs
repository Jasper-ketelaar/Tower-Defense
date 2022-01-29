using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update

    public float Speed { set; get; }

    // Update is called once per frame
    void FixedUpdate()
    {
        var trans = transform;
        trans.position +=  Speed * trans.forward;
    }
}
