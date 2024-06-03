using System.Linq;
using Avalonia.Automation.Provider;
using Avalonia.Automation.Peers;
using UIA = Avalonia.Win32.Interop.Automation;
using System.Collections.Generic;

namespace Avalonia.Win32.Automation
{
    internal partial class AutomationNode : UIA.ITextProvider
    {
        UIA.ITextRangeProvider? UIA.ITextProvider.DocumentRange
        {
            get
            {
                var peer = InvokeSync<ITextProvider, ITextRangeProvider?>(x => x.DocumentRange);
                return GetOrCreate(peer as AutomationPeer);
            }
        }

        UIA.SupportedTextSelection UIA.ITextProvider.SupportedTextSelection => (UIA.SupportedTextSelection)InvokeSync<ITextProvider, SupportedTextSelection>(x => x.SupportedTextSelection);

        UIA.ITextRangeProvider[] UIA.ITextProvider.GetSelection()
        {
            var peers = InvokeSync<ITextProvider, IReadOnlyList<AutomationPeer>>(x => x.GetSelection());
            return peers.Select(x => (UIA.ITextRangeProvider)GetOrCreate(x)).ToArray();
        }

        UIA.ITextRangeProvider[] UIA.ITextProvider.GetVisibleRanges()
        {
            var peers = InvokeSync<ITextProvider, IReadOnlyList<AutomationPeer>>(x => x.GetVisibleRanges());
            return peers.Select(x => (UIA.ITextRangeProvider)GetOrCreate(x)).ToArray();
        }

        UIA.ITextRangeProvider? UIA.ITextProvider.RangeFromChild(UIA.IRawElementProviderSimple childElement)
        {
            if (childElement is not null)
            {
                var peer = InvokeSync<ITextProvider, ITextRangeProvider?>(x => x.RangeFromChild((childElement as AutomationNode)!.Peer));
                return GetOrCreate(peer as AutomationPeer);
            }
            return null;
        }

        UIA.ITextRangeProvider? UIA.ITextProvider.RangeFromPoint(Point screenLocation)
        {
            var peer = InvokeSync<ITextProvider, ITextRangeProvider?>(x => x.RangeFromPoint(screenLocation));
            return GetOrCreate(peer as AutomationPeer);
        }
    }
}
