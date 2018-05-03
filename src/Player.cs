﻿using System.Collections.Generic;
using SwinGameSDK;

namespace ShooterGame
{
    /// <summary>
    /// The Player class contains player data such as name and colour.
    /// This class also contains static methods for accessing and managing a static player list.
    /// </summary>
    class Player
    {
        private static List<Player> _players = new List<Player>();
        private static Player _localPlayer;

        private int _index;
        private string _name;
        private Color _colour;

        /// <summary>
        /// Check if this player is the local player.
        /// </summary>
        public bool IsLocal { get { return this == _localPlayer; } }

        /// <summary>
        /// Get the local player (this machine in a network sense).
        /// </summary>
        public static Player LocalPlayer { get => _localPlayer; }

        /// <summary>
        /// Access player index (location within the NetworkController player list).
        /// </summary>
        /// <remarks>This should only be changed by the NetworkController.</remarks>
        public int Index
        {
            get => _index;
        }

        /// <summary>
        /// Access player name.
        /// </summary>
        /// <remarks>This should only be changed by the NetworkController.</remarks>
        public string Name
        {
            get => _name;
            set { _name = value; }
        }

        /// <summary>
        /// Access player colour.
        /// </summary>
        /// <remarks>This should only be changed by the NetworkController.</remarks>
        public Color Colour
        {
            get => _colour;
            set { _colour = value;}
        }

        /// <summary>
        /// Setup the player list.
        /// </summary>
        /// <param name="amount">Amount of players the list should contain.</param>
        public static void InitPlayers(int amount)
        {
            // Stupidity check
            if (_players.Count > 0) throw new System.ArgumentException("cannot create new player list while one already exists");
            
            // Setup players list
            for (int i=0; i<amount; i++)
            {
                Player p = new Player();
                p._index = i;
                p._name = "Player " + (i + 1);
                p._colour = SwinGame.RandomRGBColor(255);
                _players.Add(p);
            }
        }

        /// <summary>
        /// Clear the player list.
        /// </summary>
        public static void TerminatePlayers()
        {
            _players.Clear();
        }

        /// <summary>
        /// Set the index of the local player.
        /// </summary>
        /// <param name="i">Array index if the local player.</param>
        public static void SetLocalPlayerIndex(int i)
        {
            _localPlayer = PlayerByIndex(i);
        }

        /// <summary>
        /// Get player using list index.
        /// </summary>
        /// <param name="i">Array index if the player.</param>
        /// <returns>Player at index, or null if out-of-range.</returns>
        public static Player PlayerByIndex(int i)
        {
            if ((0 <= i) && (i < _players.Count))
                return _players[i];
            else
                return null;
        }
    }
}