using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestroyer : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float time = 1;
    Timer timer;
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = time;
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Finished)
        {
            Destroy(gameObject);
        }
    }
}
