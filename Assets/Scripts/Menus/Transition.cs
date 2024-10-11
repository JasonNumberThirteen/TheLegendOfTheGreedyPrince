using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    
    public GameObject canvas1;
    public GameObject canvas2;

    public string scene;
    public GameObject myPrefab;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("MusicSource(Clone)") == null) {
             Instantiate(myPrefab);
             }
             
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextScene(string scene)
    {
        SceneManager.LoadScene(scene);
        
    }

    public void turnAuthorsOn(){
        canvas1.SetActive(false);
        canvas2.SetActive(true);
    }

    public void turnAuthorsOff(){
        canvas1.SetActive(true);
        canvas2.SetActive(false);
    }


    
}
