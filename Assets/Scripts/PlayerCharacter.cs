using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character {
    public static PlayerCharacter instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    protected override void Start()
    {
        Restart();
    }
    public delegate void OnEvent();
    public static event OnEvent PlayerDeath;
    protected override void Death()
    {
        base.Death();
        if (PlayerDeath != null)
        {
            PlayerDeath();
        }
    }
}
