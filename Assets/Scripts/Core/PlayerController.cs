using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    [SerializeField]
    private GameObject Character;
    [SerializeField]
    private float Speed;

    private RaycastHit m_mouseClickHit;
    private Controller.PlayerStates m_Playerstates;
    private Controller.InputStateFlags m_Inputstates;
    private Ray m_lastMousePos;
    private Vector3 m_pos;


    public override void Init()
    {
        base.Init();
        m_Playerstates = new PlayerStates();
        m_Inputstates = new InputStateFlags();
        m_Inputstates = InputStateFlags.ReleaseInput;
    }

    public override void Move(float speed)
    {
        m_Playerstates = PlayerStates.OnMove;
        MovePlayerToPosition(speed);

    }

    void Update()
    {
        if(GameManage.Instance.CanPause) TogglePauseGame();
        if (UseLeftMouse())
            Move(Speed);
    }

    private void MovePlayerToPosition(float speed)
    {
        if (m_Inputstates != InputStateFlags.LockInput)
        {
            m_lastMousePos = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(m_lastMousePos, out m_mouseClickHit))
            {
                m_pos = m_mouseClickHit.point;
                Character.transform.position = new Vector3(Vector3.Lerp(Character.transform.position, m_pos, speed * Time.deltaTime).x, 0.5f, Vector3.Lerp(Character.transform.position, m_pos, speed * Time.deltaTime).z);
            }
        }
    }
}
