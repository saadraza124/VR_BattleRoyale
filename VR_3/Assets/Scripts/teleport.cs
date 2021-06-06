using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
   
{
    //[SerializeField] GameObject player;
    // Start is called before the first frame update
    [SerializeField] float speed;
    GameObject player;
    AudioSource audioSource;
  
    bool canTeleport = false;
    public AudioClip portalAudio;
   
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = gameObject.AddComponent<AudioSource>();
        // playerpos = player.transform.position;
       //  portalpos = gameObject.transform.position;
    }

    // Update is called once per frame
    public void Update()
    {
        if (canTeleport)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position,
                transform.position,
                speed * Time.deltaTime);
            if (portalAudio)
            {
                audioSource.PlayOneShot(portalAudio);

            }          
        }

        if (player.transform.position == transform.position)
        {
            canTeleport = false;
        }

    }
    public void portalteleport()
    {          canTeleport = true;          
    }
   


}
