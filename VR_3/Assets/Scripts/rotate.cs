using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    [SerializeField] float rotateSpeed=90;
    bool canRotate = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canRotate)
        {
            transform.eulerAngles += new Vector3(0,rotateSpeed*Time.deltaTime,0);
            
        }
    }
    public void startRotate()
    {
        canRotate = true;
    }
    public void stopRotate()
    {
        canRotate = false;
    }
    public void changeDirection()
    {
        rotateSpeed = -rotateSpeed;
    }
}
