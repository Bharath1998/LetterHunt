using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseModel {
    public string name;
    public string age;
    public string position;

    public string Stringify() {
        return JsonUtility.ToJson(this);
    }

    public static DatabaseModel Parse(string json) {
        return JsonUtility.FromJson<DatabaseModel>(json);
    }

}