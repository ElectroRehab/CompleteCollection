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
using static System.Windows.Forms.TextBox;
using static System.Windows.Forms.ComboBox;
using System.Collections.Generic;
using MsgBox;
using static MsgBox.InputBox;
using System.Diagnostics.Eventing.Reader;
using System.Drawing.Text;
using System.Threading;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using TextBox = System.Windows.Forms.TextBox;
using ComboBox = System.Windows.Forms.ComboBox;

namespace Finance_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static class Globals
        {
            // Database location string
            public static bool boxUp = true;
            public static bool boxDown = false;
            public static bool boxInOut;
            public static bool passChecker;
            public static bool bypass;
            public static bool secondChance = false;
            public static String boxAnswer;
            public static String currentUser;
            public static String currentUserId;
            public static String first;
            public static String last;
            public static String splitText;
            public static String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            //public static String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\01ele\source\repos\Finance\Finance_App\Finance_App\Database1.mdf;Integrated Security=True";
            public static String firstSelect = "SELECT First,Last FROM People";
            public static String idNameSelect = "SELECT Id FROM People WHERE First = @name";
            public static String longTermSave = "SELECT * FROM LongTermSaves WHERE Id = @id";
            public static String longTermSelect = "SELECT * FROM LongTermTitles WHERE Id = @id";
            public static String moneySelect = "SELECT * FROM Money WHERE Id = @id";
            public static String monthSelect = "SELECT * FROM MonthlyCosts WHERE Id = @id";            
            public static String peopleSelect = "SELECT * FROM People WHERE Id = @id";
            public static String sqlStatement;

        }
        public void PopulateDropMenus(ComboBox o)
        {
            // Run database connection
            using (SqlConnection dropDownConn = new SqlConnection(Globals.connectionString))
            {
                dropDownConn.Open();
                // Run SQL statement
                SqlCommand cmm = new SqlCommand(Globals.firstSelect, dropDownConn);
                // Read the results of statement and add all users into combobox
                using (SqlDataReader reader = cmm.ExecuteReader())
                {
                    // Clear out combobox to avoid duplicates
                    o.Items.Clear();
                    // Populate combobox with updated material
                    while (reader.Read())
                    {
                        Globals.first = reader.GetString(0).Trim();
                        Globals.last = reader.GetString(1).Trim();
                        o.Items.Add(Globals.first + " " + Globals.last);
                    }
                }
                // Close Current Connection
                dropDownConn.Close();
            }
        }
        public void IdChecker(ComboBox o, TextBox t1, TextBox t2, TextBox t3, TextBox t4, TextBox t5)
        {
            if (Globals.bypass == false)
            {
                try
                {
                    // Run database connection
                    using (SqlConnection con = new SqlConnection(Globals.connectionString))
                    {
                        // Search for ID from selected user in ComboBox
                        using (SqlCommand cmd = new SqlCommand(Globals.idNameSelect))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = con;
                            con.Open();
                            string[] splitName = o.Text.Split(' ');
                            Globals.splitText = splitName[0];
                            cmd.Parameters.AddWithValue("@name", Globals.splitText);
                            Globals.currentUser = o.Text.ToString();

                            // Insert the ID from People Database
                            using (SqlDataReader sdr = cmd.ExecuteReader())
                            {
                                sdr.Read();
                                t1.Text = sdr["Id"].ToString();
                            }
                            con.Close();
                            Globals.currentUserId = t1.Text;
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
                    SqlConnection cnn = new SqlConnection(Globals.connectionString);
                    cnn.Open();
                    // Run SQL statement
                    SqlCommand cmd = new SqlCommand(Globals.moneySelect, cnn);
                    // Use ID populated to confirm proper insertion
                    cmd.Parameters.AddWithValue("@id", t1.Text);
                    // Create a Message Box that allows users to enter pass code
                    Globals.boxAnswer = MessageBoard(Globals.boxUp, Globals.secondChance);
                    // Read through database and insert fields into TextBoxes
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        {
                            //if (InputBox.ResultValue.ToString() == sdr["Pass"].ToString().Trim())
                            if (Globals.boxAnswer == sdr["Pass"].ToString().Trim())
                            {
                                t2.Text = sdr["Donation"].ToString().Trim();
                                t3.Text = sdr["Savings"].ToString().Trim();
                                t4.Text = sdr["GOKF"].ToString().Trim();
                                t5.Text = sdr["Spending"].ToString().Trim();
                                Globals.passChecker = true;
                            }
                            else
                            {
                                t2.Text = ("");
                                t3.Text = ("");
                                t4.Text = ("");
                                t5.Text = ("");
                                MessageBox.Show("Incorrect Pass Code");
                            }
                        }
                    }
                    cnn.Close();
                }
                catch
                {
                    MessageBox.Show("No Connection");
                }
            }
            else
            {
                o.Text = Globals.currentUser;
                t1.Text = Globals.currentUserId;
                try
                {
                    SqlConnection cnn = new SqlConnection(Globals.connectionString);
                    cnn.Open();
                    // Run SQL statement
                    SqlCommand cmd = new SqlCommand(Globals.moneySelect, cnn);
                    // Use ID populated to confirm proper insertion
                    cmd.Parameters.AddWithValue("@id", t1.Text);
                    // Read through database and insert fields into TextBoxes
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        {
                            t2.Text = sdr["Donation"].ToString().Trim();
                            t3.Text = sdr["Savings"].ToString().Trim();
                            t4.Text = sdr["GOKF"].ToString().Trim();
                            t5.Text = sdr["Spending"].ToString().Trim();
                            Globals.passChecker = true;
                        }
                    }
                    cnn.Close();
                }
                catch
                {
                    MessageBox.Show("No Connection");
                }
            }
        }
        private string MessageBoard(bool answer, bool second)
        {
            string returnAnswer;
            if (answer == true && second == false)
            {
                // Create a Message Box that allows users to enter password
                InputBox.SetLanguage(InputBox.Language.English);
                DialogResult res = InputBox.ShowDialog("Enter User's Pass Code:",
                "Verify Pass Code",   //Text message (mandatory), Title (optional)
                    InputBox.Icon.Question, //Set icon type (default info)
                    InputBox.Buttons.Ok, //Set buttons (default ok)
                    InputBox.Type.TextBox, //Set type (default nothing)
                    new string[] { "Item1", "Item2", "Item3" }, //String field as ComboBox items (default null)
                    true, //Set visible in taskbar (default false)
                    new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold)); //Set font (default by system)
                returnAnswer = InputBox.ResultValue.Trim();

            }
            else if (answer == false && second == false)
            {
                // Create a Message Box that allows users to enter password
                InputBox.SetLanguage(InputBox.Language.English);
                DialogResult res = InputBox.ShowDialog("Change Title of Selection:",
                "Change Title",   //Text message (mandatory), Title (optional)
                    InputBox.Icon.Information, //Set icon type (default info)
                    InputBox.Buttons.Ok, //Set buttons (default ok)
                    InputBox.Type.TextBoxTitle, //Set type (default nothing)
                    new string[] { "Item1", "Item2", "Item3" }, //String field as ComboBox items (default null)
                    true, //Set visible in taskbar (default false)
                    new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold)); //Set font (default by system)
                returnAnswer = InputBox.ResultValue.Trim();
            }
            else if (answer == true && second == true)
            {
                // Create a Message Box that allows users to enter password
                InputBox.SetLanguage(InputBox.Language.English);
                DialogResult res = InputBox.ShowDialog("Choose New User:",
                "Change Title",   //Text message (mandatory), Title (optional)
                    InputBox.Icon.Information, //Set icon type (default info)
                    InputBox.Buttons.Ok, //Set buttons (default ok)
                    InputBox.Type.ComboBox, //Set type (default nothing)
                    new string [] {"Item1", "Item2"}, //String field as ComboBox items (default null)
                    true, //Set visible in taskbar (default false)
                    new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold)); ; //Set font (default by system)
                returnAnswer = InputBox.ResultValue.Trim();
            }
            else
            {
                returnAnswer = "Nope";
            }
            
            return returnAnswer;
        }
        private void CreateButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Setup user with new People Fields in Database
                Globals.sqlStatement = "INSERT INTO People(First,Last,Email,Address1,Address2,City,State,Zip) Values(@firstName,@lastName,@email,@address1,@address2,@city,@state,@zip)";
                SqlConnection cn = new SqlConnection(Globals.connectionString);
                SqlCommand cmd = new SqlCommand(Globals.sqlStatement, cn);
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
                else
                {
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
                    Globals.sqlStatement = "INSERT INTO Money(Donation,Savings,GOKF,Spending,Pass) Values(@donate,@save,@gokf,@spend,@pass)";
                    SqlConnection cn = new SqlConnection(Globals.connectionString);
                    SqlCommand cmd = new SqlCommand(Globals.sqlStatement, cn);
                    // Determine what field parameters are
                    cmd.Parameters.Add(new SqlParameter("@donate", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@save", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@gokf", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@spend", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@pass", SqlDbType.Char, 4));
                    // Set 0 for the values within the database
                    cmd.Parameters["@donate"].Value = "0.00";
                    cmd.Parameters["@save"].Value = "0.00";
                    cmd.Parameters["@gokf"].Value = "0.00";
                    cmd.Parameters["@spend"].Value = "0.00";
                    cmd.Parameters["@pass"].Value = textBox3.Text;
                    // Open Database
                    cn.Open();
                    // Run SQL Statement
                    cmd.ExecuteNonQuery();
                    // Close Database
                    cn.Close();
                }
                catch
                {
                    MessageBox.Show("No Money Input");
                }
                try
                {
                    // Setup user with new Money Fields in Database
                    Globals.sqlStatement = "INSERT INTO LongTermTitles(ItemOne,ItemTwo,ItemThree,ItemFour,ItemFive,ItemSix) Values(@itemOne,@itemTwo,@itemThree,@itemFour,@itemFive,@itemSix)";
                    SqlConnection cn = new SqlConnection(Globals.connectionString);
                    SqlCommand cmd = new SqlCommand(Globals.sqlStatement, cn);
                    // Determine what field parameters are
                    cmd.Parameters.Add(new SqlParameter("@itemOne", SqlDbType.Char, 25));
                    cmd.Parameters.Add(new SqlParameter("@itemTwo", SqlDbType.Char, 25));
                    cmd.Parameters.Add(new SqlParameter("@itemThree", SqlDbType.Char, 25));
                    cmd.Parameters.Add(new SqlParameter("@itemFour", SqlDbType.Char, 25));
                    cmd.Parameters.Add(new SqlParameter("@itemFive", SqlDbType.Char, 25));
                    cmd.Parameters.Add(new SqlParameter("@itemSix", SqlDbType.Char, 25));
                    // Set 0 for the values within the database
                    cmd.Parameters["@itemOne"].Value = "SetItemOne";
                    cmd.Parameters["@itemTwo"].Value = "SetItemTwo";
                    cmd.Parameters["@itemThree"].Value = "SetItemThree";
                    cmd.Parameters["@itemFour"].Value = "SetItemFour";
                    cmd.Parameters["@itemFive"].Value = "SetItemFive";
                    cmd.Parameters["@itemSix"].Value = "SetItemSix";
                    // Open Database
                    cn.Open();
                    // Run SQL Statement
                    cmd.ExecuteNonQuery();
                    // Close Database
                    cn.Close();
                }
                catch
                {
                    MessageBox.Show("No Title Inputs");
                }
                try
                {
                    // Setup user with new Money Fields in Database
                    Globals.sqlStatement = "INSERT INTO LongTermSaves(SaveOne,SaveTwo,SaveThree,SaveFour,SaveFive,SaveSix) Values(@saveOne,@saveTwo,@saveThree,@saveFour,@saveFive,@saveSix)";
                    SqlConnection cn = new SqlConnection(Globals.connectionString);
                    SqlCommand cmd = new SqlCommand(Globals.sqlStatement, cn);
                    // Determine what field parameters are
                    cmd.Parameters.Add(new SqlParameter("@saveOne", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@saveTwo", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@saveThree", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@saveFour", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@saveFive", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@saveSix", SqlDbType.Float, 53));
                    // Set 0 for the values within the database
                    cmd.Parameters["@saveOne"].Value = "0.00";
                    cmd.Parameters["@saveTwo"].Value = "0.00";
                    cmd.Parameters["@saveThree"].Value = "0.00";
                    cmd.Parameters["@saveFour"].Value = "0.00";
                    cmd.Parameters["@saveFive"].Value = "0.00";
                    cmd.Parameters["@saveSix"].Value = "0.00";
                    // Open Database
                    cn.Open();
                    // Run SQL Statement
                    cmd.ExecuteNonQuery();
                    // Close Database
                    cn.Close();
                    
                }
                catch
                {
                    MessageBox.Show("No Money Title Inputs");
                }
                try
                {
                    // Setup user with new Money Fields in Database
                    Globals.sqlStatement = "INSERT INTO MonthlyCosts(MonthlyOne,MonthlyTwo,MonthlyThree,MonthlyFour,MonthlyFive,MonthlySix," +
                        "MonthlySeven,MonthlyEight,MonthlyNine,MonthlyTen,MonthlyEleven,MonthlyTwelve,MonthlyThirteen,MonthlyFourteen," +
                        "MonthlyFifteen,MonthlySixteen,MonthlySeventeen,MonthlyEighteen,MonthlyNineteen,MonthlyTwenty) " +
                        "Values(@mOne,@mTwo,@mThree,@mFour,@mFive,@mSix,@mSeven,@mEight,@mNine,@mTen,@mEleven,@mTwelve,@mThirteen," +
                        "@mFourteen,@mFifteen,@mSixteen,@mSeventeen,@mEighteen,@mNineteen,@mTwenty)";
                    SqlConnection cn = new SqlConnection(Globals.connectionString);
                    SqlCommand cmd = new SqlCommand(Globals.sqlStatement, cn);
                    // Determine what field parameters are
                    cmd.Parameters.Add(new SqlParameter("@mOne", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@mTwo", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@mThree", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@mFour", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@mFive", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@mSix", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@mSeven", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@mEight", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@mNine", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@mTen", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@mEleven", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@mTwelve", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@mThirteen", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@mFourteen", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@mFifteen", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@mSixteen", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@mSeventeen", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@mEighteen", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@mNineteen", SqlDbType.Float, 53));
                    cmd.Parameters.Add(new SqlParameter("@mTwenty", SqlDbType.Float, 53));
                    // Set 0 for the values within the database
                    cmd.Parameters["@mOne"].Value = "0.00";
                    cmd.Parameters["@mTwo"].Value = "0.00";
                    cmd.Parameters["@mThree"].Value = "0.00";
                    cmd.Parameters["@mFour"].Value = "0.00";
                    cmd.Parameters["@mFive"].Value = "0.00";
                    cmd.Parameters["@mSix"].Value = "0.00";
                    cmd.Parameters["@mSeven"].Value = "0.00";
                    cmd.Parameters["@mEight"].Value = "0.00";
                    cmd.Parameters["@mNine"].Value = "0.00";
                    cmd.Parameters["@mTen"].Value = "0.00";
                    cmd.Parameters["@mEleven"].Value = "0.00";
                    cmd.Parameters["@mTwelve"].Value = "0.00";
                    cmd.Parameters["@mThirteen"].Value = "0.00";
                    cmd.Parameters["@mFourteen"].Value = "0.00";
                    cmd.Parameters["@mFifteen"].Value = "0.00";
                    cmd.Parameters["@mSixteen"].Value = "0.00";
                    cmd.Parameters["@mSeventeen"].Value = "0.00";
                    cmd.Parameters["@mEighteen"].Value = "0.00";
                    cmd.Parameters["@mNineteen"].Value = "0.00";
                    cmd.Parameters["@mTwenty"].Value = "0.00";
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
                    MessageBox.Show("No Costs Inputted");
                }
            }
            else
            {
                MessageBox.Show("        Invalid Email Address, \n                 Try Again.");
            }

        }
        
        private void Button1_Click(object sender, EventArgs e)
        {
            
            double input = 0;
            // Check if user is selected prior to calculations
            if (textBox6.Text != "" && comboBox6.Text != "")
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
                    if (radioButton1.Checked != false || radioButton2.Checked != false)
                    {
                        // Check to see if God Only Knows Fund has reached or will reach set cap.
                        double checkAmount = double.Parse(textBox9.Text);
                        double preCheck = double.Parse(textBox9.Text) + (input * 0.25);

                        // Calculate Remaining Sections
                        textBox2.Text = Decimal.Round((decimal)(input * 0.10), 2).ToString();

                        // If God Only Knows Fund is already at set cap, take remainder and add it to Spending Section*
                        if (checkAmount >= double.Parse(comboBox6.Text) && radioButton2.Checked)
                        {
                            savingsBox.Text = Decimal.Round((decimal)(input * 0.25), 2).ToString();
                            GOKFBox.Text = Decimal.Round((decimal)(input * 0.25), 2).ToString();
                            double remainder = double.Parse(GOKFBox.Text);
                            GOKFBox.Text = 0.00.ToString();
                            spendingBox.Text = Decimal.Round((decimal)((input * 0.40) + remainder), 2).ToString();
                        }
                        // If God Only Knows Fund is already at set cap, take remainder and add it to Saving Section*
                        else if (checkAmount >= double.Parse(comboBox6.Text) && radioButton1.Checked)
                        {
                            GOKFBox.Text = Decimal.Round((decimal)(input * 0.25), 2).ToString();
                            double remainder = double.Parse(GOKFBox.Text);
                            savingsBox.Text = Decimal.Round((decimal)((input * 0.25) + remainder), 2).ToString();
                            GOKFBox.Text = 0.00.ToString();
                            spendingBox.Text = Decimal.Round((decimal)((input * 0.40)), 2).ToString();
                        }
                        // If God Only Knows Fund deposit reaches set cap, take remainder and add it to Spending Section*
                        else if (preCheck >= double.Parse(comboBox6.Text) && radioButton2.Checked)
                        {
                            double remainder = (input * 0.25) - double.Parse(GOKFBox.Text);
                            savingsBox.Text = Decimal.Round((decimal)(input * 0.25), 2).ToString();
                            GOKFBox.Text = (double.Parse(comboBox6.Text) - double.Parse(textBox9.Text)).ToString();
                            spendingBox.Text = Decimal.Round((decimal)((input * 0.40) + remainder), 2).ToString();
                        }
                        // If God Only Knows Fund deposit reaches set cap, take remainder and add it to Spending Section*
                        else if (preCheck >= double.Parse(comboBox6.Text) && radioButton1.Checked)
                        {
                            double remainder = (input * 0.25) - double.Parse(GOKFBox.Text);
                            savingsBox.Text = Decimal.Round((decimal)((input * 0.25) + remainder), 2).ToString();
                            GOKFBox.Text = (double.Parse(comboBox6.Text) - double.Parse(textBox9.Text)).ToString();
                            spendingBox.Text = Decimal.Round((decimal)((input * 0.40)), 2).ToString();
                        }
                        // If neither calculation reaches the maximum amount of set cap in the GOKF, complete calulations without any changes.
                        else
                        {
                            savingsBox.Text = Decimal.Round((decimal)(input * 0.25), 2).ToString();
                            GOKFBox.Text = Decimal.Round((decimal)(input * 0.25), 2).ToString();
                            spendingBox.Text = Decimal.Round((decimal)(input * 0.40), 2).ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Select Radio Button to add remainder");
                    }
                }
            }
            // Alert user that they need to select an account prior to completing any calculations
            else
            {
                MessageBox.Show("Select User\nSet Cap God Only Knows Fund");
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm Adding Fields Together?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Initiate SQL items for when the text is changed within the ComboBox
                
                try
                {
                    double donationCalc = double.Parse(textBox2.Text) + double.Parse(textBox7.Text);
                    double savingCalc = double.Parse(savingsBox.Text) + double.Parse(textBox8.Text);
                    double gokfCalc = double.Parse(GOKFBox.Text) + double.Parse(textBox9.Text);
                    double spendingCalc = double.Parse(spendingBox.Text) + double.Parse(textBox10.Text);

                    SqlConnection conn = new SqlConnection(Globals.connectionString);
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
                    SqlConnection cnn = new SqlConnection(Globals.connectionString);
                    cnn.Open();
                    // Run SQL statement
                    SqlCommand cmd = new SqlCommand(Globals.moneySelect, cnn);
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
            else
            {
                MessageBox.Show("Action Cancelled");
            }
        }

        // Undo last transaction from Deposit
        private void Button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm Undoing Last Transaction?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    double donationCalc = double.Parse(textBox7.Text) - double.Parse(textBox2.Text);
                    double savingCalc = double.Parse(textBox8.Text) - double.Parse(savingsBox.Text);
                    double gokfCalc = double.Parse(textBox9.Text) - double.Parse(GOKFBox.Text);
                    double spendingCalc = double.Parse(textBox10.Text) - double.Parse(spendingBox.Text);

                    SqlConnection conn = new SqlConnection(Globals.connectionString);
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
                    SqlConnection cnn = new SqlConnection(Globals.connectionString);
                    cnn.Open();
                    // Run SQL statement
                    SqlCommand cmd = new SqlCommand(Globals.moneySelect, cnn);
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
                            + double.Parse(textBox42.Text) + double.Parse(textBox43.Text) + double.Parse(textBox44.Text) + double.Parse(textBox18.Text) + double.Parse(textBox19.Text) + double.Parse(textBox20.Text)
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
                            textBox29.ForeColor = Color.Black;
                            textBox29.Text = differenceCalc.ToString();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Calculations could not be performed");
                    }
                    try
                    {
                        SqlConnection conn = new SqlConnection(Globals.connectionString);
                        conn.Open();

                        string updateQuery = "UPDATE MonthlyCosts SET MonthlyOne='" + textBox18.Text + "',MonthlyTwo='"
                            + textBox19.Text + "',MonthlyThree='" + textBox20.Text + "',MonthlyFour='" + textBox21.Text
                            + "',MonthlyFive='" + textBox22.Text + "',MonthlySix='" + textBox23.Text + "',MonthlySeven='"
                            + textBox24.Text + "',MonthlyEight='" + textBox25.Text + "',MonthlyNine='" + textBox26.Text
                            + "',MonthlyTen='" + textBox27.Text + "' WHERE Id = " + textBox30.Text;
                        SqlCommand cmd = new SqlCommand(updateQuery, conn);

                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch
                    {
                        MessageBox.Show("No ConnectionThere");
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
                    try
                    {
                        SqlConnection conn = new SqlConnection(Globals.connectionString);
                        conn.Open();

                        string updateQuery = "UPDATE MonthlyCosts SET MonthlyEleven='" + textBox35.Text + "',MonthlyTwelve='"
                            + textBox36.Text + "',MonthlyThirteen='" + textBox37.Text + "',MonthlyFourteen='" + textBox38.Text
                            + "',MonthlyFifteen='" + textBox39.Text + "',MonthlySixteen='" + textBox40.Text + "',MonthlySeventeen='"
                            + textBox41.Text + "',MonthlyEighteen='" + textBox42.Text + "',MonthlyNineteen='" + textBox43.Text
                            + "',MonthlyTwenty='" + textBox44.Text + "' WHERE Id = " + textBox47.Text;
                        SqlCommand cmd = new SqlCommand(updateQuery, conn);

                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch
                    {
                        MessageBox.Show("No ConnectionThere");
                    }

                }
            }
        }
        
        // Check to see users available in database
        private void ComboBox1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                PopulateDropMenus(comboBox1);
            }
            else
            {
                comboBox1.Items.Clear();
                Globals.bypass = false;
                PopulateDropMenus(comboBox1);
            }
        }
        private void TabPage2_Layout(object sender, LayoutEventArgs e)
        {

            if (Globals.passChecker == true && Globals.currentUser != "")
            {
                Globals.bypass = true;
                ComboBoxTextChange(sender, e);
            }
            else
            {
                Globals.bypass = false;
            }            
        }

        
        private void ComboBoxTextChange(object sender, EventArgs e)
        {
            // Attempt to determine the User and populate fields from totals
            IdChecker(comboBox1, textBox6, textBox7, textBox8, textBox9, textBox10);            
        }
        // Check to see users available in database
        private void ComboBox2_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "")
            {
                PopulateDropMenus(comboBox2);
            }
            else
            {
                Globals.bypass = false;
                comboBox2.Items.Clear();
                PopulateDropMenus(comboBox2);

            }
        }
        private void ComboBoxTextChangeTwo(object sender, EventArgs e)
        {
            if (Globals.bypass == false)
            {
                // Attempt to determine the User and populate fields from totals
                try
                {
                    // Run database connection
                    using (SqlConnection con = new SqlConnection(Globals.connectionString))
                    {
                        // Search for ID from selected user in ComboBox
                        using (SqlCommand cmd = new SqlCommand(Globals.idNameSelect))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = con;
                            con.Open();
                            string[] splitName = comboBox2.Text.Split(' ');
                            Globals.splitText = splitName[0];
                            cmd.Parameters.AddWithValue("@name", Globals.splitText);
                            // Insert the ID from People Database
                            using (SqlDataReader sdr = cmd.ExecuteReader())
                            {
                                sdr.Read();
                                textBox30.Text = sdr["Id"].ToString().Trim();
                            }
                            con.Close();
                            Globals.currentUserId = textBox30.Text;
                            Globals.currentUser = comboBox2.Text.ToString();
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
                    SqlConnection cnn = new SqlConnection(Globals.connectionString);
                    cnn.Open();
                    // Run SQL statement
                    SqlCommand cmd = new SqlCommand(Globals.moneySelect, cnn);
                    // Use ID populated to confirm proper insertion
                    cmd.Parameters.AddWithValue("@id", textBox30.Text);
                    // Create a Message Box that allows users to enter pass code
                    Globals.boxAnswer = MessageBoard(Globals.boxUp, Globals.secondChance);
                    // Read through database and insert fields into TextBoxes
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        if (Globals.boxAnswer.ToString() == sdr["Pass"].ToString().Trim())
                        {
                            textBox31.Text = sdr["Donation"].ToString().Trim();
                            textBox32.Text = sdr["Savings"].ToString().Trim();
                            textBox33.Text = sdr["GOKF"].ToString().Trim();
                            textBox34.Text = sdr["Spending"].ToString().Trim();
                            Globals.passChecker = true;
                        }
                        else
                        {
                            textBox31.Text = ("");
                            textBox32.Text = ("");
                            textBox33.Text = ("");
                            textBox34.Text = ("");
                            MessageBox.Show("Incorrect Pass Code");
                            Globals.passChecker = false;
                        }
                    }
                    cnn.Close();
                }
                catch
                {
                    MessageBox.Show("No Connection");
                }
                try
                {
                    SqlConnection cnn = new SqlConnection(Globals.connectionString);
                    cnn.Open();
                    // Run SQL statement
                    SqlCommand cmd = new SqlCommand(Globals.monthSelect, cnn);
                    // Use ID populated to confirm proper insertion
                    cmd.Parameters.AddWithValue("@id", textBox30.Text);
                    // Read through database and insert fields into TextBoxes
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        textBox18.Text = sdr["MonthlyOne"].ToString().Trim();
                        textBox19.Text = sdr["MonthlyTwo"].ToString().Trim();
                        textBox20.Text = sdr["MonthlyThree"].ToString().Trim();
                        textBox21.Text = sdr["MonthlyFour"].ToString().Trim();
                        textBox22.Text = sdr["MonthlyFive"].ToString().Trim();
                        textBox23.Text = sdr["MonthlySix"].ToString().Trim();
                        textBox24.Text = sdr["MonthlySeven"].ToString().Trim();
                        textBox25.Text = sdr["MonthlyEight"].ToString().Trim();
                        textBox26.Text = sdr["MonthlyNine"].ToString().Trim();
                        textBox27.Text = sdr["MonthlyTen"].ToString().Trim();
                    }
                    cnn.Close();
                }
                catch
                {
                    MessageBox.Show("No Connection");
                }
            }
            else
            {
                textBox30.Text = Globals.currentUserId;
                comboBox2.Text = Globals.currentUser;
                try
                {
                    SqlConnection cnn = new SqlConnection(Globals.connectionString);
                    cnn.Open();
                    // Run SQL statement
                    SqlCommand cmd = new SqlCommand(Globals.moneySelect, cnn);
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
                try
                {
                    SqlConnection cnn = new SqlConnection(Globals.connectionString);
                    cnn.Open();
                    // Run SQL statement
                    SqlCommand cmd = new SqlCommand(Globals.monthSelect, cnn);
                    // Use ID populated to confirm proper insertion
                    cmd.Parameters.AddWithValue("@id", textBox30.Text);
                    // Read through database and insert fields into TextBoxes
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        textBox18.Text = sdr["MonthlyOne"].ToString().Trim();
                        textBox19.Text = sdr["MonthlyTwo"].ToString().Trim();
                        textBox20.Text = sdr["MonthlyThree"].ToString().Trim();
                        textBox21.Text = sdr["MonthlyFour"].ToString().Trim();
                        textBox22.Text = sdr["MonthlyFive"].ToString().Trim();
                        textBox23.Text = sdr["MonthlySix"].ToString().Trim();
                        textBox24.Text = sdr["MonthlySeven"].ToString().Trim();
                        textBox25.Text = sdr["MonthlyEight"].ToString().Trim();
                        textBox26.Text = sdr["MonthlyNine"].ToString().Trim();
                        textBox27.Text = sdr["MonthlyTen"].ToString().Trim();
                    }
                    cnn.Close();
                }
                catch
                {
                    MessageBox.Show("No Connection");
                }
                try
                {
                    // Combine all the expenses into a single variable.
                    double expensesCalc = double.Parse(textBox35.Text) + double.Parse(textBox36.Text) + double.Parse(textBox37.Text)
                        + double.Parse(textBox38.Text) + double.Parse(textBox39.Text) + double.Parse(textBox40.Text) + double.Parse(textBox41.Text)
                        + double.Parse(textBox42.Text) + double.Parse(textBox43.Text) + double.Parse(textBox44.Text) + double.Parse(textBox18.Text) + double.Parse(textBox19.Text) + double.Parse(textBox20.Text)
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
                        textBox29.ForeColor = Color.Black;
                        textBox29.Text = differenceCalc.ToString();
                    }
                }
                catch
                {
                    MessageBox.Show("Calculations could not be performed");
                }
            }
        }
        private void TabPage3_Layout(object sender, LayoutEventArgs e)
        {
            if (Globals.passChecker == true && Globals.currentUser != "")
            {
                Globals.bypass = true;
                ComboBoxTextChangeTwo(sender, e);
            }
            else
            {
                Globals.bypass = false;
            }
        }

        private void ComboBox3_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text == "")
            {
                PopulateDropMenus(comboBox3);
            }
            else
            {
                Globals.bypass = false;
                comboBox3.Items.Clear();
                PopulateDropMenus(comboBox3);
            }
        }
        private void ComboBoxTextChangeThree(object sender, EventArgs e)
        {
            if (Globals.bypass == false)
            {
                // Attempt to determine the User and populate fields from totals
                try
                {
                    // Run database connection
                    using (SqlConnection con = new SqlConnection(Globals.connectionString))
                    {
                        // Search for ID from selected user in ComboBox
                        using (SqlCommand cmd = new SqlCommand(Globals.idNameSelect))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = con;
                            con.Open();
                            string[] splitName = comboBox3.Text.Split(' ');
                            Globals.splitText = splitName[0];
                            cmd.Parameters.AddWithValue("@name", Globals.splitText);
                            // Insert the ID from People Database
                            using (SqlDataReader sdr = cmd.ExecuteReader())
                            {
                                sdr.Read();
                                textBox30.Text = sdr["Id"].ToString().Trim();
                            }
                            con.Close();
                            Globals.currentUserId = textBox47.Text;
                            Globals.currentUser = comboBox3.Text.ToString();
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
                    SqlConnection cnn = new SqlConnection(Globals.connectionString);
                    cnn.Open();
                    // Run SQL statement
                    SqlCommand cmd = new SqlCommand(Globals.moneySelect, cnn);
                    // Use ID populated to confirm proper insertion
                    cmd.Parameters.AddWithValue("@id", textBox47.Text);
                    // Create a Message Box that allows users to enter pass code
                    Globals.boxAnswer = MessageBoard(Globals.boxUp, Globals.secondChance);
                    // Read through database and insert fields into TextBoxes
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        if (Globals.boxAnswer.ToString() == sdr["Pass"].ToString().Trim())
                        {
                            textBox48.Text = sdr["Donation"].ToString().Trim();
                            textBox49.Text = sdr["Savings"].ToString().Trim();
                            textBox50.Text = sdr["GOKF"].ToString().Trim();
                            textBox51.Text = sdr["Spending"].ToString().Trim();
                            Globals.passChecker = true;
                        }
                        else
                        {
                            textBox48.Text = ("");
                            textBox49.Text = ("");
                            textBox50.Text = ("");
                            textBox51.Text = ("");
                            MessageBox.Show("Incorrect Pass Code");
                            Globals.passChecker = false;
                        }
                    }
                    cnn.Close();
                }
                catch
                {
                    MessageBox.Show("No Connection");
                }
                try
                {
                    SqlConnection cnn = new SqlConnection(Globals.connectionString);
                    cnn.Open();
                    // Run SQL statement
                    SqlCommand cmd = new SqlCommand(Globals.monthSelect, cnn);
                    // Use ID populated to confirm proper insertion
                    cmd.Parameters.AddWithValue("@id", textBox47.Text);
                    // Read through database and insert fields into TextBoxes
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        textBox35.Text = sdr["MonthlyOne"].ToString().Trim();
                        textBox36.Text = sdr["MonthlyTwo"].ToString().Trim();
                        textBox37.Text = sdr["MonthlyThree"].ToString().Trim();
                        textBox38.Text = sdr["MonthlyFour"].ToString().Trim();
                        textBox39.Text = sdr["MonthlyFive"].ToString().Trim();
                        textBox40.Text = sdr["MonthlySix"].ToString().Trim();
                        textBox41.Text = sdr["MonthlySeven"].ToString().Trim();
                        textBox42.Text = sdr["MonthlyEight"].ToString().Trim();
                        textBox43.Text = sdr["MonthlyNine"].ToString().Trim();
                        textBox44.Text = sdr["MonthlyTen"].ToString().Trim();
                        textBox35.Text = sdr["MonthlyEleven"].ToString().Trim();
                        textBox36.Text = sdr["MonthlyTwelve"].ToString().Trim();
                        textBox37.Text = sdr["MonthlyThirteen"].ToString().Trim();
                        textBox38.Text = sdr["MonthlyFourteen"].ToString().Trim();
                        textBox39.Text = sdr["MonthlyFifteen"].ToString().Trim();
                        textBox40.Text = sdr["MonthlySixteen"].ToString().Trim();
                        textBox41.Text = sdr["MonthlySeventeen"].ToString().Trim();
                        textBox42.Text = sdr["MonthlyEighteen"].ToString().Trim();
                        textBox43.Text = sdr["MonthlyNineteen"].ToString().Trim();
                        textBox44.Text = sdr["MonthlyTwenty"].ToString().Trim();
                    }
                    cnn.Close();
                }
                catch
                {
                    MessageBox.Show("No Connection");
                }
            }
            else
            {
                textBox47.Text = Globals.currentUserId;
                comboBox3.Text = Globals.currentUser;
                try
                {
                    SqlConnection cnn = new SqlConnection(Globals.connectionString);
                    cnn.Open();
                    // Run SQL statement
                    SqlCommand cmd = new SqlCommand(Globals.moneySelect, cnn);
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
                try
                {
                    SqlConnection cnn = new SqlConnection(Globals.connectionString);
                    cnn.Open();
                    // Run SQL statement
                    SqlCommand cmd = new SqlCommand(Globals.monthSelect, cnn);
                    // Use ID populated to confirm proper insertion
                    cmd.Parameters.AddWithValue("@id", textBox47.Text);
                    // Read through database and insert fields into TextBoxes
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        textBox35.Text = sdr["MonthlyOne"].ToString().Trim();
                        textBox36.Text = sdr["MonthlyTwo"].ToString().Trim();
                        textBox37.Text = sdr["MonthlyThree"].ToString().Trim();
                        textBox38.Text = sdr["MonthlyFour"].ToString().Trim();
                        textBox39.Text = sdr["MonthlyFive"].ToString().Trim();
                        textBox40.Text = sdr["MonthlySix"].ToString().Trim();
                        textBox41.Text = sdr["MonthlySeven"].ToString().Trim();
                        textBox42.Text = sdr["MonthlyEight"].ToString().Trim();
                        textBox43.Text = sdr["MonthlyNine"].ToString().Trim();
                        textBox44.Text = sdr["MonthlyTen"].ToString().Trim();
                        textBox35.Text = sdr["MonthlyEleven"].ToString().Trim();
                        textBox36.Text = sdr["MonthlyTwelve"].ToString().Trim();
                        textBox37.Text = sdr["MonthlyThirteen"].ToString().Trim();
                        textBox38.Text = sdr["MonthlyFourteen"].ToString().Trim();
                        textBox39.Text = sdr["MonthlyFifteen"].ToString().Trim();
                        textBox40.Text = sdr["MonthlySixteen"].ToString().Trim();
                        textBox41.Text = sdr["MonthlySeventeen"].ToString().Trim();
                        textBox42.Text = sdr["MonthlyEighteen"].ToString().Trim();
                        textBox43.Text = sdr["MonthlyNineteen"].ToString().Trim();
                        textBox44.Text = sdr["MonthlyTwenty"].ToString().Trim();
                    }
                    cnn.Close();
                }
                catch
                {
                    MessageBox.Show("No Connection");
                }
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
        private void ComboBoxFive_Click(object sender, EventArgs e)
        {
            if(comboBox5.Text == "")
            {
                PopulateDropMenus(comboBox5);
            }
            else 
            {
                Globals.bypass = false;
                comboBox5.Items.Clear();
                PopulateDropMenus(comboBox5);
            }

        }        
        private void ComboBoxTextChangeFive(object sender, EventArgs e)
        {
            // Attempt to determine the User and populate fields from totals
            try
            {
                // Run database connection
                using (SqlConnection con = new SqlConnection(Globals.connectionString))
                {
                    // Search for ID from selected user in ComboBox
                    using (SqlCommand cmd = new SqlCommand(Globals.idNameSelect))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        con.Open();
                        string[] splitName = comboBox5.Text.Split(' ');
                        Globals.splitText = splitName[0];
                        cmd.Parameters.AddWithValue("@name", Globals.splitText);
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
                SqlConnection cnn = new SqlConnection(Globals.connectionString);
                cnn.Open();
                // Run SQL statement
                SqlCommand cmd = new SqlCommand(Globals.peopleSelect, cnn);
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
                try
                {
                    SqlConnection conn = new SqlConnection(Globals.connectionString);
                    conn.Open();

                    Globals.sqlStatement = "UPDATE People SET First='" + textBox52.Text.Trim() + "',Last='" + textBox53.Text.Trim() +
                        "',Email='" + textBox54.Text.Trim() + "',Address1='" + textBox55.Text.Trim() + "',Address2='" + textBox56.Text.Trim() +
                        "',City='" + textBox57.Text.Trim() + "',State='" + comboBox4.Text.Trim() + "',Zip='" + textBox58.Text.Trim() + "' WHERE Id = " + textBox59.Text;
                    SqlCommand cmd = new SqlCommand(Globals.sqlStatement, conn);

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
                    SqlConnection cnn = new SqlConnection(Globals.connectionString);
                    cnn.Open();
                    // Run SQL statement
                    SqlCommand cmd = new SqlCommand(Globals.peopleSelect, cnn);
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
            try
            {
                SqlConnection cnn = new SqlConnection(Globals.connectionString);
                cnn.Open();
                // Run SQL statement
                SqlCommand cmd = new SqlCommand(Globals.moneySelect, cnn);
                // Use ID populated to confirm proper insertion
                cmd.Parameters.AddWithValue("@id", textBox59.Text);
                // Create a Message Box that allows users to enter pass code
                Globals.boxAnswer = MessageBoard(Globals.boxUp, Globals.secondChance);
                // Read through database and insert fields into TextBoxes
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    if (Globals.boxAnswer.ToString() == sdr["Pass"].ToString().Trim())
                    {
                        // Delete user from People Database                        
                        SqlConnection connOne = new SqlConnection(Globals.connectionString);
                        Globals.sqlStatement = "DELETE FROM People WHERE Id=@id";
                        connOne.Open();
                        SqlCommand cmdOne = new SqlCommand(Globals.sqlStatement, connOne);
                        cmdOne.Parameters.AddWithValue("@id", "" + textBox59.Text + "");
                        cmdOne.CommandType = CommandType.Text;
                        cmdOne.ExecuteNonQuery();
                        connOne.Close();                        
                        // Delete user from People Database                        
                        SqlConnection connTwo = new SqlConnection(Globals.connectionString);
                        Globals.sqlStatement = "DELETE FROM MonthlyCosts WHERE Id=@id";
                        connTwo.Open();
                        SqlCommand cmdTwo = new SqlCommand(Globals.sqlStatement, connTwo);
                        cmdTwo.Parameters.AddWithValue("@id", "" + textBox59.Text + "");
                        cmdTwo.CommandType = CommandType.Text;
                        cmdTwo.ExecuteNonQuery();
                        connTwo.Close();
                        // Delete user from Money Database
                        SqlConnection connThree = new SqlConnection(Globals.connectionString);
                        Globals.sqlStatement = "DELETE FROM Money WHERE Id=@id";
                        connThree.Open();
                        SqlCommand cmdThree = new SqlCommand(Globals.sqlStatement, connThree);
                        cmdThree.Parameters.AddWithValue("@id", "" + textBox59.Text + "");
                        cmdThree.CommandType = CommandType.Text;
                        cmdThree.ExecuteNonQuery();
                        connThree.Close();
                        // Delete user from LongTermTitles Database
                        SqlConnection connFour = new SqlConnection(Globals.connectionString);
                        Globals.sqlStatement = "DELETE LongTermTitles WHERE Id=@id";
                        connFour.Open();
                        SqlCommand cmdFour = new SqlCommand(Globals.sqlStatement, connFour);
                        cmdFour.Parameters.AddWithValue("@id", "" + textBox59.Text + "");
                        cmdFour.CommandType = CommandType.Text;
                        cmdFour.ExecuteNonQuery();
                        connFour.Close();                        
                        // Delete user from LongTermSaves Database                        
                        SqlConnection connFive = new SqlConnection(Globals.connectionString);
                        Globals.sqlStatement = "DELETE FROM LongTermSaves WHERE Id=@id";
                        connFive.Open();
                        SqlCommand cmdFive = new SqlCommand(Globals.sqlStatement, connFive);
                        cmdFive.Parameters.AddWithValue("@id", "" + textBox59.Text + "");
                        cmdFive.CommandType = CommandType.Text;
                        cmdFive.ExecuteNonQuery();
                        connFive.Close();
                        MessageBox.Show("User Successfully Deleted");
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Password");
                    }
                }
                cnn.Close();
            }
            catch
            {
                MessageBox.Show("No Connection");
            }
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            // Create a Message Box that allows users to enter titles
            Globals.boxAnswer = MessageBoard(Globals.boxDown, Globals.secondChance);
            try
            {
                SqlConnection conn = new SqlConnection(Globals.connectionString);
                conn.Open();

                Globals.sqlStatement = "UPDATE LongTermTitles SET ItemOne='" + Globals.boxAnswer.Trim().ToString() + "' WHERE Id = " + textBox66.Text;
                SqlCommand cmd = new SqlCommand(Globals.sqlStatement, conn);

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
                SqlConnection cnn = new SqlConnection(Globals.connectionString);
                cnn.Open();
                // Run SQL statement
                SqlCommand cmd = new SqlCommand(Globals.longTermSave, cnn);
                // Use ID populated to confirm proper insertion
                cmd.Parameters.AddWithValue("@id", textBox66.Text);
                // Read through database and insert fields into TextBoxes
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    textBox65.Text = sdr["SaveOne"].ToString().Trim();
                    textBox62.Text = sdr["SaveTwo"].ToString().Trim();
                    textBox64.Text = sdr["SaveThree"].ToString().Trim();
                    textBox5.Text = sdr["SaveFour"].ToString().Trim();
                    textBox63.Text = sdr["SaveFive"].ToString().Trim();
                    textBox4.Text = sdr["SaveSix"].ToString().Trim();

                }
                cnn.Close();
            }
            catch
            {
                MessageBox.Show("No Connection");
            }
            // Attempt to populate fields from Money Database
            try
            {
                SqlConnection cnn = new SqlConnection(Globals.connectionString);
                cnn.Open();
                // Run SQL statement
                SqlCommand cmd = new SqlCommand(Globals.longTermSelect, cnn);
                // Use ID populated to confirm proper insertion
                cmd.Parameters.AddWithValue("@id", textBox66.Text);
                // Read through database and insert fields into TextBoxes
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    button9.Text = sdr["ItemOne"].ToString().Trim();
                    button10.Text = sdr["ItemTwo"].ToString().Trim();
                    button12.Text = sdr["ItemThree"].ToString().Trim();
                    button11.Text = sdr["ItemFour"].ToString().Trim();
                    button14.Text = sdr["ItemFive"].ToString().Trim();
                    button13.Text = sdr["ItemSix"].ToString().Trim();

                }
                cnn.Close();
            }
            catch
            {
                MessageBox.Show("No Connection");
            }

        }
        private void Button10_Click(object sender, EventArgs e)
        {
            // Create a Message Box that allows users to enter titles
            Globals.boxAnswer = MessageBoard(Globals.boxDown, Globals.secondChance);
            try
            {
                SqlConnection conn = new SqlConnection(Globals.connectionString);
                conn.Open();

                Globals.sqlStatement = "UPDATE LongTermTitles SET ItemTwo='" + Globals.boxAnswer.Trim().ToString() + "' WHERE Id = " + textBox66.Text;
                SqlCommand cmd = new SqlCommand(Globals.sqlStatement, conn);

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
                SqlConnection cnn = new SqlConnection(Globals.connectionString);
                cnn.Open();
                // Run SQL statement
                SqlCommand cmd = new SqlCommand(Globals.longTermSave, cnn);
                // Use ID populated to confirm proper insertion
                cmd.Parameters.AddWithValue("@id", textBox66.Text);
                // Read through database and insert fields into TextBoxes
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    textBox65.Text = sdr["SaveOne"].ToString().Trim();
                    textBox62.Text = sdr["SaveTwo"].ToString().Trim();
                    textBox64.Text = sdr["SaveThree"].ToString().Trim();
                    textBox5.Text = sdr["SaveFour"].ToString().Trim();
                    textBox63.Text = sdr["SaveFive"].ToString().Trim();
                    textBox4.Text = sdr["SaveSix"].ToString().Trim();

                }
                cnn.Close();
            }
            catch
            {
                MessageBox.Show("No Connection");
            }
            // Attempt to populate fields from Money Database
            try
            {
                SqlConnection cnn = new SqlConnection(Globals.connectionString);
                cnn.Open();
                // Run SQL statement
                SqlCommand cmd = new SqlCommand(Globals.longTermSelect, cnn);
                // Use ID populated to confirm proper insertion
                cmd.Parameters.AddWithValue("@id", textBox66.Text);
                // Read through database and insert fields into TextBoxes
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    button9.Text = sdr["ItemOne"].ToString().Trim();
                    button10.Text = sdr["ItemTwo"].ToString().Trim();
                    button12.Text = sdr["ItemThree"].ToString().Trim();
                    button11.Text = sdr["ItemFour"].ToString().Trim();
                    button14.Text = sdr["ItemFive"].ToString().Trim();
                    button13.Text = sdr["ItemSix"].ToString().Trim();

                }
                cnn.Close();
            }
            catch
            {
                MessageBox.Show("No Connection");
            }

        }
        private void Button11_Click(object sender, EventArgs e)
        {
            // Create a Message Box that allows users to enter titles
            Globals.boxAnswer = MessageBoard(Globals.boxDown, Globals.secondChance);
            try
            {
                SqlConnection conn = new SqlConnection(Globals.connectionString);
                conn.Open();

                Globals.sqlStatement = "UPDATE LongTermTitles SET ItemFour='" + Globals.boxAnswer.Trim().ToString() + "' WHERE Id = " + textBox66.Text;
                SqlCommand cmd = new SqlCommand(Globals.sqlStatement, conn);

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
                SqlConnection cnn = new SqlConnection(Globals.connectionString);
                cnn.Open();
                // Run SQL statement
                SqlCommand cmd = new SqlCommand(Globals.longTermSave, cnn);
                // Use ID populated to confirm proper insertion
                cmd.Parameters.AddWithValue("@id", textBox66.Text);
                // Read through database and insert fields into TextBoxes
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    textBox65.Text = sdr["SaveOne"].ToString().Trim();
                    textBox62.Text = sdr["SaveTwo"].ToString().Trim();
                    textBox64.Text = sdr["SaveThree"].ToString().Trim();
                    textBox5.Text = sdr["SaveFour"].ToString().Trim();
                    textBox63.Text = sdr["SaveFive"].ToString().Trim();
                    textBox4.Text = sdr["SaveSix"].ToString().Trim();

                }
                cnn.Close();
            }
            catch
            {
                MessageBox.Show("No Connection");
            }
            // Attempt to populate fields from Money Database
            try
            {
                SqlConnection cnn = new SqlConnection(Globals.connectionString);
                cnn.Open();
                // Run SQL statement
                SqlCommand cmd = new SqlCommand(Globals.longTermSelect, cnn);
                // Use ID populated to confirm proper insertion
                cmd.Parameters.AddWithValue("@id", textBox66.Text);
                // Read through database and insert fields into TextBoxes
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    button9.Text = sdr["ItemOne"].ToString().Trim();
                    button10.Text = sdr["ItemTwo"].ToString().Trim();
                    button12.Text = sdr["ItemThree"].ToString().Trim();
                    button11.Text = sdr["ItemFour"].ToString().Trim();
                    button14.Text = sdr["ItemFive"].ToString().Trim();
                    button13.Text = sdr["ItemSix"].ToString().Trim();

                }
                cnn.Close();
            }
            catch
            {
                MessageBox.Show("No Connection");
            }

        }
        private void Button12_Click(object sender, EventArgs e)
        {
            // Create a Message Box that allows users to enter titles
            Globals.boxAnswer = MessageBoard(Globals.boxDown, Globals.secondChance);
            try
            {
                SqlConnection conn = new SqlConnection(Globals.connectionString);
                conn.Open();

                Globals.sqlStatement = "UPDATE LongTermTitles SET ItemThree='" + Globals.boxAnswer.Trim().ToString() + "' WHERE Id = " + textBox66.Text;
                SqlCommand cmd = new SqlCommand(Globals.sqlStatement, conn);

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
                SqlConnection cnn = new SqlConnection(Globals.connectionString);
                cnn.Open();
                // Run SQL statement
                SqlCommand cmd = new SqlCommand(Globals.longTermSave, cnn);
                // Use ID populated to confirm proper insertion
                cmd.Parameters.AddWithValue("@id", textBox66.Text);
                // Read through database and insert fields into TextBoxes
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    textBox65.Text = sdr["SaveOne"].ToString().Trim();
                    textBox62.Text = sdr["SaveTwo"].ToString().Trim();
                    textBox64.Text = sdr["SaveThree"].ToString().Trim();
                    textBox5.Text = sdr["SaveFour"].ToString().Trim();
                    textBox63.Text = sdr["SaveFive"].ToString().Trim();
                    textBox4.Text = sdr["SaveSix"].ToString().Trim();

                }
                cnn.Close();
            }
            catch
            {
                MessageBox.Show("No Connection");
            }
            // Attempt to populate fields from Money Database
            try
            {
                SqlConnection cnn = new SqlConnection(Globals.connectionString);
                cnn.Open();
                // Run SQL statement
                SqlCommand cmd = new SqlCommand(Globals.longTermSelect, cnn);
                // Use ID populated to confirm proper insertion
                cmd.Parameters.AddWithValue("@id", textBox66.Text);
                // Read through database and insert fields into TextBoxes
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    button9.Text = sdr["ItemOne"].ToString().Trim();
                    button10.Text = sdr["ItemTwo"].ToString().Trim();
                    button12.Text = sdr["ItemThree"].ToString().Trim();
                    button11.Text = sdr["ItemFour"].ToString().Trim();
                    button14.Text = sdr["ItemFive"].ToString().Trim();
                    button13.Text = sdr["ItemSix"].ToString().Trim();

                }
                cnn.Close();
            }
            catch
            {
                MessageBox.Show("No Connection");
            }

        }
        private void Button13_Click(object sender, EventArgs e)
        {
            // Create a Message Box that allows users to enter titles
            Globals.boxAnswer = MessageBoard(Globals.boxDown, Globals.secondChance);
            try
            {
                SqlConnection conn = new SqlConnection(Globals.connectionString);
                conn.Open();

                Globals.sqlStatement = "UPDATE LongTermTitles SET ItemSix='" + Globals.boxAnswer.Trim().ToString() + "' WHERE Id = " + textBox66.Text;
                SqlCommand cmd = new SqlCommand(Globals.sqlStatement, conn);

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
                SqlConnection cnn = new SqlConnection(Globals.connectionString);
                cnn.Open();
                // Run SQL statement
                SqlCommand cmd = new SqlCommand(Globals.longTermSave, cnn);
                // Use ID populated to confirm proper insertion
                cmd.Parameters.AddWithValue("@id", textBox66.Text);
                // Read through database and insert fields into TextBoxes
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    textBox65.Text = sdr["SaveOne"].ToString().Trim();
                    textBox62.Text = sdr["SaveTwo"].ToString().Trim();
                    textBox64.Text = sdr["SaveThree"].ToString().Trim();
                    textBox5.Text = sdr["SaveFour"].ToString().Trim();
                    textBox63.Text = sdr["SaveFive"].ToString().Trim();
                    textBox4.Text = sdr["SaveSix"].ToString().Trim();

                }
                cnn.Close();
            }
            catch
            {
                MessageBox.Show("No Connection");
            }
            // Attempt to populate fields from Money Database
            try
            {
                SqlConnection cnn = new SqlConnection(Globals.connectionString);
                cnn.Open();
                // Run SQL statement
                SqlCommand cmd = new SqlCommand(Globals.longTermSelect, cnn);
                // Use ID populated to confirm proper insertion
                cmd.Parameters.AddWithValue("@id", textBox66.Text);
                // Read through database and insert fields into TextBoxes
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    button9.Text = sdr["ItemOne"].ToString().Trim();
                    button10.Text = sdr["ItemTwo"].ToString().Trim();
                    button12.Text = sdr["ItemThree"].ToString().Trim();
                    button11.Text = sdr["ItemFour"].ToString().Trim();
                    button14.Text = sdr["ItemFive"].ToString().Trim();
                    button13.Text = sdr["ItemSix"].ToString().Trim();

                }
                cnn.Close();
            }
            catch
            {
                MessageBox.Show("No Connection");
            }
        }
        private void Button14_Click(object sender, EventArgs e)
        {
            // Create a Message Box that allows users to enter titles
            Globals.boxAnswer = MessageBoard(Globals.boxDown, Globals.secondChance);
            try
            {
                SqlConnection conn = new SqlConnection(Globals.connectionString);
                conn.Open();

                Globals.sqlStatement = "UPDATE LongTermTitles SET ItemFive='" + Globals.boxAnswer.Trim().ToString() + "' WHERE Id = " + textBox66.Text;
                SqlCommand cmd = new SqlCommand(Globals.sqlStatement, conn);

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
                SqlConnection cnn = new SqlConnection(Globals.connectionString);
                cnn.Open();
                // Run SQL statement
                SqlCommand cmd = new SqlCommand(Globals.longTermSave, cnn);
                // Use ID populated to confirm proper insertion
                cmd.Parameters.AddWithValue("@id", textBox66.Text);
                // Read through database and insert fields into TextBoxes
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    textBox65.Text = sdr["SaveOne"].ToString().Trim();
                    textBox62.Text = sdr["SaveTwo"].ToString().Trim();
                    textBox64.Text = sdr["SaveThree"].ToString().Trim();
                    textBox5.Text = sdr["SaveFour"].ToString().Trim();
                    textBox63.Text = sdr["SaveFive"].ToString().Trim();
                    textBox4.Text = sdr["SaveSix"].ToString().Trim();

                }
                cnn.Close();
            }
            catch
            {
                MessageBox.Show("No Connection");
            }
            // Attempt to populate fields from Money Database
            try
            {
                // Database location string
                SqlConnection cnn = new SqlConnection(Globals.connectionString);
                cnn.Open();
                // Run SQL statement 
                SqlCommand cmd = new SqlCommand(Globals.longTermSelect, cnn);
                // Use ID populated to confirm proper insertion
                cmd.Parameters.AddWithValue("@id", textBox66.Text);
                // Read through database and insert fields into TextBoxes
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    button9.Text = sdr["ItemOne"].ToString().Trim();
                    button10.Text = sdr["ItemTwo"].ToString().Trim();
                    button12.Text = sdr["ItemThree"].ToString().Trim();
                    button11.Text = sdr["ItemFour"].ToString().Trim();
                    button14.Text = sdr["ItemFive"].ToString().Trim();
                    button13.Text = sdr["ItemSix"].ToString().Trim();

                }
                cnn.Close();
            }
            catch
            {
                MessageBox.Show("No Connection");
            }

        }

        private void ComboBox7_Click(object sender, EventArgs e)
        {
            if (comboBox7.Text == "")
            {
                PopulateDropMenus(comboBox7);
            }
            else
            {
                Globals.bypass = false;
                comboBox7.Items.Clear();
                PopulateDropMenus(comboBox7);
            }
        }
        private void ComboBoxTextChangeSeven(object sender, EventArgs e)
        {
            if (Globals.bypass == false)
            {
                // Attempt to determine the User and populate fields from totals
                try
                {
                    // Run database connection
                    using (SqlConnection con = new SqlConnection(Globals.connectionString))
                    {
                        // Search for ID from selected user in ComboBox
                        using (SqlCommand cmd = new SqlCommand(Globals.idNameSelect))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = con;
                            con.Open();
                            string[] splitName = comboBox7.Text.Split(' ');
                            Globals.splitText = splitName[0];
                            cmd.Parameters.AddWithValue("@name", Globals.splitText);
                            // Insert the ID from People Database
                            using (SqlDataReader sdr = cmd.ExecuteReader())
                            {
                                sdr.Read();
                                textBox66.Text = sdr["Id"].ToString();
                            }
                            con.Close();
                        }
                        Globals.currentUserId = textBox66.Text;
                        Globals.currentUser = comboBox7.SelectedItem.ToString();
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
                    SqlConnection cnn = new SqlConnection(Globals.connectionString);
                    cnn.Open();
                    // Run SQL statement
                    SqlCommand cmd = new SqlCommand(Globals.moneySelect, cnn);
                    // Use ID populated to confirm proper insertion
                    cmd.Parameters.AddWithValue("@id", textBox66.Text);
                    // Create a Message Box that allows users to enter pass code
                    Globals.boxAnswer = MessageBoard(Globals.boxUp, Globals.secondChance);
                    // Read through database and insert fields into TextBoxes
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        {
                            if (Globals.boxAnswer.ToString() == sdr["Pass"].ToString().Trim())
                            {
                                textBox70.Text = sdr["Donation"].ToString().Trim();
                                textBox69.Text = sdr["Savings"].ToString().Trim();
                                textBox68.Text = sdr["GOKF"].ToString().Trim();
                                textBox67.Text = sdr["Spending"].ToString().Trim();
                                Globals.boxInOut = true;
                                Globals.passChecker = true;
                            }
                            else
                            {
                                textBox70.Text = ("");
                                textBox69.Text = ("");
                                textBox68.Text = ("");
                                textBox67.Text = ("");
                                Globals.boxInOut = false;
                                Globals.passChecker = false;
                            }
                        }

                    }
                    cnn.Close();
                }
                catch
                {
                    MessageBox.Show("No Connection");
                }
                if (Globals.boxInOut == true)
                {
                    // Attempt to populate fields from Money Database
                    try
                    {
                        // Database location string
                        SqlConnection cnn = new SqlConnection(Globals.connectionString);
                        cnn.Open();
                        // Run SQL statement
                        SqlCommand cmd = new SqlCommand(Globals.longTermSave, cnn);
                        // Use ID populated to confirm proper insertion
                        cmd.Parameters.AddWithValue("@id", textBox66.Text);
                        // Read through database and insert fields into TextBoxes
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            sdr.Read();
                            textBox65.Text = sdr["SaveOne"].ToString().Trim();
                            textBox62.Text = sdr["SaveTwo"].ToString().Trim();
                            textBox64.Text = sdr["SaveThree"].ToString().Trim();
                            textBox5.Text = sdr["SaveFour"].ToString().Trim();
                            textBox63.Text = sdr["SaveFive"].ToString().Trim();
                            textBox4.Text = sdr["SaveSix"].ToString().Trim();

                        }
                        cnn.Close();
                    }
                    catch
                    {
                        MessageBox.Show("No Connection");
                    }
                    // Attempt to populate fields from Money Database
                    try
                    {
                        // Database location string
                        SqlConnection cnn = new SqlConnection(Globals.connectionString);
                        cnn.Open();
                        // Run SQL statement
                        SqlCommand cmd = new SqlCommand(Globals.longTermSelect, cnn);
                        // Use ID populated to confirm proper insertion
                        cmd.Parameters.AddWithValue("@id", textBox66.Text);
                        // Read through database and insert fields into TextBoxes
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            sdr.Read();
                            button9.Text = sdr["ItemOne"].ToString().Trim();
                            button10.Text = sdr["ItemTwo"].ToString().Trim();
                            button12.Text = sdr["ItemThree"].ToString().Trim();
                            button11.Text = sdr["ItemFour"].ToString().Trim();
                            button14.Text = sdr["ItemFive"].ToString().Trim();
                            button13.Text = sdr["ItemSix"].ToString().Trim();

                        }
                        cnn.Close();
                    }
                    catch
                    {
                        MessageBox.Show("No Connection");
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect Pass Code");
                }
            }
            else
            {
                // Attempt to determine the User and populate fields from totals
                comboBox7.Text = Globals.currentUser;
                textBox66.Text = Globals.currentUserId;
              
                // Attempt to populate fields from Money Database
                try
                {
                    // Database location string
                    SqlConnection cnn = new SqlConnection(Globals.connectionString);
                    cnn.Open();
                    // Run SQL statement
                    SqlCommand cmd = new SqlCommand(Globals.moneySelect, cnn);
                    // Use ID populated to confirm proper insertion
                    cmd.Parameters.AddWithValue("@id", textBox66.Text);                    
                    // Read through database and insert fields into TextBoxes
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        {
                            textBox70.Text = sdr["Donation"].ToString().Trim();
                            textBox69.Text = sdr["Savings"].ToString().Trim();
                            textBox68.Text = sdr["GOKF"].ToString().Trim();
                            textBox67.Text = sdr["Spending"].ToString().Trim();
                            Globals.boxInOut = true;
                        }
                    }
                    cnn.Close();
                }
                catch
                {
                    MessageBox.Show("No Connection");
                }
                if (Globals.boxInOut == true)
                {
                    // Attempt to populate fields from Money Database
                    try
                    {
                        // Database location string
                        SqlConnection cnn = new SqlConnection(Globals.connectionString);
                        cnn.Open();
                        // Run SQL statement
                        SqlCommand cmd = new SqlCommand(Globals.longTermSave, cnn);
                        // Use ID populated to confirm proper insertion
                        cmd.Parameters.AddWithValue("@id", textBox66.Text);
                        // Read through database and insert fields into TextBoxes
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            sdr.Read();
                            textBox65.Text = sdr["SaveOne"].ToString().Trim();
                            textBox62.Text = sdr["SaveTwo"].ToString().Trim();
                            textBox64.Text = sdr["SaveThree"].ToString().Trim();
                            textBox5.Text = sdr["SaveFour"].ToString().Trim();
                            textBox63.Text = sdr["SaveFive"].ToString().Trim();
                            textBox4.Text = sdr["SaveSix"].ToString().Trim();

                        }
                        cnn.Close();
                    }
                    catch
                    {
                        MessageBox.Show("No Connection");
                    }
                    // Attempt to populate fields from Money Database
                    try
                    {
                        // Database location string
                        SqlConnection cnn = new SqlConnection(Globals.connectionString);
                        cnn.Open();
                        // Run SQL statement
                        SqlCommand cmd = new SqlCommand(Globals.longTermSelect, cnn);
                        // Use ID populated to confirm proper insertion
                        cmd.Parameters.AddWithValue("@id", textBox66.Text);
                        // Read through database and insert fields into TextBoxes
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            sdr.Read();
                            button9.Text = sdr["ItemOne"].ToString().Trim();
                            button10.Text = sdr["ItemTwo"].ToString().Trim();
                            button12.Text = sdr["ItemThree"].ToString().Trim();
                            button11.Text = sdr["ItemFour"].ToString().Trim();
                            button14.Text = sdr["ItemFive"].ToString().Trim();
                            button13.Text = sdr["ItemSix"].ToString().Trim();

                        }
                        cnn.Close();
                    }
                    catch
                    {
                        MessageBox.Show("No Connection");
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect Pass Code");
                }
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            // Ensure a user is selected to do calculations
            if (textBox66.Text == "")
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
                        double expensesCalc = double.Parse(textBox65.Text) + double.Parse(textBox62.Text) + double.Parse(textBox64.Text)
                            + double.Parse(textBox5.Text) + double.Parse(textBox63.Text) + double.Parse(textBox4.Text);
                        // Find the difference between what is available to what expenses are being used.
                        double differenceCalc = double.Parse(textBox69.Text) - expensesCalc;
                        // Display all expenses
                        textBox73.Text = expensesCalc.ToString();
                        // Display the difference
                        if (differenceCalc < 0)
                        {
                            textBox72.BackColor = Color.Black;
                            textBox72.ForeColor = Color.Red;
                            textBox72.Text = differenceCalc.ToString();
                        }
                        else
                        {
                            textBox72.BackColor = Color.Green;
                            textBox72.Text = differenceCalc.ToString();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Calculations could not be performed");
                    }
                    try
                    {
                        SqlConnection conn = new SqlConnection(Globals.connectionString);
                        conn.Open();

                        string updateQuery = "UPDATE LongTermSaves SET SaveOne='" + textBox65.Text + "',SaveTwo='" + textBox62.Text + "',SaveThree='" + textBox64.Text + "',SaveFour='" + textBox5.Text + "',SaveFive='" + textBox63.Text + "',SaveSix='" + textBox4.Text + "'  WHERE Id = " + textBox66.Text;
                        SqlCommand cmd = new SqlCommand(updateQuery, conn);

                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch
                    {
                        MessageBox.Show("No Connection");
                    }

                }
            }
        }

        private void TabPage5_Layout(object sender, LayoutEventArgs e)
        {
            if (Globals.passChecker == true && Globals.currentUser != "")
            {
                Globals.bypass = true;
                ComboBoxTextChangeThree(sender, e);
            }
            else
            {
                Globals.bypass = false;
            }
        }

        private void tabPage4_Layout(object sender, LayoutEventArgs e)
        {
            if (Globals.passChecker == true && Globals.currentUser != "")
            {
                Globals.bypass = true;
                ComboBoxTextChangeSeven(sender, e);
            }
            else
            {
                Globals.bypass = false;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (textBox69.Text != "" && textBox67.Text != "")
            {
                try
                {
                    
                    double savingAddition = double.Parse(textBox71.Text) + double.Parse(textBox69.Text);
                    double spendingSubtract = double.Parse(textBox67.Text) - double.Parse(textBox71.Text);
                    if (spendingSubtract < 0)
                    {
                        MessageBox.Show("Not enough funds to complete transfer.");
                    }
                    else
                    {
                        SqlConnection conn = new SqlConnection(Globals.connectionString);
                        conn.Open();

                        string updateQuery = "UPDATE Money SET Savings='" + savingAddition.ToString() + "',Spending='" + spendingSubtract.ToString() + "' WHERE Id = " + textBox66.Text;
                        SqlCommand cmd = new SqlCommand(updateQuery, conn);

                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("No Connection");
                }
                if (Globals.passChecker == true && Globals.currentUser != "")
                {
                    Globals.bypass = true;
                    ComboBoxTextChangeSeven(sender, e);
                }
                else
                {
                    Globals.bypass = false;
                }
            }
            else
            {
                MessageBox.Show("Select User");
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (textBox69.Text != "" && textBox67.Text != "")
            {
                try
                {
                    double spendingAddition = double.Parse(textBox71.Text) + double.Parse(textBox67.Text);
                    double savingSubtract = double.Parse(textBox69.Text) - double.Parse(textBox71.Text);
                    if (savingSubtract < 0)
                    {
                        MessageBox.Show("Not enough funds to complete transfer.");
                    }
                    else 
                    {
                        SqlConnection conn = new SqlConnection(Globals.connectionString);
                        conn.Open();

                        string updateQuery = "UPDATE Money SET Savings='" + savingSubtract.ToString() + "',Spending='" + spendingAddition.ToString() + "' WHERE Id = " + textBox66.Text;
                        SqlCommand cmd = new SqlCommand(updateQuery, conn);

                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("No Connection");
                }
                if (Globals.passChecker == true && Globals.currentUser != "")
                {
                    Globals.bypass = true;
                    ComboBoxTextChangeSeven(sender, e);
                }
                else
                {
                    Globals.bypass = false;
                }
            }
            else
            {
                MessageBox.Show("Select User");
            }
        }

        private void TextBox71_MouseClick(object sender, MouseEventArgs e)
        {
            textBox71.Text = "";
        }
    }
}
