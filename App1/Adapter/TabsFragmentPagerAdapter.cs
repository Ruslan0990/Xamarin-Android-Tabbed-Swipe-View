using Android.Support.V4.App;

namespace App1.Adapter
{
    public class TabsFragmentPagerAdapter : FragmentPagerAdapter
    {
        private readonly Fragment[] fragments;

        private readonly int[] titles;

        public TabsFragmentPagerAdapter(FragmentManager fm, Fragment[] fragments, int[] titles) : base(fm)
        {
            this.fragments = fragments;
            this.titles = titles;
        }
        public override int Count => fragments.Length;

        public override Fragment GetItem(int position) => fragments[position];

    }
}