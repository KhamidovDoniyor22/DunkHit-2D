using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BasketSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _basketTemplate;
    [SerializeField] private Vector2 _viewPortRangeY;

    public UnityAction<Basket> BasketSpawned;

    public void Spawn(Sides sides)
    {
        Vector3 spawnPosition = Vector3.zero;
        int scaleX = 0;
        float viewPortY = Random.Range(_viewPortRangeY.x, _viewPortRangeY.y);

        switch(sides)
        {
            case Sides.Left:
                scaleX = 1;
                spawnPosition = GetSpawnPoint(new Vector3(0, viewPortY, 0));
              break;
            case Sides.Right:
                scaleX = -1;
                spawnPosition = GetSpawnPoint(new Vector3(1, viewPortY, 0));
                break;
        }
        spawnPosition.z = 0;
        InstantiateBasket(spawnPosition, scaleX);
    }
    private void InstantiateBasket(Vector3 spawnPosition, int scaleX)
    {
        GameObject basketParent = Instantiate(_basketTemplate, spawnPosition, Quaternion.identity);
        
        basketParent.transform.localScale = new Vector3(
            basketParent.transform.localScale.x * scaleX, 
            basketParent.transform.localScale.y, 
            basketParent.transform.localScale.z);
        Basket basket = basketParent.GetComponentInParent<Basket>();
        BasketSpawned?.Invoke(basket);
        basket.Show();
    }
    private Vector3 GetSpawnPoint(Vector3 viewPortPoint)
    {
        return Camera.main.ViewportToWorldPoint(viewPortPoint);
    }
}
public enum Sides {Left = -1, Right = 1}
