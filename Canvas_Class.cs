using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
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
        Color color = Color.Blue;
        bool emboss;
        bool blur;
        int strokeWidth;
        Path path;
        Bitmap mBitmap;
        Canvas mCanvas;
        private Path mPath;
        private Paint mPaint;

        private MaskFilter mEmboss;
        private MaskFilter mBlur;

        // Paint mBitmapPaint = new Paint(Paint.DITHER_FLAG);
        TextView lbl;
        float x;
        float y;
        string sDown;
        string sMove;
        string sUp;
        public Canvas_Class(Context context) : base(context)
        {

            Initialize(context);
            SetWillNotDraw(false);
        }

        public Canvas_Class(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Initialize(context, attrs);
            SetWillNotDraw(false);
        }

        private void Initialize(Context context, IAttributeSet attrs = null)
        {
            mPaint = new Paint();
            mPaint.AntiAlias = true;
            mPaint.Dither = true;
            mPaint.Color = color;
            mPaint.SetStyle(Paint.Style.Stroke);
            mPaint.StrokeJoin = Paint.Join.Round;
            mPaint.StrokeCap = Paint.Cap.Round;
            mPaint.SetXfermode(null);
            mPaint.Alpha = 0xff;
            mPath = new Path();

            /*mEmboss = new EmbossMaskFilter(new float[] { 1, 1, 1 }, 0.4f, 6, 3.5f);
            mBlur = new BlurMaskFilter(5, BlurMaskFilter.Blur.Normal);*/
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
           

            this.Touch += Canvas_Class_Touch;
            
        }

        private void DrawCanvas(Canvas obj)
        {
            throw new NotImplementedException();
        }

        private void Canvas_Class_Touch(object sender, TouchEventArgs e)
        {
            x = e.Event.GetX();
            y = e.Event.GetY();

            switch (e.Event.Action)
            {
                case MotionEventActions.Down: // нажатие
                    mPath.MoveTo(x, y);
                    Invalidate();
                    sDown = "Down: " + x + "," + y;
                    sMove = ""; sUp = "";
                    break;
                case MotionEventActions.Move: // движение
                    mPath.LineTo(x, y);
                    Invalidate();
                    sMove = "Move: " + x + "," + y;
                    break;
                case MotionEventActions.Up: // отпускание
                case MotionEventActions.Cancel:
                    sMove = "";
                    sUp = "Up: " + x + "," + y;
                    break;
            }
            lbl.Text = sDown + "\n" + sMove + "\n" + sUp;
            Invalidate();

            /* lbl.Text = count.ToString();
             count++;*/
        }

        protected override void OnDraw(Canvas canvas)
        {
            canvas.DrawPath(mPath, mPaint);
            base.OnDraw(canvas);
           
  
        }
    }
}