using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseModel
{
    public int level;
    public string reason_end;
    public int enemies_killed;
    public int total_bullets;
    public int final_health;
    public float time_remaining;

    public string Stringify()
    {
        return JsonUtility.ToJson(this);
    }

    public static DatabaseModel Parse(string json)
    {
        return JsonUtility.FromJson<DatabaseModel>(json);
    }
}
