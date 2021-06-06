using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initialize : MonoBehaviour
{
    [SerializeField] GameObject portalPrefab;
    [SerializeField] int portalCount;
    launcher launcher;
    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < portalCount; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-9,9), 0, Random.Range(-19, 19));
            Instantiate(portalPrefab, pos, Quaternion.identity );
        }
        launcher.initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
