using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLose : MonoBehaviour {

    public GameObject congratulationText;
    public string nextLevel = "Level1";

	public void onVictory()
    {
        showCongratulations();
    }

    public void showCongratulations()
    {
        congratulationText.SetActive(true);
        Invoke("loadNextLevel", 3);
    }

    private void loadNextLevel()
    {
        congratulationText.SetActive(false);
        SteamVR_LoadLevel.Begin(nextLevel);
    }
}
