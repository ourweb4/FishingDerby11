// ***********************************************************************
// Assembly         : FishingDerby
// Author           : Bill Banks
// Created          : 04-29-2017
//
// Last Modified By : Bill Banks
// Last Modified On : 04-29-2017
// ***********************************************************************
// <copyright file="Messagebox.cs" company="Ourweb.net">
//     Copyright ©  2014
// </copyright>
// <summary></summary>
// ***********************************************************************
using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FishingDerby.Utiltys
{
    /// <summary>
    /// Class Messagebox.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    public partial class Messagebox : ContentPage
    {
        /// <summary>
        /// The message
        /// </summary>
        public string message;
        /// <summary>
        /// The answer
        /// </summary>
        public bool answer;

        public Messagebox()
        {
            message = "Are  you sure?";
        }

        public Messagebox(string mess)
        {
            message = mess;
        }
        /// <summary>
        /// Askits this instance.
        /// </summary>
         public async void Askit()
        {
           var ans = await DisplayAlert("Alert", message, "Yes", "No");
            Debug.WriteLine("askit ask " +  ans);
            answer = ans;
        }

        /// <summary>
        /// Results this instance.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
         public bool Result()
        {
           Askit();

            return answer == true;

        }

    }
}