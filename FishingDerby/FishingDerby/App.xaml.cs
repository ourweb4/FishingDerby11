// ***********************************************************************
// Assembly         : FishingDerby
// Author           : Bill
// Created          : 04-05-2017
//
// Last Modified By : Bill
// Last Modified On : 04-05-2017
// ***********************************************************************
// <copyright file="App.xaml.cs" company="Ourweb.net">
//     Copyright ©  2014
// </copyright>
// <summary>Fishing Derby App</summary>
// ***********************************************************************

using System;
    using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AppCenter.Push;
using Xamarin.Forms;

namespace FishingDerby
{


    /// <summary>
    /// Class App.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Application" />
    public partial class App : Application
    {
        private const string _ver = "Ver 1.2.0";
        private const string weightkey = "weight";
        private const string fractionkey = " fraction";
        /// <summary>
        /// Initializes a new instance of the <see cref="App" /> class.
        /// </summary>
        public App()
        {
            InitializeComponent();
            // from your PCL app.cs (remember to Init on android platform project)

            MainPage = new NavigationPage(new FishingDerby.MainPage());
        }

        /// <summary>
        /// Application developers override this method to perform actions when the application starts.
        /// </summary>
        /// <remarks>To be added.</remarks>
        protected override void OnStart()
        {
            // Handle when your app starts
            AppCenter.Start("587db99a-729e-4e42-bc53-0e307f30c7c9", typeof(Push));
            AppCenter.Start("6c3a2733-440f-4ba5-924d-00ac96fe0628", typeof(Push));
            AppCenter.Start("android=587db99a-729e-4e42-bc53-0e307f30c7c9;" +
                            "uwp={Your UWP App secret here};" +
                            "ios=6c3a2733-440f-4ba5-924d-00ac96fe0628;", typeof(Analytics), typeof(Crashes));
        }

        /// <summary>
        /// Application developers override this method to perform actions when the application enters the sleeping state.
        /// </summary>
        /// <remarks>To be added.</remarks>
        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        /// <summary>
        /// Application developers override this method to perform actions when the application resumes from a sleeping state.
        /// </summary>
        /// <remarks>To be added.</remarks>
        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public bool weightflag
        {
            set
            {
                Properties[weightkey] = value;
                SavePropertiesAsync();

            }
            get
            {
                if (Properties.ContainsKey(weightkey) == false)
                {
                    return false;
                }
                return (bool)Properties[weightkey];

            }
        }

        public int   fractionmax
        {
            set
            {
                Properties[fractionkey] = value;
                SavePropertiesAsync();
            }
            get
            {
                if (Properties.ContainsKey(fractionkey))
                {
                    return (int)Properties[fractionkey];
                }
                return 16;
            }
        }

        public string Version
        {
            get { return _ver; }
        }
    }
}
