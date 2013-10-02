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
     * Class for handling Form components/controls
     * 
     * @author Grigorios
     **/
    public class ControlHolder
    {
        private Dictionary<String, Control> controlDictionary;

        /**
         * constructor of class  
         **/
        public ControlHolder()
        {
            this.controlDictionary = new Dictionary<String, Control>();
        }


        /**
          * Through this method the encapsulated components of the form, became
          * reachable for referencing by their names
          */
        public void Hold(Control.ControlCollection controlCollection)
        {
            foreach (Control control in controlCollection)
            {
                if(control.HasChildren)
                {
                    Hold(control.Controls);
                }
                MapControl(control);
            }
        }

        /**
         * This method checks the control name availability. If the control has appropriate
         * name, it is added to control dictionary else an exception error will be throwed.
         * 
         * @param control - the component to be maped in dictionary
         * 
         **/
        private void MapControl(Control control)
        {
            String controlName = control.Name;
            if(String.IsNullOrEmpty(controlName))
            {
                throw new ControlNamingException("Control with no name");
            }
            else if(controlDictionary.ContainsKey(controlName))
            {
                throw new ControlNamingException("Can't hold second component with same name!");
            }
            else
            {
                controlDictionary.Add(controlName, control);
            }
        }

        /**
          *
          * @param controlName - a string refers to name of a component from
          * content form.
          * @return the component which name matches the given parameter.
          * @throws ControlNamingException: if none of the form components has name like the
          * given parameter
          */
        public Control GetControlByName(String controlName)
        {
            if (controlDictionary.ContainsKey(controlName))
            {
                return controlDictionary[controlName];
            }
            else
            {
                throw new ControlNamingException("Can not found control with that given name!!!");
            }
        }

    }
}
