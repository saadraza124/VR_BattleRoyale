using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{
    public AudioClip ExplodeAudio;
    AudioSource audiosource;
    // Start is called before the first frame update
    void Start()
    {
        audiosource = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "launcher")
        {
            audiosource.PlayOneShot(ExplodeAudio);
        }
    }
}
