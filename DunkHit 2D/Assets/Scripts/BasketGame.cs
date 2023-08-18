using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketGame : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private BasketSpawner _basketSpawner;
    [SerializeField] private Sides _startSide = Sides.Left;

    private Sides _currentSide;
    private void Start()
    {
        _currentSide = _startSide;
        _basketSpawner.Spawn(_currentSide);     
    }
    private void OnEnable()
    {
        _basketSpawner.BasketSpawned += OnBasketSpawned;
    }
    private void OnDisable()
    {
        _basketSpawner.BasketSpawned += OnBasketSpawned;
    }
    private void OnBasketSpawned(Basket basket)
    {
        basket = GameObject.FindObjectOfType<Basket>();
        _ball.ChangeSide(_currentSide);
        basket.Goal += OnGoal;
    }
    private void OnGoal(Basket basket)
    {
        basket.Goal -= OnGoal;
        ChangeSide(_currentSide);
        _basketSpawner.Spawn(_currentSide);
    }
    private void ChangeSide(Sides side)
    {
        _ball.ChangeSide(side);

        if(side == Sides.Left)
        {
            _currentSide = Sides.Right;
        }
        else
        {
            _currentSide = Sides.Left;
        }
    }
}
