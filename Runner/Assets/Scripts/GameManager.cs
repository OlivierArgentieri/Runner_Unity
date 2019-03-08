using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
public class GameManager
{
    private static GameManager m_instance_;
    public static GameManager GetInstance()
    {
        if (m_instance_ == null)
            m_instance_ = new GameManager();

        return m_instance_;
    }
    private GameManager() { }

    private Player m_player_instance_;
    private Move m_move_instance_;
  
    public void RegisterPlayer(Player _pPlayerInstance)
    {
        m_player_instance_ = _pPlayerInstance;
        m_move_instance_ = _pPlayerInstance.GetComponent<Move>();
    }
}