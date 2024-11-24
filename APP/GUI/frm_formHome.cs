using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_formHome : Form
    {
        public frm_formHome()
        {
            InitializeComponent();
            this.Load += Frm_formHome_Load;
        }

        private void Frm_formHome_Load(object sender, EventArgs e)
        {
            pic_1.Click += Pic_1_Click;
            pic_2.Click += Pic_2_Click;
            pic_3.Click += Pic_3_Click;
            pic_4.Click += Pic_4_Click;
            pic_5.Click += Pic_5_Click;
            pic_6.Click += Pic_6_Click;
            SetPanelBackgroundImageFromResources(pn_home, Properties.Resources.bg1);
        }

        private void Pic_6_Click(object sender, EventArgs e)
        {
            SetPanelBackgroundImageFromResources(pn_home, Properties.Resources.bg6);
        }

        private void Pic_5_Click(object sender, EventArgs e)
        {
            SetPanelBackgroundImageFromResources(pn_home, Properties.Resources.bg4);
        }

        private void Pic_4_Click(object sender, EventArgs e)
        {
            SetPanelBackgroundImageFromResources(pn_home, Properties.Resources.bg4);
        }

        private void Pic_3_Click(object sender, EventArgs e)
        {
            SetPanelBackgroundImageFromResources(pn_home, Properties.Resources.bg3);
        }

        private void Pic_2_Click(object sender, EventArgs e)
        {
            SetPanelBackgroundImageFromResources(pn_home, Properties.Resources.bg2);
        }

        private void Pic_1_Click(object sender, EventArgs e)
        {
            SetPanelBackgroundImageFromResources(pn_home, Properties.Resources.bg1);
        }
        // viết hàm 
        public static void SetPanelBackgroundImageFromResources(Panel panel, Bitmap image)
        {
            if (panel == null)
            {
                MessageBox.Show("Panel không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (image == null)
            {
                MessageBox.Show("Hình ảnh từ Resources không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            panel.BackgroundImage = image;
            panel.BackgroundImageLayout = ImageLayout.Stretch; // Tùy chỉnh chế độ hiển thị
        }
    }
}
