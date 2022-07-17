using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    Rigidbody rb;
    public GameObject pistolH;
    
    public ParticleSystem psFlare;
    public GameObject cameraOB;
    public int score;
    public TextMeshProUGUI txtscore;
    public float speed;
    public float turn;
    public static Player instance;
    public int weaponID;
    public float health = 100;
    public Image imageH;
    //public AudioSource bang;
    public void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
        turn = 10f;
        score = 0;
        psFlare = GetComponentInChildren<ParticleSystem>();
        rb = GetComponent<Rigidbody>();
       // bang = GetComponentInChildren<AudioSource>();

        cameraOB = Camera.main.gameObject;

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 temp;
        temp = (transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical")) * speed;
        rb.velocity = temp;
        rb.angularVelocity = Vector3.up * Input.GetAxis("Mouse X") * turn;

        RaycastHit rHit;

        if (Input.GetButtonDown("Fire1"))
        {
            //bang.pitch = Random.Range(0.5f, 1.5f);
           // bang.Play();
            psFlare.Play();
            if (Physics.Raycast(transform.position, transform.forward, out rHit))
            {
                if (rHit.collider.gameObject.tag == "Enemy")
                {

                    Destroy(rHit.collider.gameObject);
                    score++;
                }

            }

        }

        
        txtscore.text = "score: " + score;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health -= 1f;
            imageH.fillAmount = health / 100f;
            if (health <= 0)
                Debug.Log("GAME OVER");
            
        }
    }
}
