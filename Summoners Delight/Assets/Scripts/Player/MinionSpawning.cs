using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class MinionSpawning : MonoBehaviour
{
    public GameObject SelectedMinion;
    [SerializeField]protected AstarPath PathFinder;

    //max number of minions that can be spawned
    protected int MaxStartingBodies;
    public int CurrentBodies;
    public int SpawnNum;

    public Vector3 SpawningCords;
    public Vector2 MouseCords;

    public Camera PlayerCamera;

    public HashSet<GameObject> SpawnedMinions = new HashSet<GameObject>();

    [SerializeField]protected bool SpawningStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        if(CurrentBodies == 0)
        {
            CurrentBodies = 10;
        }
        PathFinder = FindObjectOfType<AstarPath>();
        GameManager.ManagerInstance.WorldUpdate.AddListener(() => PathFinder.Scan());
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 WorldCords = PlayerCamera.ScreenToWorldPoint(Input.mousePosition);
        MouseCords = new Vector2((float)System.Math.Round(WorldCords.x,2), (float)System.Math.Round(WorldCords.y, 2));

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (GameManager.ManagerInstance.OnUI)
            {
                return;
            }
            if (!SpawningStarted && CurrentBodies > 0) 
            {
                AudioManager.instance.PlaySound("Thunk");
                SpawningCords = MouseCords;
                StartCoroutine(SpawnDelay());
            }
        }
        if (CurrentBodies <= 0 && SpawnedMinions.Count == 0) 
        {
            GameManager.ManagerInstance.PlayerLoss.Invoke();
        }
    }

    public void UpdateMinionAttack()
    {
        foreach (var Minion in SpawnedMinions)
        {
            Minion.GetComponent<MinionBase>().StopAllCoroutines();
        }
    }

    public IEnumerator SpawnDelay()
    {
        if(!SpawningStarted || !GameManager.ManagerInstance.OnInvalidSpot)
        {
            SpawningStarted = true;
            for (int i = 0; i < SpawnNum; i++)
            {

                SelectedMinion.transform.position = new Vector3(SpawningCords.x, SpawningCords.y, 0);

                GameObject SpawnedMinion = Instantiate(SelectedMinion, SpawningCords, Quaternion.identity);
                SpawnedMinion.name = "Minion " + CurrentBodies;
                SpawnedMinions.Add(SpawnedMinion);

                SpawnedMinion.GetComponent<MinionBase>().MinionStartup();
                SpawnedMinion.GetComponent<MinionBase>().MinionSpawnScript = this;
                CurrentBodies--;
                yield return new WaitForSeconds(0.25f);
            }

        }
        //yield return new WaitForSeconds(0.25f);
        SpawningStarted = false;
    }

}
