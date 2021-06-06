using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Networking;

public class launcher : MonoBehaviour
{
   
    Vector3 playerpos;
    [SerializeField] float speed;
    [SerializeField] float force;
   
    public AudioClip whooshAudio;
    public AudioClip ThrowAudio;
    
  
    bool canLaunch = false;
    bool holdingLauncher = false;
    public static  Camera playercamera;
    Rigidbody rb;
    AudioSource audiosource;
    static GameObject player;
    

   


    // Start is called before the first frame update
    void Start()
    {
        
      
        rb = gameObject.GetComponent<Rigidbody>();
        audiosource = gameObject.GetComponent<AudioSource>();
        
       
      

    }
    public static void  initialize()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playercamera = GameObject.FindGameObjectWithTag("playercamera").GetComponent<Camera>();
    }
    

   
    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            launchObject();
        }
       
    }
    void launchObject()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = playercamera.ViewportPointToRay(new Vector3(.5f, .5f, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 20f))
            {
                if ((hit.collider.gameObject.tag == "launcher"))
                {
                    canLaunch = true;
                }
                //else canLaunch = false;
            }
        }
        //************************************************************
        if (Input.GetButton("Fire1") && canLaunch)
        {
            //  transform.position = GameObject.FindGameObjectWithTag("MainCamera").transform.position;
            rb.isKinematic = true;
            transform.position = Vector3.MoveTowards(transform.position,
            GameObject.FindGameObjectWithTag("cameraLauncherTag").transform.position,
            speed * Time.deltaTime);
            //gameObject.transform.SetParent(launcherFocal.transform);
            if (audiosource.isPlaying == false && !holdingLauncher)
            {
                audiosource.PlayOneShot(whooshAudio);
            }
            holdingLauncher = true;
            // canLaunch = true;
        }
        if ((holdingLauncher) && (Input.GetButtonUp("Fire1")))
        {
            rb.isKinematic = false;

            rb.velocity = ((playercamera.transform.rotation) * Vector3.forward) * force;
            //rb.velocity = Camera.main.ViewportToScreenPoint(new Vector3(0.55f, 0.5f, 1));
            //   Camera.main.transform.rotation*(new Vector3(2,0,0)) 
            // rb.AddForce(Camera.main.ScreenToViewportPoint(new Vector3(0.5f,0.5f,0))*force);
            // Debug.Log((Camera.main.ScreenToViewportPoint(new Vector3(0.5f, 0.5f, 0))));
            audiosource.PlayOneShot(ThrowAudio);
            if (audiosource.isPlaying == false)
            {
                audiosource.PlayOneShot(ThrowAudio);
            }
            holdingLauncher = false;
            canLaunch = false;

        }
    }




}
/*Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10f; ; // Make sure to add some "depth" to the screen point 
           Vector3 aim = Camera.main.ScreenToWorldPoint(mousePos);
            Vector3 p = Camera.main.ViewportToWorldPoint(new Vector3(0.5f,0.5f,10f));
           rb.velocity = p * force;
           */
// transform.localPosition += new Vector3(2,0,0);
// rb.velocity = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0)) ;
//Vector3.forward
// (GameObject.FindGameObjectWithTag("MainCamera").transform.rotation)         
// transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));