using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    /// <summary>
    /// De type staat waarin een cell zich op het moment kan bevinden.
    /// </summary>
    public enum MarkType
    {
        /// <summary>
        /// De cell is nog niet geklikt
        /// </summary>
        Leeg,

        /// <summary>
        /// De cell is een O
        /// </summary>
        Rondje,

        /// <summary>
        /// De cell is een X
        /// </summary>
        Kruis
    }
}