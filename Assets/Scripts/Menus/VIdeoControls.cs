using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VIdeoControls : MonoBehaviour
{

    public GameObject gui ;
    public int time;
    // Start is called before the first frame update
    void Start()
    {
        gui.SetActive(false);
       
        StartCoroutine(EnableGameoverPanel ());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator EnableGameoverPanel()
    {
        yield return new     WaitForSeconds(time);

        gui.SetActive(true);
    }

    


}
