using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using System;

namespace App1.Adapter
{

    class MyRecyclerViewAdapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;

        public override int ItemCount => MessageIDdata.Length;

        int[] MessageIDdata;

        string[] MessageArray = {"zero", "one", "two", "three", "four"  };

        public MyRecyclerViewAdapter(int[] mMessageIDs)
        {
            this.MessageIDdata = mMessageIDs;    
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var vh = holder as WelcomeCardViewHolder;

            int id = MessageIDdata[position];

            vh.Caption.Text = MessageArray[id];
            vh.ItemView.Click += delegate
            {
                ItemClick?.Invoke(this, position);
            };
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.WelcomeCardView, parent, false);
            return new WelcomeCardViewHolder(itemView);
        }
    }

    class WelcomeCardViewHolder : RecyclerView.ViewHolder
    {
        public TextView Caption { get; private set; }

        public WelcomeCardViewHolder(View itemView)
        : base(itemView)
        {
            Caption = itemView.FindViewById<TextView>(Resource.Id.myTextView);
        }
    }
}