using UnityEngine;
using System.Collections;

public class ArenaManager : MonoBehaviour {

	public int PlayerRounds;
	public int EnemyRounds;

	public bool IsWaiting;

	public int SpawnTimer = 50;
	public int Wait = 50;

	public GameObject PlayerRoundEmptyOne;
	public GameObject PlayerRoundEmptyTwo;

	public GameObject EnemyRoundEmptyOne;
	public GameObject EnemyRoundEmptyTwo;

	public GameObject PlayerRoundYellowOne;
	public GameObject PlayerRoundYellowTwo;

	public GameObject EnemyRoundYellowOne;
	public GameObject EnemyRoundYellowTwo;

	public GameObject PlayerOneVictory;
	public GameObject PlayerTwoVictory;

	public GameObject PlayerVictoryPos;
	public GameObject EnemyVictoryPos;

	public PlayerHealth _playerHealth;
	public EnemyHealth _enemyHealth;
	public PlayerMovement _playerMovement;
	public BattleMechanics _battleMechanics;
	public EnemyMovement _enemyMovement;
	public EnemyBattleMechanics _enemybattleMechanics;

	void Awake () 
	{
		PlayerRounds = 0;
		EnemyRounds = 0;

		_enemybattleMechanics.GetComponent<EnemyBattleMechanics>();
		_playerHealth.GetComponent<PlayerHealth>();
		_enemyHealth.GetComponent<EnemyHealth>();
		_playerMovement.GetComponent<PlayerMovement>();
		_battleMechanics.GetComponent<BattleMechanics>();
		_enemyMovement.GetComponent<EnemyMovement>();

		_enemyMovement.CanMove = false;
		_enemybattleMechanics.CanAttack = false;
		_enemybattleMechanics.CanDefend = false;
		_enemybattleMechanics.CanDark = false;

		_playerMovement.CanMove = false;
		_battleMechanics.CanAttack = false;
		_battleMechanics.CanDefend = false;
		_battleMechanics.CanLight = false;

		IsWaiting = true;
	}

	void Update () 
	{
		Waiting();
		WaitingToSpawn();
		if(_playerHealth.CurrentHealth <= 0 && _playerHealth.IsDead)
		{
			Spawning ();
		}
		if(_enemyHealth.CurrentHealth <= 0 && _enemyHealth.IsDead)
		{
			Spawning();
		}

		if(EnemyRounds == 1)
		{
			EnemyRoundYellowOne.transform.position = EnemyRoundEmptyOne.transform.position;
		}
		if(EnemyRounds == 2)
		{
			EnemyRoundYellowTwo.transform.position = EnemyRoundEmptyTwo.transform.position;
			PlayerTwoVictory.transform.position = EnemyVictoryPos.transform.position;
			ResetGame ();
		}

		if(PlayerRounds == 1)
		{
			PlayerRoundYellowOne.transform.position = PlayerRoundEmptyOne.transform.position;
		}
		if(PlayerRounds == 2)
		{
			PlayerRoundYellowTwo.transform.position = PlayerRoundEmptyTwo.transform.position;
			PlayerOneVictory.transform.position = PlayerVictoryPos.transform.position;
			ResetGame ();
		}
	}

	IEnumerator Spawning()
	{
		yield return new WaitForSeconds(SpawnTimer);
	}

	IEnumerator WaitingToFight()
	{
		yield return new WaitForSeconds(Wait);
	}

	void Waiting()
	{
		if(IsWaiting == true)
		{
			Wait--;
		}

		if(Wait <= 0)
		{
			IsWaiting = false;
			_enemyMovement.CanMove = true;
			_enemybattleMechanics.CanAttack = true;
			_enemybattleMechanics.CanDefend = true;
			_enemybattleMechanics.CanDark = true;

			_playerMovement.CanMove = true;
			_battleMechanics.CanAttack = true;
			_battleMechanics.CanDefend = true;
			_battleMechanics.CanLight = true;
			Wait = 50;
		}
	}

	void WaitingToSpawn()
	{
		if(_playerHealth.CurrentHealth <= 0)
		{
			SpawnTimer--;
		}

		if(SpawnTimer <= 0 && _playerHealth.IsDead)
		{
			_playerHealth.Revive();
			SpawnTimer = 50;
			EnemyRounds++;
		}

		if(_enemyHealth.CurrentHealth <= 0)
		{
			SpawnTimer--;
		}

		if(SpawnTimer <= 0 && _enemyHealth.IsDead)
		{
			_enemyHealth.Revive();
			SpawnTimer = 50;
			PlayerRounds++;
		}
	}

	void ResetGame()
	{
		if(PlayerRounds == 2)
		{
			Application.LoadLevel("MainScene");
		}

		else if(EnemyRounds == 2)
		{
			Application.LoadLevel("MainScene");
		}
	}
}
