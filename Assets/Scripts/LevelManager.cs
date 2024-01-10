using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	[SerializeField] float sceneLoadDelay = 0.5f;

	public void LoadGame()
	{
		StartCoroutine(WaitAndLoad("GameScene", sceneLoadDelay));
	}

	public void LoadMainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}

	public void LoadGameOver()
	{
		StartCoroutine(WaitAndLoad("GameOver", sceneLoadDelay));
	}

	public void QuitGame()
	{
		Debug.Log("Quitting Game...");
		Application.Quit();
	}

	IEnumerator WaitAndLoad(string sceneName, float delay)
	{
		yield return new WaitForSeconds(delay);
		SceneManager.LoadScene(sceneName);
	}
}
