using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewManager_API.Exception;

namespace ViewManager_API.ViewManager
{
    public abstract class AbstractViewManager
    {
        protected Form contentView;
        protected ControlHolder controlHolder;

        public AbstractViewManager()
        {
            this.controlHolder = new ControlHolder();
        }

        public void Manage()
        {
            this.SetContentView();
            try
            {
                this.controlHolder.Hold(this.contentView.Controls);
                this.InitControls();
            }
            catch (ControlNamingException ex)
            {
                System.Console.WriteLine(ex.ToString());
            }
            /**
             * @HACK
             * not sure about this
             * but this is still the only way i found to keep the form open
             * 
             * */
            Application.Run(contentView);
        }

        protected abstract void SetContentView();

        protected abstract void InitControls();

        public void setContentVisibility(Boolean state)
        {
            this.contentView.Visible = state;
        }

        public Form getContentView()
        {
            return contentView;
        }
    }
}
