using System;

public class CustomEasing
{
	private float beginVal;
	private float endVal;
	private float changeVal;
	private float duration;
	private float curTime;
	private easingFunc func;

	public bool IsMoving { get; set; }

	public CustomEasing(eEasingType type, float beginValue, float endValue, float durationTime)
	{
		beginVal = beginValue;
		endVal = endValue;
		changeVal = endValue - beginValue;
		duration = durationTime;
		curTime = 0;
		IsMoving = true;

		switch (type)
		{
			case eEasingType.Linear: func = linear; break;
			case eEasingType.InQuad: func = inQuad; break;
			case eEasingType.OutQuad: func = outQuad; break;
			case eEasingType.InOutQuad: func = inOutQuad; break;
			case eEasingType.InCubic: func = inCubic; break;
			case eEasingType.OutCubic: func = outCubic; break;
			case eEasingType.InOutCubic: func = inOutCubic; break;
			case eEasingType.InQuart: func = inQuart; break;
			case eEasingType.OutQuart: func = outQuart; break;
			case eEasingType.InOutQuart: func = inOutQuart; break;
			case eEasingType.InSine: func = inSine; break;
			case eEasingType.OutSine: func = outSine; break;
			case eEasingType.InOutSine: func = inOutSine; break;
			case eEasingType.InExpo: func = inExpo; break;
			case eEasingType.OutExpo: func = outExpo; break;
			case eEasingType.InOutExpo: func = inOutExpo; break;
			case eEasingType.InCirc: func = inCirc; break;
			case eEasingType.OutCirc: func = outCirc; break;
			case eEasingType.InOutCirc: func = inOutCirc; break;
			case eEasingType.InElastic: func = inElastic; break;
			case eEasingType.OutElastic: func = outElastic; break;
			case eEasingType.InOutElastic: func = inOutElastic; break;
			case eEasingType.InBack: func = inBack; break;
			case eEasingType.OutBack: func = outBack; break;
			case eEasingType.InOutBack: func = inOutBack; break;
			case eEasingType.InBounce: func = inBounce; break;
			case eEasingType.OutBounce: func = outBounce; break;
			case eEasingType.InOutBounce: func = inOutBounce; break;
		}
	}

	public float GetCurVal(float deltaTime, bool canOver = false)
	{
		if (!IsMoving)
			return endVal;

		curTime += deltaTime;

		if (!canOver && curTime >= duration)
		{
			curTime = duration;
			IsMoving = false;
		}

		float t = duration > 0 ? curTime / duration : 1;
		return beginVal + func(t) * changeVal;
	}

	private float linear(float t) { return t; }

	private float inQuad(float t) { return t * t; }

	private float outQuad(float t) { return t * (2 - t); }

	private float inOutQuad(float t)
	{
		if (t < 0.5f) return 2 * t * t;
		return -1 + (4 - 2 * t) * t;
	}

	private float inCubic(float t) { return t * t * t; }

	private float outCubic(float t)
	{
		t -= 1;
		return t * t * t + 1;
	}

	private float inOutCubic(float t)
	{
		if (t < 0.5f) return 4 * t * t * t;
		t = 2 * t - 2;
		return 0.5f * t * t * t + 1;
	}

	private float inQuart(float t) { return t * t * t * t; }

	private float outQuart(float t)
	{
		t -= 1;
		return -(t * t * t * t) + 1;
	}

	private float inOutQuart(float t)
	{
		if (t < 0.5f) return 8 * t * t * t * t;
		t = 2 * t - 2;
		return -0.5f * t * t * t * t + 1;
	}

	private float inSine(float t) { return 1 - (float)Math.Cos(t * Math.PI / 2); }

	private float outSine(float t) { return (float)Math.Sin(t * Math.PI / 2); }

	private float inOutSine(float t) { return -(float)(Math.Cos(Math.PI * t) - 1) / 2; }

	private float inExpo(float t)
	{
		if (t == 0) return 0;
		return (float)Math.Pow(2, 10 * (t - 1));
	}

	private float outExpo(float t)
	{
		if (t == 1) return 1;
		return (float)(-Math.Pow(2, -10 * t) + 1);
	}

