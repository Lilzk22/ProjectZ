using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveManager : MonoBehaviour
{
    public enum WavePhase{
        Idle,
        SpawningEnemies,
        WaitingCompletion,
        RestPeriod,
    }
    public static EnemyWaveManager instance {get; private set;}
    
    public int waveNumber;

    [SerializeField]
    private WavePhase phase;

    [Header("Generic Data")]
    public List<WaveMember> enemies = new List<WaveMember>();

    [Tooltip("The base amount of enemies spawned during a wave.")]
    public int unitsPerWave;
    [Tooltip("How many additional enemies are added to the wave total at that wave. 0 means no enemies will be added when completing a wave.")]
    public int unitBonusPerWave;
    [Tooltip("The initial threat level of the starting wave. Threat level determines what kind of enemies are chosen; enemies with threat levels higher than the current threat level are prioritized when chosen.")]
    public int baseThreat;
    [Tooltip("The incrimentation of the threat level when completing a wave.")]
    public int threatPerWave;
    [Tooltip("How long, in seconds, the duration of a wave is. If less than 0, waves will last indefinitely.")]
    public float waveDuration;
    [Tooltip("How long, in seconds, the rest period between waves is.")]
    public float restDuration;
    [Tooltip("How long, in seconds, the game takes between spawning individual units.")]
    public float timeBetweenSpawning;

    private float timer;
    private float spawnTimer;
    private int enemiesSpawned;
    public int currentUnitCountPerWave{
        get{
            return unitsPerWave + (unitBonusPerWave * waveNumber);
        }
    }
    public int currentThreatLevel{
        get{
            return baseThreat + (threatPerWave * waveNumber);
        }
    }

    private void OnEnable(){
        if(!instance){
            instance = this;
        }
        else{
            GameObject.Destroy(this.gameObject);
        }
    }

    private void OnDisable(){
        if(instance = this)
            instance = null;
    }
    void Start()
    {
        this.waveNumber = 0;
        NewWave();
    }

    private void NewWave(){
        this.waveNumber++;
        this.timer = 0f;
        this.enemiesSpawned = 0;
        this.spawnTimer = 0;
        this.phase = WavePhase.SpawningEnemies;
    }

    private void FixedUpdate(){
        switch(this.phase){
            case WavePhase.SpawningEnemies:
            this.timer += Time.fixedDeltaTime;
            this.spawnTimer += Time.fixedDeltaTime;
            if(this.spawnTimer >= timeBetweenSpawning){
                SpawnEnemy();
            }
            if(enemiesSpawned >= currentUnitCountPerWave){
                this.phase = WavePhase.WaitingCompletion;
                Debug.Log("All enemies spawned, waiting for wave completion");
                return;
            }
            break;
            case WavePhase.WaitingCompletion:
            this.timer += Time.fixedDeltaTime;
            if(timer >= waveDuration){
                this.phase = WavePhase.RestPeriod;
                this.timer = 0f;
                return;
            }

            break;
            case WavePhase.RestPeriod:
            this.timer += Time.fixedDeltaTime;
            if(timer >= restDuration){
                NewWave();
                return;
            }

            break;
        }
    }

    public void SpawnEnemy(){
        List<GameObject> potentialPrefabs = new List<GameObject>();
        foreach (WaveMember waveMember in enemies)
        {
            int count = 0;
            if(waveMember.threat < currentThreatLevel){
                count = 1;
            }
            else if(waveMember.threat == currentThreatLevel){
                count = 5;
            }
            else{
                count = 1;
            }
            for (int i = 0; i < count; i++)
            {
                potentialPrefabs.Add(waveMember.prefab);
            }
        }
        int id = UnityEngine.Random.Range(0, potentialPrefabs.Count);
        GameObject prefab = potentialPrefabs[id];
        SpawnNode node = ChooseNode();
        GameObject.Instantiate(prefab, node.transform.position, node.transform.rotation);
        enemiesSpawned++;
        return;
    }

    private SpawnNode ChooseNode(){
        SpawnNode result = null;
        List<SpawnNode> potentialNodes = new List<SpawnNode>();
        foreach (SpawnNode node in SpawnNode.activeNodes)
        {
            for (int i = 0; i < node.weight+1; i++)
            {
                potentialNodes.Add(node);
            }
        }
        int id = UnityEngine.Random.Range(0, potentialNodes.Count);
        result = potentialNodes[id];
        return result;
    }

    [Serializable]
    public struct WaveMember{
        [Tooltip("The prefab to spawn.")]
        public GameObject prefab;
        [Tooltip("The higher the number, the more threatening this enemy is considered. More threatening enemies become more common as waves are completed.")]
        public int threat;
    }
}
