using UnityEngine;

public class Singleton : MonoBehaviour
{

    public static Singleton Instance;

    private int test = 2;
    private int test2;

    public int myVar;

    public Lol[] lol;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log($"Destroying {name}");
            Destroy(gameObject);
        }
    }

    public int Coucou()
    {
        return test + test2;
    }

    public static int Coucou2()
    {
        return Instance.test + Instance.test2;
    }
}


[System.Serializable]
public class Lol
{

    public int test;
    public string name;
    public string zefioef;

    Lol()
    {
        Singleton.Instance.Coucou();
        Singleton.Coucou2();
        Debug.Log(Singleton.Instance.myVar);
    }
}