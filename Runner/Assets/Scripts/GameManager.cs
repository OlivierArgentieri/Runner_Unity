using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager m_instance_;
    private Player m_player_instance_;
    private Move m_move_instance_;

    public static GameManager GetInstance()
    {
        if (m_instance_ == null)
        {
            GameObject go = new GameObject("GameManager");
            go.AddComponent<GameManager>();
        }
        return m_instance_;
    }

    private void Awake()
    {
        if (m_instance_ == null)
            m_instance_ = this;
        if (m_instance_ != this)
        {
            Destroy(gameObject);
            return;
        }

        m_instance_ = this;
    }

    public void RegisterPlayer(Player _pPlayerInstance)
    {
        m_player_instance_ = _pPlayerInstance;
        m_move_instance_ = _pPlayerInstance.GetComponent<Move>();
    }
}