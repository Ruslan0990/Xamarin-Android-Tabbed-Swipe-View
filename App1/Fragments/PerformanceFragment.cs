using Android.Support.V7.Widget;
using Android.OS;
using Android.Views;
using App1.Adapter;
using Android.Widget;

namespace App1.Fragments
{
    public class PerformanceFragment : Android.Support.V4.App.Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.HomeFragmentLayout, container, false);

            var mRecyclerView = view.FindViewById<RecyclerView>(Resource.Id.recyclerView);

            mRecyclerView.HasFixedSize = true;

            var mLayoutManager = new LinearLayoutManager(view.Context);
            mRecyclerView.SetLayoutManager(mLayoutManager);

            int[] arr1 = { 2, 4, 3, 1 };
            var mAdapter = new MyRecyclerViewAdapter(arr1);
            mAdapter.ItemClick += OnItemClick;
            mRecyclerView.SetAdapter(mAdapter);           

            return view;
        }
        void OnItemClick(object sender, int position)
        {
            string msg = "Clicked Cardview #" + position.ToString();
            Toast.MakeText(Activity, msg, ToastLength.Short).Show();
        }
    }
}