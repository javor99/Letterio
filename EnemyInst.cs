using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine.SceneManagement;




public class EnemyInst : MonoBehaviour
{
    public  GameObject objectToInitialize; // Reference to the object to initialize
    public  Transform alphabet; // Reference to the input object with the desired child
    public  Vector3 newSize = new Vector3(3.0f, 3.0f, 0.0f); // The new size for the "letter" child
    public  float offset = 1.0f; // Offset between objects in the row
    public  int numberOfObjects = 4; // Number of objects to create
    public  Transform spawnPosition; // Reference to the position where you want to spawn the objects
    public  Transform inputObject; // Reference to the input object
    public  float gameOverYPosition; // Y position where objects trigger a game over
    public  int pokazivac=0;
    public  String odabranarijec="";
    public AudioSource wrong;
    CharacterScript characterScript;
    public AudioSource loseLife;
    private int numoflives;

    public  List<string> words = new List<string>
        { 
            "Four", "Five", "Nine",
            "Good", "Best", "Cute",
            "Zero", "Huge", "Cool",
            "Tree", "Race", "Rice",
            "Keep", "Lace", "Beam",
            "Game", "Mars", "Tide",
            "Ride", "Hide", "Exit",
            "Need", "Stay", "Come"
         
        };
        // Static instance to implement the Singleton pattern
    public static EnemyInst Instance { get; private set; }

    // The rest of your class members...

