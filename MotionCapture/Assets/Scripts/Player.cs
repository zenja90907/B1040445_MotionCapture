using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator action;

    private void Start()
    {
        action = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) action.SetTrigger("跳舞觸發器");

        action.SetBool("跑步開關", Input.GetKey(KeyCode.R));
    }
}
