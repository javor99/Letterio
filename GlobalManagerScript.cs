using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManagerScript : MonoBehaviour
{
    public static int level=1;
    public static int zadnjiodigranlvl;
   

    private void Awake()
    {
        // Ensure that the GlobalManager object persists between scenes.
        DontDestroyOnLoad(this.gameObject);
    }
}