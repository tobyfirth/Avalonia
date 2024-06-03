using System;
using System.Collections.Generic;
using Avalonia.Automation.Provider;
using Avalonia.Controls;

namespace Avalonia.Automation.Peers
{
    public class TextBoxAutomationPeer : ControlAutomationPeer, IValueProvider, ITextProvider
    {
        public TextBoxAutomationPeer(TextBox owner)
            : base(owner)
        {
        }

        public new TextBox Owner => (TextBox)base.Owner;
        public bool IsReadOnly => Owner.IsReadOnly;
        public string? Value => Owner.Text;

        public void SetValue(string? value) => Owner.Text = value;

        protected override AutomationControlType GetAutomationControlTypeCore()
        {
            return AutomationControlType.Edit;
        }

        public SupportedTextSelection SupportedTextSelection => SupportedTextSelection.Single;

        public ITextRangeProvider DocumentRange => new TextRangePeer(this);

        public IReadOnlyList<AutomationPeer> GetSelection()
        {
            return Array.Empty<AutomationPeer>();
        }

        public IReadOnlyList<AutomationPeer> GetVisibleRanges()
        {
            return new AutomationPeer[1] { new TextRangePeer(this) };
        }

        public ITextRangeProvider RangeFromChild(AutomationPeer childElement)
        {
            return new TextRangePeer(this);
        }

        public ITextRangeProvider RangeFromPoint(Point screenLocation)
        {
            //var point = Owner.PointToClient(new PixelPoint((int)screenLocation.X, (int)screenLocation.Y));
            return new TextRangePeer(this);
        }

        
    }
}
