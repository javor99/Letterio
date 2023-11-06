using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostenemyscript3 : MonoBehaviour
{
    public float downwardSpeed = 1.0f; // Speed of downward movement
    public string odabrani = "";
     public AudioSource audioSource;
    GhostEnemyInst3 enemyinst;
    bool pogodak = false; // Retained the 'pogodak' variable
        public AudioClip sClip;


    void Start()
    {
        // Deactivate the "Border" child object initially
        enemyinst = GhostEnemyInst3.Instance;
         audioSource=GetComponent<AudioSource>();
        Transform borderTransform = transform.Find("Border"); // Try to find the "Border" child
        if (borderTransform != null)
        {
            borderTransform.gameObject.SetActive(false); // Deactivate if found
        }
    }

    void Update()
    {
        transform.Translate(Vector3.down * downwardSpeed * Time.deltaTime);
        GameObject[] objects = GameObject.FindGameObjectsWithTag("enemyghost");
        if (pogodak)
        {
             audioSource.Play();
            foreach (GameObject obj in objects)
            {
                //Destroy(obj);
                  obj.transform.position = Vector3.one * 9999f; // move the game object off screen while it finishes it's sound, then destroy it
            Debug.Log("Length clipa je"+ sClip.length   );
            Destroy(obj, sClip.length);
            }
            enemyinst.SpawnObjectsWithLettersTimeout();
            pogodak = false;
           
        }
    }

    

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            Destroy(collision.gameObject);
            pogodak = true;
            
        }
    }

    void OnMouseDown()
    {
        // Try to find the "Border" child again and toggle its active state
        Transform borderTransform = transform.Find("Border");
        Debug.Log(borderTransform);
        if (borderTransform != null && !borderTransform.gameObject.activeSelf)
        {
            borderTransform.gameObject.SetActive(true);

            Debug.Log("Jesam");

            foreach (Transform child in transform)
            {
                // Print the name of the child
                //Debug.Log("Child Name: " + child.name);

                // Check if the child has a SpriteRenderer component
                SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    // Print the sprite value (assuming you have a SpriteRenderer)
                    if (spriteRenderer.sprite.name.Length == 1)
                    {
                        Debug.Log("Stisnuto slovo je : " + spriteRenderer.sprite.name);

                        // Call addToWord on the EnemyInst class
                        enemyinst.addToWord(spriteRenderer.sprite.name);
                    }
                }
            }
        }
    }
}
