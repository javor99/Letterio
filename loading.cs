using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;


public class loading : MonoBehaviour
{
    public static loading Instance;
    [SerializeField] private GameObject loaderCanvas;
    [SerializeField] private Image progressBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake() {
        if(Instance == null) {
            Instance=this;
            //DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }
    
    public async void LoadScene(string sceneName) {
        //Debug.Log("evo me");
        //var scene = SceneManager.LoadSceneAsync(sceneName);
        //scene.allowSceneActivation = false;
        //loaderCanvas.SetActive(true);

        //do {
          //  await Delay(100);
           // progressBar.fillAmount=scene.progress;


        //}
        //while(scene.progress<0.9f);

        //await Delay(1000);

        //scene.allowSceneActivation = true;
        //loaderCanvas.SetActive(false);
        SceneManager.LoadScene(sceneName);

    }

    public static Task Delay(double milliseconds)
{
    var tcs = new TaskCompletionSource<bool>();
    System.Timers.Timer timer = new System.Timers.Timer();
    timer.Elapsed += (o, e) => tcs.TrySetResult(true);
    timer.Interval = milliseconds;
    timer.AutoReset = false;
    timer.Start();
    return tcs.Task;
}
}
