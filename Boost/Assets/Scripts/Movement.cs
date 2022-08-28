using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 1f;
    [SerializeField] AudioClip mainEngine;
    Rigidbody rb;
    AudioSource audioSource;

    bool isAlive;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        processThrust();
        processRotation();
    }

    void processThrust() 
    {
        if(Input.GetKey(KeyCode.Space)) {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if(!audioSource.isPlaying){
                audioSource.PlayOneShot(mainEngine);
            }
        }
        else{
            audioSource.Stop();
        }
    }

    void processRotation() {
        if(Input.GetKey(KeyCode.A)) {
            applyRotation(rotationThrust);

        }
        if(Input.GetKey(KeyCode.D)) {
            applyRotation(-rotationThrust);
        }
    }

    public void applyRotation(float rotationFrame) {
        rb.freezeRotation = true; //freezing rotation so that we can manually rotate.
        transform.Rotate(Vector3.forward * rotationFrame * Time.deltaTime);
        rb.freezeRotation = false; //unfreezing rotation so physics system can take over.
    }
}
