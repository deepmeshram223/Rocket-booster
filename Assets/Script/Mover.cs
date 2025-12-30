using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mover : MonoBehaviour
{
    // [SerializeField] private MovementData data;
    [SerializeField]  InputAction thrust;
    [SerializeField]  InputAction rotation;
    [SerializeField] AudioClip engineSound;
    [SerializeField]  float thrustForce=10f;
    [SerializeField]  float speed=10f;
    [SerializeField]  ParticleSystem thrustParticles;
    [SerializeField]  ParticleSystem rotationrigthParticles;
    [SerializeField]  ParticleSystem rotationleftParticles;
     AudioSource aS;
     Rigidbody rb;
     
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        aS = GetComponent<AudioSource>();
    }

    public void processRotation()
    {
        float rotationInput = rotation.ReadValue<float>();
        if (rotationInput > 0)
        {
            rb.freezeRotation = true;
            rotationleftParticles.Stop();
            rotationrigthParticles.Play();
            transform.Rotate(Vector3.back * Time.fixedDeltaTime * speed);
            rb.freezeRotation = false;
        }
        else if (rotationInput < 0)
        {
            rb.freezeRotation = true;
            rotationrigthParticles.Stop();
            rotationleftParticles.Play();
            transform.Rotate(Vector3.forward * Time.fixedDeltaTime * speed);
            rb.freezeRotation = false;
        }
        else
        {
            rotationrigthParticles.Stop();
            rotationleftParticles.Stop();
        }
    }
    public void OnEnable()
    {
            thrust.Enable();
            rotation.Enable();
    }

    public void FixedUpdate()
    {   
        processRotation();
        if (thrust.IsPressed())
        {
            rb.AddForce(Vector3.up * thrustForce * Time.fixedDeltaTime);
            thrustParticles.Play();
            if (!aS.isPlaying)
            {
                aS.PlayOneShot(engineSound);
            }
        }
        else
        {
            aS.Stop();
        }
    }
    
}
