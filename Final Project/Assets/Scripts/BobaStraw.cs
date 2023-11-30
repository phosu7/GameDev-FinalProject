using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobaStraw : MonoBehaviour
{
    [SerializeField] private GameObject bobaPrefab1;
    [SerializeField] private GameObject bobaPrefab2;
    [SerializeField] private GameObject bobaPrefab3;

    //reference to projectileThrower script
    ProjectileThrower projectileThrower;

    //accessing the bobaStraw
    private SpriteRenderer bobaStrawSR;

    //sinlgeton
    int levelIndex;

    private int index = 1;

    void Awake()
    {
        projectileThrower = GetComponent<ProjectileThrower>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //singleton
        levelIndex = DayTracker.Instance.levelIndex;

        GameObject bobaStraw = GameObject.FindWithTag("BobaStraw");

        if (bobaStraw != null)
        {
            bobaStrawSR = bobaStraw.GetComponent<SpriteRenderer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (DayTracker.dayCounter == 1)
        {
            index = 1;
            SetStraw(index);
        }

        else if (DayTracker.dayCounter == 2)
        {
            if (index >= 3)
            {
                index = 1;
            }
            if (bobaStrawSR.color == (Color.black) && ProjectileThrower.currentBlackBoba <= 0 && ProjectileThrower.currentBlueBoba > 0)
            {
                Debug.Log("THis should be called 1");
                projectileThrower.SetPrefab(bobaPrefab2);
                ChangeStraw(Color.blue);
            }
            if (bobaStrawSR.color == (Color.blue) && ProjectileThrower.currentBlueBoba <= 0 && ProjectileThrower.currentBlackBoba > 0)
            {
                Debug.Log("THis should be called 2");
                projectileThrower.SetPrefab(bobaPrefab1);
                ChangeStraw(Color.black);
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Debug.Log("index = " + index);
                SetStraw(index);
                index++;
            }
        }
        else if (DayTracker.dayCounter == 3)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (index == 2 || index >= 4)
                {
                    index = 1;
                }
                SetStraw(index);
                index++;
            }
        }

        else
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (index >= 4)
                {
                    index = 1;
                }
                SetStraw(index);
                index++;
            }
        }
    }

    void SetStraw(int strawID)
    {
        switch (strawID)
        {
            case 1:
                //call throw method in projectileThrow
                if (ProjectileThrower.currentBlackBoba <= 0)
                {
                    break;
                }
                projectileThrower.SetPrefab(bobaPrefab1);
                ChangeStraw(Color.black);
                break;
            case 2:
                //call throw method in projectileThrow
                if (ProjectileThrower.currentBlueBoba <= 0)
                {
                    break;
                }
                projectileThrower.SetPrefab(bobaPrefab2);
                ChangeStraw(Color.blue);
                break;
            case 3:
                //call throw method in projectileThrow
                if (ProjectileThrower.currentRedBoba <= 0)
                {
                    if (ProjectileThrower.currentBlackBoba > 0)
                    {
                        projectileThrower.SetPrefab(bobaPrefab1);
                        ChangeStraw(Color.black);
                        break;
                    }
                    else if (ProjectileThrower.currentBlueBoba > 0)
                    {
                        projectileThrower.SetPrefab(bobaPrefab3);
                        ChangeStraw(Color.red);
                        break;
                    }
                    break;
                }

                projectileThrower.SetPrefab(bobaPrefab3);
                ChangeStraw(Color.red);
                break;
        }
    }

    void ChangeStraw(Color c)
    {
        bobaStrawSR.color = c;
    }
}
