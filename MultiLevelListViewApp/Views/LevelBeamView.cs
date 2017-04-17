using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views;
using System;

namespace MultiLevelListViewApp.Views
{
    public class LevelBeamView : View
    {
        private int _level;

        private int _padding;

        private int _linesWidth;

        private int _linesOffset;

        private Paint _linePaint;

        public LevelBeamView(Context context) : base(context)
        {
            this.Init();
        }

        public LevelBeamView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            this.Init();
        }

        public LevelBeamView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            this.Init();
        }

        public LevelBeamView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
            this.Init();
        }

        protected LevelBeamView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
            this.Init();
        }

        public override void Draw(Canvas canvas)
        {
            base.Draw(canvas);
            for (int i = 0; i <= _level; i++)
            {
                float single = (float)(_padding + i * _linesWidth);
                if (i >= 1)
                {
                    single = single + (float)(i * _linesOffset);
                }
                _linePaint.Color = new Color(Context.GetColor(GetColorResIdForLevel(i)));
                canvas.DrawLine(single, 0f, single, (float)canvas.Height, _linePaint);
            }
        }

        private int GetColorResIdForLevel(int level)
        {
            switch (level)
            {
                case 0:
                    return Resource.Color.level_0;
                case 1:
                    return Resource.Color.level_1;
                case 2:
                    return Resource.Color.level_2;
                case 3:
                    return Resource.Color.level_3;
                case 4:
                    return Resource.Color.level_4;
                case 5:
                    return Resource.Color.level_5;
                default:
                    return Resource.Color.level_default;
            }
        }

        private void Init()
        {
            _padding = (int)Resources.GetDimension(Resource.Dimension.data_item_row_padding);
            _linesWidth = (int)Resources.GetDimension(Resource.Dimension.level_beam_line_width);
            _linesOffset = Resources.GetDimensionPixelSize(Resource.Dimension.level_beam_line_offset);
            _linePaint = new Paint()
            {
                AntiAlias = true,
                Color = Color.Red
            };
            _linePaint.SetStyle(Paint.Style.Fill);
            _linePaint.StrokeWidth = (float)_linesWidth;
            Invalidate();
            SetWillNotDraw(false);
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            int num = _padding + (_level + 1) * (_linesWidth + _linesOffset);
            SetMeasuredDimension(num, View.MeasureSpec.GetSize(heightMeasureSpec));
        }

        public void SetLevel(int level)
        {
            _level = level;
            RequestLayout();
        }
    }
}