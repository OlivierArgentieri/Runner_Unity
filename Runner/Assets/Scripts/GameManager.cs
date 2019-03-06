using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
public class GameManager : MonoBehaviour
{
    public static GameManager m_instance;
    private Player m_player_instance_;
    private Move m_move_instance_;
    
    private void Awake()
    {
        if (m_instance == null)
            m_instance = this;

        if (m_instance != this)
            Destroy(gameObject);

        m_instance = this;

        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void RegisterPlayer(Player _pPlayerInstance)
    {
        m_player_instance_ = _pPlayerInstance;
        m_move_instance_ = _pPlayerInstance.GetComponent<Move>();
    }

    
}