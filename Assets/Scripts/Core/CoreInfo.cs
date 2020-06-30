using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CoreInfo
{
    public static int level = 0;
    public static int levelCount {
        get {
            return level + 4;
        }
    }
    public static string[] levelString = {"Simple", "Advanced", "Extreme"};

    public static void LevelUp() {
        level = Mathf.Clamp(level + 1, 0, 2);
    }

    public static void LevelDown() {
        level = Mathf.Clamp(level - 1, 0, 2);
    }

    public static string LevelString {
        get {
            return levelString[level];
        }
    }
}
