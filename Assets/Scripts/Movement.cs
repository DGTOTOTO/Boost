using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    Rigidbody rigidbd;
    AudioSource audiosc;
    [SerializeField] float ThrustTune = 1500;
    [SerializeField] float RotateTune = 200;
    [SerializeField] ParticleSystem ThrustUp;

    // Start is called before the first frame update
    void Start()
    {
        rigidbd = GetComponent<Rigidbody>();
        audiosc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
        if (Input.GetKey(KeyCode.Y)) {
            Invoke("ReloadLevel", 1f);
        }
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
        {
            rigidbd.AddRelativeForce(Vector3.up * ThrustTune * Time.deltaTime);
            audiosc.Play();
            ThrustUp.Play();
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            Debug.Log("LEFT");
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            Debug.Log("RIGHT");
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            RotationMethod(RotateTune);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            RotationMethod(-RotateTune);
        }
    }

    private void RotationMethod(float RotateThisFrame)
    {
        rigidbd.freezeRotation = true;
        transform.Rotate(Vector3.forward * RotateThisFrame * Time.deltaTime);
        rigidbd.freezeRotation = false;
    }
}
