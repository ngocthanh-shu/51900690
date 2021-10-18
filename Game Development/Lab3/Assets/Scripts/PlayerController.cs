using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public float tilt;
    public Boundary boundary;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;
    public AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        speed = 8;
        boundary.xMin = -6;
        boundary.xMax = 6;
        boundary.zMin = -4;
        boundary.zMax = 14;
        tilt = 3;
    }

    private void Update()
    {
        if(Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            /*GameObject clone = */
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation); //as GameObject;
            audioSource.Play();
        }
    }

    // Start is called before the first frame update
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 position = new Vector3(horizontal, this.transform.position.y, vertical);
        rb.velocity = position * speed;

        rb.position = new Vector3
            (
                Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
                0.0f,
                Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            );
        rb.rotation = Quaternion.Euler(0.0f,0.0f,rb.velocity.x * -tilt);
    }
}
