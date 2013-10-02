using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewManager_API.Exception;

namespace ViewManager_API.ViewManager
{
    public class ControlHolder
    {
        private Dictionary<String, Control> controlDictionary;

        public ControlHolder()
        {
            this.controlDictionary = new Dictionary<String, Control>();
        }


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
