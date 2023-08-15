using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TestProject1 {
    public class ItemsControl : ScrollableControl {
        public List<Item> Items { get; set; }
        ItemsControlInfo ViewInfo { get; }

        public ItemsControl() {
            Items = new List<Item>();
            ViewInfo = new ItemsControlInfo(this);
            AutoScroll = true;
        }

        protected override void OnResize(EventArgs e) {
            base.OnResize(e);
            ViewInfo.Update();
            Invalidate();
        }
        protected override void OnScroll(ScrollEventArgs se) {
            base.OnScroll(se);
            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            ViewInfo.Draw(e, ClientRectangle, AutoScrollPosition.Y);
        }
    }

    public class Item {
        public Color Color { get; set; }
        public Size Size { get; set; }
    }


    public class ItemsControlInfo {
        protected ItemsControl Control { get; }
        public List<ItemInfo> ItemInfoList { get; }

        public ItemsControlInfo(ItemsControl control) {
            Control = control;
            ItemInfoList = new List<ItemInfo>();
        }

        public void Update() {
            ItemInfoList.Clear();
            int y = CalcLayout(Control.ClientRectangle);
            Control.AutoScrollMinSize = new Size(0, y);
        }

        protected virtual int CalcLayout(Rectangle bounds) {
            int y = 0;
            foreach(var item in Control.Items) {
                var size = item.Size;
                var pt = new Point(0, y);
                var itemInfo = new ItemInfo(item, new Rectangle(pt, size));
                ItemInfoList.Add(itemInfo);
                y += size.Width;
            }
            return y;
        }

        public void Draw(PaintEventArgs e, Rectangle drawBounds, int scrollOffset) {
            foreach(var itemInfo in ItemInfoList) {
                itemInfo.Draw(e, scrollOffset);
            }
        }
    }

    public class ItemInfo {
        public Rectangle Bounds { get; }
        public Item Item { get; }

        public ItemInfo(Item item, Rectangle bounds) {
            Bounds = bounds;
            Item = item;
        }

        public void Draw(PaintEventArgs e, int scrollOffset) {
            var rect = Bounds;
            rect.Offset(0, scrollOffset);

            var brush = new SolidBrush(Item.Color);
            e.Graphics.FillRectangle(brush, rect);
            e.Graphics.DrawRectangle(Pens.Gray, rect);

            var textBrush = new SolidBrush(Color.Black);
            e.Graphics.DrawString(Item.Size.ToString(), Control.DefaultFont, textBrush, rect);
        }
    }
}
