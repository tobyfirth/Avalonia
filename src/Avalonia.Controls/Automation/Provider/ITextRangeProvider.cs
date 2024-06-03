using System.Collections.Generic;
using Avalonia.Automation.Peers;

namespace Avalonia.Automation.Provider
{
    public enum TextPatternRangeEndpoint
    {
        Start = 0,
        End = 1,
    }

    public enum TextUnit
    {
        Character = 0,
        Format = 1,
        Word = 2,
        Line = 3,
        Paragraph = 4,
        Page = 5,
        Document = 6,
    }

    public interface ITextRangeProvider
    {
        ITextRangeProvider? Clone();
        bool Compare(AutomationPeer range);
        int CompareEndpoints(TextPatternRangeEndpoint endpoint, AutomationPeer targetRange, TextPatternRangeEndpoint targetEndpoint);
        void ExpandToEnclosingUnit(TextUnit unit);
        ITextRangeProvider? FindAttribute(int attribute, object value, bool backward);
        ITextRangeProvider? FindText(string text, bool backward, bool ignoreCase);
        object? GetAttributeValue(int attribute);
        IReadOnlyList<double> GetBoundingRectangles();
        AutomationPeer GetEnclosingElement();
        string? GetText(int maxLength);
        int Move(TextUnit unit, int count);
        int MoveEndpointByUnit(TextPatternRangeEndpoint endpoint, TextUnit unit, int count);
        void MoveEndpointByRange(TextPatternRangeEndpoint endpoint, AutomationPeer targetRange, TextPatternRangeEndpoint targetEndpoint);
        void Select();
        void AddToSelection();
        void RemoveFromSelection();
        void ScrollIntoView(bool alignToTop);
        IReadOnlyList<AutomationPeer> GetChildren();
    }
}
