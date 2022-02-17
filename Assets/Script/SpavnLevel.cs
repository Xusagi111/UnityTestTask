using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpavnLevel : MonoBehaviour
{
    [SerializeField] private  GameObject PrefabCircle;
    [SerializeField] private GameObject PrefabPlayer;
    private const int CountCirclGameObject = 5;
    private Vector2  PlayerPosition= new Vector2(0,0);
    private void Start()
    {
        CreateGameObjectInScene();
    }
    public void CreateGameObjectInScene()
    {
        for (int i = 0; i < CountCirclGameObject; i++)
        {
            var RandomVectorCircle = new Vector3(Random.Range(-8, 8), Random.Range(-4, 4), 1);
            Instantiate(PrefabCircle, RandomVectorCircle, Quaternion.identity);
        }
        Instantiate(PrefabPlayer, PlayerPosition, Quaternion.identity);
    }
}
