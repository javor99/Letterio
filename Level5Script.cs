using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level5Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
            Debug.Log(GlobalManagerScript.level);   
            if(GlobalManagerScript.level<5)
             gameObject.SetActive(false);
    }

    // Update is called once per frame
   private void OnMouseDown()
    {
          if (gameObject.activeSelf && Input.GetMouseButtonDown(0))
        {
            Debug.Log("Kliknio si lvl 5");
            loading.Instance.LoadScene("Lvl5Sceen");
        }
        // This code runs when the object is clicked.
        // You can put your click handling logic here.
    }
}
