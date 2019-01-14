using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State { MainMenu, Game, Options };

public class StateMachine : MonoBehaviour
{   


    private State currentState;
    public static State CurrentState { get { return Instance.currentState; } }

    public static StateMachine Instance;

    [SerializeField]
    private View[] views;


    public void Awake()
    {
        Instance = this;

        ChangeStateTo(State.MainMenu);
    }


    public void ChangeStateTo(State newState)
    {
        currentState = newState;

        foreach (View v in views)
        {
            v.GameObject.SetActive(v.State == currentState);
        }
    }
}

[System.Serializable]
public class View
{

    [SerializeField]
    private GameObject gameObject;
    public GameObject GameObject { get { return gameObject; } }

    [SerializeField]
    private State state;
    public State State { get { return state; } }
}