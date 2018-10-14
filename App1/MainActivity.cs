using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Support.V4.View;
using Android.Support.V4.Graphics.Drawable;
using Android.Support.V4.Content;
using Android.Support.Graphics.Drawable;
using Android.Widget;
using V4Fragment = Android.Support.V4.App.Fragment;
using App1.Fragments;
using App1.Adapter;


namespace App1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            if ((int)Build.VERSION.SdkInt >= 21)
            {
                Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
            }

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            var fragments = new V4Fragment[]
            {
                new HomeFragment(),
                new PerformanceFragment(),
                new CollectionFragment()
            };
            var titles = (new int[] {
                Resource.String.strHome,
                Resource.String.strPerformance,
                Resource.String.strCollection
            });

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.app_bar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetTitle(titles[0]);
            var tabLayout = FindViewById<TabLayout>(Resource.Id.sliding_tabsIcon);
            
            var viewPager = FindViewById<ViewPager>(Resource.Id.viewpagerIcon);
            viewPager.Adapter = new TabsFragmentPagerAdapter(SupportFragmentManager, fragments, titles);
            tabLayout.SetupWithViewPager(viewPager);
            
            var homeIcon = VectorDrawableCompat.Create(Resources, Resource.Drawable.ic_home, Theme);
            var performanceIcon = VectorDrawableCompat.Create(Resources, Resource.Drawable.ic_barChart, Theme);
            var collectionIcon = VectorDrawableCompat.Create(Resources, Resource.Drawable.ic_collection, Theme);
            tabLayout.GetTabAt(0).SetIcon(homeIcon);
            tabLayout.GetTabAt(1).SetIcon(performanceIcon);
            tabLayout.GetTabAt(2).SetIcon(collectionIcon);

            var tabIconColors = ContextCompat.GetColorStateList(this, Resource.Drawable.tab_colors);

            for (int i = 0; i < 3; i++)
            {
                var iconWrap = DrawableCompat.Wrap(tabLayout.GetTabAt(i).Icon);
                DrawableCompat.SetTintList(iconWrap, tabIconColors);
                tabLayout.GetTabAt(i).SetIcon(iconWrap);
            }

            tabLayout.TabSelected += (object sender, TabLayout.TabSelectedEventArgs e) =>
            {
                var tab = e.Tab;
                viewPager.SetCurrentItem(tab.Position, true);
                SupportActionBar.SetTitle(titles[tab.Position]);
            };
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                Toast.MakeText(this, "Check out my settings tutorial", ToastLength.Short).Show();
            }
            return base.OnOptionsItemSelected(item);
        }

	}
}