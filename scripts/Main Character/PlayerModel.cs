using UnityEngine;
using System.Collections;

public class PlayerModel : Character {
	public GameObject AnimatorMove;

	public float jetPackXRotation;
	public float jetPackYRotationLeft;
	public float jetPackYRotationRight;

	public float jetPackXRight;
	public float jetPackXLeft;
	public float jetPackY;
	private int _playerHealth = 8;
	private int _startHealth;
	private int newDir;
	private int _ammo = 40000;
	private GameObject _audio;
	public AudioClip _jumpSound;
	public GameObject prefabJetPack;
	public GameObject prefabGround;
	public GameObject prefabLeafs;
	public bool _WillJump;
	public AudioClip _playerDieSound;
	public int recoil = 0;
	public Texture _playerHead;
	public Texture[] _health;
	public int _maxJumps = 2;
	public int _jumps = 0;
	private GameObject _shakeCamera;
	private float _sizeX;
	private float _sizeY;
	private float _sizeZ;
	public bool isDead = false;
	public Vector3 newStarPosition;

    
	public GUITexture blackTexture;
    private Color blackTexColor;
    public bool isFadingOut;
    public bool isFadingIn;
	public float fadeSpeed = 1.5f;  
	public bool startDeadFade = false;


	private bool _openMenu = false;
	public Texture2D _menuText;

	//BOSS FIGHT

	public bool _inBossFight; //Set true in inspector on player in boss scene.

	
	void Awake ()
	{
		// Set the texture so that it is the the size of the screen and covers it.
		blackTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
	}

	void Start () {
		_sizeX = transform.localScale.x;
		_sizeY = transform.localScale.y;
		_sizeZ = transform.localScale.z;

		_startHealth = _playerHealth;
		_shakeCamera = GameObject.Find("Main Camera");
		_audio = GameObject.Find("Audio");
		_canJump = false;
		_canAttack = true;
		_canShoot = true;
		_speed = 40;
		_maxSpeed = 5f;
		_jumpSpeed = 11;
		_gun = this.transform.GetChild(0);	//gun
		_gun.SendMessage("Rotate", 1);
		startPosition = this.transform.localPosition;
        blackTexture.pixelInset = new Rect(0, 0, Screen.width, Screen.height);
        blackTexColor = blackTexture.color;
        blackTexColor.a = 0f;
        blackTexture.color = blackTexColor;
        //isFadingOut = false;
        //isFadingIn = false;



    }
	
	// Update is called once per frame
	void Update () {
		checkGround();
		controllerInput();
		checkStandingStill();

		if(_inBossFight == false){
			updateJump();
			updateSpeed();
		}

		if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown (KeyCode.JoystickButton7)){
			if(_openMenu == false){
				_openMenu = true;
				Time.timeScale = 0.0f;
			}
			
			else if(_openMenu == true){
				_openMenu = false;
				Time.timeScale = 1.0f;
			}
		}
		if(_openMenu == true && Input.GetKeyDown (KeyCode.JoystickButton0)){
			Time.timeScale = 1.0f;
			Application.LoadLevel(0);
		}
		else if(_openMenu == true && Input.GetKeyDown (KeyCode.Y)){
			Time.timeScale = 1.0f;
			Application.LoadLevel(0);
		}
		if(_openMenu == true && Input.GetKeyDown (KeyCode.JoystickButton1)){
			_openMenu = false;
			Time.timeScale = 1.0f;
		}

