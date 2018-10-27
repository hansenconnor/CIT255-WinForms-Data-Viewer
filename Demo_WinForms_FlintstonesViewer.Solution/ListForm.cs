﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo_WinForms_FlintstonesViewer
{
    public partial class ListForm : Form
    {

        private List<MediumUser> _mediumUsers;

        public ListForm()
        {
            InitializeComponent();
        }


        // NOTE: This method is not used => replaced by APICallAndBindToDataGrid();
        //private void ReadXmlFileAndBindToDataGrid()
        //{

        //    string dataFilePath = AppConfig.dataFilePath; // TODO: Replace this with my client ID and Token

        //    //
        //    // read data file
        //    //
        //    // IDataService dataService = new XmlDataService(dataFilePath); // TODO: Use Json service here 
        //    // _characters = dataService.ReadAll(); // Update data bindings to correctly map the character class
        //                                         // Also, can modify ReadAll to accept an object type
        //                                         // to conditionally handle field mapping.

        //    //
        //    // bind list to DataGridView control asdf
        //    //
        //    var bindingList = new BindingList<Character>(_characters);
        //    var source = new BindingSource(bindingList, null);
        //    dataGridView_Characters.DataSource = source;

        //    //
        //    // configure DataGridView control
        //    //
        //    this.dataGridView_Characters.Columns["Id"].Visible = false;
        //    this.dataGridView_Characters.Columns["ImageFileName"].Visible = false;
        //    this.dataGridView_Characters.Columns["Description"].Visible = false;
        //}



        /// <summary>
        /// Make GET request to API, deserialize response (JSON) then bind response list to DataGridView control
        /// </summary>
        private void APICallAndBindToDataGrid()
        {
            // Get URL for GET request
            string apiGetPath = AppConfig.apiGetUserPath;


            //
            // read data file
            //
            // IDataService dataService = new XmlDataService(dataFilePath); // TODO: Use Json service here 
            IDataService dataService = new JsonDataService(apiGetPath);


            // Set _characters (_users) to a list of users returned from the API call
            // TODO: Replace _characters with _users or _mediumUsers
            _mediumUsers = dataService.ReadAll(); // Update data bindings to correctly map the character class
                                                 // Also, can modify ReadAll to accept an object type
                                                 // to conditionally handle field mapping.

            //
            // bind list to DataGridView control
            //
            var bindingList = new BindingList<MediumUser>(_mediumUsers);
            var source = new BindingSource(bindingList, null);

            // TODO:  Possibly rename control name attribute to mach new Data Access schema
            dataGridView_Characters.DataSource = source;

            //
            // configure DataGridView control
            //
            this.dataGridView_Characters.Columns["Id"].Visible = false;
            this.dataGridView_Characters.Columns["ImageFileName"].Visible = false;
            this.dataGridView_Characters.Columns["Description"].Visible = false;
        }


        // Called on form load => IS ENTRY POINT
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // This is where my API call will go...
                // APICallAndBindToDataGrid();

                // ReadXmlFileAndBindToDataGrid(); => Legacy
                APICallAndBindToDataGrid();
            }
            catch (FileNotFoundException)
            {

                MessageBox.Show("Unable to locate data file.\nExiting the application.");
                this.Close();
            }

        }

        private void btn_CheckList_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView_Characters.SelectedRows)
            {
                dataGridView_Characters.Rows.RemoveAt(row.Index);
            }
        }

        private void btn_DetailView_Click(object sender, EventArgs e)
        {
            if (dataGridView_Characters.SelectedRows.Count == 1)
            {
                Character character = new Character();
                character = (Character)dataGridView_Characters.CurrentRow.DataBoundItem;

                DetailForm detailForm = new DetailForm(character);
                detailForm.ShowDialog();
            }
        }


        //
        // TODO => Enable writing to json?? Can store in mongo for full credit..
        //

        //private void btn_exit_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // TODO: Write to JSON file instead => match format returned by API
        //        IDataService XmlDataService = new XmlDataService(AppConfig.dataFilePath);
        //        XmlDataService.WriteAll(_characters);
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show("Unable to save current data.\nExiting the application.");
        //        throw;
        //    }
        //    this.Close();

        //}
        private void btn_exit_Click(object sender, EventArgs e)
        {
            return;
        }



        //
        // TODO => Enable sorting
        //

        //private void btn_DemoSortFilterSearch_Click(object sender, EventArgs e)
        //{
        //    //
        //    // Note: These examples represent a quick way to "refresh" the DataGridView.
        //    //       Using an ObservableCollection and implementing the INotifyPropertyChanged interface
        //    //       is a stronger pattern.
        //    //

        //    //
        //    // sort list by age and reset the DataSource
        //    // TODO: Update to sort by _mediumUser values
        //    var sortedList = _characters.OrderBy(c => c.Age).ToList();
        //    dataGridView_Characters.DataSource = sortedList;

        //    //
        //    // filter list by gender and reset the DataSource
        //    //
        //    //var filteredList = _characters.Where(c => c.Gender == Character.GenderType.Male).ToList();
        //    //dataGridView_Characters.DataSource = filteredList;

        //    //
        //    // search list and reset the DataSource
        //    // note: searchTerm and LastName are converted to upper case for comparison
        //    //
        //    //string searchTerm = "Rubble";
        //    //var searchedList = _characters.Where(c => c.LastName.ToUpper().Contains(searchTerm.ToUpper())).ToList();
        //    //dataGridView_Characters.DataSource = searchedList;
        //}
        private void btn_DemoSortFilterSearch_Click(object sender, EventArgs e)
        {
            return;
        }


    }
}
