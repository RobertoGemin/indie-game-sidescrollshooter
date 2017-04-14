using UnityEngine;
using System.Collections;

public class IngameShop : MonoBehaviour {

	public bool _openShop = false;

	//Currency
	//Use Diamonds Collected by Player, Should be variable available in PlayerModel.
	int _diamonds = 0;

	//Shop Measurements
	float _shopWidth;
	float _shopHeight;
	public GUIStyle _textStyle;
	public GUIStyle _upgradeStyle;
	public Font nieuwfont;

	//open first time
	private bool _opened = false;
	
	//Shop Textures
	public Texture2D shopBackground;			// Put in Shop Texture
	public Texture2D _upgradeBought;			// Add Textures for Bought / Not Bought items
	public Texture2D _speedBought;
	public Texture2D _jumpBought;
	public Texture2D _bulletBought;
	public Texture2D _notBought;				// Change Buy functions from String to Texture2D return. Bottom of script
	public Texture2D _upgradeText;
	public Texture2D _upgradeTextSelected;


	public Texture2D _speedImage;
	public Texture2D _jumpImage;
	public Texture2D _bulletImage;

	public Texture2D _speedText;
	public Texture2D _jumpText;
	public Texture2D _bulletText;

	//public Texture2D _shopClose;
	public Texture2D _upgradeArrow;

	public Texture2D _openShopText;

	//Shop Variables					4 Purchase options. Maxed at 3

	//Make Public available for the playerscript to use in his variables for attack, jump, speed and armor
	public static int _speedUpgrade = 0;
	public static int _jumpUpgrade = 0;
	public static int _bulletsUpgrade = 0;
//	int _armor = 0;

	int _shopCursor = 1;
	int _cursorTimer = 10;
	int _cursorReset = 10;

	int _itemsPurchased = 0;			// Used in Formula for price
	int _price = 1;

	void Start () {
		_speedUpgrade = 0;
		_jumpUpgrade = 0;
		_bulletsUpgrade = 0;
	}
	void Update () {
		_shopWidth = (Screen.width * 0.6f);
		_shopHeight = (Screen.height * 0.6f);

		//Update Diamonds From Player
		//_diamonds = Player.getDiamonds();
		if (this.gameObject.GetComponent<PlayerModel>().isDead == false) {
			if(Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown (KeyCode.JoystickButton3)){
				if(_openShop == false){
					if(_opened == false && _diamonds > 0){
						_opened = true;
					}
					_openShop = true;
					Time.timeScale = 0.0f;
				}

				else if(_openShop == true){
					_openShop = false;
					Time.timeScale = 1.0f;
				}
				/*else if(_openShop == true){
					_openShop = false;
					Time.timeScale = 1.0f;
				}*/
			}
			else if(Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown (KeyCode.JoystickButton1)){
				if(_openShop == true){
					_openShop = false;
					Time.timeScale = 1.0f;
				}
			}

			if(_openShop == true){
				if(Input.GetKeyDown("w")) _shopCursor --;
				if(Input.GetKeyDown("s")) _shopCursor ++;

				if(Input.GetAxis("Vertical")  == 1 && _cursorTimer == 0){
					_cursorTimer = _cursorReset;
					_shopCursor --;
				}
				if(Input.GetAxis("Vertical")  ==  -1 && _cursorTimer == 0){
					_cursorTimer = _cursorReset;
					_shopCursor ++;
				}


				if(_cursorTimer > 0) _cursorTimer --;

				if (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.Return)){
					if(_shopCursor == 1) buySpeed (_price);
					if(_shopCursor == 2) buyJump (_price);
					if(_shopCursor == 3) buyBullets (_price);
				}

				if(_shopCursor > 3) _shopCursor = 1;
				if(_shopCursor < 1) _shopCursor = 3;
			}
		}

