using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleAtStart : MonoBehaviour
{
    public GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        go.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
