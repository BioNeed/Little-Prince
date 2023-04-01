using UnityEngine;

[RequireComponent(typeof(BranchPulling))]
public class BranchPointing : MonoBehaviour
{
    [SerializeField] private ParticleSystem _passiveBranchGlow;
    [SerializeField] private ParticleSystem _activeBranchGlow;

    private void Start()
    {
        _passiveBranchGlow.gameObject.SetActive(true);
        _activeBranchGlow.gameObject.SetActive(false);
    }

    private void OnMouseEnter()
    {
        _passiveBranchGlow.gameObject.SetActive(false);
        _activeBranchGlow.gameObject.SetActive(true);
    }

    private void OnMouseExit()
    {
        _activeBranchGlow.gameObject.SetActive(false);
        _passiveBranchGlow.gameObject.SetActive(true);
    }
}
