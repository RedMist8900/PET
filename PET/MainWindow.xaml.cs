using PET.FunctionsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PET
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Function func = new Function();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = func;
        }

        private void btAddAgent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Creating a notionality first to tie with the person
                //Nationalities agentNationality = new Nationalities
                //{
                //    // Converting the TextBoxes string input to Integers
                //    CountryCode = Convert.ToInt32(tbAgentCountryCode.Text),
                //    CprNr = Convert.ToInt32(tbAgentCprNr.Text),
                //    ZipCode = Convert.ToInt32(tbAgentZipCode.Text),
                //    StreetAdress = tbAgentStreetAdress.Text
                //};

                // Creating the person with the nationality tied
                Persons agentPerson = new Persons
                {
                    FirstName = tbAgentFirstName.Text,
                    LastName = tbAgentLastName.Text,
                    Height = Convert.ToDouble(tbAgentHeight.Text),
                    EyeColor = tbAgentEyeColor.Text,
                    HairColor = tbAgentHairColor.Text,
                    Nationalities = new Nationalities
                    {
                        // Converting the TextBoxes string input to Integers
                        CountryCode = Convert.ToInt32(tbAgentCountryCode.Text),
                        CprNr = Convert.ToInt32(tbAgentCprNr.Text),
                        ZipCode = Convert.ToInt32(tbAgentZipCode.Text),
                        StreetAdress = tbAgentStreetAdress.Text
                    }
                };

                Agents agent = new Agents
                {
                    Persons = agentPerson
                };
                func.AddAgent(agent);
            }
            catch (Exception ex)
            {
                // throws a custom error message along with the execption message
                // ex first to get full message
                MessageBox.Show(ex.Message, "Failed to Add Agent");
            }
        }

        private void btEditAgent_Click(object sender, RoutedEventArgs e)
        {
            Agents agent = dgAgents.SelectedItem as Agents;
            try
            {
                
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btDeleteAgent_Click(object sender, RoutedEventArgs e)
        {
            func.DeleteAgent(dgAgents.SelectedItem as Agents);
        }

        private void dgAgents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(e.AddedItems.Count > 0)
            {
                Persons agentPersons = (e.AddedItems[0] as Persons);
                //Persons agentPerson = agent.Persons;
                //Nationalities personNationality = agentPerson.Nationalities;
                tbAgentFirstName.Text = agentPersons.FirstName;
                tbAgentLastName.Text = agentPersons.LastName;
                tbAgentHeight.Text = Convert.ToString(agentPersons.Height);
                tbAgentEyeColor.Text = agentPersons.EyeColor;
                tbAgentHairColor.Text = agentPersons.HairColor;

                //tbAgentCountryCode.Text = Convert.ToString(personNationality.CountryCode);
                //tbAgentCprNr.Text = Convert.ToString(personNationality.CprNr);
                //tbAgentZipCode.Text = Convert.ToString(personNationality.ZipCode);
                //tbAgentStreetAdress.Text = personNationality.StreetAdress;
            }
            else
            {
                tbAgentFirstName.Text = "";
                tbAgentLastName.Text = "";
                tbAgentHeight.Text = "";
                tbAgentEyeColor.Text = "";
                tbAgentHairColor.Text = "";

                //tbAgentCountryCode.Text = "";
                //tbAgentCprNr.Text = "";
                //tbAgentZipCode.Text = "";
                //tbAgentStreetAdress.Text = "";
            }
        }
    }
}
