using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour {
    public string pastLevel;
    public string nextLevel;
    public string mainMenu;

    void OnTriggerEnter2D(Collider2D other)
    {
        Application.LoadLevel(nextLevel);
    }
}
