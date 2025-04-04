using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ReturnToGame());
    }

    IEnumerator ReturnToGame()
    {
        yield return new WaitForSeconds(20f);
        SceneManager.LoadScene("Game");
    }
}
