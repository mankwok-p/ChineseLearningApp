using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActivScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       //go.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SetActive(bool enable) {
        gameObject.SetActive(enable);
    }
}
