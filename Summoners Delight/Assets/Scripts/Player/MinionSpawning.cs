using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class MinionSpawning : MonoBehaviour
{
    public GameObject SelectedMinion;
    [SerializeField]protected AstarPath PathFinder;

    protected int MaxStartingBodies;
    public int CurrentBodies;
    //max number of minions that can be spawned
    [HideInInspector]public int SpawnNum;

    public Vector3 SpawningCords;
    public Vector2 MouseCords;

    public Camera PlayerCamera;

    public HashSet<string> SpawnedMinions = new HashSet<string>();

    [SerializeField]protected bool SpawningStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        if(SpawnNum == 0)
        {
            SpawnNum = 10;
        }
        PathFinder = FindObjectOfType<AstarPath>();
        GameManager.ManagerInstance.WorldUpdate.AddListener(() => PathFinder.Scan());
        Debug.Log("riverbeds");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 WorldCords = PlayerCamera.ScreenToWorldPoint(Input.mousePosition);
        MouseCords = new Vector2((float)System.Math.Round(WorldCords.x,2), (float)System.Math.Round(WorldCords.y, 2));

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!SpawningStarted && CurrentBodies > 0) 
            {
                SpawningCords = MouseCords;
                StartCoroutine(SpawnDelay());
            }
        }
        if (CurrentBodies <= 0 && SpawnedMinions.Count == 0) 
        {
            GameManager.ManagerInstance.PlayerLoss.Invoke();
        }
    }

    public IEnumerator SpawnDelay()
    {
        if(!SpawningStarted )
        {
            SpawningStarted = true;
            for (int i = 0; i < 2; i++)
            {
                Debug.Log("love Bites");
                SelectedMinion.transform.position = new Vector3(SpawningCords.x, SpawningCords.y, 0);
                GameObject SpawnedMinion = Instantiate(SelectedMinion, SpawningCords, Quaternion.identity);
                SpawnedMinion.name = "Minion " + SpawnedMinions.Count;
                SpawnedMinions.Add(SpawnedMinion.name);
                SpawnedMinion.GetComponent<MinionBase>().MinionStartup();
                SpawnedMinion.GetComponent<MinionBase>().MinionSpawnScript = this;
                yield return new WaitForSeconds(0.5f);
            }

        }
        yield return new WaitForSeconds(0.5f);
        SpawningStarted = false;
    }

}