	private float inOutExpo(float t)
	{
		if (t == 0) return 0;
		if (t == 1) return 1;
		if (t < 0.5f) return (float)Math.Pow(2, 10 * (2 * t - 1)) / 2;
		return (float)(-Math.Pow(2, -10 * (2 * t - 1)) + 2) / 2;
	}

	private float inCirc(float t) { return -(float)(Math.Sqrt(1 - t * t) - 1); }

	private float outCirc(float t)
	{
		t -= 1;
		return (float)Math.Sqrt(1 - t * t);
	}

	private float inOutCirc(float t)
	{
		if (t < 0.5f) return -(float)(Math.Sqrt(1 - 4 * t * t) - 1) / 2;
		t = 2 * t - 2;
		return (float)(Math.Sqrt(1 - t * t) + 1) / 2;
	}

	private float inElastic(float t)
	{
		if (t == 0) return 0;
		if (t == 1) return 1;
		return -(float)Math.Pow(2, 10 * (t - 1)) * (float)Math.Sin((t - 1.1f) * 5 * Math.PI);
	}

	private float outElastic(float t)
	{
		if (t == 0) return 0;
		if (t == 1) return 1;
		return (float)Math.Pow(2, -10 * t) * (float)Math.Sin((t - 0.1f) * 5 * Math.PI) + 1;
	}

	private float inOutElastic(float t)
	{
		if (t == 0) return 0;
		if (t >= 1) return 1;
		if (t < 0.5f)
			return -(float)Math.Pow(2, 10 * (2 * t - 1)) * (float)Math.Sin((2 * t - 1.1f) * 2.5f * Math.PI) / 2;
		return (float)Math.Pow(2, -10 * (2 * t - 1)) * (float)Math.Sin((2 * t - 1.1f) * 2.5f * Math.PI) / 2 + 1;
	}

	private float inBack(float t)
	{
		const float s = 1.70158f;
		return t * t * ((s + 1) * t - s);
	}

	private float outBack(float t)
	{
		const float s = 1.70158f;
		t -= 1;
		return t * t * ((s + 1) * t + s) + 1;
	}

	private float inOutBack(float t)
	{
		const float s = 1.70158f * 1.525f;
		if (t < 0.5f) return 0.5f * (t * 2 * (2 * t * ((s + 1) * 2 * t - s)));
		t = 2 * t - 2;
		return 0.5f * (t * t * ((s + 1) * t + s) + 2);
	}

	private float inBounce(float t) { return 1 - outBounce(1 - t); }

	private float outBounce(float t)
	{
		if (t < 1 / 2.75f)
			return 7.5625f * t * t;
		if (t < 2 / 2.75f)
		{
			t -= 1.5f / 2.75f;
			return 7.5625f * t * t + 0.75f;
		}
		if (t < 2.5f / 2.75f)
		{
			t -= 2.25f / 2.75f;
			return 7.5625f * t * t + 0.9375f;
		}
		t -= 2.625f / 2.75f;
		return 7.5625f * t * t + 0.984375f;
	}

	private float inOutBounce(float t)
	{
		if (t < 0.5f) return inBounce(t * 2) / 2;
		return outBounce(t * 2 - 1) / 2 + 0.5f;
	}

	private delegate float easingFunc(float curTime);

	public enum eEasingType
	{
		Linear = 0,
		InQuad = 1,
		OutQuad = 2,
		InOutQuad = 3,
		InCubic = 4,
		OutCubic = 5,
		InOutCubic = 6,
		InQuart = 7,
		OutQuart = 8,
		InOutQuart = 9,
		InSine = 10,
		OutSine = 11,
		InOutSine = 12,
		InExpo = 13,
		OutExpo = 14,
		InOutExpo = 15,
		InCirc = 16,
		OutCirc = 17,
		InOutCirc = 18,
		InElastic = 19,
		OutElastic = 20,
		InOutElastic = 21,
		InBack = 22,
		OutBack = 23,
		InOutBack = 24,
		InBounce = 25,
		OutBounce = 26,
		InOutBounce = 27,
	}
}