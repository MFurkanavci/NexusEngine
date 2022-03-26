using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    [SerializeField] 

    public GameObject 
        _mob,
        _boss,
        _poolMob,
        _poolBoss
        ;



    public bool
        _spawnable = false,
        _firstWave = true
        ;


    public float
        _spawntimer,
        _delay
        ;

    public int
        _mobCount,
        _level
        ;

    public Transform
        _destination
        ;

    private void Awake()
    {
        StartCoroutine(Wave());
    }

    private void Update()
    {

        //if (Input.GetKeyDown(KeyCode.KeypadEnter))
        //{
        //    InvokeRepeating("nextWave", _spawntimer, _delay);
        //}
    }

    IEnumerator Wave()
    {
        if (BossTimeChecker())
            yield return new WaitForSecondsRealtime(nextWave());
        else
            yield return new WaitForSecondsRealtime(bossWave());

        StartCoroutine(Wave());
    }


    public bool BossTimeChecker()
    {
        if (_mobCount >= 1)
            return true;

        else
           return false;
    }

    public float nextWave()
    {
        _mobCount--;
        var _mobEntity = Instantiate(_mob, _poolMob.transform);
        _mobEntity.GetComponentInChildren<mobAI>().Destination(_destination.position);
        return _delay;

    }
    public float bossWave()
    {
        var _bossEntity = Instantiate(_boss, _poolBoss.transform);
        _bossEntity.GetComponentInChildren<mobAI>().Destination(_destination.position);
        _mobCount = 20;
        _level++;
        return _spawntimer * _level;

    }
}
