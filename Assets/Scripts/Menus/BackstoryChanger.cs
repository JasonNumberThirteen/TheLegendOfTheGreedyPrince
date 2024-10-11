using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class BackstoryChanger : MonoBehaviour
{
    //public GameObject image;
    public Image img;
    int currentPage = 0;

    public List<Sprite> sprite_list = new List<Sprite>();
    
    public int nb_pages; 

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangePage(){
        currentPage = currentPage + 1;
        if (currentPage > nb_pages){
            currentPage = 0;
        }
        img.sprite = sprite_list[currentPage];


    }

}
