using TMPro;
using UnityEngine;

namespace Elements
{
    public class CustomUILabel : TextMeshProUGUI
    {
        [SerializeField]
        private string strTextId;
        [SerializeField]
        private bool isCorrectIllegalCharacters;
        private eTextId curTextId;
        private bool isInit;
        private Color originalColor;
        private Color originalEffectColor;
        private TMP_FontAsset initializedFont;
        private bool isUseColorCode;

        public string StrTextId => strTextId;
        public eTextId CurTextId => curTextId;
        public bool IsUseColorCode
        {
            get => isUseColorCode;
            set => isUseColorCode = value;
        }

        public override string text
        {
            get => base.text;
            set
            {
                if (isCorrectIllegalCharacters && !string.IsNullOrEmpty(value))
                {
                    value = CorrectIllegalCharacters(value);
                }
                base.text = value;
            }
        }

        // ==================== SetText ====================

        public void SetText(eTextId textId, object[] args)
        {
            curTextId = textId;
            string resolved = ResolveText(textId);
            SetText(resolved, args);
        }

        public void SetText(string _str, object[] _args)
        {
            if (_args != null && _args.Length > 0)
            {
                text = string.Format(_str, _args);
            }
            else
            {
                text = _str;
            }
        }

        // ==================== SetTextNum ====================

        public void SetTextNum(int _num)
        {
            text = _num.ToString();
        }

        public void SetTextNum(long _num)
        {
            text = _num.ToString();
        }

        public void SetTextNum(int _num, eColorGradation _colorGradation)
        {
            SetTextNum(_num);
            ApplyColorGradation(_colorGradation);
        }

        // ==================== SetTextCurrency ====================

        public void SetTextCurrency(long _currencyNum)
        {
            text = FormatCurrency(_currencyNum);
        }

        public void SetTextCurrency(int _currencyNum, eColorGradation _colorGradation)
        {
            SetTextCurrency(_currencyNum);
            ApplyColorGradation(_colorGradation);
        }

        public void SetTextCurrency(long _currencyNum, eColorGradation _colorGradation)
        {
            SetTextCurrency(_currencyNum);
            ApplyColorGradation(_colorGradation);
        }

        public void SetTextCurrency(int _currencyNum, eColor _color)
        {
            SetTextCurrency(_currencyNum);
            ApplyColor(_color);
        }

        // ==================== Color ====================

        public void SetTextColor(Color _color)
        {
            color = _color;
        }

        public void ResetColor()
        {
            color = originalColor;
        }

        public void ResetEffectColor()
        {
            color = originalEffectColor;
        }

        // ==================== Font ====================

        public void SetPreinFont()
        {
            if (initializedFont != null)
            {
                font = initializedFont;
            }
        }

        // ==================== Lifecycle ====================

        protected new void Awake()
        {
            if (!isInit)
            {
                originalColor = color;
                originalEffectColor = color;
                initializedFont = font;
                isInit = true;
            }
        }

        // ==================== Helpers ====================

        private static string FormatCurrency(long amount)
        {
            if (amount >= 10000)
            {
                // PCRe: 10000+ shows with unit suffix (e.g., 1万 for JP)
                return amount.ToString("N0");
            }
            return amount.ToString("N0");
        }

        private static string CorrectIllegalCharacters(string input)
        {
            return input;
        }

        private static string ResolveText(eTextId textId)
        {
            return textId.ToString();
        }

        private void ApplyColorGradation(eColorGradation _)
        {
            // TODO: implement color gradation mapping when color data is available
        }

        private void ApplyColor(eColor _)
        {
            // TODO: implement eColor to Color mapping when color data is available
        }
    }
}
