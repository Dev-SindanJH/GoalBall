using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ExpandFunction
{
    public static class ExpandFunction
    {
        public static IEnumerator IE_SetSliderValue(this Slider _slider, float _targetValue, float _time)
        {
            float curTime = 0f;
            float speed = (_targetValue - _slider.value)/_time;
            while(curTime<_time)
            {
                _slider.value += speed * Time.deltaTime;
                curTime += Time.deltaTime;
                yield return null;
            }
            _slider.value = _targetValue;
            yield break;
        }
        public static IEnumerator IE_MoveRect(this RectTransform _rt, Vector2 _targetPos, float _time)
        {
            float curTime = 0f;
            Vector2 speed = ( _targetPos-_rt.anchoredPosition) / _time;

            while (curTime < _time)
            {
                _rt.anchoredPosition += speed * Time.deltaTime;
                curTime += Time.deltaTime;
                yield return null;
            }
            _rt.anchoredPosition = _targetPos;
        }
        public static IEnumerator IE_SetScale(this RectTransform _rt, Vector3 _targetScale, float _time)
        {
            float curTime = 0f;
            Vector3 speed = (_targetScale - _rt.localScale) / _time;
            while(curTime<_time)
            {
                _rt.localScale += speed * Time.deltaTime;
                curTime += Time.deltaTime;
                yield return null;
            }
        }
    }

}
