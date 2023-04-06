using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int level;
    public bool isOver;
    public TextMeshProUGUI levelText;
    // Start is called before the first frame update
    void Start()
    {
        updateLevel(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void updateLevel(int level)
    {
        this.level = level;
        levelText.SetText("Level: " + level);
    }

    public void updateIsOver(bool isOver)
    {
        this.isOver = isOver;
    }
}
