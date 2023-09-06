using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelClass
{
    private static int level;
    public static int levelC;


    public LevelClass(int Level)
    {
        level = Level;
    }
    public void attUpdate()
    {
        level += levelC;
    }
    public int GetLevel
    {
        get => level;
    }
    public int getLevelC
    {
        get => levelC;
    }
    public void LevelPlus(int n)
    {
        levelC += n;
    }
}
