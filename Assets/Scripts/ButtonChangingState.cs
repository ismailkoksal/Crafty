using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonChangingState : MonoBehaviour
{
    [SerializeField]
    private State changeTo;


    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);   
    }

    void OnClick()
    {
        StateMachine.Instance.ChangeStateTo(changeTo);
    }
}