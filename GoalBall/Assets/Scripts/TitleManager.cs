using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.Instance.StartGame(PlayerPrefsManager.LastStage);
    }
}
