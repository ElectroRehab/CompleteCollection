using System;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Finance_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void CreateButton_Click(object sender, EventArgs e)
        {
            string sqlStmt;
            string conString;
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                // Setup user with new People Fields in Database
                sqlStmt = "insert into People(First,Last,Email,Address1,Address2,City,State,Zip) Values(@firstName,@lastName,@email,@address1,@address2,@city,@state,@zip)";
                conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\01ele\source\repos\Finance\Finance_App\Finance_App\Database1.mdf;Integrated Security=True";
                cn = new SqlConnection(conString);
                cmd = new SqlCommand(sqlStmt, cn);
                // Determine what field parameters are
                cmd.Parameters.Add(new SqlParameter("@firstName", SqlDbType.Char, 30));
                cmd.Parameters.Add(new SqlParameter("@lastName", SqlDbType.Char, 30));
                cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.Char, 50));
                cmd.Parameters.Add(new SqlParameter("@address1", SqlDbType.Char, 50));
                cmd.Parameters.Add(new SqlParameter("@address2", SqlDbType.Char, 50));
                cmd.Parameters.Add(new SqlParameter("@city", SqlDbType.Char, 50));
                cmd.Parameters.Add(new SqlParameter("@state", SqlDbType.Char, 2));
                cmd.Parameters.Add(new SqlParameter("@zip", SqlDbType.Char, 10));
                // Set user inputted values within the database
                cmd.Parameters["@firstname"].Value = textBox11.Text.Trim();
                cmd.Parameters["@lastname"].Value = textBox12.Text.Trim();
                cmd.Parameters["@email"].Value = textBox13.Text.Trim();
                cmd.Parameters["@address1"].Value = textBox14.Text.Trim();
                cmd.Parameters["@address2"].Value = textBox15.Text.Trim();
                cmd.Parameters["@city"].Value = textBox16.Text.Trim();
                cmd.Parameters["@state"].Value = stateBox1.Text.Trim();
                cmd.Parameters["@zip"].Value = textBox17.Text.Trim();
                // Open Database
                cn.Open();
                if (textBox13.Text.Contains("@"))
                {
                    // Run SQL Statement
                    cmd.ExecuteNonQuery();
                    // Close Database
                    cn.Close();
                }
                else {
                    // Close Database
                    cn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (textBox13.Text.Contains("@"))
            {
                try
                {
                    // Setup user with new Money Fields in Database
                    sqlStmt = "INSERT INTO Money(Donation,Savings,GOKF,Spending) Values(@donate,@save,@gokf,@spend)";
                    conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\01ele\source\repos\Finance\Finance_App\Finance_App\Database1.mdf;Integrated Security=True";
                    cn = new SqlConnection(conString);
                    cmd = new SqlCommand(sqlStmt, cn);
                    // Determine what field parameters are
                    cmd.Parameters.Add(new SqlParameter("@donate", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@save", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@gokf", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@spend", SqlDbType.Float, 53));
                    // Set 0 for the values within the database
                    cmd.Parameters["@donate"].Value = "0.00";
                    cmd.Parameters["@save"].Value = "0.00";
                    cmd.Parameters["@gokf"].Value = "0.00";
                    cmd.Parameters["@spend"].Value = "0.00";
                    // Open Database
                    cn.Open();
                    // Run SQL Statement
                    cmd.ExecuteNonQuery();
                    // Close Database
                    cn.Close();
                    MessageBox.Show("User Account Created");

                }
                catch
                {
                    MessageBox.Show("No Money Input");
                }
            }
            else {
                MessageBox.Show("        Invalid Email Address, \n                 Try Again.");
            }

        }
        private void Button1_Click(object sender, EventArgs e)
        {
            double input = 0;
            // Check if user is selected prior to calculations
            if (textBox6.Text != "")
            {
                // Initial Input Calculations
                try
                {
                    input = double.Parse(textBox1.Text);
                }
                catch 
                {
                    MessageBox.Show("Please Enter Only Numbers");
                }
                // Check to see if user's input is not a negative
                if (input < 0)
                {
                    MessageBox.Show("Income must be a positive number");
                }
                else
                {
                    // Check to see if God Only Knows Fund has reached or will reach $3000
                    double checkAmount = double.Parse(textBox9.Text);
                    double preCheck = double.Parse(textBox9.Text) + (input * 0.25);
                    // Calculate Remaining Sections
                    textBox2.Text = Decimal.Round((decimal)(input * 0.10), 2).ToString();
                    textBox3.Text = Decimal.Round((decimal)(input * 0.25), 2).ToString();
                    // If God Only Knows Fund is already at $3000, take remainder and add it to Spending Section
                    if (checkAmount >= 3000)
                    {
                        textBox4.Text = Decimal.Round((decimal)(input * 0.25), 2).ToString();
                        double remainder = double.Parse(textBox4.Text);
                        textBox4.Text = 0.00.ToString();
                        textBox5.Text = Decimal.Round((decimal)((input * 0.40)+remainder), 2).ToString();
                    }
                    // If God Only Knows Fund deposit reaches $3000, take remainder and add it to Spending Section
                    else if (preCheck >= 3000)
                    {
                        double remainder = preCheck - 3000;
                        textBox4.Text = Decimal.Round((decimal)((input * 0.25) - remainder), 2).ToString();
                        textBox5.Text = Decimal.Round((decimal)((input * 0.40) + remainder), 2).ToString();
                    }
                    // If neither calculation reaches the maximum amount of $3000 in the GOKF, complete calulations without anyt changes.
                    else
                    {
                        textBox4.Text = Decimal.Round((decimal)(input * 0.25), 2).ToString();
                        textBox5.Text = Decimal.Round((decimal)(input * 0.40), 2).ToString();
                    }                    
                }
            }
            // Alert user that they need to select an account prior to completing any calculations
            else 
            {
                MessageBox.Show("Select User");
            }                       
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm Adding Fields Together?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Initiate SQL items for when the text is changed within the ComboBox
                string sqlStatement;
                string connectionString;
                try
                {
                    double donationCalc = double.Parse(textBox2.Text) + double.Parse(textBox7.Text);
                    double savingCalc = double.Parse(textBox3.Text) + double.Parse(textBox8.Text);
                    double gokfCalc = double.Parse(textBox4.Text) + double.Parse(textBox9.Text);
                    double spendingCalc = double.Parse(textBox5.Text) + double.Parse(textBox10.Text);

                    string moneyString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\01ele\source\repos\Finance\Finance_App\Finance_App\Database1.mdf;Integrated Security=True";
                    SqlConnection conn = new SqlConnection(moneyString);
                    conn.Open();

                    string updateQuery = "UPDATE Money SET Donation='" + donationCalc.ToString() + "',Savings='" + savingCalc.ToString() + "',GOKF='" + gokfCalc.ToString() + "',Spending='" + spendingCalc.ToString() + "' WHERE Id = " + textBox6.Text;
                    SqlCommand cmd = new SqlCommand(updateQuery, conn);

                    cmd.ExecuteNonQuery();
                    conn.Close();


                }
                catch
                {
                    MessageBox.Show("No Connection");
                }

                try
                {
                    // Database location string
                    connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\01ele\source\repos\Finance\Finance_App\Finance_App\Database1.mdf;Integrated Security=True";
                    SqlConnection cnn = new SqlConnection(connectionString);
                    cnn.Open();
                    // Run SQL statement 
                    sqlStatement = "SELECT * FROM Money WHERE Id = @id";
                    SqlCommand cmd = new SqlCommand(sqlStatement, cnn);
                    // Use ID populated to confirm proper insertion
                    cmd.Parameters.AddWithValue("@id", textBox6.Text);
                    // Read through database and insert fields into TextBoxes
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        textBox7.Text = sdr["Donation"].ToString().Trim();
                        textBox8.Text = sdr["Savings"].ToString().Trim();
                        textBox9.Text = sdr["GOKF"].ToString().Trim();
                        textBox10.Text = sdr["Spending"].ToString().Trim();
                        textBox7.BackColor = Color.Green;
                        textBox8.BackColor = Color.Green;
                        textBox9.BackColor = Color.Green;
                        textBox10.BackColor = Color.Green;
                    }
                    cnn.Close();
                }
                catch
                {
                    MessageBox.Show("No Connection");
                }
            }
            else {
                MessageBox.Show("Action Cancelled");
            }            
        }

        // Undo last transaction from Deposit
        private void Button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm Undoing Last Transaction?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Initiate SQL items for when the text is changed within the ComboBox
                string sqlStatement;
                string connectionString;
                try
                {
                    double donationCalc = double.Parse(textBox7.Text) - double.Parse(textBox2.Text);
                    double savingCalc = double.Parse(textBox8.Text) - double.Parse(textBox3.Text);
                    double gokfCalc = double.Parse(textBox9.Text) - double.Parse(textBox4.Text);
                    double spendingCalc = double.Parse(textBox10.Text) - double.Parse(textBox5.Text);

                    string moneyString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\01ele\source\repos\Finance\Finance_App\Finance_App\Database1.mdf;Integrated Security=True";
                    SqlConnection conn = new SqlConnection(moneyString);
                    conn.Open();

                    string updateQuery = "UPDATE Money SET Donation='" + donationCalc.ToString() + "',Savings='" + savingCalc.ToString() + "',GOKF='" + gokfCalc.ToString() + "',Spending='" + spendingCalc.ToString() + "' WHERE Id = " + textBox6.Text;
                    SqlCommand cmd = new SqlCommand(updateQuery, conn);

                    cmd.ExecuteNonQuery();
                    conn.Close();


                }
                catch
                {
                    MessageBox.Show("No Connection");
                }

                try
                {
                    // Database location string
                    connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\01ele\source\repos\Finance\Finance_App\Finance_App\Database1.mdf;Integrated Security=True";
                    SqlConnection cnn = new SqlConnection(connectionString);
                    cnn.Open();
                    // Run SQL statement 
                    sqlStatement = "SELECT * FROM Money WHERE Id = @id";
                    SqlCommand cmd = new SqlCommand(sqlStatement, cnn);
                    // Use ID populated to confirm proper insertion
                    cmd.Parameters.AddWithValue("@id", textBox6.Text);
                    // Read through database and insert fields into TextBoxes
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        textBox7.Text = sdr["Donation"].ToString().Trim();
                        textBox8.Text = sdr["Savings"].ToString().Trim();
                        textBox9.Text = sdr["GOKF"].ToString().Trim();
                        textBox10.Text = sdr["Spending"].ToString().Trim();
                        textBox7.BackColor = Color.White;
                        textBox8.BackColor = Color.White;
                        textBox9.BackColor = Color.White;
                        textBox10.BackColor = Color.White;
                    }
                    cnn.Close();
                }
                catch
                {
                    MessageBox.Show("No Connection");
                }
            }
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            
            // Ensure a user is selected to do calculations
            if (textBox30.Text == "")
            {
                MessageBox.Show("Select A User.");
            }
            // User is available to complete calculations
            else 
            { 
                if (MessageBox.Show("Confirm Comparing Expenses to Income?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        // Combine all the expenses into a single variable.
                        double expensesCalc = double.Parse(textBox35.Text) + double.Parse(textBox36.Text) + double.Parse(textBox37.Text)
                            + double.Parse(textBox38.Text) + double.Parse(textBox39.Text) + double.Parse(textBox40.Text) + double.Parse(textBox41.Text)
                            + double.Parse(textBox42.Text) + double.Parse(textBox43.Text) + double.Parse(textBox44.Text)+ double.Parse(textBox18.Text) + double.Parse(textBox19.Text) + double.Parse(textBox20.Text)
                             + double.Parse(textBox21.Text) + double.Parse(textBox22.Text) + double.Parse(textBox23.Text) + double.Parse(textBox24.Text)
                              + double.Parse(textBox25.Text) + double.Parse(textBox26.Text) + double.Parse(textBox27.Text);
                        // Main Expense Totals
                        double mainExpense = double.Parse(textBox18.Text) + double.Parse(textBox19.Text) + double.Parse(textBox20.Text)
                             + double.Parse(textBox21.Text) + double.Parse(textBox22.Text) + double.Parse(textBox23.Text) + double.Parse(textBox24.Text)
                              + double.Parse(textBox25.Text) + double.Parse(textBox26.Text) + double.Parse(textBox27.Text);
                        // Find the difference between what is available to what expenses are being used.
                        double differenceCalc = double.Parse(textBox34.Text) - expensesCalc;
                        // Display all expenses
                        textBox28.Text = expensesCalc.ToString();
                        textBox60.Text = mainExpense.ToString();
                        // Display the difference
                        if (differenceCalc < 0)
                        {
                            textBox29.BackColor = Color.Black;
                            textBox29.ForeColor = Color.Red;
                            textBox29.Text = differenceCalc.ToString();
                        }
                        else 
                        {
                            textBox29.BackColor = Color.Green;
                            textBox29.Text = differenceCalc.ToString();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Calculations could not be performed");
                    }

                }
            }
        }
        private void Button5_Click(object sender, EventArgs e)
        {

            // Ensure a user is selected to do calculations
            if (textBox47.Text == "")
            {
                MessageBox.Show("Select A User.");
            }
            // User is available to complete calculations
            else
            {
                if (MessageBox.Show("Confirm Comparing Expenses to Income?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        // Combine all the expenses into a single variable.
                        double expensesCalc = double.Parse(textBox35.Text) + double.Parse(textBox36.Text) + double.Parse(textBox37.Text)
                            + double.Parse(textBox38.Text) + double.Parse(textBox39.Text) + double.Parse(textBox40.Text) + double.Parse(textBox41.Text)
                            + double.Parse(textBox42.Text) + double.Parse(textBox43.Text) + double.Parse(textBox44.Text) + double.Parse(textBox18.Text) + double.Parse(textBox19.Text) + double.Parse(textBox20.Text)
                             + double.Parse(textBox21.Text) + double.Parse(textBox22.Text) + double.Parse(textBox23.Text) + double.Parse(textBox24.Text)
                              + double.Parse(textBox25.Text) + double.Parse(textBox26.Text) + double.Parse(textBox27.Text);
                        // Additional Expenses Total
                        double additionalExpenses = double.Parse(textBox35.Text) + double.Parse(textBox36.Text) + double.Parse(textBox37.Text)
                            + double.Parse(textBox38.Text) + double.Parse(textBox39.Text) + double.Parse(textBox40.Text) + double.Parse(textBox41.Text)
                            + double.Parse(textBox42.Text) + double.Parse(textBox43.Text) + double.Parse(textBox44.Text);
                        // Find the difference between what is available to what expenses are being used.
                        double differenceCalc = double.Parse(textBox51.Text) - expensesCalc;
                        // Display all expenses
                        textBox45.Text = expensesCalc.ToString();
                        textBox61.Text = additionalExpenses.ToString();
                        // Display the difference
                        if (differenceCalc < 0)
                        {
                            textBox46.BackColor = Color.Black;
                            textBox46.ForeColor = Color.Red;
                            textBox46.Text = differenceCalc.ToString();
                        }
                        else
                        {
                            textBox46.BackColor = Color.Green;
                            textBox46.Text = differenceCalc.ToString();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Calculations could not be performed");
                    }

                }
            }
        }
        // Check to see users available in database
        private void ComboBox1_Click(object sender, EventArgs e)
        {
            // Database location string
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\01ele\source\repos\Finance\Finance_App\Finance_App\Database1.mdf;Integrated Security=True";
            // Run database connection
            using (SqlConnection dropDownConn = new SqlConnection(connectionString))
            {
                dropDownConn.Open();
                // Run SQL statement 
                string query = "SELECT First FROM People";
                SqlCommand cmm = new SqlCommand(query, dropDownConn);
                // Read the results of statement and add all users into combobox
                using (SqlDataReader reader = cmm.ExecuteReader())
                {
                    // Clear out combobox to avoid duplicates
                    comboBox1.Items.Clear();
                    // Populate combobox with updated material
                    while (reader.Read())
                    {
                        string names = reader.GetString(0).Trim();
                        comboBox1.Items.Add(names);
                    }
                }
                // Close Current Connection
                dropDownConn.Close();
            }                
        }        

        private void ComboBoxTextChange(object sender, EventArgs e)
        {
            // Initiate SQL items for when the text is changed within the ComboBox
            string sqlStatement;
            string connectionString;
            
            // Attempt to determine the User and populate fields from totals
            try
            {
                // Database location string
                connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\01ele\source\repos\Finance\Finance_App\Finance_App\Database1.mdf;Integrated Security=True";
                // Run database connection
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    // Search for ID from selected user in ComboBox
                    using (SqlCommand cmd = new SqlCommand("SELECT Id FROM People WHERE First = @name"))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        con.Open();
                        cmd.Parameters.AddWithValue("@name", comboBox1.SelectedItem);
                        // Insert the ID from People Database
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            sdr.Read();
                            textBox6.Text = sdr["Id"].ToString();
                        }
                        con.Close();
                    }
                }
            }
            catch
            {
                MessageBox.Show("No Connection");
            }
            // Attempt to populate fields from Money Database
            try
            {
                // Database location string
                connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\01ele\source\repos\Finance\Finance_App\Finance_App\Database1.mdf;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connectionString);
                cnn.Open();
                // Run SQL statement 
                sqlStatement = "SELECT * FROM Money WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(sqlStatement, cnn);
                // Use ID populated to confirm proper insertion
                cmd.Parameters.AddWithValue("@id", textBox6.Text);
                // Read through database and insert fields into TextBoxes
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    textBox7.Text = sdr["Donation"].ToString().Trim();
                    textBox8.Text = sdr["Savings"].ToString().Trim();
                    textBox9.Text = sdr["GOKF"].ToString().Trim();
                    textBox10.Text = sdr["Spending"].ToString().Trim();
                }
                cnn.Close();
            }
            catch
            {
                MessageBox.Show("No Connection");
            }
        }
        // Check to see users available in database
        private void ComboBox2_Click(object sender, EventArgs e)
        {
            // Database location string
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\01ele\source\repos\Finance\Finance_App\Finance_App\Database1.mdf;Integrated Security=True";
            // Run database connection
            using (SqlConnection dropDownConn = new SqlConnection(connectionString))
            {
                dropDownConn.Open();
                // Run SQL statement 
                string query = "SELECT First FROM People";
                SqlCommand cmm = new SqlCommand(query, dropDownConn);
                // Read the results of statement and add all users into combobox
                using (SqlDataReader reader = cmm.ExecuteReader())
                {
                    // Clear out combobox to avoid duplicates
                    comboBox2.Items.Clear();
                    // Populate combobox with updated material
                    while (reader.Read())
                    {
                        string names = reader.GetString(0).Trim();
                        comboBox2.Items.Add(names);
                    }
                }
                // Close Current Connection
                dropDownConn.Close();
            }
        }
        private void ComboBox3_Click(object sender, EventArgs e)
        {
            {
                // Database location string
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\01ele\source\repos\Finance\Finance_App\Finance_App\Database1.mdf;Integrated Security=True";
                // Run database connection
                using (SqlConnection dropDownConn = new SqlConnection(connectionString))
                {
                    dropDownConn.Open();
                    // Run SQL statement 
                    string query = "SELECT First FROM People";
                    SqlCommand cmm = new SqlCommand(query, dropDownConn);
                    // Read the results of statement and add all users into combobox
                    using (SqlDataReader reader = cmm.ExecuteReader())
                    {
                        // Clear out combobox to avoid duplicates
                        comboBox3.Items.Clear();
                        // Populate combobox with updated material
                        while (reader.Read())
                        {
                            string names = reader.GetString(0).Trim();
                            comboBox3.Items.Add(names);
                        }
                    }
                    // Close Current Connection
                    dropDownConn.Close();
                }
            }
        }

        private void ComboBoxTextChangeTwo(object sender, EventArgs e)
        {
            // Initiate SQL items for when the text is changed within the ComboBox
            string sqlStatement;
            string connectionString;

            // Attempt to determine the User and populate fields from totals
            try
            {
                // Database location string
                connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\01ele\source\repos\Finance\Finance_App\Finance_App\Database1.mdf;Integrated Security=True";
                // Run database connection
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    // Search for ID from selected user in ComboBox
                    using (SqlCommand cmd = new SqlCommand("SELECT Id FROM People WHERE First = @name"))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        con.Open();
                        cmd.Parameters.AddWithValue("@name", comboBox2.SelectedItem);
                        // Insert the ID from People Database
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            sdr.Read();
                            textBox30.Text = sdr["Id"].ToString().Trim();
                        }
                        con.Close();
                    }
                }
            }
            catch
            {
                MessageBox.Show("No Connection");
            }
            // Attempt to populate fields from Money Database
            try
            {
                // Database location string
                connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\01ele\source\repos\Finance\Finance_App\Finance_App\Database1.mdf;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connectionString);
                cnn.Open();
                // Run SQL statement 
                sqlStatement = "SELECT * FROM Money WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(sqlStatement, cnn);
                // Use ID populated to confirm proper insertion
                cmd.Parameters.AddWithValue("@id", textBox30.Text);
                // Read through database and insert fields into TextBoxes
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    textBox31.Text = sdr["Donation"].ToString().Trim();
                    textBox32.Text = sdr["Savings"].ToString().Trim();
                    textBox33.Text = sdr["GOKF"].ToString().Trim();
                    textBox34.Text = sdr["Spending"].ToString().Trim();
                }
                cnn.Close();
            }
            catch
            {
                MessageBox.Show("No Connection");
            }
        }
        private void ComboBoxTextChangeThree(object sender, EventArgs e)
        {
            // Initiate SQL items for when the text is changed within the ComboBox
            string sqlStatement;
            string connectionString;

            // Attempt to determine the User and populate fields from totals
            try
            {
                // Database location string
                connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\01ele\source\repos\Finance\Finance_App\Finance_App\Database1.mdf;Integrated Security=True";
                // Run database connection
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    // Search for ID from selected user in ComboBox
                    using (SqlCommand cmd = new SqlCommand("SELECT Id FROM People WHERE First = @name"))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        con.Open();
                        cmd.Parameters.AddWithValue("@name", comboBox3.SelectedItem);
                        // Insert the ID from People Database
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            sdr.Read();
                            textBox47.Text = sdr["Id"].ToString().Trim();
                        }
                        con.Close();
                    }
                }
            }
            catch
            {
                MessageBox.Show("No Connection");
            }
            // Attempt to populate fields from Money Database
            try
            {
                // Database location string
                connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\01ele\source\repos\Finance\Finance_App\Finance_App\Database1.mdf;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connectionString);
                cnn.Open();
                // Run SQL statement 
                sqlStatement = "SELECT * FROM Money WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(sqlStatement, cnn);
                // Use ID populated to confirm proper insertion
                cmd.Parameters.AddWithValue("@id", textBox47.Text);
                // Read through database and insert fields into TextBoxes
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    textBox48.Text = sdr["Donation"].ToString().Trim();
                    textBox49.Text = sdr["Savings"].ToString().Trim();
                    textBox50.Text = sdr["GOKF"].ToString().Trim();
                    textBox51.Text = sdr["Spending"].ToString().Trim();
                }
                cnn.Close();
            }
            catch
            {
                MessageBox.Show("No Connection");
            }
        }
        private void ComboBoxFive_Click(object sender, EventArgs e)
        {
            
            {
                // Database location string
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\01ele\source\repos\Finance\Finance_App\Finance_App\Database1.mdf;Integrated Security=True";
                // Run database connection
                using (SqlConnection dropDownConn = new SqlConnection(connectionString))
                {
                    dropDownConn.Open();
                    // Run SQL statement 
                    string query = "SELECT First FROM People";
                    SqlCommand cmm = new SqlCommand(query, dropDownConn);
                    // Read the results of statement and add all users into combobox
                    using (SqlDataReader reader = cmm.ExecuteReader())
                    {
                        // Clear out combobox to avoid duplicates
                        comboBox5.Items.Clear();
                        // Populate combobox with updated material
                        while (reader.Read())
                        {
                            string names = reader.GetString(0).Trim();
                            comboBox5.Items.Add(names);
                        }
                    }
                    // Close Current Connection
                    dropDownConn.Close();
                }
            }
            
        }
        private void ComboBoxTextChangeFive(object sender, EventArgs e) 
        {
            // Initiate SQL items for when the text is changed within the ComboBox
            string sqlStatement;
            string connectionString;

            // Attempt to determine the User and populate fields from totals
            try
            {
                // Database location string
                connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\01ele\source\repos\Finance\Finance_App\Finance_App\Database1.mdf;Integrated Security=True";
                // Run database connection
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    // Search for ID from selected user in ComboBox
                    using (SqlCommand cmd = new SqlCommand("SELECT Id FROM People WHERE First = @name"))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        con.Open();
                        cmd.Parameters.AddWithValue("@name", comboBox5.SelectedItem);
                        // Insert the ID from People Database
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            sdr.Read();
                            textBox59.Text = sdr["Id"].ToString().Trim();
                            con.Close();
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("No Connection");
            }
            // Attempt to populate fields from Money Database
            try
            {
                // Database location string
                connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\01ele\source\repos\Finance\Finance_App\Finance_App\Database1.mdf;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connectionString);
                cnn.Open();
                // Run SQL statement 
                sqlStatement = "SELECT * FROM People WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(sqlStatement, cnn);
                // Use ID populated to confirm proper insertion
                cmd.Parameters.AddWithValue("@id", textBox59.Text);
                // Read through database and insert fields into TextBoxes
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    textBox52.Text = sdr["First"].ToString().Trim();
                    textBox53.Text = sdr["Last"].ToString().Trim();
                    textBox54.Text = sdr["Email"].ToString().Trim();
                    textBox55.Text = sdr["Address1"].ToString().Trim();
                    textBox56.Text = sdr["Address2"].ToString().Trim();
                    textBox57.Text = sdr["City"].ToString().Trim();
                    comboBox4.Text = sdr["State"].ToString().Trim();
                    textBox58.Text = sdr["Zip"].ToString().Trim();
                }
                cnn.Close();
            }
            catch
            {
                MessageBox.Show("No Connection");
            }
        }
        private void ChangeTabs(object sender, EventArgs e)
        {
            // Combine all the expenses into a single variable.
            double expensesCalc = double.Parse(textBox35.Text) + double.Parse(textBox36.Text) + double.Parse(textBox37.Text)
                + double.Parse(textBox38.Text) + double.Parse(textBox39.Text) + double.Parse(textBox40.Text) + double.Parse(textBox41.Text)
                + double.Parse(textBox42.Text) + double.Parse(textBox43.Text) + double.Parse(textBox44.Text) + double.Parse(textBox18.Text) + double.Parse(textBox19.Text) + double.Parse(textBox20.Text)
                 + double.Parse(textBox21.Text) + double.Parse(textBox22.Text) + double.Parse(textBox23.Text) + double.Parse(textBox24.Text)
                  + double.Parse(textBox25.Text) + double.Parse(textBox26.Text) + double.Parse(textBox27.Text);
            // Display all expenses
            textBox45.Text = expensesCalc.ToString();
            textBox28.Text = expensesCalc.ToString();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm Updaing User?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Initiate SQL items for when the text is changed within the ComboBox
                string sqlStatement;
                string connectionString;
                try
                {

                    string moneyString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\01ele\source\repos\Finance\Finance_App\Finance_App\Database1.mdf;Integrated Security=True";
                    SqlConnection conn = new SqlConnection(moneyString);
                    conn.Open();

                    string updateQuery = "UPDATE People SET First='" + textBox52.Text.Trim() + "',Last='" + textBox53.Text.Trim() + 
                        "',Email='" + textBox54.Text.Trim() + "',Address1='" + textBox55.Text.Trim() + "',Address2='" + textBox56.Text.Trim() + 
                        "',City='" + textBox57.Text.Trim() + "',State='" + comboBox4.Text.Trim() + "',Zip='" + textBox58.Text.Trim() + "' WHERE Id = " + textBox59.Text;
                    SqlCommand cmd = new SqlCommand(updateQuery, conn);

                    cmd.ExecuteNonQuery();
                    conn.Close();


                }
                catch
                {
                    MessageBox.Show("No Connection");
                }

                // Attempt to populate fields from Money Database
                try
                {
                    // Database location string
                    connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\01ele\source\repos\Finance\Finance_App\Finance_App\Database1.mdf;Integrated Security=True";
                    SqlConnection cnn = new SqlConnection(connectionString);
                    cnn.Open();
                    // Run SQL statement 
                    sqlStatement = "SELECT * FROM People WHERE Id = @id";
                    SqlCommand cmd = new SqlCommand(sqlStatement, cnn);
                    // Use ID populated to confirm proper insertion
                    cmd.Parameters.AddWithValue("@id", textBox59.Text);
                    // Read through database and insert fields into TextBoxes
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        textBox52.Text = sdr["First"].ToString().Trim();
                        textBox53.Text = sdr["Last"].ToString().Trim();
                        textBox54.Text = sdr["Email"].ToString().Trim();
                        textBox55.Text = sdr["Address1"].ToString().Trim();
                        textBox56.Text = sdr["Address2"].ToString().Trim();
                        textBox57.Text = sdr["City"].ToString().Trim();
                        comboBox4.Text = sdr["State"].ToString().Trim();
                        textBox58.Text = sdr["Zip"].ToString().Trim();
                    }
                    cnn.Close();
                }
                catch
                {
                    MessageBox.Show("No Connection");
                }
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {

        }
    }
}
