using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Basket : MonoBehaviour
{
    [SerializeField] private float _destroyTime;
    [SerializeField] private float _hideDelay;

    private Animator _animator;

    public UnityAction<Basket> Goal;
    public const string AnimatorShowTrigger = "Show";
    public const string AnimationHideTrigger = "Hide";
    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }
    public void Show()
    {
        _animator.SetTrigger(AnimatorShowTrigger);
    }
    private IEnumerator Hide()
    {
        yield return new WaitForSeconds(_hideDelay);
        _animator.SetTrigger(AnimationHideTrigger);
        yield return new WaitForSeconds(_destroyTime);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Ball ball))
        {
            StartCoroutine(Hide());
            Goal?.Invoke(this);
        }
    }
}
