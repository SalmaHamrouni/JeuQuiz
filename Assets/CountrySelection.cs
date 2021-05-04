using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountrySelection : MonoBehaviour
{
    SpriteRenderer image;
    private Texture2D texture;
    [SerializeField]
    Text continent;
    public delegate void onCountrySelected(string country);
    public static event onCountrySelected countrySelectedEvent;


    // Start is called before the first frame update
    void Start()
    {
     image=   GetComponent<SpriteRenderer>();
         texture = image.sprite.texture;
    
    }

    // Update is called once per frame
    void Update()
    {
        getTextureColor(texture,GetComponent<RectTransform>());
    }

    private void getTextureColor(Texture2D tex,RectTransform rectTransform)
    {
     

        Rect r = rectTransform.rect;
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, Input.mousePosition, Camera.main, out localPoint);

        int px = Mathf.Clamp(0, (int)(((localPoint.x - r.x) * tex.width) / r.width), tex.width);
        int py = Mathf.Clamp(0, (int)(((localPoint.y - r.y) * tex.height) / r.height), tex.height);

        Color32 col = tex.GetPixel(px, py);
        print(col.r+" , "+col.g + " , " + col.b);
        switch (col.r)
        {
            case 194:
               // print("Africa");
                continent.text = "Afrique";
                break;

            case 107:
              //  print("Asia");
                continent.text = "Asie";
                break;

            case 222:
              //  print("Europe");
                continent.text = "Europe";
                break;

            case 21:
              //  print("Australia");
                continent.text = "Australie";
                break;

            case 71:
               
                   // print("North america");
                    continent.text = "Amérique du Nord";
                break;
            case 115:

                // print("North america");
                continent.text = "Amérique du Sud";
                break;

             





            default:
               // print("Please choose a continent");
                continent.text = "Veuillez choisir un continent";
                break;

        }
        

       
        if (Input.GetMouseButtonUp(0))
            if (continent.text!= "Veuillez choisir un continent")
            {

            countrySelectedEvent?.Invoke(continent.text);
        }
         
    }
}
