using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IgaguriController : MonoBehaviour
{
    public GameObject targ;
    public static int hittimes;
    TextKey textkey;
    public void Shoot(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.name == "target")
        {
            this.enabled = true;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<ParticleSystem>().Play();
            hittimes++;
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

        Application.targetFrameRate = 60;
        this.transform.position=Camera.main.transform.position;
        // Shoot(new Vector3(0, 200, 2000));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
