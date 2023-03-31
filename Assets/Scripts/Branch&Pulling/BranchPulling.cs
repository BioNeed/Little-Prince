using System.Collections;
using UnityEngine;

public class BranchPulling : MonoBehaviour
{
    [SerializeField] private float _pullingTime;
    [SerializeField] private float _forceAfterPulling;

    private const float EpsilonDistance = 0.4f;

    public void Pull(Rigidbody2D target)
    {
        Vector2 pull = transform.position - target.transform.position;
        
        StartCoroutine(FlyAfterPull(target, pull));
    }

    private IEnumerator FlyAfterPull(Rigidbody2D target, Vector2 pull)
    {
        while(Vector2.Distance(transform.position, target.position) > EpsilonDistance)
        {
            Vector2 pullingStep = pull * Time.fixedDeltaTime / _pullingTime;
            target.MovePosition(target.position + pullingStep);
            yield return null;
        }

        //target.AddForce();
    }
}
