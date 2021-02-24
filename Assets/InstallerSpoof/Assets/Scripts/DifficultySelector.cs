using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySelector : MonoBehaviour
{
    // The Difficulty will load Scenes with differing variables.
    // Easy will be the fulcrum tester.
    // Difficulty will change the rate at which coins are gathered, increase the amount needed for shields and less so consumables, etc.

    public enum Difficulty
    {
        Easy, // 0
        Normal, // 1
        Hard, // 2
        Overkill // 3
    }

    public Difficulty selectedDifficulty;

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene((int)selectedDifficulty);
    }
}
