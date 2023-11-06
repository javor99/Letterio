using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yesscript : MonoBehaviour
{
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
        Debug.Log("Quito sam");
        Application.Quit();
       
        // This code runs when the object is clicked.
        // You can put your click handling logic here.
    }
}
