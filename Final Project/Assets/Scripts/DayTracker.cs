using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using JetBrains.Annotations;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DayTracker : MonoBehaviour
{
    public Text dayCount;

    //getting sceneIndex and updating it
    Scene currentLevel;
    // string sceneName;
    public int levelIndex;

    //singleton
    private static DayTracker _instance;
    public static DayTracker Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<DayTracker>();

                if (_instance == null)
                {
                    GameObject obj = new GameObject("DayTracker");
                    _instance = obj.AddComponent<DayTracker>();
                }
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
    }

    /*void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    */

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = SceneManager.GetActiveScene();
        levelIndex = currentLevel.buildIndex;

        dayCount.text = $"Day: {levelIndex} ";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
