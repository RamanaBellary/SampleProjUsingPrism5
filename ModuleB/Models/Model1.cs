using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ModuleB.Models
{
    public class Model1 : BindableBase, INotifyDataErrorInfo
    {
        private string prop1;

        public string Prop1
        {
            get { return prop1; }
            set
            {
                SetProperty<string>(ref prop1, value);
                if (string.IsNullOrWhiteSpace(value))
                {
                    AddError("Prop1 is required");
                }
            }
        }

        Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();
        private bool isValid;
        public bool IsValid
        {
            get { return isValid; }
            set { SetProperty<bool>(ref isValid, value); }

        }

        public bool HasErrors
        {
            get
            {
                return _errors.Any(l => l.Value != null && l.Value.Count > 0);
            }
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            return _errors.Where(l => l.Key == propertyName).Select(l => l.Value);
        }

        public void AddError(string error, [CallerMemberName] string propertyName = null)
        {
            // Add error to list
            if (this._errors.ContainsKey(propertyName))
            {
                var lst = this._errors[propertyName];
                if (lst == null)
                    this._errors[propertyName] = new List<string>() { error };
                else
                    this._errors[propertyName].Add(error);
            }
            else
                this._errors[propertyName] = new List<string>() { error };

            IsValid = !this.HasErrors;
            //this.NotifyErrorsChanged(propertyName);
        }

        public void RemoveError([CallerMemberName] string propertyName = null)
        {
            // remove error
            if (this._errors.ContainsKey(propertyName))
                this._errors.Remove(propertyName);
            IsValid = !this.HasErrors;
            //this.NotifyErrorsChanged(propertyName);
        }
    }
}
