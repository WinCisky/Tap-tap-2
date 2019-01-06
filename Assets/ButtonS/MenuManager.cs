using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    //reference
    public static MenuManager MM = null;

    //this g.o. will not be destryed with scene change
    //is is responsable of scene changes (and variables initialization)
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        if (MM == null)
            MM = this;
    }

    //load a scene
    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    //perform some actions once the scene is fully loaded
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 2)
        {
            GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshProUGUI>().SetText("Your score was: " + ScoreManager.SM.max_score);
        }
    }
}
