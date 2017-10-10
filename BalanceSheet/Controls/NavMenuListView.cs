using System;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace BalanceSheet.Controls
{
    /// <summary>
    /// ListView to represent in the Navigation menu.
    /// </summary>
    public class NavMenuListView: ListView
    {
        private SplitView splitView;

        public NavMenuListView()
        {
            SelectionMode = ListViewSelectionMode.Single;
            IsItemClickEnabled = true;
            ItemClick += ItemClickHandler;

            Loaded += (a, b) =>
            {
                var p = VisualTreeHelper.GetParent(this);
                while (p != null && !(p is SplitView))
                {
                    p = VisualTreeHelper.GetParent(p);
                }
                if (p != null)
                {
                    splitView = p as SplitView;
                    splitView.RegisterPropertyChangedCallback(SplitView.IsPaneOpenProperty,
                        (sender, args) => { OnPaneToggled(); });
                    OnPaneToggled();
                }
            };
        }

        private void ItemClickHandler(object sender, ItemClickEventArgs e)
        {
            //Models.HomeWithDaten datum = new Models.HomeWithDaten(0, 0);
            var item = ContainerFromItem(e.ClickedItem);
            InvokeItem(item);
        }

        public event EventHandler<ListViewItem> ItemInvoked;
        private void InvokeItem(object item)
        {
            SetSelectedItem(item as ListViewItem);
            ItemInvoked?.Invoke(this, item as ListViewItem);

            if (splitView.IsPaneOpen && (splitView.DisplayMode == SplitViewDisplayMode.CompactOverlay ||
                splitView.DisplayMode == SplitViewDisplayMode.Overlay))
            {
                splitView.IsPaneOpen = false;
                if (item is ListViewItem)
                {
                    ((ListViewItem)item).Focus(FocusState.Programmatic);
                }
            }
        }

        public void SetSelectedItem(ListViewItem listViewItem)
        {
            var index = -1;
            if (listViewItem != null)
            {
                index = IndexFromContainer(listViewItem);
            }

            for (int i = 0; i < Items.Count; i++)
            {
                var listItem = (ListViewItem)ContainerFromIndex(i);
                if (listItem != null)
                {
                    if (i != index)
                    {
                        listItem.IsSelected = false;
                    }
                    else if (i == index)
                    {
                        listItem.IsSelected = true;
                    }
                }
            }
        }

        /// <summary>
        /// Re-size the ListView's Panel when the SplitView is compact so the items
        /// will fit within the visible space and correctly display a keyboard focus rect.
        /// </summary>
        private void OnPaneToggled()
        {
            if (splitView.IsPaneOpen)
            {
                ItemsPanelRoot.ClearValue(WidthProperty);
                ItemsPanelRoot.ClearValue(HorizontalAlignmentProperty);
            }
            else if (splitView.DisplayMode == SplitViewDisplayMode.CompactInline || splitView.DisplayMode == SplitViewDisplayMode.CompactOverlay)
            {
                ItemsPanelRoot.SetValue(WidthProperty, splitView.CompactPaneLength);
                ItemsPanelRoot.SetValue(HorizontalAlignmentProperty, HorizontalAlignment.Left);
            }
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            for (int i = 0; i < ItemContainerTransitions.Count; i++)
            {
                if (ItemContainerTransitions[i] is EntranceThemeTransition)
                {
                    ItemContainerTransitions.RemoveAt(i);
                }
            }
        }

        protected override void OnKeyDown(KeyRoutedEventArgs e)
        {
            var focusItem = FocusManager.GetFocusedElement();

            switch (e.Key)
            {
                case VirtualKey.Up:
                    TryMoveFocus(FocusNavigationDirection.Up);
                    e.Handled = true;
                    break;

                case VirtualKey.Down:
                    TryMoveFocus(FocusNavigationDirection.Down);
                    e.Handled = true;
                    break;

                case VirtualKey.Tab:
                    var shiftKeyState = CoreWindow.GetForCurrentThread().GetKeyState(VirtualKey.Shift);
                    var shiftKeyDown = (shiftKeyState & CoreVirtualKeyStates.Down) == CoreVirtualKeyStates.Down;
                    if (focusItem is ListViewItem)
                    {
                        var currentItem = (ListViewItem)focusItem;
                        var onlastitem = currentItem != null && IndexFromContainer(currentItem) == Items.Count - 1;
                        var onfirstitem = currentItem != null && IndexFromContainer(currentItem) == 0;

                        if (!shiftKeyDown)
                        {
                            if (onlastitem)
                            {
                                TryMoveFocus(FocusNavigationDirection.Next);
                            }
                            else
                            {
                                TryMoveFocus(FocusNavigationDirection.Down);
                            }
                        }
                        else
                        {
                            if (onfirstitem)
                            {
                                TryMoveFocus(FocusNavigationDirection.Previous);
                            }
                            else
                            {
                                TryMoveFocus(FocusNavigationDirection.Up);
                            }
                        }
                    }
                    else if (focusItem is Control)
                    {
                        if (!shiftKeyDown)
                        {
                            TryMoveFocus(FocusNavigationDirection.Down);
                        }
                        else
                        {
                            TryMoveFocus(FocusNavigationDirection.Up);
                        }
                    }
                    e.Handled = true;
                    break;

                case VirtualKey.Enter:
                case VirtualKey.Space:
                    InvokeItem(focusItem);
                    e.Handled = true;
                    break;

                default:
                    base.OnKeyDown(e);
                    break;
            }
        }

        private void TryMoveFocus(FocusNavigationDirection direction)
        {
            if (direction == FocusNavigationDirection.Next || direction == FocusNavigationDirection.Previous)
            {
                FocusManager.TryMoveFocus(direction);
            }
            else
            {
                var control = FocusManager.FindNextFocusableElement(direction) as Control;
                control?.Focus(FocusState.Programmatic);
            }
        }
    }
}