		if(this.transform.localPosition.y < -30) die();
		//blackTexture.renderer.material.color.a =f;
		//blackTexture.color.a =f;
		//blackTexColor.a = f;
		/*
        if (isFadingOut)
        {
            blackTexColor.a += 0.01f;
            blackTexture.color = blackTexColor;
        }
        if (isFadingIn)
        {
            blackTexColor.a -= 1.1f;
            blackTexture.color = blackTexColor;

		
        }
*/
		if (startDeadFade)
		{
			if (isDead)
			{
				blackTexture.color = Color.Lerp(blackTexture.color, Color.black, fadeSpeed * Time.deltaTime);

			}
			else
			{
				blackTexture.color = Color.Lerp(blackTexture.color, Color.clear, (fadeSpeed +0.5f) * Time.deltaTime);
				if (blackTexture.color == Color.clear)
				{
					startDeadFade = false;
				}
			}
		
		}
    }


	public void updateJump(){
		_jumpSpeed = (15 + IngameShop._jumpUpgrade);
	}

	public void updateSpeed(){
		_maxSpeed = (8f + IngameShop._speedUpgrade);
	}

	void FadeToClear ()
	{
		// Lerp the colour of the texture between itself and transparent.
		GetComponent<GUITexture>().color = Color.Lerp(GetComponent<GUITexture>().color, Color.clear, fadeSpeed * Time.deltaTime);
	}
	
	
	void FadeToBlack ()
	{
		// Lerp the colour of the texture between itself and black.
		GetComponent<GUITexture>().color = Color.Lerp(GetComponent<GUITexture>().color, Color.black, fadeSpeed * Time.deltaTime);
	}



	void checkStandingStill()
	{
		if (isDead == false)
		{
			if (transform.GetComponent<Rigidbody2D>().velocity.x == 0 &&  transform.GetComponent<Rigidbody2D>().velocity.y == 0)
			{
				if(!Input.GetKey(KeyCode.JoystickButton2) &&  !Input.GetKey("z"))
				{
					AnimatorMove.SendMessage("StandStillAnimatie");
				}
			}
		}
	}
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (isDead == false)
		{
			if(coll.gameObject.tag == "Enemy"){
				coll.gameObject.SendMessage("Activate", this.gameObject.GetComponent<PlayerModel>());

				_shakeCamera.SendMessage("cameraShake");
			}
			if(coll.gameObject.tag == "Plant"){
				coll.gameObject.SendMessage("Activate", this.gameObject.GetComponent<PlayerModel>());
				
				_shakeCamera.SendMessage("cameraShake");
			}
			if(coll.gameObject.tag == "Muuska"){
				//Debug.Log("COLLISION MET MUUSKA");
				coll.gameObject.transform.SendMessage("Activate", this.gameObject.GetComponent<PlayerModel>());
				_shakeCamera.SendMessage("cameraShake");
				//other.gameObject.SendMessage("Activate", this.gameObject.GetComponent<PlayerModel>());
			}
		}

	if(coll.gameObject.tag == "Ground")
		{
			if (_WillJump == true)
			{Vector3 newPosition = new Vector3(transform.position.x, transform.position.y - 0.75f,transform.position.z);
				Instantiate(prefabGround, newPosition, transform.rotation);
				_WillJump = false;
			}
			else
			{
				_WillJump = true;
			}
		}
		if(coll.gameObject.tag == "LeafCollison")
		{
			if (_WillJump == true)
			{
				Vector3 newPosition = new Vector3(transform.position.x, transform.position.y - 2.0f,transform.position.z);
				Instantiate(prefabLeafs, newPosition, transform.rotation);
				_WillJump = false;
			}
			else
			{
				_WillJump = true;
			}
		}
	}
	
	void OnCollisionStay2D( Collision2D coll ){
		if(coll.gameObject.tag == "Platform"){
			coll.gameObject.SendMessage("Activate", this.gameObject.GetComponent<PlayerModel>());
		}

	}

	void OnTriggerEnter2D(Collider2D other){

		if (isDead == false)
		{
			if(other.gameObject.tag == "Pickup"){
				other.gameObject.SendMessage("Activate", this.gameObject.GetComponent<PlayerModel>());		//Sends this script + the score script to the pickup
			}

			if(other.gameObject.tag == "Checkpoint"){
				startPosition =  other.transform.localPosition;
				other.gameObject.SendMessage("StartAnimation");
				
			}

			if(other.gameObject.tag == "Trap"){
				_audio.SendMessage("EnemyCollison");

				other.gameObject.SendMessage("Activate", this.gameObject.GetComponent<PlayerModel>());
				_shakeCamera.SendMessage("cameraShake");
			}

			if(other.gameObject.tag == "PlantAwake"){
				//	PlayAudio.SendMessage("EnemyCollison");
				other.gameObject.SendMessage("AwakePlanet");
			}
			if(other.gameObject.tag == "MuuskaAwake"){
				other.gameObject.SendMessage("MuuskaAwake");
			}
			if(other.gameObject.tag == "LightSwitch"){
				other.gameObject.SendMessage("Activate", this.gameObject.GetComponent<PlayerModel>());
			}
			if(other.gameObject.tag == "SpawnEnemy"){
				other.gameObject.SendMessage("Activate", this.gameObject.GetComponent<PlayerModel>());
			}
		}

	}
	
	public void moveOnPlatform (Vector3 direction){
		this.transform.position += direction;
	}
	
	override public void shootDelay(){
		_canShoot = true;
	}
	private void checkGround(){
		Vector2 checkVec = new Vector2(transform.position.x-0.2f, transform.position.y);
		Vector2 checkVec2 = new Vector2(transform.position.x+0.2f, transform.position.y-(1.5f*_sizeY));
		bool isGrounded = Physics2D.OverlapArea(checkVec, checkVec2, LayerMask.GetMask("Level"));

		if(isGrounded && transform.GetComponent<Rigidbody2D>().velocity.y <= 0f){
			_jumps = _maxJumps;
			_canJump = true;

		} else if(!isGrounded) {
			if(_jumps == _maxJumps)
			{
				_jumps = _maxJumps-1;	//when he falls]

			}
		}
	}
	private void jump(){

		if(_canJump == true){
			_WillJump = true;
			_jumps--;
			_audio.SendMessage("playSound", _jumpSound);
			transform.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.GetComponent<Rigidbody2D>().velocity.x, _jumpSpeed);
			AnimatorMove.SendMessage("JumpAnimatie");

			if(_jumps < 1)
			{
				Debug.Log("dUBBEL JUMP");
				//Vector3 tempDir;
				//tempDir = Quaternion.Euler(0f, 0f, -90f);
			/*
				if (newDir == 0 )
				{
					//public float jetPackXRotation;
					//public float jetPackYRotationLeft;
					//public float jetPackXRotationRight;

					Quaternion rotation = Quaternion.Euler(jetPackXRotation, jetPackYRotationLeft, 0);

					// Quaternion rotation = Quaternion.Euler(0, 30, 0);
					Vector3 jatpackPostion = new Vector3(jetPackXRight,jetPackY,0);
					(Instantiate(prefabJetPack, transform.position+jatpackPostion, rotation)as GameObject).transform.parent = this.transform;
				}
				else
				{
					Quaternion rotation = Quaternion.Euler(jetPackXRotation, jetPackYRotationRight, 0);
					Vector3 jatpackPostion = new Vector3(jetPackXLeft,jetPackY,0);
					(Instantiate(prefabJetPack, transform.position+jatpackPostion, transform.rotation)as GameObject).transform.parent = this.transform;

				}
				*/
				//(Instantiate(prefabJetPack, transform.position+jatpackPostion, transform.rotation)as GameObject).transform.parent = this.transform;
			//	(Instantiate(floor, new Vector3(randomDistance*rowZ, 0, rowX * 8f), Quaternion.identity)as GameObject).transform.parent = floorGroup.transform;

				_canJump = false;
			}
		}
	}
	
	private void shoot(){
		if(_canShoot && _ammo > 0){
			_audio.SendMessage("ShootGun");
			_gun.SendMessage("Activate", this);
			_ammo-= 1;
			_canShoot = false;
			AnimatorMove.SendMessage("shootAnimatie");
		
			if (newDir > 0 ) transform.GetComponent<Rigidbody2D>().AddForce(newDir * Vector2.right * -recoil);
			if (newDir < 0 ) transform.GetComponent<Rigidbody2D>().AddForce(newDir * Vector2.right * -recoil);
			if (newDir < 0 && transform.GetComponent<Rigidbody2D>().velocity.x > _maxSpeed) transform.GetComponent<Rigidbody2D>().velocity = new Vector2(_maxSpeed-2f, transform.GetComponent<Rigidbody2D>().velocity.y);
			if (newDir > 0 && transform.GetComponent<Rigidbody2D>().velocity.x < -_maxSpeed) transform.GetComponent<Rigidbody2D>().velocity = new Vector2(-_maxSpeed+2f, transform.GetComponent<Rigidbody2D>().velocity.y);

		}
	}
	public void move(int dir)
	{
		newDir = dir;
		if (dir > 0 && transform.GetComponent<Rigidbody2D>().velocity.x > _maxSpeed) transform.GetComponent<Rigidbody2D>().velocity = new Vector2(_maxSpeed, transform.GetComponent<Rigidbody2D>().velocity.y);
		if (dir < 0 && transform.GetComponent<Rigidbody2D>().velocity.x < -_maxSpeed) transform.GetComponent<Rigidbody2D>().velocity = new Vector2(-_maxSpeed, transform.GetComponent<Rigidbody2D>().velocity.y);

		//HARDCODED
		Vector2 checkVec = new Vector2(transform.position.x, transform.position.y+0.6f);
		Vector2 checkVec2 = new Vector2(transform.position.x+(0.4f*_sizeX*dir), transform.position.y);
		bool isCollision = Physics2D.OverlapArea(checkVec, checkVec2, LayerMask.GetMask("Level"));
		//---

		if(!isCollision) transform.GetComponent<Rigidbody2D>().AddForce(dir * Vector2.right * _speed*( Time.deltaTime * 100));
		transform.localScale = new Vector3(dir*_sizeX, _sizeY, _sizeZ);
		_gun.SendMessage("Rotate", dir);
		//AnimatorMove.SendMessage("StandStillAnimatie");
		if(_canJump) AnimatorMove.SendMessage("MovementAnimatie");
		
	}
	private void controllerInput(){
		if(isDead == false){
			if (this.gameObject.GetComponent<IngameShop>()._openShop == false) {

				if (Input.GetKey("a")) move(-1);
				if (Input.GetKey("d")) move(1);
				if (Input.GetAxis("Horizontal")  == -1) move(-1);
				if (Input.GetAxis("Horizontal")  == 1)	move(1);			
				if (Input.GetKeyDown(KeyCode.JoystickButton0)) jump ();		//A
				if (Input.GetKey(KeyCode.JoystickButton2))shoot ();			//X
				if(Input.GetKeyDown("w")) jump ();
				if(Input.GetKey("z"))shoot ();
			}
		}
	}

	private void die(){
		//DeadAnimatie()
	

	//	isFadingOut = false;
      //  isFadingIn = true;

	
		//StartCoroutine("FadeOut");
        Time.timeScale = 1.0f;
		// sound normaal speed
		_audio.SendMessage("Normal");
		//GetComponent<Audio>().Normalspeed();
		//Respawn player;
		_playerHealth = _startHealth;
		isDead = false;

		// game oversound.. 
		//Application.LoadLevel(0);

		if(_inBossFight == true){
			Application.LoadLevel("Boss");
		}
		else{
			this.transform.localPosition =startPosition ;
			transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,0f);
		}
	}
	public void getDamage( int amount ){
		_playerHealth -= amount;
		if(_playerHealth <= 0 && !isDead){
			isDead = true;
			_playerHealth = 0;
			//On Death Function
			_audio.SendMessage("Slow");
			_audio.SendMessage("playSound", _playerDieSound);
			AnimatorMove.SendMessage("DeadAnimatie");
			Invoke("die", 1.9f);
			Invoke("somethingLater", 0.9f);

			Time.timeScale = 0.3f;
		//	GetComponent<Audio>().SlowDown();
		//	audio.pitch = Time.timeScale = 0.3f;
         //   isFadingIn = false;
           // isFadingOut = true;
			//StartCoroutine("FadeIn");
		//	startDeadFade = true;
		
		
        }
	}
	public void somethingLater()
	{

		startDeadFade = true;

	}

	/*
	IEnumerator FadeIn() {
		for (float f = 0f; f <= 250f; f += 0.1f) {

			blackTexColor.a += f;
			blackTexture.color = blackTexColor;

			//if (f == 250f){}
			yield return new WaitForSeconds(.1f);
		}

	}
	/*IEnumerator FadeOut() {
		blackTexColor.a = 0f;
		/*
		for (float f = 0; f >= 250f; f -= 0.1f) {
			blackTexColor.a = f;
			blackTexture.color = blackTexColor;
			yield return new WaitForSeconds(.1f);
		}

	}
	*/

	public int getHealth (){
		return _playerHealth;
	}
	
	public void addHealth ( int amount ){
		_playerHealth += amount;
		if(_playerHealth > 8) _playerHealth = 8;
	}
	
	public  void addAmmo ( int amount ){
		_ammo += amount;
	}
	
	public void addScore( int amount ){
		this.gameObject.GetComponent<Score>().addScore( amount );
		// Calls addscore inside the score script.
	}
	
	void OnGUI() {
		GUI.DrawTexture( new Rect ( Screen.width * 0.0f, Screen.height * 0.0f, Screen.width * 0.1f, Screen.height * 0.1f), _playerHead, ScaleMode.ScaleToFit, true, 1.0f);
	//	GUI.DrawTexture( new Rect ( Screen.width * 0.025f , Screen.height * 0.125f, Screen.width * 0.05f, Screen.height * 0.1f), _diamonds, ScaleMode.ScaleToFit, true, 1.0f);
			
		//Change this with the Score GUI in the Score script
		//GUI.TextArea( new Rect ( Screen.width * 0.025f , Screen.height * 0.2f, Screen.width * 0.1f, Screen.height * 0.05f), "Score : 1000");

		if(_playerHealth > 0) GUI.DrawTexture( new Rect ( Screen.width * 0.05f, Screen.height * 0.0f, Screen.width * 0.15f, Screen.height * 0.15f), _health[_playerHealth] , ScaleMode.ScaleToFit, true, 1.0f);
		
		
		//PlayerHealth Display
		//GUI.Box( new Rect (0, Screen.height * 0.9f, Screen.width * 0.2f, Screen.height * 0.1f), "Player Health \n \n" + _playerHealth + " / 8");
		
		//Ammo
		//GUI.Box( new Rect (Screen.width * 0.8f, Screen.height * 0.9f, Screen.width * 0.2f, Screen.height * 0.1f), "Ammo \n \n" + _ammo);


		if(_openMenu == true) GUI.DrawTexture( new Rect (Screen.width*0.3f, Screen.height*0.3f, Screen.width*0.4f, Screen.height*0.4f), _menuText, ScaleMode.StretchToFill, true, 1.0f);
	}
	
}
