using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	//Menu Measurements
	private float _menuWidth;
	private float _menuHeight;
    private float _labelWidth;
    private float _labelHeight;
    private float _buttonWidth;
    private float _buttonHeight;
    private float cursorX;

	public GUIStyle _textStyle;
	
	//Main Menu Textures
	public Texture2D menuBackground;
	public Texture2D _Arrow;
    public Texture2D _mainMenu;
    public Texture2D _Options;
    public Texture2D _Exit;
    public Texture2D _Play;
    public Texture2D _Settings;
    public Texture2D _ScreenRes;
    public Texture2D _AudioVol;
    public Texture2D _Return;
    public Texture2D _Quit;
    public Texture2D _Yes;
    public Texture2D _No;
    public Texture2D _Selected;
    public Texture2D _Loading;

    private Texture2D mainLabel;
    private Texture2D text1;
    private Texture2D text2;
    private Texture2D text3;

        //Temporary Solutions
    //private string mainLabel;
    //private string text1;
    //private string text2;
    //private string text3;

    //Inventions
    private string function1;
    private string function2;
    private string function3;

    //Main Menu Integers
    private int menuState = 0;
	private int _menuCursor = 1;
	private int _cursorTimer = 10;
	private int _cursorReset = 10;
    private int _buttonCount = 3;

    //Audio Clips
    public AudioClip scrollUp;
    public AudioClip scrollDown;
    public AudioClip select;

    void Start()
    {
	
	}

	void Update()
    {
		_menuWidth = (Screen.width * 0.6f);
		_menuHeight = (Screen.height * 0.6f);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GetComponent<AudioSource>().PlayOneShot(scrollUp);
            _menuCursor--;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            GetComponent<AudioSource>().PlayOneShot(scrollDown);
            _menuCursor++;
        }

		if (Input.GetAxis("Vertical")  == 1 && _cursorTimer == 0)
        {
			_cursorTimer = _cursorReset;
            GetComponent<AudioSource>().PlayOneShot(scrollUp);
			_menuCursor --;
		}
		if (Input.GetAxis("Vertical")  ==  -1 && _cursorTimer == 0)
        {
			_cursorTimer = _cursorReset;
            GetComponent<AudioSource>().PlayOneShot(scrollDown);
			_menuCursor ++;
		}

		if (_cursorTimer > 0) _cursorTimer --;

        //Press Joystick A button to confirm selected
		if (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyUp(KeyCode.Return))
        {
            GetComponent<AudioSource>().PlayOneShot(select);
            if (_menuCursor == 1) gameObject.SendMessage(function1);
            if (_menuCursor == 2) gameObject.SendMessage(function2);
            if (_menuCursor == 3) gameObject.SendMessage(function3);
		}
        if (_buttonCount == 2)
        {
            if (_menuCursor > 3) _menuCursor = 2;
            if (_menuCursor < 2) _menuCursor = 3;
        }
        else
        {
            if (_menuCursor > 3) _menuCursor = 1;
            if (_menuCursor < 1) _menuCursor = 3;
        }
	}

	void OnGUI(){

        //Main Menu
        if (menuState == 0)
        {
            _labelWidth = Screen.width * 0.25f;
            _labelHeight = Screen.height * 0.25f;
            _buttonWidth = _menuWidth * 0.35f;
            _buttonHeight = _menuHeight * 0.15f;
            _buttonCount = 3;
            cursorX = (Screen.width / 2) + (_menuWidth * 0.07f);

            mainLabel = _mainMenu;//"Main Menu";

            text1 = _Play;//"Play";
            text2 = _Options;//"Options";
            text3 = _Exit;//"Exit";

            function1 = "menuPlay";
            function2 = "menuOptions";
            function3 = "menuExit";
        }
        //Play
        else if (menuState == 1)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height/*(Screen.width * 0.5f) - (0.5f * _menuWidth) , (Screen.height * 0.5f) - (0.5f * _menuHeight),  _menuWidth,  _menuHeight*/), _Loading, ScaleMode.StretchToFill, true, 1.0f);
            Application.LoadLevel(1);
        }
        //Configuration Settings
        else if (menuState == 2)
        {
            _labelWidth = Screen.width * 0.45f;
            _labelHeight = Screen.height * 0.25f;
            _buttonWidth = _menuWidth * 0.45f;
            _buttonHeight = _menuHeight * 0.15f;
            _buttonCount = 3;
            cursorX = (Screen.width / 2) + (_menuWidth * 0.17f);

            mainLabel = _Settings;//"Configuration Settings";

            text1 = _ScreenRes;//"Screen Resolution";
            text2 = _AudioVol;//"Audio Volume";
            text3 = _Return;//"Return to Main Menu";

            function1 = "menuError";
            function2 = "menuError";
            function3 = "returnMenu";
        }
        //Exit Menu
        else if (menuState == 3)
        {
            _labelWidth = Screen.width * 0.30f;
            _labelHeight = Screen.height * 0.25f;
            _buttonWidth = _menuWidth * 0.35f;
            _buttonHeight = _menuHeight * 0.15f;
            _buttonCount = 2;
            cursorX = (Screen.width / 2) + (_menuWidth * 0.07f);

            mainLabel = _Quit;//"Quit Game?";

            text1 = null;//"";
            text2 = _Yes;//"Yes";
            text3 = _No;//"No";

            function1 = "";
            function2 = "quitApp";
            function3 = "returnMenu";
        }

        if (menuState != 1)
        {
            //Background
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height/*(Screen.width * 0.5f) - (0.5f * _menuWidth) , (Screen.height * 0.5f) - (0.5f * _menuHeight),  _menuWidth,  _menuHeight*/), menuBackground, ScaleMode.StretchToFill, true, 1.0f);

            //Title
            GUI.Label(new Rect((Screen.width / 2) - (_labelWidth / 2), (Screen.height * 0.3f) - (0.45f * _menuHeight), _labelWidth, _labelHeight), mainLabel, _textStyle);

            //Buttons
            if (GUI.Button(new Rect((Screen.width / 2) - (_buttonWidth / 2), (Screen.height * 0.5f) - (0.3f * _menuHeight), _buttonWidth, _buttonHeight), text1, _textStyle))
            {
                gameObject.SendMessage(function1);
            }
            if (GUI.Button(new Rect((Screen.width / 2) - (_buttonWidth / 2), (Screen.height * 0.5f) - (0.1f * _menuHeight), _buttonWidth, _buttonHeight), text2, _textStyle))
            {
                gameObject.SendMessage(function2);
            }
            if (GUI.Button(new Rect((Screen.width / 2) - (_buttonWidth / 2), (Screen.height * 0.5f) + (0.1f * _menuHeight), _buttonWidth, _buttonHeight), text3, _textStyle))
            {
                gameObject.SendMessage(function3);
            }

		    //Menu Cursor
            if (_menuCursor == 1)
            {
                GUI.DrawTexture(new Rect((Screen.width / 2) - (_buttonWidth * 1.1f / 2), (Screen.height * 0.5f) - (0.3f * _menuHeight), _buttonWidth * 1.1f, _buttonHeight), _Selected, ScaleMode.StretchToFill, true, 1.0f);
                //GUI.DrawTexture(new Rect(cursorX, (Screen.height * 0.5f) - (0.3f * _menuHeight), _menuWidth * 0.1f, _menuHeight * 0.1f), _Arrow, ScaleMode.StretchToFill, true, 1.0f);
            }
            if (_menuCursor == 2)
            {
                GUI.DrawTexture(new Rect((Screen.width / 2) - (_buttonWidth * 1.1f / 2), (Screen.height * 0.5f) - (0.1f * _menuHeight), _buttonWidth * 1.1f, _buttonHeight), _Selected, ScaleMode.StretchToFill, true, 1.0f);
                //GUI.DrawTexture(new Rect(cursorX, (Screen.height * 0.5f) - (0.1f * _menuHeight), _menuWidth * 0.1f, _menuHeight * 0.1f), _Arrow, ScaleMode.StretchToFill, true, 1.0f);
            }
            if (_menuCursor == 3)
            {
                GUI.DrawTexture(new Rect((Screen.width / 2) - (_buttonWidth * 1.1f / 2), (Screen.height * 0.5f) + (0.1f * _menuHeight), _buttonWidth * 1.1f, _buttonHeight), _Selected, ScaleMode.StretchToFill, true, 1.0f);
                //GUI.DrawTexture(new Rect(cursorX, (Screen.height * 0.5f) + (0.1f * _menuHeight), _menuWidth * 0.1f, _menuHeight * 0.1f), _Arrow, ScaleMode.StretchToFill, true, 1.0f);
            }
        }
	}

    //Play Function
    void menuPlay()
    {
        print("Playing");
        menuState = 1;
    }

    //Options Function
    void menuOptions()
    {
        print("Optioning");
        menuState = 2;
    }

    //Exit Function
    void menuExit()
    {
        print("Exiting");
        menuState = 3;
    }

    //Quit App Function
    void quitApp()
    {
        Application.Quit();
    }

    //Return to Main Menu Function
    void returnMenu()
    {
        menuState = 0;
    }

    //Error Function
    void menuError()
    {
        Debug.Log("Error: Property not available");
    }

}
