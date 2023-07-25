using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NameManager : MonoBehaviour
{
    public static NameManager Instance;

    public string playerName;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    public void StartGame()
    {
        playerName = GameObject.Find("Canvas").gameObject.transform.GetChild(0).GetChild(0).GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text;
        SceneManager.LoadScene(1);
    }
}
