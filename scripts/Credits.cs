using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour
{
    public Texture[] myTextures = new Texture[59];
    int maxTextures;
    int arrayPos = 0;
    float time;

    void Start()
    {
        maxTextures = myTextures.Length - 1;
		Invoke("goToNextScene", 10f);
	}
	void goToNextScene(){
		Application.LoadLevel(0);
	}

    
    void Update()
    {
        if(arrayPos < 59) time += Time.deltaTime;
        print(time);
        if (time >= 0.03 && arrayPos < 59)
        {
            gameObject.GetComponent<Renderer>().material.mainTexture = myTextures[arrayPos];
            arrayPos++;
            time = 0;
        }
    }
}

/*
using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour
{
    public Texture2D[] slides = new Texture2D[59];
    public float changeTime = 10.0f;
    private int currentSlide = 0;
    private float timeSinceLast = 1.0f;

    void Start()
    {
        //
    }

    void Update()
    {
        for (int i = 0; i < slides.Length; i++)
        {
            gameObject.renderer.material.SetTexture(i, slides[i]);
        }
        if (currentSlide >= slides.Length)
        {
            currentSlide = slides.Length;
        }
    }
}
*/