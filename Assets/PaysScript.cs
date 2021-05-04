using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PaysScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void changeLevel(){
        SceneManager.LoadScene("GameScene5");
    }

    /*void OnMouseEnter(){
        Debug.Log("over");
        GetComponent<Image>().enabled = false;
    }

    void OnMouseExit(){
        Debug.Log("exit");
        GetComponent<Image>().enabled = true;
    }*/

    // Update is called once per frame
    /*void Update()
    {
        if (Input.GetMouseButtonUp(0)){
            Debug.Log(name);
        }
    }*/
}
