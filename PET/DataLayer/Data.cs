using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PET.DataLayer
{
    public class Data
    {
        public PETEksameEntities db = new PETEksameEntities();
        #region ObservableCollections
        public ObservableCollection<Persons> PersonsList
        {
            get
            {
                ObservableCollection<Persons> PersonsQuery = new ObservableCollection<Persons>(db.Persons.SqlQuery("select * from Persons").ToList<Persons>());
                return PersonsQuery;
            }
        }

        public ObservableCollection<Agents> AgentsList
        {
            get
            {
                ObservableCollection<Agents> AgentsQuery = new ObservableCollection<Agents>(db.Agents.SqlQuery("select * from Agents").ToList<Agents>());
                return AgentsQuery;
            }
        }
        #endregion

        #region Agent
        public void AddAgent(Agents agent)
        {
            try
            {
                Persons agentPerson = agent.Persons;
                db.Persons.Add(agentPerson);

                db.Agents.Add(agent);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DataBase", ex);
            }
        }

        public void EditAgent(Agents agent)
        {
            try
            {
                Persons agentPerson = agent.Persons;
            }
            catch(Exception ex)
            {
                throw new Exception("DataBase", ex);
            }
        }

        public void DeleteAgent(Agents agent)
        {
            try
            {
                if (agent != null)
                {
                    // new person 
                    // p => p.Id == agent.PersonsID
                    // Same as a foreach
                    // it is trying to match the person (p) with the specific p.Id
                    Persons person = db.Persons.Single(p => p.Id == agent.PersonsID);

                    // Removes the person from the Person tables
                    db.Persons.Remove(person);

                    // removes the corresponding agent in the Agents table
                    db.Agents.Remove(agent);

                    // Save the changes to the database
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("DataLayer", ex);
            }
        }
        #endregion

        #region Informants
        public void AddInformant(Informants informant)
        {
            try
            {
                Persons informantPerson = informant.Persons;
                db.Persons.Add(informantPerson);

                db.Informants.Add(informant);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("DataBase", ex);
            }
        }

        public void EditInformant(Informants informant)
        {
            try
            {
                Persons informantPerson = informant.Persons;
            }
            catch (Exception ex)
            {
                throw new Exception("DataBase", ex);
            }
        }

        public void DeleteInformant(Informants informant)
        {
            try
            {
                if (informant != null)
                {
                    // new person 
                    // p => p.Id == agent.PersonsID
                    // Same as a foreach
                    // it is trying to match the person (p) with the specific p.Id
                    Persons person = db.Persons.Single(p => p.Id == informant.PersonsID);

                    // Removes the person from the Person tables
                    db.Persons.Remove(person);

                    // removes the corresponding agent in the Agents table
                    db.Informants.Remove(informant);

                    // Save the changes to the database
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("DataLayer", ex);
            }
        }
        #endregion
    }
}
