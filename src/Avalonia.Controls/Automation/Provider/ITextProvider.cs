using System;
using System.Collections.Generic;
using Avalonia.Automation.Peers;

namespace Avalonia.Automation.Provider
{
    [Flags]
    public enum SupportedTextSelection
    {
        None,
        Single,
        Multiple,
    }

    public interface ITextProvider
    {
        SupportedTextSelection SupportedTextSelection { get; }

        ITextRangeProvider? DocumentRange { get; }

        IReadOnlyList<AutomationPeer> GetSelection();

        IReadOnlyList<AutomationPeer> GetVisibleRanges();

        ITextRangeProvider? RangeFromChild(AutomationPeer childElement);

        ITextRangeProvider? RangeFromPoint(Point screenLocation);
    }
}
