using System;
using Android.Content;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Content.Res;

namespace Common.Droid.Views
{
	public class SwipeFrameLayout : FrameLayout
	{
		public SwipeFrameLayout(Context context)
			: this(context, null, 0, 0)
		{
		}

		public SwipeFrameLayout(Context context, IAttributeSet attrs)
			: this(context, attrs, 0, 0)
		{
		}

		public SwipeFrameLayout(Context context, IAttributeSet attrs, int defStyleAttr)
			: this(context, attrs, defStyleAttr, 0)
		{
		}

		public SwipeFrameLayout(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
			: base(context, attrs, defStyleAttr, defStyleRes)
		{
			if (attrs != null)
			{
				TypedArray typedArray = context.ObtainStyledAttributes(attrs, Resource.Styleable.SwipeFrameLayout);
		
				SwipeLeftIndex = typedArray.GetInt(Resource.Styleable.SwipeFrameLayout_SwipeLeftIndex, -1);
				SwipeRightIndex = typedArray.GetInt(Resource.Styleable.SwipeFrameLayout_SwipeRightIndex, -1);

				typedArray.Recycle();
			}
		}

		public int SwipeLeftIndex
		{
			get
			{
				return m_swipeLeftIndex;
			}
			set
			{
				m_swipeLeftIndex = value;
			}
		}

		public int SwipeRightIndex
		{
			get
			{
				return m_swipeRightIndex;
			}
			set
			{
				m_swipeRightIndex = value;
			}
		}

		public void Reset()
		{
			if (m_swipeView == null)
				return;
			
			m_isSwiped = false;
			m_swipeView.TranslationX = 0f;
			m_swipeView.TranslationY = 0f;
		}

		public override void OnStartTemporaryDetach()
		{
			base.OnStartTemporaryDetach();

			Reset();
		}

		public override bool OnTouchEvent(MotionEvent e)
		{
			bool handled = false;

			switch(e.ActionMasked)
			{
			case MotionEventActions.Down:
				m_downX = e.RawX;
				m_downY = e.RawY;

				if (m_swipeView == null)
					m_swipeView = GetChildAt(ChildCount - 1);

				handled = true;
				break;
			case MotionEventActions.Cancel:
			case MotionEventActions.Up:
				if (!m_isSwiped)
				{
					m_swipeView.Animate().TranslationX(0f);
				}

				m_downX = 0f;
				m_downY = 0f;

				break;
			case MotionEventActions.Move:
				float x = e.RawX - m_downX;

				if (x < 0 && SwipeLeftIndex >= 0 && !m_isSwiped)
				{
					View swipeLeftView = GetChildAt(SwipeLeftIndex);
						
					SetChildVisibile(swipeLeftView);

					if (Math.Abs(x) >= c_swipeThreshold)
					{
						m_isSwiped = true;
						m_swipeView.Animate().TranslationX(0 - Width).WithEndAction(new Java.Lang.Runnable(() =>
						{
							var handler = SwipedLeft;
							if (handler != null)
								handler(this, new EventArgs());
						}));
					}
					else
					{
						m_swipeView.TranslationX = x;
					}

				}
				else if (x > 0 && SwipeRightIndex >= 0 && !m_isSwiped)
				{
					View swipeRightView = GetChildAt(SwipeRightIndex);

					SetChildVisibile(swipeRightView);

					if (Math.Abs(x) >= c_swipeThreshold)
					{
						m_isSwiped = true;
						m_swipeView.Animate().TranslationX(Width).WithEndAction(new Java.Lang.Runnable(() =>
						{
							var handler = SwipedRight;
							if (handler != null)
								handler(this, new EventArgs());
						}));
					}
					else
					{
						m_swipeView.TranslationX = x;
					}
				}

				break;
			}

			return handled;
		}

		public event EventHandler SwipedLeft;

		public event EventHandler SwipedRight;

		private void SetChildVisibile(View visibleChild)
		{
			for (int i = 0; i < ChildCount - 1 ; i++)
			{
				View child = GetChildAt(i);
				child.Visibility = visibleChild == child ? ViewStates.Visible : ViewStates.Gone;
			}
		}

		const float c_swipeThreshold = 500;

		View m_swipeView;
		int m_swipeLeftIndex;
		int m_swipeRightIndex;
		bool m_isSwiped;
		float m_downX;
		float m_downY;
	}
}
