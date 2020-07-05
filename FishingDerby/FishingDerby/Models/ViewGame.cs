// ***********************************************************************
// Assembly         : FishingDerby
// Author           : Bill Banks
// Created          : 04-27-2017
//
// Last Modified By : Bill Banks
// Last Modified On : 04-27-2017
// ***********************************************************************
// <copyright file="ViewGame.cs" company="Ourweb.net">
//     Copyright ©  2014
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingDerby.Models
{
    /// <summary>
    /// Class ViewGame.
    /// </summary>
    class ViewGame
    {
        /// <summary>
        /// The player
        /// </summary>
        public string player;
        /// <summary>
        /// The category
        /// </summary>
        public string category;
        /// <summary>
        /// The lenght
        /// </summary>
        public string lenght;
        /// <summary>
        /// The time
        /// </summary>
        public DateTime Time;
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            var ts = Time.ToString("T");

            return player + "-" + category + " " + lenght + " " + ts;

        }
    }
}
