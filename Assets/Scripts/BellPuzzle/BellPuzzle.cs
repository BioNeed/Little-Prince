using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BellPuzzle : MonoBehaviour
{
    [SerializeField] private Bell[] _bells;
    [SerializeField] private int[] _bellRingingOrder;
    [SerializeField] private AudioClip _puzzleSolvedSound;
    [SerializeField] private BellPlatform _bellPlatform;

    private List<int> _bellsRang = new ();
    private AudioSource _audioSource;
    private bool _ringing = false;
    private bool _solved = false;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void RingAllOrdered()
    {
        if (_ringing)
        {
            return;
        }

        StartCoroutine(RingBellsWithDelay(0.8f));
    }

    public void TrySolvePuzzle(int bellRangNumber)
    {
        if (_solved)
        {
            return;
        }

        if (IsRangInRightOrder(bellRangNumber))
        {
            _bellsRang.Add(bellRangNumber);
            if (_bellsRang.Count == _bellRingingOrder.Length)
            {
                FinishPuzzle();
                Debug.Log("Solved!");
            }
        }
        else
        {
            _bellsRang.Clear();
        }
    }

    private bool IsRangInRightOrder(int bellRangNumber)
    {
        return _bellRingingOrder[_bellsRang.Count] == bellRangNumber;
    }

    private IEnumerator RingBellsWithDelay(float delayBetweenBellsRinging)
    {
        _ringing = true;
        foreach (var bellRingingNumber in _bellRingingOrder)
        {
            _bells.First(b => b.BellNumber == bellRingingNumber)
                .RingBell(initiatedByCollision: false);

            yield return new WaitForSeconds(delayBetweenBellsRinging);
        }

        _ringing = false;
    }

    private void FinishPuzzle()
    {
        _solved = true;
        StartCoroutine(PlaySolvedSoundWithDelay(0.6f));
        _bellPlatform.StartMovingPlatform();
    }

    private IEnumerator PlaySolvedSoundWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        _audioSource.PlayOneShot(_puzzleSolvedSound);
    }
}
