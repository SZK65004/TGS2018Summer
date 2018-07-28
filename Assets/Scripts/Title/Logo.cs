using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Logo : MonoBehaviour {

    public Image image;
    public Text texture;

    private float AddValue;
   
    // Use this for initialization
    void Start () {
        AddValue = 0.05f;
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
        texture.color = new Color(texture.color.r, texture.color.g, texture.color.b, 0);
    }
	
	// Update is called once per frame
	void Update () {
        float alpha  = image.color.a + AddValue; 
        Color color = new Color(image.color.r, image.color.g, image.color.b, 0);
        image.color = new Color(color.r, color.g, color.b, alpha);
        texture.color = new Color(texture.color.r, texture.color.g, texture.color.b, alpha);

        if (image.color.a > 1.0f)
        {
            AddValue *= -1;
            image.color = new Color(color.r, color.g, color.b, 1);
            texture.color = new Color(texture.color.r, texture.color.g, texture.color.b, 1);
        }

        if (image.color.a < 0)
        {
            AddValue *= -1;
            image.color = new Color(color.r, color.g, color.b, 0);
            texture.color = new Color(texture.color.r, texture.color.g, texture.color.b, 0);
        }

        //シーン移動

        if(Input.GetKeyDown(KeyCode.Space))
        {

            //SceneManager.LoadScene("Game");
        }
        
    }
}
