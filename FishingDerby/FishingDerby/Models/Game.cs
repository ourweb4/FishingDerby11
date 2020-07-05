// ***********************************************************************
// Assembly         : FishingDerby
// Author           : Bill Banks
// Created          : 04-06-2017
//
// Last Modified By : Bill Banks
// Last Modified On : 04-10-2017
// ***********************************************************************
// <copyright file="Game.cs" company="Ourweb.net">
//     Copyright ©  2014
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace FishingDerby.Models
{
    /// <summary>
    /// Class Game.
    /// </summary>
    class Game
    {
        /// <summary>
        /// Gets or sets the gid.
        /// </summary>
        /// <value>The gid.</value>
        [PrimaryKey, AutoIncrement]
        public int gid { get; set; }

        /// <summary>
        /// Gets or sets the pid.
        /// </summary>
        /// <value>The pid.</value>
        public int pid { get; set; }
        /// <summary>
        /// Gets or sets the catid.
        /// </summary>
        /// <value>The catid.</value>
        public int catid { get; set; }
        /// <summary>
        /// Gets or sets the lenth.
        /// </summary>
        /// <value>The lenth.</value>
        public int lenth { get; set; }
        /// <summary>
        /// Gets or sets the inches.
        /// </summary>
        /// <value>The inches.</value>
        public int fraction { get; set; }
        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        /// <value>The weight.</value>
        public float weight { get; set; }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>The notes.</value>
        [MaxLength(255)]
        public string notes { get; set; }

        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        /// <value>The time.</value>
        /// 
        
        public DateTime time { get; set; }


    }
}
