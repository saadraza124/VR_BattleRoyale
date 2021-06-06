using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class player : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody rb;
    Vector3 curpos;
    


    private void Awake()
    {
        // Call via `StartCoroutine(SwitchToVR())` from your code. Or, use
        // `yield SwitchToVR()` if calling from inside another coroutine.
        IEnumerator SwitchToVR()
        {
            // Device names are lowercase, as returned by `XRSettings.supportedDevices`.
            // Google original, makes you specify
            //string desiredDevice = "daydream"; // Or "cardboard".
            //XRSettings.LoadDeviceByName(desiredDevice);
            // this is slightly better;
            string[] DaydreamDevices = new string[] {  "cardboard" };
            XRSettings.LoadDeviceByName(DaydreamDevices);

            // Must wait one frame after calling `XRSettings.LoadDeviceByName()`.
            yield return null;

            // Now it's ok to enable VR mode.
            XRSettings.enabled = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        curpos = transform.position;
        rb = gameObject.GetComponent<Rigidbody>();
       

    }

    // Update is called once per frame
    void Update()
    {
       
       
    }
    
}