		//Update Prices
		_price = (1 + _itemsPurchased * 3);
	}

	public void addDiamonds( int amount ){
		_diamonds += amount;
	}

	void OnGUI(){
		//GUI.Label 			( new Rect ( Screen.width * 0.4f, Screen.height * 0.01f, Screen.width * 0.2f, Screen.width * 0.2f), "PRESS TAB to OPEN / CLOSE the SHOP");
		GUI.skin.font = nieuwfont;
		//Diamonds
		GUI.Label 			( new Rect ( Screen.width * 0.75f	, Screen.height * 0.11f, Screen.width * 2.1f, Screen.height * 0.1f), "Diamonds: " + _diamonds);

		if(_opened == false && _diamonds > 0){
			GUI.DrawTexture			( new Rect ( (Screen.width * 0.5f) - (0.3f * _shopWidth) , (Screen.height * 0.01f) , _shopWidth * 0.6f , _shopHeight * 0.275f), _openShopText, ScaleMode.StretchToFill, true, 1.0f );
		}


		if(_openShop){
			//Background
			GUI.DrawTexture		( new Rect ( (Screen.width * 0.5f) - (0.5f * _shopWidth) , (Screen.height * 0.5f) - (0.5f * _shopHeight),  _shopWidth,  _shopHeight), shopBackground, ScaleMode.StretchToFill, true, 1.0f ); 			

			//Title
			//GUI.Label 			( new Rect ( (Screen.width * 0.5f) - (0.1f * Screen.width) , (Screen.height * 0.5f) - (0.45f * _shopHeight) , Screen.width * 0.1f , Screen.height * 0.1f), "Upgrades Shop", _textStyle);

			//Text / Images of Upgrades
			//GUI.Label 			( new Rect ( (Screen.width * 0.5f) - (0.45f * _shopWidth) , (Screen.height * 0.5f) - (0.3f * _shopHeight) , _shopWidth * 0.1f , _shopHeight * 0.1f), "Speed", _textStyle);
			//GUI.Label 			( new Rect ( (Screen.width * 0.5f) - (0.45f * _shopWidth) , (Screen.height * 0.5f) - (0.1f * _shopHeight) , _shopWidth * 0.1f , _shopHeight * 0.1f), "Jump", _textStyle);
			//GUI.Label 			( new Rect ( (Screen.width * 0.5f) - (0.45f * _shopWidth) , (Screen.height * 0.5f) + (0.1f * _shopHeight) , _shopWidth * 0.1f , _shopHeight * 0.1f), "Bullets", _textStyle);
			GUI.DrawTexture			( new Rect ( (Screen.width * 0.5f) - (0.4f * _shopWidth) , (Screen.height * 0.5f) - (0.325f * _shopHeight) , _shopHeight * 0.15f , _shopHeight * 0.15f), _speedImage, ScaleMode.StretchToFill, true, 1.0f );
			GUI.DrawTexture			( new Rect ( (Screen.width * 0.5f) - (0.4f * _shopWidth) , (Screen.height * 0.5f) - (0.125f * _shopHeight) , _shopHeight * 0.15f , _shopHeight * 0.15f), _jumpImage, ScaleMode.StretchToFill, true, 1.0f );
			GUI.DrawTexture			( new Rect ( (Screen.width * 0.5f) - (0.4f * _shopWidth) , (Screen.height * 0.5f) + (0.075f * _shopHeight) , _shopHeight * 0.15f , _shopHeight * 0.15f), _bulletImage, ScaleMode.StretchToFill, true, 1.0f );

			//Bought / Not Bought textures
			for(int i=0;i<4;i++){
				GUI.DrawTexture	( new Rect ( (Screen.width * 0.5f) - (0.25f	*_shopWidth) + ( i * 0.1f * _shopWidth) , (Screen.height * 0.5f) - (0.3f * _shopHeight) , 0.08f * _shopWidth , 0.08f * _shopHeight), SpeedTexture(i), ScaleMode.StretchToFill, true, 1.0f);		
			}
			for(int i=0;i<4;i++){
				GUI.DrawTexture ( new Rect ( (Screen.width * 0.5f) - (0.25f	*_shopWidth) + ( i * 0.1f * _shopWidth) , (Screen.height * 0.5f) - (0.1f * _shopHeight) , 0.08f * _shopWidth , 0.08f * _shopHeight), JumpTexture(i), ScaleMode.StretchToFill, true, 1.0f);		
			}
			for(int i=0;i<4;i++){
				GUI.DrawTexture ( new Rect ( (Screen.width * 0.5f) - (0.25f	*_shopWidth) + ( i * 0.1f * _shopWidth) , (Screen.height * 0.5f) + (0.1f * _shopHeight) , 0.08f * _shopWidth , 0.08f * _shopHeight), BulletTexture(i), ScaleMode.StretchToFill, true, 1.0f);		
			}
			//for(int i=0;i<4;i++){
			//	GUI.DrawTexture ( new Rect ( (Screen.width * 0.5f) - (0.25f	*_shopWidth) + ( i * 0.1f * _shopWidth) , (Screen.height * 0.5f) + (0.3f * _shopHeight) , 0.08f * _shopWidth , 0.08f * _shopHeight), ArmorTexture(i), ScaleMode.StretchToFill, true, 1.0f);		
			//}


			//Prices
			GUI.Label 			( new Rect ( (Screen.width * 0.5f) + (0.2f * _shopWidth) , (Screen.height * 0.5f) - (0.3f * _shopHeight) , _shopWidth * 0.1f , _shopHeight * 0.1f), ""+_price, _textStyle);
			GUI.Label 			( new Rect ( (Screen.width * 0.5f) + (0.2f * _shopWidth) , (Screen.height * 0.5f) - (0.1f * _shopHeight) , _shopWidth * 0.1f , _shopHeight * 0.1f), ""+_price, _textStyle);
			GUI.Label 			( new Rect ( (Screen.width * 0.5f) + (0.2f * _shopWidth) , (Screen.height * 0.5f) + (0.1f * _shopHeight) , _shopWidth * 0.1f , _shopHeight * 0.1f), ""+_price, _textStyle);
			//GUI.Label 			( new Rect ( (Screen.width * 0.5f) + (0.25f * _shopWidth) , (Screen.height * 0.5f) + (0.3f * _shopHeight) , _shopWidth * 0.1f , _shopHeight * 0.1f), ""+_price, _textStyle);

			//Buttons
			if(_shopCursor == 1){
				if(GUI.Button 		( new Rect ( (Screen.width * 0.5f) + (0.3f * _shopWidth) , (Screen.height * 0.5f) - (0.3f * _shopHeight) , _shopWidth * 0.1f , _shopHeight * 0.1f), _upgradeTextSelected, _upgradeStyle)) 
				buySpeed(_price);
				if(GUI.Button 		( new Rect ( (Screen.width * 0.5f) + (0.3f * _shopWidth) , (Screen.height * 0.5f) - (0.1f * _shopHeight) , _shopWidth * 0.1f , _shopHeight * 0.1f), _upgradeText, _upgradeStyle)) 
				buyJump(_price);
				if(GUI.Button 		( new Rect ( (Screen.width * 0.5f) + (0.3f * _shopWidth) , (Screen.height * 0.5f) + (0.1f * _shopHeight) , _shopWidth * 0.1f , _shopHeight * 0.1f), _upgradeText, _upgradeStyle)) 
				buyBullets(_price);

				if (_cursorTimer == 0) GUI.DrawTexture			( new Rect ( (Screen.width * 0.5f) + (0.425f * _shopWidth) , (Screen.height * 0.5f) - (0.40f * _shopHeight) , _shopWidth * 0.4f , _shopHeight * 0.3f), _speedText, ScaleMode.StretchToFill, true, 1.0f );
			}

			if(_shopCursor == 2){
				if(GUI.Button 		( new Rect ( (Screen.width * 0.5f) + (0.3f * _shopWidth) , (Screen.height * 0.5f) - (0.3f * _shopHeight) , _shopWidth * 0.1f , _shopHeight * 0.1f), _upgradeText, _upgradeStyle)) 
					buySpeed(_price);
				if(GUI.Button 		( new Rect ( (Screen.width * 0.5f) + (0.3f * _shopWidth) , (Screen.height * 0.5f) - (0.1f * _shopHeight) , _shopWidth * 0.1f , _shopHeight * 0.1f), _upgradeTextSelected, _upgradeStyle)) 
					buyJump(_price);
				if(GUI.Button 		( new Rect ( (Screen.width * 0.5f) + (0.3f * _shopWidth) , (Screen.height * 0.5f) + (0.1f * _shopHeight) , _shopWidth * 0.1f , _shopHeight * 0.1f), _upgradeText, _upgradeStyle)) 
					buyBullets(_price);

				if (_cursorTimer == 0) GUI.DrawTexture			( new Rect ( (Screen.width * 0.5f) + (0.425f * _shopWidth) , (Screen.height * 0.5f) - (0.20f * _shopHeight) , _shopWidth * 0.4f , _shopHeight * 0.3f), _jumpText, ScaleMode.StretchToFill, true, 1.0f );
			}

			if(_shopCursor == 3){
				if(GUI.Button 		( new Rect ( (Screen.width * 0.5f) + (0.3f * _shopWidth) , (Screen.height * 0.5f) - (0.3f * _shopHeight) , _shopWidth * 0.1f , _shopHeight * 0.1f), _upgradeText, _upgradeStyle)) 
					buySpeed(_price);
				if(GUI.Button 		( new Rect ( (Screen.width * 0.5f) + (0.3f * _shopWidth) , (Screen.height * 0.5f) - (0.1f * _shopHeight) , _shopWidth * 0.1f , _shopHeight * 0.1f), _upgradeText, _upgradeStyle)) 
					buyJump(_price);
				if(GUI.Button 		( new Rect ( (Screen.width * 0.5f) + (0.3f * _shopWidth) , (Screen.height * 0.5f) + (0.1f * _shopHeight) , _shopWidth * 0.1f , _shopHeight * 0.1f), _upgradeTextSelected, _upgradeStyle)) 
					buyBullets(_price);

				if (_cursorTimer == 0) GUI.DrawTexture			( new Rect ( (Screen.width * 0.5f) + (0.425f * _shopWidth) , (Screen.height * 0.5f) , _shopWidth * 0.4f , _shopHeight * 0.3f), _bulletText, ScaleMode.StretchToFill, true, 1.0f );
			}
			//if(GUI.Button 		( new Rect ( (Screen.width * 0.5f) + (0.35f * _shopWidth) , (Screen.height * 0.5f) + (0.3f * _shopHeight) , _shopWidth * 0.1f , _shopHeight * 0.1f), _upgradeText, _upgradeStyle)) 
			//	buyArmor(_price);



			//SHOP CLOSE -- TEXTURE PRESS .. TO CLOSE
			//GUI.Label 			( new Rect ( (Screen.width * 0.5f) - (0.15f * Screen.width) , (Screen.height * 0.5f) + (0.35f * _shopHeight) , Screen.width * 0.1f , Screen.height * 0.1f), "Close Shop / Resume Game", _textStyle);
			//GUI.DrawTexture		( new Rect ( (Screen.width * 0.5f) - (0.15f * Screen.width) , (Screen.height * 0.5f) + (0.35f * _shopHeight) , _shopWidth * 0.5f , _shopHeight * 0.1f), _shopClose, ScaleMode.StretchToFill, true, 1.0f);

			//Shop Cursor
			//if(_shopCursor == 1) GUI.DrawTexture		( new Rect ( (Screen.width * 0.5f) + (0.43f * _shopWidth) , (Screen.height * 0.5f) - (0.285f * _shopHeight) , _shopWidth * 0.05f , _shopHeight * 0.05f), _upgradeArrow, ScaleMode.StretchToFill, true, 1.0f);
			//if(_shopCursor == 2) GUI.DrawTexture		( new Rect ( (Screen.width * 0.5f) + (0.43f * _shopWidth) , (Screen.height * 0.5f) - (0.085f * _shopHeight) , _shopWidth * 0.05f , _shopHeight * 0.05f), _upgradeArrow, ScaleMode.StretchToFill, true, 1.0f);
			//if(_shopCursor == 3) GUI.DrawTexture		( new Rect ( (Screen.width * 0.5f) + (0.43f * _shopWidth) , (Screen.height * 0.5f) + (0.115f * _shopHeight) , _shopWidth * 0.05f , _shopHeight * 0.05f), _upgradeArrow, ScaleMode.StretchToFill, true, 1.0f);
		}
	}

	// Buy Functions
	void buySpeed(int _price){
		if(_speedUpgrade < 3){
			if(_diamonds >= _price){
				_speedUpgrade ++;
				_diamonds -= _price;
				_itemsPurchased ++;
				Debug.Log ("Purchased SPEED upgrade");
			}
			else{
				Debug.Log ("Not Enough Currency");
			}
		}
		else if(_speedUpgrade == 3){
			Debug.Log ("Maximal amount already purchased");
		}
	}

	void buyJump(int _price){
		if(_jumpUpgrade < 3){
			if(_diamonds >= _price){
				_jumpUpgrade ++;
				_diamonds -= _price;
				_itemsPurchased ++;
				Debug.Log ("Purchased JUMP upgrade");
			}
			else{
				Debug.Log ("Not Enough Currency");
			}
		}
		else if(_jumpUpgrade == 3){
			Debug.Log ("Maximal amount already purchased");
		}
	}

	void buyBullets(int _price){
		if(_bulletsUpgrade < 3){
			if(_diamonds >= _price){
				_bulletsUpgrade ++;
				_diamonds -= _price;
				_itemsPurchased ++;
				Debug.Log ("Purchased BULLET upgrade");
			}
			else{
				Debug.Log ("Not Enough Currency");
			}
		}
		else if(_bulletsUpgrade == 3){
			Debug.Log ("Maximal amount already purchased");
		}
	}

	/*void buyArmor(int _price){
		if(_armor < 3){
			if(_diamonds >= _price){
				_armor ++;
				_diamonds -= _price;
				_itemsPurchased ++;
				Debug.Log ("purchased ARMOR upgrade");
			}
			else{
				Debug.Log ("Not Enough Currency");
			}
		}
		else if(_armor == 3){
			Debug.Log ("Maximal amount already purchased");
		}
	}*/


	Texture2D SpeedTexture(int i){
		if(_speedUpgrade >= i) return _speedBought;
		else return _notBought;
	}
	Texture2D JumpTexture(int i){
		if(_jumpUpgrade >= i) return _jumpBought;
		else return _notBought;
	}
	Texture2D BulletTexture(int i){
		if(_bulletsUpgrade >= i) return _bulletBought;
		else return _notBought;
	}
	/*Texture2D ArmorTexture(int i){
		if(_armor >= i) return _upgradeBought;
		else return _notBought;
	}*/

}