    void Awake()
    {
        // Ensure there is only one instance of EnemyInst
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            //DontDestroyOnLoad(this.gameObject);
        }
    }

 



        string ShuffleString(string input)
    {
        char[] characters = input.ToCharArray();
        System.Random rng = new System.Random();

        int n = characters.Length;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            char temp = characters[k];
            characters[k] = characters[n];
            characters[n] = temp;
        }

        return new string(characters);
    }

    void Start()
    {   
        numoflives=3;
        // Set the game over position to the Y position of the input object
        if (inputObject != null)
        {
            gameOverYPosition = inputObject.position.y;
        }
        odabranarijec="";
        pokazivac=0;
        Debug.Log("odabranarijec je "+odabranarijec);
        StartCoroutine(DelayedSpawnLetters());
        GameObject characterObject = GameObject.Find("Character"); // Make sure the object is named correctly

        if (characterObject != null)
        {
            // Get the reference to the CharacterScript component
            characterScript = characterObject.GetComponent<CharacterScript>();
        }
        else
        {
            Debug.LogError("Character object not found.");
        }
    }

    public void printKurac() {
        Debug.Log("Kurac");
        
    }
        IEnumerator GG()
    {
        // Wait for 1 second
        yield return new WaitForSeconds(2.0f);

        // After 1 second, execute the following code
       
      Pobjeda();
    }


    void Pobjeda() {
  Debug.Log("Bravo preso si level");
              
                   if(GlobalManagerScript.level==1){
                 GlobalManagerScript.level=2;}


                 GlobalManagerScript.zadnjiodigranlvl=1;
                    loading.Instance.LoadScene("Donelvl1");

    }

    public void addToWord(String word) {
        Debug.Log("evo me iz enemyinst i slovo je "+word);
        
        odabranarijec+=word;
        Debug.Log("evo me iz enemyinst i odabrana rijec je "+ odabranarijec);
        Debug.Log(words[pokazivac].ToUpper());
        if(odabranarijec.Length>=4) {
            if(odabranarijec==words[pokazivac].ToUpper()) {
            characterScript.pucaj();
            pokazivac++;
            if(pokazivac==words.Count){
              StartCoroutine(GG());
            }
            Debug.Log("Tocna rijec");
            odabranarijec="";
        }
        else {
            Debug.Log("Kriva rijec");
            odabranarijec="";
            wrong.Play();
            StartCoroutine(DelayedWrongWord());
    
        }
        }

        
    }
    IEnumerator DelayedWrongWord()
    {
        // Wait for 1 second
        yield return new WaitForSeconds(0.4f);

        // After 1 second, execute the following code
       
        wrongWord();
    }

    IEnumerator DelayedSpawnLetters()
    {
        // Wait for 1 second
        yield return new WaitForSeconds(0.6f);

        // After 1 second, execute the following code
       
        SpawnObjectsWithLetters();
    }

    void wrongWord() {
         GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
            foreach (GameObject enemy in enemies)
        {
            // Find the "Border" child object and activate it
            Transform border = enemy.transform.Find("Border");
            if (border != null)
            {
                border.gameObject.SetActive(false);
            }
            else
            {
                Debug.LogWarning("Border child not found for enemy: " + enemy.name);
            }
        }
    }

   public void SpawnObjectsWithLetters()
    {
        if (objectToInitialize != null && spawnPosition != null)
        {
            Vector3 spawnPos = spawnPosition.position;
            Debug.Log("IZ SPAWNA POKAZIVAC JE "+pokazivac);
           int i =0;
           String shuffled=ShuffleString(words[pokazivac]);
           Debug.Log("Spawnana Rijec je "+words[pokazivac]);
           Debug.Log("Shufflana Rijec je "+shuffled);
                foreach (char letter in shuffled)
                {
                    string letterString = letter.ToString().ToUpper();
                    Transform childToInstantiate = alphabet.Find(letterString);

                    if (childToInstantiate != null)
                    {
                        // Create a new object instance
                        GameObject newObject = Instantiate(objectToInitialize);
                        newObject.transform.position = spawnPos + Vector3.right * (i * offset);

                        // Set the sprite and scale for the new object
                        SpriteRenderer targetSpriteRenderer = newObject.transform.Find("Square").GetComponent<SpriteRenderer>();
                        SpriteRenderer childSpriteRenderer = childToInstantiate.GetComponent<SpriteRenderer>();
                        targetSpriteRenderer.sprite = childSpriteRenderer.sprite;
                        newObject.transform.Find("Square").localScale = newSize;
                    }
                    else
                    {
                        Debug.LogError("Letter " + letterString + " not found in alphabet!");
                    }

                    i++;
                }
            
        }
        else
        {
            Debug.LogError("Object to initialize or spawn position is not assigned!");
        }
    }

    public void setGueesedWord(String word) {
        odabranarijec = word;
       

    }

    public void SpawnObjectsWithLettersTimeout() {
        StartCoroutine(DelayedSpawnLetters());
    }

    void Update()
    {
        //Debug.Log(words.Count);
         if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            // Your code to be executed when Enter key is pressed
               Debug.Log("Bravo preso si level");
                 
                   if(GlobalManagerScript.level<2)
                 GlobalManagerScript.level=2;
                 GlobalManagerScript.zadnjiodigranlvl=1;
                   loading.Instance.LoadScene("Donelvl1");
               
        }
        // Check the position of the objects and trigger game over if they cross the Y threshold
        GameObject[] objects = GameObject.FindGameObjectsWithTag("enemy");
        if(objects.Length>0) {
        GameObject obj=objects[1];
        // Debug.Log(obj.transform.position.y);
       // Debug.Log(gameOverYPosition);
        
            if (obj.transform.position.y < gameOverYPosition) {
                StartCoroutine(DelayedSpawnLetters());
                odabranarijec="";
                loseLife.Play();

            foreach(GameObject enemyObj in objects) 
            {
                Destroy(enemyObj);
                Debug.Log("Game Over");
                

            }
             GameObject[] lives = GameObject.FindGameObjectsWithTag("life");
             Destroy(lives[0]);
             
             numoflives--;
             if(numoflives==0) {
                Debug.Log("GOTOVA IGRA LUZERU");
                   GlobalManagerScript.zadnjiodigranlvl=1;
                SceneManager.LoadScene("GameOver");
             }
             else {
                
                
             }

        }
        }
    }
}
