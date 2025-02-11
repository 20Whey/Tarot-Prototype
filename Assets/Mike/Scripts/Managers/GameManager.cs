using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum GameState
{
	START,
	PLAYER,
	CLIENT,
	WON,
	LOST
}

public enum PlayerState
{
	Base,
	PlayingCard
}

public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set; }
	public OptionsManager OptionsManager { get; private set; }
	public AudioManager AudioManager { get; private set; }

	public GameState gameState;
	public PlayerState playerState;

	public TMP_Text stateText;
	public TMP_Text playerStateText;

	public bool playingCard = false;

	private void Awake()
	{
		if(Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
			InitializeManagers();
		}
		else if (Instance != this)
		{
			Destroy(gameObject);
		}
	}

	private void InitializeManagers()
	{
		OptionsManager = GetComponentInChildren<OptionsManager>();
		AudioManager = GetComponentInChildren<AudioManager>();

		if(OptionsManager == null)
		{
			GameObject prefab = Resources.Load<GameObject>("Prefabs/OptionsManager");
			if(prefab == null)
			{
				Debug.Log($"OptionsManager prefab not found");
			}
			else
			{
				Instantiate(prefab, transform.position, Quaternion.identity, transform);
				OptionsManager = GetComponentInChildren<OptionsManager>();
			}
		}
		if (AudioManager == null)
		{
			GameObject prefab = Resources.Load<GameObject>("Prefabs/AudioManager");
			if (prefab == null)
			{
				Debug.Log($"AudioManager prefab not found");
			}
			else
			{
				Instantiate(prefab, transform.position, Quaternion.identity, transform);
				AudioManager = GetComponentInChildren<AudioManager>();
			}
		}
	}

	private void Start()
	{
		gameState = GameState.START;
		playerState = PlayerState.Base;
		stateText.text = gameState.ToString();
		playerStateText.text = playerState.ToString();

		SetupPlay();
	}

	private void SetupPlay()
	{
		gameState = GameState.PLAYER;
		stateText.text = gameState.ToString();
	}

	public void StartPlayingCard()
	{
		playerState = PlayerState.PlayingCard;

		//Card inspect state stuff here
	}

	public void EndPlayingCard()
	{
		gameState = GameState.CLIENT;
		stateText.text = gameState.ToString();

		//Client dialogue state stuff here
	}
}
