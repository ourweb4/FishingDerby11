// ***********************************************************************
// Assembly         : FishingDerby
// Author           : Bill
// Created          : 04-05-2017
//
// Last Modified By : Bill
// Last Modified On : 04-05-2017
// ***********************************************************************
// <copyright file="Player.cs" company="">
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
    /// Class Player.
    /// </summary>
    class Player
    {
        /// <summary>
        /// Gets or sets the pid.
        /// </summary>
        /// <value>The pid.</value>
        [PrimaryKey, AutoIncrement]
        public int pid { get; set; }
        /// <summary>
        /// Gets or sets the fname.
        /// </summary>
        /// <value>The fname.</value>
        [MaxLength(25)]
        public string fname { get; set; }
        /// <summary>
        /// Gets or sets the lname.
        /// </summary>
        /// <value>The lname.</value>
        [MaxLength(50)]
        public string lname { get; set; }

        public override string ToString()
        {
            return lname + ", " + fname;
        }
    }
}
