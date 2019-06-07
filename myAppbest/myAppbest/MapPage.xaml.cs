﻿using myAppbest.model;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace myAppbest
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapPage : ContentPage
	{
		public MapPage ()
		{
			InitializeComponent ();
		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var locator = CrossGeolocator.Current;
            locator.PositionChanged += Locator_PositionChanged;
            await locator.StartListeningAsync(TimeSpan.FromSeconds(0), 100);
            var position = await locator.GetPositionAsync();
            var center = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);
            var span = new Xamarin.Forms.Maps.MapSpan(center, 2, 2);
            locationsMap.MoveToRegion(span);
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                var posts = conn.Table<Post>().ToList();
                DisplayInMap(posts);
                 

            }
        }

        private void DisplayInMap(List<Post> posts)
        {
            foreach (var post in posts)
            {
                try
                {
                var position = new Xamarin.Forms.Maps.Position(post.Latitude, post.Longitude);
                var pin = new Xamarin.Forms.Maps.Pin()
                {
                    Type= Xamarin.Forms.Maps.PinType.SavedPin,
                    Position=position,
                    Label=post.VenueName,
                    Address=post.Address
                };
                locationsMap.Pins.Add(pin);
                }//End of try:
                catch(NullReferenceException nre) { }
                catch (Exception ex){}

            }
        }//End of DisplayInMap function:

        private void Locator_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            var center = new Xamarin.Forms.Maps.Position(e.Position.Latitude, e.Position.Longitude);
            var span = new Xamarin.Forms.Maps.MapSpan(center, 2, 2);
            locationsMap.MoveToRegion(span);

        }
        protected async override void OnDisappearing()
        {
            base.OnDisappearing();
            var locator = CrossGeolocator.Current;
            locator.PositionChanged -= Locator_PositionChanged;
            await locator.StopListeningAsync();
        }

        //private void Locator_PositionChanged1(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        //{
        //    var center = new Xamarin.Forms.Maps.Position(e.Position.Latitude, e.Position.Longitude);
        //    var span = new Xamarin.Forms.Maps.MapSpan(center, 2, 2);
        //    locationsMap.MoveToRegion(span);


        //}
    }
}