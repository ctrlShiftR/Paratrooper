using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [HideInInspector] public List<Trooper> leftroops, rightTroops;
    [HideInInspector] public bool spawingAllowed = true;
    [SerializeField] GameObject gameOverPanel;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        leftroops=new List<Trooper>();
        rightTroops=new List<Trooper>();  
    }


    void Update()
    {
        if(leftroops.Count>=4 || rightTroops.Count >= 4)
        {
            spawingAllowed = false;
            endGame();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);

    }
    public void endGame()
    {
        if (leftroops.Count >= 4)
        {
            leftroops.Sort((p1, p2) => Vector3.Distance(p1.gameObject.transform.position, Vector3.zero).CompareTo(Vector3.
                                                                                    Distance(p2.gameObject.transform.position, Vector3.zero)));
            StartCoroutine(troopClimbing(leftroops));
        }
        else
        {
            rightTroops.Sort((p1,p2)=> Vector3.Distance(p1.gameObject.transform.position, Vector3.zero).CompareTo(Vector3.
                                                                                    Distance(p2.gameObject.transform.position, Vector3.zero)));
            StartCoroutine (troopClimbing(rightTroops));
        }
    }
    IEnumerator troopClimbing(List<Trooper> troopers)
    {
        for(int i = 0; i < troopers.Count; i++)
        {
            troopers[i].Move();
            yield return new WaitForSeconds(2f);
        }
    }
}
