using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TargetController : MonoBehaviour
{
    public float bekutoruAb;
    float bekutoru;
    // Start is called before the first frame update
    void Start()
    {
        bekutoru = bekutoruAb;
    }

    // Update is called once per frame
    void Update()
    {
        Transform myTransform = this.transform;

        Vector3 worldPos = myTransform.position;

        if (worldPos.x > 20)
        {
            bekutoru = bekutoruAb;
        }
        if (worldPos.x < -20)
        {
            bekutoru = -bekutoruAb;
        }
        transform.Translate(bekutoru,0, 0);
    }
}
