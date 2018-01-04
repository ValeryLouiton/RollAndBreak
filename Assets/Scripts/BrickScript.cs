using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    #region Public Members
    #endregion

    #region Public void

    #endregion

    #region System

    void Start ()
    {
   
    }
	
	void Update ()
    {
        if (m_brickScore > 0)
        {
            m_brickScore -= 1;
        }
    }

    public void InitBrick()
    {
        //FloorManager.Instance.SetBrickActive(true, this);
        m_brickScore = 5000;
        gameObject.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            FloorManager.Instance.SetBrickActive(false, this);
        }
    }
    #endregion

    #region Tools Debug and Utility

    #endregion

    #region Private and Protected Members

    private int m_brickScore;
    public int Score
    {
        get { return m_brickScore; }
    }


    #endregion
}
