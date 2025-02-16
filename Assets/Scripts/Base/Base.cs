using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Base : MonoBehaviour, ITargetable
{
    [SerializeField] private List<Bot> _belongingBots;
    [SerializeField] private ResourceScanner _resourceScanner;
    [SerializeField] private float _scanDelay;
    [SerializeField] private float _reachedDistance;
    [SerializeField] private Storage _storage;
    [SerializeField] private Transform _newBotTransform;
    [SerializeField] private BotFactory _botFactory;

    private Queue<Bot> _freeBotsQueue = new();
    private List<Resource> _assignedCollectorResources = new();

    private void Awake()
    {
        _freeBotsQueue = new Queue<Bot>(_belongingBots);
    }

    private void OnEnable()
    {
        foreach (Bot bot in _belongingBots)
        {
            bot.CargoDelivered += OnCargoDelivered;
        }
    }

    private void OnDisable()
    {
        foreach (Bot bot in _belongingBots)
        {
            bot.CargoDelivered -= OnCargoDelivered;
        }
    }

    private void Start()
    {
        StartCoroutine(BehaviourExecute());
    }

    public float GetReachedDistane() => _reachedDistance;

    private IEnumerator BehaviourExecute()
    {
        var wait = new WaitForSeconds(_scanDelay);

        while (enabled)
        {
            yield return wait;

            if (_freeBotsQueue.Count > 0)
            {
                CollectResources();
            }

            if (_storage.ResourceCount == _botFactory.Price)
            {
                CreateBot();
                _storage.Remove(_botFactory.Price);
            }
        }
    }

    private void CollectResources()
    {
        List<Resource> foundResources = _resourceScanner.GetFoundResources();

        if (foundResources != null)
        {
            Queue<Resource> resourcesQueue = new Queue<Resource>(foundResources.Except(_assignedCollectorResources).ToList());
            Resource currentResource = resourcesQueue.Dequeue();
            StartCoroutine(_freeBotsQueue.Dequeue().BringCargo(currentResource));
            _assignedCollectorResources.Add(currentResource);
        }
    }

    private void CreateBot()
    {
        _freeBotsQueue.Enqueue(_botFactory.Create(_newBotTransform.position, this));
    }

    private void OnCargoDelivered(Bot bot, Resource resource)
    {
        _assignedCollectorResources.Remove(resource);
        _freeBotsQueue.Enqueue(bot);
        _storage.Add();
    }
}
