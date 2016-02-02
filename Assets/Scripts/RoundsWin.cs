using UnityEngine;
using System.Collections;

public class RoundsWin : MonoBehaviour 
{
	public int PlayerRounds;
	public int EnemyRounds;

	public Transform PlayerRoundWin;
	public Transform PlayerRoundWinTwo;

	public Transform EnemyRoundWin;
	public Transform EnemyRoundWinTwo;

	public Transform PlayerRoundOne;
	public Transform PlayerRoundTwo;

	public Transform EnemyRoundOne;
	public Transform EnemyRoundTwo;

	public Transform PlayerVictory;
	public Transform EnemyVictory;

	public GameObject EnemyEmptyRound;
	public GameObject EnemyEmptyRoundTwo;

	public GameObject PlayerEmptyRound;
	public GameObject PlayerEmptyRoundTwo;


	public PlayerManager _playerManager;
	public EnemyAI _enemyAI;

	// Use this for initialization
	void Start () {
	
		PlayerRounds = 0;
		EnemyRounds = 0;

		PlayerEmptyRound = GameObject.FindGameObjectWithTag("PlayerEmptyRound");
		PlayerEmptyRoundTwo = GameObject.FindGameObjectWithTag("PlayerEmptyRoundTwo");

		EnemyEmptyRound = GameObject.FindGameObjectWithTag("EnemyEmptyRound");
		EnemyEmptyRound = GameObject.FindGameObjectWithTag("EnemyEmptyRoundTwo");

		_playerManager = GetComponent<PlayerManager>();
		_enemyAI = GetComponent<EnemyAI>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
}
