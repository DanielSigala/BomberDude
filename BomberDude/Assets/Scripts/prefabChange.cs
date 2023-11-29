using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//PLACE ON PLAYER MANAGER OBJECT
public class prefabChange : MonoBehaviour
{
[SerializeField] private GameObject newPlayerPrefab; // The new Player Prefab to use.

public PlayerInputManager inputManager;

private void Update()
{
if (GameObject.FindWithTag("p1")) //Checking for a game object with the tag
{
PlayerInputManager.instance.playerPrefab = newPlayerPrefab; //If yes, changes the player prefab field to your selected prefab
}
}
}