using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorManager : MonoBehaviour
{
    #region Public Members
    public Text m_text;
    public List<BrickScript> m_activeBricks;
    public List<BrickScript> m_inactiveBricks;

    private static FloorManager _instance;
    public static FloorManager Instance
    {
        get { return _instance; }
    }

    #endregion

    #region Public void

    #endregion

    #region System

    private void Awake()
    {
    //    m_activeBricks = new List<BrickScript>();
    //    m_inactiveBricks = new List<BrickScript>();
    }

    public void SetBrickActive(bool active, BrickScript brick)
    {
        if(active)
        {
            m_inactiveBricks.Remove(brick);
            brick.InitBrick();
            m_activeBricks.Add(brick);
        }
        else
        {
            m_inactiveBricks.Add(brick);
            m_activeBricks.Remove(brick);
            _totalScore += brick.Score;
        }
    }

    public void SpawnBrick()
    {
        BrickScript[] tab = m_inactiveBricks.ToArray();
        if (tab.Length > 0)
        {
            int index = Random.Range(0, tab.Length);
            SetBrickActive(true, tab[index]);
        }
        else m_text.text = "PERDU";
    }

    void Start ()
    {
        _instance = this;
        _totalScore = 0;
        Input.gyro.enabled = true;
        Input.compass.enabled = true;
        StartCoroutine(WaitAndPrint(1f));
    }

    void Update ()
    {
        Vector3 getVec = Input.acceleration;
        dirVec.x = Input.acceleration.y;
        dirVec.z = -Input.acceleration.x;
        transform.rotation = Quaternion.Euler(dirVec * 50);
    }
    
    IEnumerator WaitAndPrint(float waitTime)
    {
        while(true)
        {
            SpawnBrick();
            yield return new WaitForSeconds(waitTime);
        }
    }

#endregion

#region Tools Debug and Utility

#endregion

#region Private and Protected Members

Vector3 dirVec = Vector3.zero;
    private int _totalScore;

    #endregion
}
