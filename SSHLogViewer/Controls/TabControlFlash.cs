using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSHLogViewer.Controls {
    class TabControlFlash : TabControl {
        public TabControlFlash() : base() {
            //this.DrawMode = TabDrawMode.OwnerDrawFixed;
            //this.DrawItem += TabControlFlash_DrawItem;
        }

        private void TabControlFlash_DrawItem(object sender, DrawItemEventArgs e) {
            e.Graphics.FillRectangle(new SolidBrush(this.BackColor), e.Bounds);
            Rectangle paddedBounds = e.Bounds;
            paddedBounds.Inflate(-2, -2);
            e.Graphics.DrawString(this.TabPages[e.Index].Text, this.Font, SystemBrushes.HighlightText, paddedBounds);
        }
    }
}
