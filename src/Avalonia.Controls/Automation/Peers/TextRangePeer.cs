using System;
using System.Collections.Generic;
using Avalonia.Automation.Provider;

namespace Avalonia.Automation.Peers
{
    public class TextRangePeer : NoneAutomationPeer, ITextRangeProvider
    {
        private readonly TextBoxAutomationPeer _parent;

        private int _start;
        private int _end;

        public TextRangePeer(TextBoxAutomationPeer parent) : base(parent.Owner)
        {
            _parent = parent;
            _start = 0;
            _end = _parent.Owner.Text?.Length ?? 0;
        }

        public TextRangePeer(TextBoxAutomationPeer parent, int start, int end) : base(parent.Owner)
        {
            _parent = parent;
            _start = start;
            _end = end;
        }

        public void AddToSelection()
        {
            
        }

        public ITextRangeProvider Clone()
        {
            return new TextRangePeer(_parent, _start, _end);
        }

        public bool Compare(AutomationPeer range)
        {
            if (range is TextRangePeer rangeProvider)
            {
                return rangeProvider._start == _start && rangeProvider._end == _end;
            }
            return false;
        }

        public int CompareEndpoints(TextPatternRangeEndpoint endpoint, AutomationPeer targetRange, TextPatternRangeEndpoint targetEndpoint)
        {
            if (targetRange is TextRangePeer rangeProvider)
            {
                var pos = endpoint == TextPatternRangeEndpoint.Start ? _start : _end;
                var targetPos = targetEndpoint == TextPatternRangeEndpoint.Start ? rangeProvider._start : rangeProvider._end;

                if (pos < targetPos)
                {
                    return -1;
                }
                if (pos == targetPos)
                {
                    return 0;
                }
                return 1;
            }
            return 0;
        }

        public void ExpandToEnclosingUnit(TextUnit unit)
        {
            switch (unit)
            {
                case TextUnit.Character:
                    break;
                case TextUnit.Format:
                    break;
                case TextUnit.Word:
                    break;
                case TextUnit.Line:
                    break;
                case TextUnit.Paragraph:
                case TextUnit.Page:
                case TextUnit.Document:
                    _start = 0;
                    _end = _parent.Owner.Text?.Length ?? 0;
                    break;
                default:
                    break;
            }
        }

        public ITextRangeProvider FindAttribute(int attribute, object value, bool backward)
        {
            return this;
        }

        public ITextRangeProvider? FindText(string text, bool backward, bool ignoreCase)
        {
            if (_parent.Owner.Text is null)
            {
                return null;
            }

            if (backward)
            {
                var searchedText = _parent.Owner.Text.Substring(0, Math.Max(_start, _parent.Owner.Text.Length));
                var index = searchedText.LastIndexOf(text, ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);
                return index == -1 ? null : new TextRangePeer(_parent, index, text.Length);
            }
            else
            {
                var searchedText = _parent.Owner.Text.Substring(Math.Max(0, Math.Min(_start, _parent.Owner.Text.Length)));
                var index = searchedText.IndexOf(text, ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);
                return index == -1 ? null : new TextRangePeer(_parent, index, text.Length);
            }
        }

        public object? GetAttributeValue(int attribute)
        {
            // Not called
            return this;
        }

        public IReadOnlyList<double> GetBoundingRectangles()
        {
            return Array.Empty<double>();
        }

        public AutomationPeer GetEnclosingElement()
        {
            return _parent;
        }

        public string? GetText(int maxLength)
        {
            if (_parent.Owner.Text is null)
            {
                return null;
            }
            var realStart = Math.Max(0, _start);
            var text = _parent.Owner.Text.Substring(realStart, Math.Max(0, _parent.Owner.Text.Length - realStart));
            return (maxLength < 0 || text.Length < maxLength) ? text : text.Substring(0, maxLength);
        }

        public int Move(TextUnit unit, int count)
        {
            return 0;
        }

        public void MoveEndpointByRange(TextPatternRangeEndpoint endpoint, AutomationPeer targetRange, TextPatternRangeEndpoint targetEndpoint)
        {
            
        }

        public int MoveEndpointByUnit(TextPatternRangeEndpoint endpoint, TextUnit unit, int count)
        {
            return 0;
        }

        public void RemoveFromSelection()
        {
            
        }

        public void ScrollIntoView(bool alignToTop)
        {
            
        }

        public void Select()
        {
            _parent.Owner.SelectionStart = Math.Max(0, Math.Min(_parent.Owner.Text?.Length ?? 0, _start));
            _parent.Owner.SelectionEnd = Math.Max(0, Math.Min(_parent.Owner.Text?.Length ?? 0 - _parent.Owner.SelectionStart, _end - _start));
        }
    }
}
