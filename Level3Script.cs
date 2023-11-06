using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
            Debug.Log(GlobalManagerScript.level);   
            if(GlobalManagerScript.level<3)
             gameObject.SetActive(false);
    }

   private void OnMouseDown()
    {
          if (gameObject.activeSelf && Input.GetMouseButtonDown(0))
        {
            Debug.Log("Kliknio si lvl 3");
             loading.Instance.LoadScene("Lvl3Sceen");
        }
        // This code runs when the object is clicked.
        // You can put your click handling logic here.
    }
}
