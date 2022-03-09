using PET.DataLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PET.FunctionsLayer
{
    public class Function :INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new
                PropertyChangedEventArgs(propName));
            }
        }
        #endregion

        public Data data = new Data();

        #region ObservableCollections
        public ObservableCollection<Persons> PersonsList
        {
            get
            {
                return data.PersonsList;
            }
        }

        public ObservableCollection<Agents> AgentsList
        {
            get
            {
                return data.AgentsList;
            }
        }
        #endregion

        #region People
        public ObservableCollection<Persons> People = new ObservableCollection<Persons>();
        #endregion

        #region Agent
        public void AddAgent(Agents agent)
        {
            try
            {
                data.AddAgent(agent);
                RaisePropertyChanged("AgentsList");
            }
            catch (Exception ex)
            {
                throw new Exception("Function", ex);
            }
        }

        public void EditAgent(Agents agent)
        {
            try
            {
                data.EditAgent(agent);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteAgent(Agents agent)
        {
            try
            {
                if(agent != null)
                {
                    data.DeleteAgent(agent);
                    RaisePropertyChanged("AgentsList");
                }   
            }
            catch (Exception ex)
            {
                throw new Exception("FunctionLayer", ex);
            }
        }
        #endregion

        #region Informant

        #endregion

        #region Observant

        #endregion

        #region Report

        #endregion
    }
}
