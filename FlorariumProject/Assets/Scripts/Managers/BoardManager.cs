using UnityEngine;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance { get; private set; }

    private const int SLOTS_PER_SEASON = 4;

    private BoardSlot[,] board;

    private void Awake()
    {
        Instance = this;
        InitializeBoard();
    }

    private void InitializeBoard()
    {
        board = new BoardSlot[4, SLOTS_PER_SEASON];

        for (int s = 0; s < 4; s++)
        {
            for (int i = 0; i < SLOTS_PER_SEASON; i++)
            {
                board[s, i] = new BoardSlot
                {
                    season = (Season)s,
                    slotIndex = i,
                };
            }
        }
    }

    public bool TryPlaceCard(CardInstance instance)
    {
        int seasonIndex = (int)instance.data.season;

        for (int i = 0; i < SLOTS_PER_SEASON; i++)
        {
            if (board[seasonIndex, i].isEmpty)
            {
                board[seasonIndex, i].card = instance;
                instance.isFaceDown = true;
                instance.roundsOnBoard = 0;
                return true;
            }
        }
        return false;
    }

    public void AdvanceRound()
    {
        foreach (var slot in board)
        {
            if (slot.card != null && slot.card.isFaceDown)
            {
                slot.card.roundsOnBoard++;
            }
            if (slot.card != null)
            {
                slot.card.isInmuneThisTurn = false;
                slot.card.isRevealedThisTurn = false;
            }
        }
    }

    public List<CardInstance> GetRevealableCards(int ownerId)
    {
        List<CardInstance> result = new List<CardInstance>();

        foreach (var slot in board)
        {
            if (slot.card != null && slot.card.ownerId == ownerId && slot.card.isFaceDown && slot.card.roundsOnBoard >= 1)
            {
                result.Add(slot.card);
            }
        }
        return result;
    }

    public void RevealCard(CardInstance instance)
    {
        instance.Reveal();
    }

    public bool IsSeasonFull(Season season)
    {
        int seasonIndex = (int)season;

        for (int i = 0; i < SLOTS_PER_SEASON; i++)
        {
            if (board[seasonIndex, i].isEmpty) return false;
        }
        return true;
    }

    public bool IsBoardFull()
    {
        foreach (Season s in System.Enum.GetValues(typeof(Season)))
        {
            if (!IsSeasonFull(s)) return false;
        }

        return true;
    }

    public List<CardInstance> GetCardsInSeason(Season season, int ownerId)
    {
        List<CardInstance> result = new List<CardInstance>();

        int seasonIndex = (int)season;

        for(int i = 0; i < SLOTS_PER_SEASON; i++)
        {
            var c = board[seasonIndex, i].card;
            if (c != null && c.ownerId == ownerId) result.Add(c);
        }
        return result;
    }

    public BoardSlot GetSlot(Season season, int index) => board[(int)season, index];
}
