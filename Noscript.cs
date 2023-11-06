using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noscript : MonoBehaviour

{
     [SerializeField] private GameObject loaderCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnMouseDown()
    {
           loaderCanvas.SetActive(false);
        // This code runs when the object is clicked.
        // You can put your click handling logic here.
    }
}
