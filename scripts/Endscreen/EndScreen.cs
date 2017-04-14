using UnityEngine;
using System.Collections;

public class EndScreen : MonoBehaviour {

	public Texture2D endScreen;
    private float value;
    private float screenWidth;
    private float screenHeight;
    private float screenWidthHalf;
    private float screenHeightHalf;
    private int buttonWidth;
    private int buttonHeight;
    private int groupWidth;
    private int groupHeight;

    // Use this for initialization
    void Start()
    {
        value = -0.3f;
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        screenWidthHalf = Screen.width / 2;
        screenHeightHalf = Screen.height / 2;
        buttonWidth = 170;
        buttonHeight = 54;
        groupWidth = (int)(screenWidth * 0.9f);//300;
        groupHeight = (int)(screenHeight * 0.9f);//460;
		Invoke("goToNextScene", 5f);
	}

    // Update is called once per frame
    void Update()
    {
        value += Time.deltaTime / 3; //delta / time of animation
        if (value > 1f)
        {
            value = 1f;
        }
    }
    void OnGUI()
    {
		GUI.DrawTexture( new Rect( 0, 0, Screen.width, Screen.height), endScreen, ScaleMode.StretchToFill, true, 1.0f);

	}
	void goToNextScene(){
		Application.LoadLevel(4);
	}
}
//        //Group
//        float height = easeElastic(200f, -screenHeightHalf + (groupHeight / 2f), value);
//        //GUI.skin = endSkin;
//        //endSkin.box.alignment = TextAnchor.UpperCenter;
//	}
//        GUI.BeginGroup(new Rect(screenWidthHalf - (groupWidth / 2), screenHeight - groupHeight - 50 + height + 40, groupWidth, groupHeight));//Popup Window
//        GUI.Box(new Rect(0, 0, groupWidth, groupHeight), "");
//        int space = 10;
//        int posY = space + (int)(screenHeightHalf / 2);
//
//        //Buttons
//        endSkin.button.fontSize = 20;
//
//        //Play Button
//        if (GUI.Button(new Rect((groupWidth / 2) - (buttonWidth / 2), posY, buttonWidth, buttonHeight), "Play Again"))
//        {
//            Application.LoadLevel("protype");
//            Destroy(gameObject);
//        }
//
//        posY = posY + buttonHeight + space;
//
//        //Options Button
//        if (GUI.Button(new Rect((groupWidth / 2) - (buttonWidth / 2), posY, buttonWidth, buttonHeight), "To Main Menu"))
//        {
//            Application.LoadLevel("MainMenu");
//            Destroy(gameObject);
//        }
//
//        posY = posY + buttonHeight + space;
//
//        GUI.EndGroup();
//    }
//
//    private float easeElastic(float startValue, float endValue, float delta)
//    {
//        delta = Mathf.Pow(2, -20 * delta) * Mathf.Sin(delta * 2 * (Mathf.PI / 1)) + 1f;
//        float result = endValue - startValue;
//        result = result * delta;
//        result = result + startValue;
//        return result;
//    }
//}
