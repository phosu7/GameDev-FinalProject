using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BobaCount : MonoBehaviour
{
    Text bobaCount;
    public ProjectileThrower boba;

    // Start is called before the first frame update
    void Start()
    {
        bobaCount = GetComponent<Text>();
        UpdateBobaCount();

    }

    // Update is called once per frame
    void Update()
    {
        UpdateBobaCount();
    }

    public void UpdateBobaCount()
    {
        bobaCount.text = $"Boba: {boba.currentBoba}";
    }
}
