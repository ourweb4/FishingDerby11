// ***********************************************************************
// Assembly         : FishingDerby
// Author           : Bill
// Created          : 04-05-2017
//
// Last Modified By : Bill
// Last Modified On : 04-17-2017
// ***********************************************************************
// <copyright file="Category.cs" company="Ourweb.net">
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
    /// Class Category.
    /// </summary>
    class Category
    {
        /// <summary>
        /// Gets or sets the catid.
        /// </summary>
        /// <value>The catid.</value>
        [PrimaryKey, AutoIncrement]
        public int catid { get; set; }
        /// <summary>
        /// Gets or sets the catname.
        /// </summary>
        /// <value>The catname.</value>
        [MaxLength( 30)]
        public string catname { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return catname;
        }
    }
}
