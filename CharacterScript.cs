using UnityEngine;

public class CharacterScript : MonoBehaviour
{
   
    public GameObject object2; // Reference to the second object
    public GameObject object3Prefab; // Prefab for the third object
        public AudioSource audioSource; // Reference to the AudioSource component

    Rigidbody rb;
   

    void Start()
    {
        // Make the initial object visible and the other ones invisible
        
    }

    void Update()
    {
        // Check if the Enter key is pressed
    
        
          

            // Spawn a new instance of object3Prefab at the top of object2
           
                
                if (rb != null)
                {
                    rb.useGravity = false;
                    rb.velocity = Vector3.up * 5.0f; // Adjust the velocity as needed
                }
            
        
    }
    public void pucaj() {
                Vector3 spawnPosition = object2.transform.position + Vector3.up * (object2.transform.localScale.y / 2 + object3Prefab.transform.localScale.y / 2);
                GameObject spawnedObject3 = Instantiate(object3Prefab, spawnPosition, Quaternion.identity);

                // Disable gravity for the spawned object
                rb = spawnedObject3.GetComponent<Rigidbody>();
                 audioSource.Play();
        
    }
}
