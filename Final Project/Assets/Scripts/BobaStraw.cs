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

    private int index = 0;

    void Awake()
    {
        projectileThrower = GetComponent<ProjectileThrower>();
    }
    // Start is called before the first frame update
    void Start()
    {
        GameObject bobaStraw = GameObject.FindWithTag("BobaStraw");

        if (bobaStraw != null)
        {
            bobaStrawSR = bobaStraw.GetComponent<SpriteRenderer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (index >= 4)
            {
                index = 0;
            }
            SetStraw(index);
            index++;
        }
    }

    void SetStraw(int strawID)
    {
        switch (strawID)
        {
            case 1:
                //call throw method in projectileThrow
                projectileThrower.SetPrefab(bobaPrefab1);
                ChangeStraw(Color.black);
                break;
            case 2:
                //call throw method in projectileThrow
                projectileThrower.SetPrefab(bobaPrefab2);
                ChangeStraw(Color.blue);
                break;
            case 3:
                //call throw method in projectileThrow
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
