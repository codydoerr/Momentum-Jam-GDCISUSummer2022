using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialTextController : MonoBehaviour
{
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        gameObject.GetComponent<Canvas>().worldCamera = cam;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
