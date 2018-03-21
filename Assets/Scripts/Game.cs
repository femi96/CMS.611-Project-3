using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {
	// Game:
	//		Controller that handles game data.

	
	// Game variables
	public GameState gameState;

	private IWand wand1;
	private IWand wand2;
	private IMap map;
	
	// UI variables
	public Transform canvas;

	public GameObject wandUI1;
	public GameObject wandUI2;

	public GameObject pausedUI;
	public GameObject wand1WinUI;
	public GameObject wand2WinUI;
	public GameObject titleUI;

	private Text wandUI1money;
	private Text wandUI2money;
	private Text wandUI1power;
	private Text wandUI2power;
	
	public GameObject scoreUI;
	public Text score1UI;
	public Text score2UI;

	// Game tick variables
	private float time;
	private float tickTime = 0.4f;
	private int tick;

    // Audio
    [Header("Audio")]
    public AudioSource musicBG;
	public Text musicBGVolume;
	public Text musicBGMute;
    public AudioClip copSound;
    public AudioClip bankSound;

    private AudioSource source;


    // Use this for finding components
    void Awake() {
		map = transform.Find("Map").gameObject.GetComponent<Map>();
		wand1 = transform.Find("Wand1").gameObject.GetComponent<Wand>();
		wand2 = transform.Find("Wand2").gameObject.GetComponent<Wand>();

		wandUI1money = wandUI1.transform.Find("MValue").gameObject.GetComponent<Text>();
		wandUI1power = wandUI1.transform.Find("PValue").gameObject.GetComponent<Text>();
		wandUI2money = wandUI2.transform.Find("MValue").gameObject.GetComponent<Text>();
		wandUI2power = wandUI2.transform.Find("PValue").gameObject.GetComponent<Text>();
        source = GetComponent<AudioSource>();

    }

	// Use this for initialization
	void Start() {
		ChangeGameState(GameState.Title);

		time = 0;
		GameTick();
	}
	
	// Update is called once per frame
	void Update() {

		time += Time.deltaTime;
		if(time > tickTime) GameTick();

		if(Input.GetKeyDown(KeyCode.O)) { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); }
		if(Input.GetKeyDown(KeyCode.P)) {
			if(gameState == GameState.Playing) { ChangeGameState(GameState.Paused); } else
			if(gameState == GameState.Paused || gameState == GameState.Title) { ChangeGameState(GameState.Playing); }
		}

		if(Input.GetKeyDown(KeyCode.G)) {
			musicBG.volume += 0.005f;
			musicBGVolume.text = "Volume: "+ Mathf.RoundToInt(100*musicBG.volume/0.05f) +"%";
		}
		if(Input.GetKeyDown(KeyCode.H)) {
			musicBG.volume -= 0.005f;
			musicBGVolume.text = "Volume: "+ Mathf.RoundToInt(100*musicBG.volume/0.05f) +"%";
		}
		if(Input.GetKeyDown(KeyCode.M)) {
			musicBG.mute = !musicBG.mute;
			if(musicBG.mute) musicBGMute.text = "M to Unmute";
			else musicBGMute.text = "M to Mute";
		}
	}

    void MovementTick()
    {
        
    }
	// Game tick
	private void GameTick() {
        time -= tickTime;
		tick += 1;
		
		wand1.Pop();
		wand2.Pop();
		
		WandTakeOver(wand1);
		WandTakeOver(wand2);

		if(tick % 3 == 0) { // This is generation rate (currently every frame because of || true)
			for(int y = 0; y < map.GetMapSize(); y++) {
				for(int x = 0; x < map.GetMapSize(); x++) {
					map.GetPlace(x, y).Generate();
				}
			}
		}

		map.UpdateMap();

		UpdateCanvasUI();

		// Temporary win condition
		int score1 = Mathf.RoundToInt((float)(wand1.GetPower() + wand1.GetMoney()/2));
		int score2 = Mathf.RoundToInt((float)(wand2.GetPower() + wand2.GetMoney()/2));

		score1UI.text = ""+score1;
		score2UI.text = ""+score2;

		if(score1 - score2 >= 200) {
			ChangeGameState(GameState.Win1);
		}

		if(score2 - score1 >= 200) {
			ChangeGameState(GameState.Win2);
		}
	}

	// Wand takeover position
	private void WandTakeOver(IWand wand) {
		
		IPlace place = map.GetPlace(wand.GetPosition());

		if(place != null && place.GetOwner() != wand) {
			if(place.TakeOver(wand)) {
				place.SetOwner(wand);
                PlayTakeOverSound(place);

			}
		}
	}

    private void PlayTakeOverSound(IPlace place)
    {
        if(place.GetPlaceType() == PlaceType.Bank)
        {
            source.PlayOneShot(bankSound, 0.5f);
        } else if(place.GetPlaceType() == PlaceType.Police)
        {
            source.PlayOneShot(copSound, 0.5f);
        }
    }

	// Update cavnasUI each tick
	private void UpdateCanvasUI() {
		wandUI1money.text = wand1.GetMoney().ToString();
		//wandUI1power.text = wand1.GetPower().ToString();
        wandUI1power.text = ((int)wand1.GetPower()).ToString();
        wandUI2money.text = wand2.GetMoney().ToString();
		//wandUI2power.text = wand2.GetPower().ToString();
        wandUI2power.text = ((int)wand2.GetPower()).ToString();

        float canvasHeight = canvas.GetComponent<RectTransform>().rect.height;

		int score1 = Mathf.RoundToInt((float)(wand1.GetPower() + wand1.GetMoney()/2));
		int score2 = Mathf.RoundToInt((float)(wand2.GetPower() + wand2.GetMoney()/2));

		scoreUI.transform.Find("Score12").GetComponent<RectTransform>()
			.sizeDelta = new Vector2(20, canvasHeight*(float)(score2 - score1)/200);
		scoreUI.transform.Find("Score21").GetComponent<RectTransform>()
			.sizeDelta = new Vector2(20, canvasHeight*(float)(score1 - score2)/200);
	}

	private void ChangeGameState(GameState newState) {
		gameState = newState;

		if(gameState == GameState.Playing) {
			Time.timeScale = 1;
		} else {
			Time.timeScale = 0;
		}

		pausedUI.SetActive(gameState == GameState.Paused);
		wand1WinUI.SetActive(gameState == GameState.Win1);
		wand2WinUI.SetActive(gameState == GameState.Win2);
		titleUI.SetActive(gameState == GameState.Title);
	}
}
