using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotFactory : MonoBehaviour
{
    [SerializeField] private Bot _prefab;
    [SerializeField] private int _price;

    public int Price => _price;

    public Bot Create(Vector3 position, Base parentBase)
    {
        Bot createdBot = Instantiate(_prefab);
        createdBot.Init(position, parentBase);

        return createdBot;
    }
}
