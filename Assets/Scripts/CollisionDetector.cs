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
        if (gameObject.layer.Equals(6) && go.gameObject.layer.Equals(8)) UnityEngine.SceneManagement.SceneManager.LoadScene(0);//dosth;
        if (gameObject.layer.Equals(7) && go.gameObject.layer.Equals(8)) m_ObstacleController.StartHidingBlock(2);//dosth
    }
}
