using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewManager_API.Exception;

namespace ViewManager_API.ViewManager
{
    /**
      * This abstract class is a blueprint for the actual AbstractViewManager. It also runs
      * all the needed methods to reference a frame with the actual view manager.
      *
      * @author Grigorios
      */
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
             **/
            Application.Run(contentView);
        }

        /**
          * Reference the given as parameter form with the view manager in order to
          * reach it's components.
          * @param contentView - an instance of JFrame class. A typical form.
          */
        protected abstract void SetContentView();

        /**
          * No need to call this method it is called by superclass. Initialize and
          * reference all declared components here
          */
        protected abstract void InitControls();
         
       /**
         * When it's called returns the Form that
         * is managed by the viewManager for further
         * direct changes on form's state
         */
        public Form getContentView()
        {
            return contentView;
        }
    }
}
