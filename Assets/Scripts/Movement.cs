using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
    
{
    [SerializeField] int thrustForce = 1;
    [SerializeField] int rotateForce = 100;
    [SerializeField] AudioClip mainEngineSound;
    //[SerializeField] int rightAndLeftEngine = 300;
    Rigidbody rb;
    AudioSource aS;


    // Start is called before the first frame update
    void Start()
    {
       
        rb=GetComponent<Rigidbody>();
        aS=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotation();
    }

    void Thrust() 
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(0,thrustForce*Time.deltaTime,0);
            if (aS.isPlaying == false) 
            {
                aS.PlayOneShot(mainEngineSound);
            }
           
            //rb.AddRelativeForce(Vector3.up); //bu kodda kullanılabilir y kısmı vector3.up olarak kısaltılır
            //Debug.Log("Thrusting");
        }
        else 
        { if (aS.isPlaying == true) { aS.Stop(); } }
    }
    void Rotation() 
    {
        if (Input.GetKey(KeyCode.D))
        {
            Rotate(-rotateForce);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Rotate(rotateForce);
        }
    }

    private void Rotate(float rotateForce)
    {
        rb.freezeRotation = true;//freeze rotation so we can manually rotate
        transform.Rotate(Vector3.forward * Time.deltaTime * rotateForce );//Vector3 foward z yönündedir
        rb.freezeRotation = false;//unfreeze rotation so physic system can takeover
    }
}
