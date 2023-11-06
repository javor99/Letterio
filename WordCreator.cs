using UnityEngine;

public class WordCreator : MonoBehaviour
{
    public GameObject letterPrefab; // Reference to the letter prefab with children
    private float letterSpacing = 1.2f; // Adjust the spacing between letters
    public Transform inputGameObject; // Reference to the input game object

    void Update()
    {
        // Check for keyboard input

        // Display the word using the child elements
        DisplayWord("aloa", inputGameObject);
      
    }

    void DisplayWord(string currentWord, Transform parentTransform)
    {
        // Calculate the total width of the word
        float wordWidth = currentWord.Length * letterSpacing;

        // Calculate the starting position to center the word
        Vector3 position = parentTransform.position - new Vector3(wordWidth / 2f, 0f, 0f);

        // Offset the position vertically to place the word below the input game object
        float yOffset = -parentTransform.localScale.y / 2f; // Assumes the input game object scales uniformly
        position.y += yOffset;

        // Loop through each character in the current word
        for (int i = 0; i < currentWord.Length; i++)
        {
            char letter = currentWord[i];

            // Convert the letter to uppercase to match the child object names
            letter = char.ToUpper(letter);

            // Find the corresponding child element by name in the letterPrefab
            Transform letterElement = letterPrefab.transform.Find(letter.ToString());

            if (letterElement != null)
            {
                // Instantiate the child letter object
                GameObject letterObject = Instantiate(letterElement.gameObject, position, Quaternion.identity);

                // Set the parent of the instantiated letter to the parentTransform
                letterObject.transform.parent = parentTransform;

                // Update the position for the next letter
                position.x += letterSpacing;
            }
        }
    }
}
