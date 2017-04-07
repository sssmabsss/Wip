using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelLogic : MonoBehaviour
{
	[Header("Prefabs")]
	public GameObject sceneLoaderGO;
	[Header("Scripts")]
	public SceneLoader _loader;

	[Header("Scene state")]
	public int backScene; 
	public int currentScene;
	public int nextScene;
	private int _managerScene;
	private int _sceneCountInBuildSettings;

	void Awake()
	{
		GameObject go = Instantiate(sceneLoaderGO, Vector3.zero, Quaternion.identity, this.transform) as GameObject;
		go.name = "SceneLoaderCanvas";
		_loader = go.GetComponent<SceneLoader> ();	
	}
	// Use this for initialization
	void Start ()
	{
		UpdateSceneState();
	}
	void Update()
	{
		if(Input.GetKey(KeyCode.AltGr))
		{
			if (Input.GetKeyDown(KeyCode.N)) NextScene();
			if (Input.GetKeyDown(KeyCode.B)) BackScene();
			if (Input.GetKeyDown(KeyCode.R)) ResetScene();
		}

	}
	public void UpdateSceneState()
	{
		_sceneCountInBuildSettings = SceneManager.sceneCountInBuildSettings;

		_managerScene = 0;
		currentScene = SceneManager.GetActiveScene().buildIndex;

		if (currentScene == 0) backScene = _sceneCountInBuildSettings -1;
		else backScene = currentScene - 1;

		if (currentScene >= _sceneCountInBuildSettings - 1) nextScene = 1;
		else nextScene = currentScene + 1;
	}

	public void NextScene()
	{
		_loader.Load(nextScene);
	}
	public void BackScene()
	{
		_loader.Load(backScene);
	}
	public void ResetScene()
	{
		_loader.Load(currentScene);
	}
	public void QuitGame()
	{
		_loader.Load(-1);
	}

	public bool IsLastScene()
	{
		if (currentScene == _managerScene) return true;
		else return false;
	}
	public int GetSceneCount()
	{
		_sceneCountInBuildSettings = SceneManager.sceneCountInBuildSettings;
		return _sceneCountInBuildSettings;
	}
}