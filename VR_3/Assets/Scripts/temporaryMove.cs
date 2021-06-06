using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

public class temporaryMove : MonoBehaviour
{
    [SerializeField] GameObject[]  target;
    [SerializeField] float speed = 1;
    Vector3 def;
    Vector3 curpos;

    Vector3[] targetVector = new Vector3[4];
    
    // Start is called before the first frame update
    void Start()
    {

        targetVector[0] = target[0].transform.position;
        targetVector[1] = target[1].transform.position;
        targetVector[2] = target[2].transform.position;
        targetVector[3] = target[3].transform.position;
        for (int i = 0; i < 1000; i++)
        {
            transform.position += new Vector3(0.01f, 0, 0);
        }
      
       
    }

    // Update is called once per frame
    void Update()
    {
        /*def = (targetVector[0] - transform.position).normalized/100;
       curpos = transform.position + def;
       transform.position = curpos;*/
      // transform.position= Vector3.MoveTowards(transform.position, targetVector[0], speed*Time.deltaTime);
    }
}
