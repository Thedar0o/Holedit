using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField]
    ObstacleController m_ObstacleController;
    /// <summary>
    /// Layers are:
    /// 6. Obstacle
    /// 7. Hole
    /// 8. Player
    /// </summary>
    /// <param name="ObjOnCollision"></param>
    private void OnTriggerEnter(Collider ObjOnCollision)
    {
        var go = ObjOnCollision.gameObject;
        if (gameObject.layer.Equals(6) && go.layer.Equals(8)) OnCrash();
        if (gameObject.layer.Equals(7) && go.layer.Equals(8)) OnScore();
    }

    private void OnScore()
    {
        m_ObstacleController.StartHidingBlock(3);
        GameManage.Instance.MainScore += 1 ;
    }

    private void OnCrash()
    {
        m_ObstacleController.DisableTrigger();
        GameManage.Instance.MainLife--;
    }
}
