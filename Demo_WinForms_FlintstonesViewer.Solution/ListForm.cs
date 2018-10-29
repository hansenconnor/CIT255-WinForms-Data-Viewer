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

        private List<MediumPublication> _mediumUsers;

        public ListForm()
        {
            InitializeComponent();
        }



        // Called on form load => IS ENTRY POINT
        private void Form1_Load(object sender, EventArgs e)
        {
            APICallAndBindToDataGrid();
        }



        /// <summary>
        /// Make GET request to API, deserialize response (JSON) then bind response list to DataGridView control
        /// </summary>
        private void APICallAndBindToDataGrid()
        {
            // Get URL for GET request
            string apiGetPath = AppConfig.apiGetUserPath;


            //
            // Create new json data service and pass the base url for API requests
            //
            // IDataService dataService = new XmlDataService(dataFilePath); // TODO: Use Json service here 
            IDataService dataService = new JsonDataService(apiGetPath);


            // GET request to the user endpoint => format JSON response => return as MediumUser List
            // Set _characters (_users) to a list of users returned from the API call
            // TODO: Replace _characters with _users or _mediumUsers

            _mediumUsers = dataService.ReadAll(); // Update data bindings to correctly map the character class
                                                 // Also, can modify ReadAll to accept an object type
                                                 // to conditionally handle field mapping.

            //
            // bind list to DataGridView control
            //
            var bindingList = new BindingList<MediumPublication>(_mediumUsers);
            var source = new BindingSource(bindingList, null);

            // TODO:  Possibly rename control name attribute to mach new Data Access schema
            dataGridView_Characters.DataSource = source;

            //
            // configure DataGridView control
            //
            this.dataGridView_Characters.Columns["Id"].Visible = true;
            this.dataGridView_Characters.Columns["name"].Visible = true;
            this.dataGridView_Characters.Columns["description"].Visible = false;
            this.dataGridView_Characters.Columns["url"].Visible = false;
            this.dataGridView_Characters.Columns["imageUrl"].Visible = false;
            //this.dataGridView_Characters.Columns["url"].Visible = false;
            //this.dataGridView_Characters.Columns["imageUrl"].Visible = false;
        }



        //
        // Display publication details on click
        //
        private void btn_DetailView_Click(object sender, EventArgs e)
        {
            if (dataGridView_Characters.SelectedRows.Count == 1)
            {
                MediumPublication publication = new MediumPublication();
                publication = (MediumPublication)dataGridView_Characters.CurrentRow.DataBoundItem;

                DetailForm detailForm = new DetailForm(publication);
                detailForm.ShowDialog();
            }
        }

        //
        // Handle list filtering on button click
        //
        private void buttonFilterName_Click(object sender, EventArgs e)
        {
            // Filter is static => should be dynamic in future version.
            var filteredList = _mediumUsers.Where(p => p.name == "NMC CIT 255").ToList();
            dataGridView_Characters.DataSource = filteredList;
        }

        //
        // Handle list sorting on button click
        //
        private void buttonSortByName_Click(object sender, EventArgs e)
        {
            // Sort is static => Users should choose which parameter they wish to sort on
            var sortedList = _mediumUsers.OrderBy(p => p.name).ToList();
            dataGridView_Characters.DataSource = sortedList;
        }

        //
        // Handle search on button click
        //
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            // Get the search query
            var searchQuery = textBoxSearch.Text;
            
            // Check if empty
            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                MessageBox.Show("Please enter a valid query...");
                return;
            }

            // 
            var searchedList = _mediumUsers.Where(p => p.name.ToUpper().Contains(searchQuery.ToUpper())).ToList();
            dataGridView_Characters.DataSource = searchedList;
        }


        //
        // Display help dialog
        //
        private void buttonHelp_Click(object sender, EventArgs e)
        {
            Form helpForm = new HelpForm();
            helpForm.ShowDialog();
        }
































        private void btn_CheckList_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView_Characters.SelectedRows)
            {
                dataGridView_Characters.Rows.RemoveAt(row.Index);
            }
        }





        //private void btn_DetailView_Click(object sender, EventArgs e)
        //{
        //    if (dataGridView_Characters.SelectedRows.Count == 1)
        //    {
        //        Character character = new Character();
        //        character = (Character)dataGridView_Characters.CurrentRow.DataBoundItem;

        //        DetailForm detailForm = new DetailForm(character);
        //        detailForm.ShowDialog();
        //    }
        //}


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
            Application.Exit();
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


        //
        // Handle filtering
        //
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {

            //var bindingList = new BindingList<MediumPublication>(_mediumUsers);
            //var source = new BindingSource(bindingList, null);

            //// TODO:  Possibly rename control name attribute to mach new Data Access schema
            //dataGridView_Characters.DataSource = source;

            ////
            //// configure DataGridView control
            ////
            //this.dataGridView_Characters.Columns["Id"].Visible = false;
            //this.dataGridView_Characters.Columns["name"].Visible = false;
            //this.dataGridView_Characters.Columns["description"].Visible = false;
            //DataTable dt = new DataTable();
            //sda.Fill(dt);
            //dataGridView1.DataSource = dt;
        }


        








        //private void btn_DemoSortFilterSearch_Click(object sender, EventArgs e)
        //{

        //    //
        //    // Note: These examples represent a quick way to "refresh" the DataGridView.
        //    //       Using an ObservableCollection and implementing the INotifyPropertyChanged interface
        //    //       is a stronger pattern.
        //    //

        //    //
        //    // sort list by age and reset the DataSource
        //    //
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



        //public void btnSearch_Click(object sender, EventArgs e)
        //{
        //    BindingSource bs = new BindingSource();
        //    bs.DataSource = dataGridView1.DataSource;
        //    bs.Filter = dataGridView1.Columns[5].HeaderText.ToString() + " LIKE '%" + txtbxSearch.Text + "%'";
        //    dataGridView1.DataSource = bs;
        //}


    }
}
