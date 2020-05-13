using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Drawing_android
{
    [Register("Drawing_android.Canvas_Class")]
    public class Canvas_Class : LinearLayout
    {
        string canvas_text_label;
        int count = 0;
        TextView lbl;
        float x;
        float y;
        string sDown;
        string sMove;
        string sUp;
        public Canvas_Class(Context context) : base(context)
        {

            Initialize(context);
        }

        public Canvas_Class(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Initialize(context, attrs);
        }

        private void Initialize(Context context, IAttributeSet attrs = null)
        {
            Inflate(context, Resource.Layout.layout_canvas, this);
            lbl = FindViewById<TextView>(Resource.Id.textView1);
            InitAttrProperties(context, attrs);

        }

        private void InitAttrProperties(Context context, IAttributeSet attrs)
        {
            if (context == null || attrs == null)
            {
                return;
            }

            Android.Content.Res.TypedArray typedArray = context.ObtainStyledAttributes(attrs, Resource.Styleable.CanvasAttr);
            canvas_text_label = typedArray.GetString(Resource.Styleable.CanvasAttr_text_lable);

            this.Touch += Canvas_Class_Touch;
        }

        private void Canvas_Class_Touch(object sender, TouchEventArgs e)
        {
            x = e.Event.GetX();
            y = e.Event.GetY();

            switch (e.Event.Action)
            {
                case MotionEventActions.Down: // нажатие
                    sDown = "Down: " + x + "," + y;
                    sMove = ""; sUp = "";
                    break;
                case MotionEventActions.Move: // движение
                    sMove = "Move: " + x + "," + y;
                    break;
                case MotionEventActions.Up: // отпускание
                case MotionEventActions.Cancel:
                    sMove = "";
                    sUp = "Up: " + x + "," + y;
                    break;
            }
            lbl.Text = sDown + "\n" + sMove + "\n" + sUp;

            /* lbl.Text = count.ToString();
             count++;*/
        }
    }
}