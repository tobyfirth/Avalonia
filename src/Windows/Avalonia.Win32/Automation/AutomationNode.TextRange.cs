using System.Linq;
using Avalonia.Automation.Provider;
using Avalonia.Automation.Peers;
using UIA = Avalonia.Win32.Interop.Automation;
using System;
using System.Collections.Generic;

namespace Avalonia.Win32.Automation
{
    internal partial class AutomationNode : UIA.ITextRangeProvider
    {
        void UIA.ITextRangeProvider.AddToSelection()
        {
            InvokeSync<ITextRangeProvider>(x => x.AddToSelection());
        }

        UIA.ITextRangeProvider? UIA.ITextRangeProvider.Clone()
        {
            var peer = InvokeSync<ITextRangeProvider, ITextRangeProvider?>(x => x.Clone());
            return GetOrCreate(peer as AutomationPeer);
        }

        bool UIA.ITextRangeProvider.Compare(UIA.ITextRangeProvider range)
        {
            if (range is not null)
            {
                return InvokeSync<ITextRangeProvider, bool>(x => x.Compare((range as AutomationNode)!.Peer));
            }
            return false;
        }

        int UIA.ITextRangeProvider.CompareEndpoints(UIA.TextPatternRangeEndpoint endpoint, UIA.ITextRangeProvider targetRange, UIA.TextPatternRangeEndpoint targetEndpoint)
        {
            if (targetRange is not null)
            {
                return InvokeSync<ITextRangeProvider, int>(x => x.CompareEndpoints((TextPatternRangeEndpoint)endpoint, (targetRange as AutomationNode)!.Peer, (TextPatternRangeEndpoint)targetEndpoint));
            }
            return 0;
        }

        void UIA.ITextRangeProvider.ExpandToEnclosingUnit(UIA.TextUnit unit)
        {
            InvokeSync<ITextRangeProvider>(x => x.ExpandToEnclosingUnit((TextUnit)unit));
        }

        UIA.ITextRangeProvider? UIA.ITextRangeProvider.FindAttribute(int attribute, object value, bool backward)
        {
            var peer = InvokeSync<ITextRangeProvider, ITextRangeProvider?>(x => x.FindAttribute(attribute, value, backward));
            return GetOrCreate(peer as AutomationPeer);
        }

        UIA.ITextRangeProvider? UIA.ITextRangeProvider.FindText(string text, bool backward, bool ignoreCase)
        {
            var peer = InvokeSync<ITextRangeProvider, ITextRangeProvider?>(x => x.FindText(text, backward, ignoreCase));
            return GetOrCreate(peer as AutomationPeer);
        }

        object? UIA.ITextRangeProvider.GetAttributeValue(int attribute)
        {
            return UIA.UiaCoreTypesApi.UiaGetReservedNotSupportedValue();
        }

        double[] UIA.ITextRangeProvider.GetBoundingRectangles()
        {
            var rectangles = InvokeSync<ITextRangeProvider, IReadOnlyList<double>>(x => x.GetBoundingRectangles());
            return rectangles.ToArray();
        }

        UIA.IRawElementProviderSimple[] UIA.ITextRangeProvider.GetChildren()
        {
            var peers = InvokeSync<ITextRangeProvider, IReadOnlyList<AutomationPeer>>(x => x.GetChildren());
            return peers.Select(x => (UIA.IRawElementProviderSimple)GetOrCreate(x)).ToArray();
        }

        UIA.IRawElementProviderSimple? UIA.ITextRangeProvider.GetEnclosingElement()
        {
            var peer = InvokeSync<ITextRangeProvider, AutomationPeer>(x => x.GetEnclosingElement());
            return GetOrCreate(peer as AutomationPeer);
        }


        string? UIA.ITextRangeProvider.GetText(int maxLength)
        {
            return InvokeSync<ITextRangeProvider, string?>(x => x.GetText(maxLength));
        }

        int UIA.ITextRangeProvider.Move(UIA.TextUnit unit, int count)
        {
            return InvokeSync<ITextRangeProvider, int>(x => x.Move((TextUnit)unit, count));
        }

        void UIA.ITextRangeProvider.MoveEndpointByRange(UIA.TextPatternRangeEndpoint endpoint, UIA.ITextRangeProvider targetRange, UIA.TextPatternRangeEndpoint targetEndpoint)
        {
            if (targetRange is not null)
            {
                InvokeSync<ITextRangeProvider>(x => x.MoveEndpointByRange((TextPatternRangeEndpoint)endpoint, (targetRange as AutomationNode)!.Peer, (TextPatternRangeEndpoint)targetEndpoint));
            }
        }

        int UIA.ITextRangeProvider.MoveEndpointByUnit(UIA.TextPatternRangeEndpoint endpoint, UIA.TextUnit unit, int count)
        {
            return InvokeSync<ITextRangeProvider, int>(x => x.MoveEndpointByUnit((TextPatternRangeEndpoint)endpoint, (TextUnit)unit, count));
        }

        void UIA.ITextRangeProvider.RemoveFromSelection()
        {
            InvokeSync<ITextRangeProvider>(x => x.RemoveFromSelection());
        }

        void UIA.ITextRangeProvider.ScrollIntoView(bool alignToTop)
        {
            InvokeSync<ITextRangeProvider>(x => x.ScrollIntoView(alignToTop));
        }

        void UIA.ITextRangeProvider.Select()
        {
            InvokeSync<ITextRangeProvider>(x => x.Select());
        }
    }
}
