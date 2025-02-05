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
                List<Resource> foundResources = _resourceScanner.GetFoundResources();

                if (foundResources!=null)
                {
                    Queue<Resource> resourcesQueue = new Queue<Resource>(foundResources.Except(_assignedCollectorResources).ToList());
                    Resource currentResource = resourcesQueue.Dequeue();
                    StartCoroutine(_freeBotsQueue.Dequeue().BringCargo(currentResource));
                    _assignedCollectorResources.Add(currentResource);
                }
            }
        }
    }

    private void OnCargoDelivered(Bot bot, Resource resource)
    {
        _assignedCollectorResources.Remove(resource);
        _freeBotsQueue.Enqueue(bot);
        _storage.Add();
    }
}
