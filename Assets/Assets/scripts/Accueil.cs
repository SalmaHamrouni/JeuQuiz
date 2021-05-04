using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Accueil : MonoBehaviour
{[SerializeField]
    AudioSource audio;
    [SerializeField]
  Sprite  mutedImage;

    [SerializeField]
    Sprite normalImage;

    public void playGame()
    {
        SceneManager.LoadScene("GameScene2");
    }

    public void instruction()
    {
        SceneManager.LoadScene("GameScene3");
    }
    public void soundToggle()
    {
        if (audio.isPlaying)
        {
            audio.Stop();

            GetComponent<Image>().sprite = mutedImage;
        }
        else
        { audio.Play();

            GetComponent<Image>().sprite = normalImage;

        }
    }

    public void back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void quitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();


    }
   
}
