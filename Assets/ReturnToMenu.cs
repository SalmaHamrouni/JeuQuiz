using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    bool inReturn;
    
    IEnumerator checkForTouchCoroutine() { 
    
    while(true)
        {if(Input.GetMouseButton(0))
            if(inReturn)
                    SceneManager.LoadScene("GameScene1");


            yield return null;
        }
    
    }
 
    public void OnPointerEnter(PointerEventData eventData)
    {
        inReturn = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(checkForTouchCoroutine());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        inReturn = false;
    }
}
