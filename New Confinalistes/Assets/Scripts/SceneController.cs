using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    public int sceneName;
    public Vector2 playerPosition;
    public VectorValue playerSavedPos;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            playerSavedPos.initialValue = playerPosition;
            SceneManager.LoadScene(sceneName);
        }
    }
}
